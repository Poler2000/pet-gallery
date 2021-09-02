using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using PetGallery.Core;

namespace PetGallery.MVVM.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        private ImageSource _primaryImage;
        public ImageSource PrimaryImage
        {
            get => _primaryImage;
            set
            {
                _primaryImage = value;
                OnPropertyChanged();
            }
        }

        public void SetSource(string url)
        {
            var image =  new BitmapImage(new Uri(url));
            PrimaryImage = image;
        }

        public HomeViewModel()
        {
            Task.Run((LoadRandomImage));
        }

        private async void LoadRandomImage()
        {
            var imageTask = await ImageProcessor.LoadImage();
            Application.Current.Dispatcher.Invoke(() => SetSource(imageTask.Url));
        }
    }
}