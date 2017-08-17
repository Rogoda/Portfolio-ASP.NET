using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio1.Models
{
    public class ImageData
    {
        static int indexer = 0;

        public ImageData()
        {
            index = indexer;
            indexer++;
        }

        private int index;

        public int Id
        {
            get { return index; }
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }
}