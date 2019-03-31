using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistickas
{
    [Serializable]
    public class PlaceTake
    {
        private string namePlace;
        private string city;
        private string street;
        private string house;


        public string NamePlace
        {
            set { namePlace = value; }
            get { return namePlace; }
        }

        public string City
        {
            set {city = value; }
            get { return city; }
        }
        public string Street
        {
            set { street = value; }
            get { return street; }
        }
        public string House
        {
            set { house = value; }
            get { return house; }
        }
        public PlaceTake()
        {
                
        }
        public PlaceTake(string name,string city,string street,string house)
        {
            NamePlace = name;
            City = city;
            Street = street;
            House = house;
        }
    }
}

