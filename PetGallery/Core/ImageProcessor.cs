using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetGallery.MVVM.Models;

namespace PetGallery.Core
{
    public static class ImageProcessor
    {
        private static async Task<ImageModel> LoadImage(string url)
        {
            try
            {
                using HttpResponseMessage response = await ApiHelper.Client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    List<ImageModel> images = JsonConvert.DeserializeObject<List<ImageModel>>(await response.Content.ReadAsStringAsync());
                    if (images is {Count: > 0})
                    {
                        return images[0];
                    }
                }
                Console.WriteLine(response.ReasonPhrase);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public static async Task<ImageModel> GetCat(string id = "", string breedId = "")
        {
            if (id.Length == 0)
            {
                return await ((breedId.Length == 0)
                    ? LoadImage($"https://api.thecatapi.com/v1/images/search")
                    : LoadImage($"https://api.thecatapi.com/v1/images/search?breed_ids={breedId}"));
            }

            return await LoadImage($"https://api.thecatapi.com/v1/images/{id}");
        }
        
        public static async Task<List<ImageModel>> GetCats(int limit = 10, string breedId = null)
        {
            var url = breedId is null ? $"https://api.thecatapi.com/v1/images/search?limit={limit}" : 
                                         $"https://api.thecatapi.com/v1/images/search?limit={limit}&breed_id={breedId}";
            List<ImageModel> images = new List<ImageModel>();
            try
            {
                using var response = await ApiHelper.Client.GetAsync(url);
                if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
                
                images = JsonConvert.DeserializeObject<List<ImageModel>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return images;
        }
        
        public static async Task<ImageModel> GetDog(string id = "", string breedId = "")
        {
            if (id.Length == 0)
            {
                return await ((breedId.Length == 0)
                    ? LoadImage($"https://api.thedogapi.com/v1/images/search")
                    : LoadImage($"https://api.thedogapi.com/v1/images/search?breed_ids={breedId}"));
            }

            return await LoadImage($"https://api.thedogapi.com/v1/images/{id}");
        }

        private static async Task<List<BreedModel>> GetBreeds(string url)
        {
            try
            {
                using HttpResponseMessage response = await ApiHelper.Client.GetAsync(url);
                if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
                
                List<BreedModel> breeds = JsonConvert.DeserializeObject<List<BreedModel>>(await response.Content.ReadAsStringAsync());
                if (breeds != null)
                {
                    return breeds;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }

        public static async Task<List<BreedModel>> GetCatBreeds()
        {
            return await GetBreeds("https://api.thecatapi.com/v1/breeds") ?? new List<BreedModel>();
        }
        
        public static async Task<List<BreedModel>> GetDogBreeds()
        {
            return await GetBreeds("https://api.thedogapi.com/v1/breeds") ?? new List<BreedModel>();
        }

        public static async Task<List<ImageModel>> GetDogs(int limit = 10, string breedId = "")
        {
            var url = breedId is null ? $"https://api.thedogapi.com/v1/images/search?limit={limit}" : 
                $"https://api.thedogapi.com/v1/images/search?limit={limit}&breed_id={breedId}";
            List<ImageModel> images = new List<ImageModel>();
            try
            {
                using var response = await ApiHelper.Client.GetAsync(url);
                if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
                
                images = JsonConvert.DeserializeObject<List<ImageModel>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return images;
        }
    }
}