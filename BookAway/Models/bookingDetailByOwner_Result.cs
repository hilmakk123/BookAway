//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookAway.Models
{
    using System;
    
    public partial class bookingDetailByOwner_Result
    {
        public int Id { get; set; }
        public Nullable<int> HotelId { get; set; }
        public Nullable<int> CustId { get; set; }
        public Nullable<System.DateTime> CheckIn { get; set; }
        public Nullable<System.DateTime> CheckOut { get; set; }
        public Nullable<int> NOfRooms { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public int Id1 { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelCity { get; set; }
        public string HotelEmail { get; set; }
        public string HotelContactNumber { get; set; }
        public Nullable<int> TotalOfRooms { get; set; }
        public Nullable<double> RentPerRoom { get; set; }
        public string HotelPic { get; set; }
        public Nullable<int> HotelOwner { get; set; }
    }
}
