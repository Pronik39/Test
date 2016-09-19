using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public enum OrderStatus
    {
        Completed,
        InProgress,
        Cancelled
    }
    public class Order
    {
        public Order()
        {

        }
        public Order(Cars.Order order)
        {
            ID = order.ID;
            Date = order.Date;
            OrderAmount = order.OrderAmount;
            Status = (OrderStatus)order.OrderStatus;
            CarID = order.CarID;

        }
        public int ID { get; set; }
        public string Date { get; set; }
        public decimal OrderAmount { get; set; }
        public OrderStatus Status { get; set; }

        public int CarID { get; set; }

        public void UpdateDb(Cars.Order order)
        {
            
        
            
            order.Date = Date;
            order.OrderAmount = OrderAmount;
            order.OrderStatus = (int)Status;
            order.CarID = CarID;
        
        }
    }
}