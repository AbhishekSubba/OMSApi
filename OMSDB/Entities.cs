using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSDB
{
    class Entities
    {
    }
    public class OrderStatus
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string status { get; set; }
        public double SubTotalFare { get; set; }
        public string message { get; set; }
    }
    public class OrderView
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string status { get; set; }
        public double SubTotalFare { get; set; }
        public string message { get; set; }

        public string Shiping_Street1 { get; set; }
        public string Shiping_Street2 { get; set; }
        public string Shiping_City { get; set; }
        public string Shiping_State { get; set; }
        public string Shiping_Country { get; set; }

        public int Shiping_Postal_Code { get; set; }
        public string QuantitiesCount { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
    }
}
