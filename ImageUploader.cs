﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using File = System.IO.File;

namespace RedditPoster
{
    static class ImageUploader
    {
        public static async Task<ImgurImageResponse> Upload(string token, string filePath)
        {
            var imageRequest = new ImgurImageRequest()
            {
                image = Convert.ToBase64String(File.ReadAllBytes(filePath)),
                title = $"Test #{DateTime.Now:MMddHHmmss} - Test Bot",
                description = "This image was uploaded by a bot",
                type = "base64"
            };
            
            var uri = new Uri("https://api.imgur.com/3/upload");

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {token}");
                var json = JsonConvert.SerializeObject(imageRequest);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead,
                        new CancellationToken());
                    var uploadedImage = JsonConvert.DeserializeObject<ImgurImageResponse>(await response.Content.ReadAsStringAsync());
                    
                    return uploadedImage;
                }
            }
        }
    }
}
