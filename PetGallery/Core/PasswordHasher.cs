using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace PetGallery.Core
{
    public static class PasswordHasher
    {
        public static string GenerateHash(SecureString securePassword)
        {
            if (securePassword is null)
            {
                return string.Empty;
            }
            
            var bstr = Marshal.SecureStringToBSTR(securePassword);
            var length = Marshal.ReadInt32(bstr, -4);
            var bytes = new byte[length];

            var bytesPin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try 
            {
                Marshal.Copy(bstr, bytes, 0, length);
                Marshal.ZeroFreeBSTR(bstr);
                using (var sha256 = SHA256.Create())
                {
                    var hash = sha256.ComputeHash(bytes);
                    return Encoding.Default.GetString(hash);
                }
            } 
            finally 
            {
                for (var i = 0; i < bytes.Length; i++) { 
                    bytes[i] = 0; 
                }

                bytesPin.Free();
            }
        }
    }
}