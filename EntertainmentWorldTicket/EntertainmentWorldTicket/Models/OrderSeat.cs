//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntertainmentWorldTicket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderSeat
    {
        public OrderSeat()
        {
            this.Seats = new HashSet<Seat>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int OSeat_ID { get; set; }
        public int OS_Row { get; set; }
        public int OS_SeatNumber { get; set; }
        public string OS_SeatColor { get; set; }
    
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
