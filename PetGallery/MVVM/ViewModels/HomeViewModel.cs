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
        public RelayCommand ChangeViewCommand { get; set; }
        
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
        
        private ImageSource _catImage;
        public ImageSource CatImage
        {
            get => _catImage;
            set
            {
                _catImage = value;
                OnPropertyChanged();
            }
        }
        
        private ImageSource _dogImage;
        public ImageSource DogImage
        {
            get => _dogImage;
            set
            {
                _dogImage = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel(RelayCommand myCollectionsViewCommand)
        {
            Task.Run((LoadRandomImage));
            ChangeViewCommand = myCollectionsViewCommand;
        }

        private async void LoadRandomImage()
        {
            var imageTaskMain = await ImageProcessor.GetCat();
            var imageTaskCat = await ImageProcessor.GetCat();
            var imageTaskDog = await ImageProcessor.GetDog();
            Application.Current.Dispatcher.Invoke(() =>
            { 
                var image =  new BitmapImage(imageTaskMain.Url);
                PrimaryImage = image;
                image = new BitmapImage(imageTaskCat.Url);
                CatImage = image;
                image = new BitmapImage(imageTaskDog.Url);
                DogImage = image;
            });
        }
    }
}