using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Cars.Data
{
    public class SqlDataProvider : IDataProvider
    {
        public Models.Client GetClient(string email)
        {
            using (var context = new DataClasses1DataContext(Settings.ConectionString))
            {
                var dbClient = context.Clients.Where(c => c.Email == email).SingleOrDefault();
                if (dbClient != null)
                {
                    return GetClient(dbClient.ID);
                }
                return null;
            }
        }

        public Models.Client GetClient(int id)
        {
            using (var context = new DataClasses1DataContext(Settings.ConectionString))
            {
                var dbClient = context.Clients.Where(c => c.ID == id).SingleOrDefault();
                var clientCarsIDs = context.ClientCars.Where(c => c.ClientID == dbClient.ID).Select(c => c.CarID);
                var clientCars = context.Cars.Where(c => clientCarsIDs.Contains(c.ID)).Select(c => new Models.Car(c));
                if (dbClient != null)
                {
                    var client = new Models.Client(dbClient);
                    client.Cars = clientCars.ToList();
                    return client;
                }
                return null;
            }
        }


        public int SaveClient(Models.Client client)
        {
            using (var context = new DataClasses1DataContext(Settings.ConectionString))
            {
                if (client.ID > 0)
                {
                    var dbClient = context.Clients.Where(c => c.ID == client.ID).Single();
                    client.UpdateDb(dbClient);
                    context.SubmitChanges();
                    return client.ID;
                }
                else
                {
                    var dbClient = new Cars.Client();
                    client.UpdateDb(dbClient);
                    context.Clients.InsertOnSubmit(dbClient);
                    context.SubmitChanges();
                    client.ID = dbClient.ID;
                    return dbClient.ID;
                }
            }
        }

        public IList<Models.Order> GetOrders(int carID)
        {
            using (var context = new DataClasses1DataContext(Settings.ConectionString))
            {
                var orders = context.Orders.Where(o => o.CarID == carID);
                return orders.Select(o => new Models.Order(o)).ToList();

            }
        }

        public Models.Order GetOrder(int orderID)
        {
            using (var context = new DataClasses1DataContext(Settings.ConectionString))
            {
                var dbOrder = context.Orders.Where(o => o.ID == orderID).Single();

                return new Models.Order(dbOrder);
                
            }
        }

        public bool PasswordValid(string password)
        {
            return password == ConfigurationManager.AppSettings["Password"];
        }

        public int SaveOrder(Models.Order order)
        {
            using (var context = new DataClasses1DataContext(Settings.ConectionString))
            {
                if (order.ID > 0)
                {
                    var dbOrder = context.Orders.Where(o => o.ID == order.ID).Single();
                    order.UpdateDb(dbOrder);
                    context.SubmitChanges();
                    return order.ID;
                }
                else
                {
                    var dbOrder = new Cars.Order();
                    order.UpdateDb(dbOrder);
                    context.Orders.InsertOnSubmit(dbOrder);
                    context.SubmitChanges();
                    return dbOrder.ID;
                }


            }
        }

        public int SaveCar(Models.Car car, int clientID)
        {
            using (var context = new DataClasses1DataContext(Settings.ConectionString))
            {
                if (car.ID > 0)
                {
                    var dbCar = context.Cars.Where(c => c.ID == car.ID).Single();
                    car.UpdateDb(dbCar);
                    context.SubmitChanges();
                    return car.ID;
                }
                else
                {
                    var dbCar = new Cars.Car();
                    car.UpdateDb(dbCar);
                    context.Cars.InsertOnSubmit(dbCar);

                    context.SubmitChanges();
                    var carID = dbCar.ID;
                    context.ClientCars.InsertOnSubmit(new ClientCar
                    {
                        ClientID = clientID,
                        CarID = carID
                    });
                    context.SubmitChanges();
                    return carID;
                }
            }
        }

        public void DeleteCar(int carID)
        {
            using (var context = new DataClasses1DataContext(Settings.ConectionString))
            {
                var dbCar = context.Cars.Where(c => c.ID == carID).Single();
                context.Cars.DeleteOnSubmit(dbCar);
                var dbClientCar = context.ClientCars.Where(c => c.CarID == carID).Single();
                context.ClientCars.DeleteOnSubmit(dbClientCar);
                context.SubmitChanges();

            }

        }

        public void DeleteOrder(int orderID)
        {
            using (var context = new DataClasses1DataContext(Settings.ConectionString))
            {
                var dbOrder = context.Orders.Where(c => c.ID == orderID).Single();
                context.Orders.DeleteOnSubmit(dbOrder);
                context.SubmitChanges();
            }
        }

        public IList<Models.Car> GetCars(int clientID)
        {
            using (var context = new DataClasses1DataContext(Settings.ConectionString))
            {
                var cars = context.Cars.Where(c => c.ClientID == clientID);
                return cars.Select(c => new Models.Car(c)).ToList();
            }
        }
    }
}