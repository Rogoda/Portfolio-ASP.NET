using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portfolio1.Models;

namespace Portfolio1.Repositories.Reops
{
    public class QuoteImages : IImageRepository
    {
        string imagesDirectoryPath = "~/slider/csss_images1/";

        List<ImageData> imagesData = new List<ImageData>();

        public QuoteImages()
        {
            imagesData.Add(new ImageData { Title = "“Everything should be made as simple as possible, but not simpler.”― Albert Einstein", Description = "bulb", Path = System.IO.Path.Combine(imagesDirectoryPath, "light.jpg") });
            imagesData.Add(new ImageData { Title = "“Talk is cheap. Show me the code.”― Linus Torvalds", Description = "code", Path = System.IO.Path.Combine(imagesDirectoryPath, "programming.jpg") });
            imagesData.Add(new ImageData { Title = "“Stay Hungry. Stay Foolish”― Steve Jobs", Description = "road", Path = System.IO.Path.Combine(imagesDirectoryPath, "road.jpg") });
            imagesData.Add(new ImageData { Title = "“It's not a bug; it's an undocumented feature!”― Anonymous", Description = "code", Path = System.IO.Path.Combine(imagesDirectoryPath, "coding.jpg") });

        }

        public IEnumerable<ImageData> dataImages
        {
            get { return imagesData; }
            set { imagesData = value.ToList(); }
        }
    }
}