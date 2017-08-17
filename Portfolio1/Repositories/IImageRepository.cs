using Portfolio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio1.Repositories
{
    public interface IImageRepository
    {
        IEnumerable<ImageData> dataImages { get; set; }
    }
}