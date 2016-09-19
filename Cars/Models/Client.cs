using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class Client
    {
        public Client()
        {
            Cars = new List<Car>();
        }
        public Client(Cars.Client client):base()
        {
            ID = client.ID;
            FirstName = client.FirstName;
            LastName = client.LastName;
            DateOfBirthday = client.DateOfBirthday;
            Address = client.Addres;
            Phone = client.Phone;
            Email = client.Email;
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirthday { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public IList<Car> Cars { get; set; }

        public void UpdateDb(Cars.Client client)
        {
           
                client.FirstName = FirstName;
                client.LastName = LastName;
                client.DateOfBirthday = DateOfBirthday;
                client.Addres = Address;
                client.Phone = Phone;
                client.Email = Email;
        
        }
    }
}