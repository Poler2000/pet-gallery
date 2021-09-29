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
        public RelayCommand ChangeViewWithCatCommand { get; set; }
        public RelayCommand ChangeViewWithDogCommand { get; set; }
        
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

        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel(RelayCommand myCollectionsViewCommand)
        {
            Username = UserInfo.CurrentUser.Login;
            Task.Run((LoadRandomImage));
            ChangeViewWithCatCommand = new RelayCommand(
                o => myCollectionsViewCommand.Execute("Cat"));
            ChangeViewWithDogCommand = new RelayCommand(
                o => myCollectionsViewCommand.Execute("Dog"));
        }

        private async void LoadRandomImage()
        {
            var imageTaskMain = await ImageProcessor.GetCat();
            var imageTaskCat = await ImageProcessor.GetCat();
            var imageTaskDog = await ImageProcessor.GetDog();
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (imageTaskMain != null)
                {
                    var image =  new BitmapImage(new Uri(imageTaskMain.Url));
                    PrimaryImage = image;
                }

                if (imageTaskCat != null)
                {
                    var image = new BitmapImage(new Uri(imageTaskCat.Url));
                    CatImage = image;
                }

                if (imageTaskDog != null)
                {
                    var image = new BitmapImage(new Uri(imageTaskDog.Url));
                    DogImage = image;
                }
            });
        }
    }
}