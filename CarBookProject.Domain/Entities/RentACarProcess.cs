using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Domain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessId { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int PickupLocation { get; set; }
        public int DropOffLocation { get; set; }
        [DataType(DataType.Date)]
        public DateTime PickUpDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DropOffDate { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan PickUpTime { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan DropOffTime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string PickUpDescription { get; set; } //Müşteri teslim alırken açıklama
        public string DropOffDescription { get; set; } //Müşteri teslim ederken açıklama
        public decimal TotalPrice { get; set; }
    }
}
