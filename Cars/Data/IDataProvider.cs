using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Data
{
    public interface IDataProvider
    {
        Models.Client GetClient(string email);
        Models.Client GetClient(int ID);

        int SaveClient(Models.Client client);

        IList<Models.Order> GetOrders(int carID);

        Models.Order GetOrder(int orderID);
        bool PasswordValid(string password);

        int SaveOrder(Models.Order order);

        int SaveCar(Models.Car car, int clientID);
        void DeleteCar(int carID);
        void DeleteOrder(int orderID);

        IList<Models.Car> GetCars(int clientID);

    }
}
