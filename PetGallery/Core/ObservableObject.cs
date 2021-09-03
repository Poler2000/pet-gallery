using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PetGallery.Core
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged is null)
            {
                Console.WriteLine("Null");
                return;
            }
            Console.WriteLine("Not Null");

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}