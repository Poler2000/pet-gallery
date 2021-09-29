using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Controls;
using System.Windows.Media;
using PetGallery.MVVM.Models;

namespace PetGallery.Core
{
    public class ImageFileManager
    {
        public static void SaveImage(ImageModel model)
        {
            if (model.Path != null && File.Exists(model.Path))
            {
                return;
            }
            
            var path = $"{Environment.CurrentDirectory}/PetImages/{model.Id}.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            model.Path = path;
            using (WebClient client = new WebClient()) 
            {
                client.DownloadFile(model.Url, path);
            }
        }

        public static string DeleteImage(ImageModel model)
        {
            throw new NotImplementedException();
        }

        public static bool FileExists(string imPath)
        {
            if (imPath is null)
            {
                return false;
            }

            return File.Exists(imPath);
        }
    }
}