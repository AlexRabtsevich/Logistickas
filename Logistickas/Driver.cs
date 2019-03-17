using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistickas
{
    class Driver
    {

        private string name;
        private string lastname;
        private string secondname;
        private int age;
        private string car;
        private string numberPhone;
        private string numberCar;

        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string LastName
        {
            set { lastname = value; }
            get { return lastname; }
        }
        public string SecondName
        {
            set { secondname = value; }
            get { return secondname; }
        }
        public string NumberCar
        {
            set { numberCar = value; }
            get { return numberCar; }
        }
        public string NumberPhone
        {
            set { numberPhone = value; }
            get { return numberPhone; }
        }
        public string Car
        {
            set { car = value; }
            get { return car; }
        }
        public int Age
        {
            set { age = value; }
            get { return age; }
        }
        public Driver()
        {

        }
        public Driver(string name, string lastname,string secondname,string car, string numberphone,string numbercar,int age)
        {
            Age = age;
            Name = name;
            LastName = lastname;
            SecondName = secondname;
            Car = car;
            NumberCar = numbercar;
            NumberPhone = numberphone;
        }


    }
}
