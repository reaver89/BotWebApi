using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace BotWebApi.Controllers
{
    public class PhotoController : ApiController
    {
        private const string UnsplashItRandomPhotoUrl = "https://unsplash.it/300/300/?random";
        // GET api/<controller>
        public async Task<HttpResponseMessage> Get()
        {
            byte[] data;

            using (var client = new WebClient())
            {
                data = await client.DownloadDataTaskAsync(new Uri(UnsplashItRandomPhotoUrl));
            }

            var stream  = new MemoryStream(data);
            var content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            content.Headers.ContentLength = stream.Length;
            return new HttpResponseMessage() {Content = content};
        }
    }
}