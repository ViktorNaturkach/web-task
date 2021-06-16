using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.ViewModels.Product
{
    public class DetailsImgViewModel
    {
        public string BigImageSrc { get; set; }
        public string UploadImageSrc { get; set; }

        public DetailsImgViewModel()
        {
            UploadImageSrc = null;
        }
    }
}
