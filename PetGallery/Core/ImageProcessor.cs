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
        public static async Task<ImageModel> LoadImage(string id)
        {
            string url = "";

            if (id is null)
            {
                return await LoadImage();
            }

            url = $"https://api.thecatapi.com/v1/images/{id}";

            using (HttpResponseMessage response = await  ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    //var data = await response.Content.ReadAsStreamAsync();
                    ImageModel image = JsonConvert.DeserializeObject<ImageModel>(await response.Content.ReadAsStringAsync());
                    if (image != null)
                    {
                        return image;
                    }

                    throw new Exception();

                }

                throw new Exception(response.ReasonPhrase);
            }
        }
        
        public static async Task<ImageModel> LoadImage()
        {
            string url = "";

            url = $"https://api.thecatapi.com/v1/images/search?breed_ids=beng";

            using (HttpResponseMessage response = await  ApiHelper.Client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    //var data = await response.Content.ReadAsStreamAsync();
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
    }
}