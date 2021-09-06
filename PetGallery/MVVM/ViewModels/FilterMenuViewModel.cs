using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PetGallery.Core;
using PetGallery.MVVM.Models;

namespace PetGallery.MVVM.ViewModels
{
    public class FilterMenuViewModel : ObservableObject
    {
        private List<BreedModel> _dogBreeds;
        private List<BreedModel> _catBreeds;
        private List<BreedModel> _currentBreeds;
        private string _selectedPet;
        private bool _isBreedBoxEnabled;
        
        public static string[] Pets { get; set; } = {"Dog", "Cat"};

        public string SelectedPet
        {
            get => _selectedPet;
            set
            {
                Console.WriteLine("Change!");
                _selectedPet = value;
                if (!Pets.Contains(_selectedPet))
                {
                    IsBreedBoxEnabled = false;
                    return;
                }

                IsBreedBoxEnabled = true;
                CurrentBreeds = _selectedPet == "Cat" ? CatBreeds : DogBreeds;
            }
        }

        public bool IsBreedBoxEnabled
        {
            get => _isBreedBoxEnabled;
            set
            {
                _isBreedBoxEnabled = value;
                OnPropertyChanged();
            }
        }

        public List<BreedModel> CatBreeds
        {
            get => _catBreeds;
            set
            {
                _catBreeds = value;
                OnPropertyChanged();
            }
        }

        public List<BreedModel> DogBreeds
        {
            get => _dogBreeds;
            set
            {
                _dogBreeds = value;
                OnPropertyChanged();
            }
        }
        
        public List<BreedModel> CurrentBreeds
        {
            get => _currentBreeds;
            set
            {
                _currentBreeds = value;
                OnPropertyChanged();
            }
        }

        public FilterMenuViewModel()
        {
            Task.Run(LoadBreeds);
        }
        
        private async void LoadBreeds()
        {
            List<BreedModel> dogBreeds = await ImageProcessor.GetDogBreeds();
            List<BreedModel> catBreeds = await ImageProcessor.GetCatBreeds();
            
            Application.Current.Dispatcher.Invoke(() =>
            {
                DogBreeds = dogBreeds;
                CatBreeds = catBreeds;
                foreach (var b in CatBreeds)
                {
                    Console.WriteLine($"id: {b.Id}, name: {b.Name}, origin: {b.Origin}, life span: {b.LifeSpan}");
                }
            });
        }
    }
}