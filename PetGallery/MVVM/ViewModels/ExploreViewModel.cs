using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PetGallery.Core;
using PetGallery.MVVM.Models;

namespace PetGallery.MVVM.ViewModels
{
    public class ExploreViewModel : ObservableObject
    {
        private bool _isMenuExpanded;
        private List<ImageSource> _petImages;

        public bool IsMenuExpanded
        {
            get => _isMenuExpanded;
            set
            {
                _isMenuExpanded = value;
                OnPropertyChanged();
            }
        }

        public List<ImageSource> PetImages
        {
            get => _petImages;
            set
            {
                _petImages = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand ExpandMenuCommand { get; set; }

        public ExploreViewModel()
        {
            SideMenu = new FilterMenuViewModel(this);
            ExpandMenuCommand = new RelayCommand(o =>
            {
                IsMenuExpanded = !IsMenuExpanded;
            });
        }

        public ExploreViewModel(string animal)
        {
            SideMenu = new FilterMenuViewModel(this);
            ExpandMenuCommand = new RelayCommand(o =>
            {
                IsMenuExpanded = !IsMenuExpanded;
            });
        }

        private async void Test()
        {
            var imageModels = await ImageProcessor.GetCats();
            Application.Current.Dispatcher.Invoke(() =>
            {
                var list = new List<ImageSource>();
                foreach (var im in imageModels)
                {
                    list.Add(new BitmapImage(new Uri(im.Url)));
                }
                PetImages = list;
                Console.WriteLine("DONE!");
            });
        }
        
        private ObservableObject _sideMenu;
        
        public ObservableObject SideMenu
        {
            get => _sideMenu;
            set
            {
                _sideMenu = value;
                OnPropertyChanged();
            }
        }

        public async void Reload(string selectedPet = "Cat", BreedModel selectedBreed = null, int selectedLimit = 10)
        {
            var imageModels = await (selectedPet == "Cat"
                ? ImageProcessor.GetCats(selectedLimit, selectedBreed?.Id)
                : ImageProcessor.GetDogs(selectedLimit, selectedBreed?.Id));
            Application.Current.Dispatcher.Invoke(() =>
            {
                var list = new List<ImageSource>();
                foreach (var im in imageModels)
                {
                    list.Add(new BitmapImage(new Uri(im.Url)));
                }
                PetImages = list;
                Console.WriteLine("DONE!");
            });
        }
    }
}