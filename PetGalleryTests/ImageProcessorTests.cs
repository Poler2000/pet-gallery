using System;
using PetGallery.Core;
using Xunit;

namespace PetGalleryTests
{
    public class ImageProcessorTests
    {
        [Fact]
        public async void GetCatBreeds_Successful()
        {
            var result = await ImageProcessor.GetCatBreeds();
            Assert.NotEmpty(result);
            foreach (var breed in result)
            {
                Assert.NotNull(breed.Name);
            }
        }
        
        [Fact]
        public async void GetDogBreeds_Successful()
        {
            var result = await ImageProcessor.GetDogBreeds();
            Assert.NotEmpty(result);
            foreach (var breed in result)
            {
                Assert.NotNull(breed.Name);
            }
        }

        [Fact]
        public async void GetCat_Random()
        {
            var result = await ImageProcessor.GetCat();
            Assert.NotNull(result.Url);
            Assert.False(string.IsNullOrWhiteSpace(result.Id));
        }
        
        [Theory]
        [InlineData("22v", null)]
        [InlineData("", "abys")]
        [InlineData("", "srex")]
        [InlineData("22v", "srex")]
        public async void GetCat_WithParameters_ShouldSucceed(string id, string breed)
        {
            var result = await ImageProcessor.GetCat(id, breed);
            Assert.NotNull(result.Url);
            Assert.False(string.IsNullOrWhiteSpace(result.Id));
        }
        
        [Theory]
        [InlineData("xxx", null)]
        [InlineData("", "xxxx")]
        [InlineData("xxx", "xxxx")]
        public async void GetCat_WithParameters_ShouldThrow(string id, string breed)
        {
            await Assert.ThrowsAsync<Exception>(() => ImageProcessor.GetCat(id, breed));
        }
    }
}