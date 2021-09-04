using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetGallery.MVVM.Models;

namespace PetGallery.Core
{
    public class ImageProcessor
    {
        /*public static async Task<ImageModel> LoadImage(string url, string id)
        {
            if (id is null)
            {
                return await LoadImage(url);
            }

            url = $"https://api.thecatapi.com/v1/images/{id}";

            using (HttpResponseMessage response = await  ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ImageModel image = JsonConvert.DeserializeObject<ImageModel>(await response.Content.ReadAsStringAsync());
                    if (image != null)
                    {
                        return image;
                    }

                    throw new Exception();

                }

                throw new Exception(response.ReasonPhrase);
            }
        }*/
        
        public static async Task<ImageModel> LoadImage(string url)
        {
            using (HttpResponseMessage response = await  ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<ImageModel> images =JsonConvert.DeserializeObject<List<ImageModel>>(await response.Content.ReadAsStringAsync());
                    if (images != null)
                    {
                        return images[0];
                    }
                    throw new Exception();

                }

                throw new Exception(response.ReasonPhrase);
            }
            
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
    }
}