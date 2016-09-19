using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class Car
    {
        public Car(){}

        public Car(Cars.Car car)
        {
            ID = car.ID;
            Make = car.Make;
            Model = car.Model;
            VIN = car.VIN;
        }
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public void UpdateDb(Cars.Car car)
        {
               
                car.Make = Make;
                car.Model = Model;
                car.Year = Year;
                car.VIN = VIN;
            
        }
    }


}