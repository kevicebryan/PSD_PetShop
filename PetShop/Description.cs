using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class Description
    {
        private string color { get;  }
        private string photo { get;  } // Img Source
        private double weight { get;  }
        private string species { get; }

        public Description(string color, string photo, double weight, string species)
        {
            this.color = color;
            this.photo = photo;
            this.weight = weight;
            this.species = species;
        }

        public string Color { get { return color; } }
        public string Photo { get { return photo; } }
        public double Weight { get { return weight; } }
        public string Species { get { return species; } }

        public String printDesc()
        {
            return $"{this.color} || {this.weight}kg || {this.species}";
        }
    }
}
