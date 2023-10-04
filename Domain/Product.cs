using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SmallDescription { get; set; }

        public ICollection<ImageUrl> ImageUrls { get; set; } = new List<ImageUrl>();     

        public byte StarCount { get; set; }  

        public int Price { get; set; }
        public ICollection<Color> Colors { get; set; } = new List<Color>();

        public ICollection<GuaranteeType> GuaranteeTypes { get; set; } = new List<GuaranteeType>();

        public int Inventory { get; set; }
        public string Review { get; set; }

    }

    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    

    public class GuaranteeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    

    public class ImageUrl
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }



}
