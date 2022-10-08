﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BookAwayEntities : DbContext
    {
        public BookAwayEntities()
            : base("name=BookAwayEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelOwner> HotelOwners { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<userRole> userRoles { get; set; }
    
        public virtual int insertIntoBookin(Nullable<int> hId, Nullable<int> cId, Nullable<System.DateTime> checkIn, Nullable<System.DateTime> checkOut, Nullable<int> noofRoomsBooked, ObjectParameter bkRooms, ObjectParameter totRooms, ObjectParameter avRooms)
        {
            var hIdParameter = hId.HasValue ?
                new ObjectParameter("HId", hId) :
                new ObjectParameter("HId", typeof(int));
    
            var cIdParameter = cId.HasValue ?
                new ObjectParameter("CId", cId) :
                new ObjectParameter("CId", typeof(int));
    
            var checkInParameter = checkIn.HasValue ?
                new ObjectParameter("CheckIn", checkIn) :
                new ObjectParameter("CheckIn", typeof(System.DateTime));
    
            var checkOutParameter = checkOut.HasValue ?
                new ObjectParameter("CheckOut", checkOut) :
                new ObjectParameter("CheckOut", typeof(System.DateTime));
    
            var noofRoomsBookedParameter = noofRoomsBooked.HasValue ?
                new ObjectParameter("noofRoomsBooked", noofRoomsBooked) :
                new ObjectParameter("noofRoomsBooked", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertIntoBookin", hIdParameter, cIdParameter, checkInParameter, checkOutParameter, noofRoomsBookedParameter, bkRooms, totRooms, avRooms);
        }
    
        public virtual ObjectResult<Hotel> HoelDisp(Nullable<System.DateTime> checkin, Nullable<System.DateTime> checkout, string dest, Nullable<int> room)
        {
            var checkinParameter = checkin.HasValue ?
                new ObjectParameter("checkin", checkin) :
                new ObjectParameter("checkin", typeof(System.DateTime));
    
            var checkoutParameter = checkout.HasValue ?
                new ObjectParameter("checkout", checkout) :
                new ObjectParameter("checkout", typeof(System.DateTime));
    
            var destParameter = dest != null ?
                new ObjectParameter("dest", dest) :
                new ObjectParameter("dest", typeof(string));
    
            var roomParameter = room.HasValue ?
                new ObjectParameter("room", room) :
                new ObjectParameter("room", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Hotel>("HoelDisp", checkinParameter, checkoutParameter, destParameter, roomParameter);
        }
    
        public virtual ObjectResult<Hotel> HoelDisp(Nullable<System.DateTime> checkin, Nullable<System.DateTime> checkout, string dest, Nullable<int> room, MergeOption mergeOption)
        {
            var checkinParameter = checkin.HasValue ?
                new ObjectParameter("checkin", checkin) :
                new ObjectParameter("checkin", typeof(System.DateTime));
    
            var checkoutParameter = checkout.HasValue ?
                new ObjectParameter("checkout", checkout) :
                new ObjectParameter("checkout", typeof(System.DateTime));
    
            var destParameter = dest != null ?
                new ObjectParameter("dest", dest) :
                new ObjectParameter("dest", typeof(string));
    
            var roomParameter = room.HasValue ?
                new ObjectParameter("room", room) :
                new ObjectParameter("room", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Hotel>("HoelDisp", mergeOption, checkinParameter, checkoutParameter, destParameter, roomParameter);
        }
    
        public virtual ObjectResult<HotelDisplay_Result> HotelDisplay(Nullable<System.DateTime> checkin, Nullable<System.DateTime> checkout, string dest, Nullable<int> room)
        {
            var checkinParameter = checkin.HasValue ?
                new ObjectParameter("checkin", checkin) :
                new ObjectParameter("checkin", typeof(System.DateTime));
    
            var checkoutParameter = checkout.HasValue ?
                new ObjectParameter("checkout", checkout) :
                new ObjectParameter("checkout", typeof(System.DateTime));
    
            var destParameter = dest != null ?
                new ObjectParameter("dest", dest) :
                new ObjectParameter("dest", typeof(string));
    
            var roomParameter = room.HasValue ?
                new ObjectParameter("room", room) :
                new ObjectParameter("room", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HotelDisplay_Result>("HotelDisplay", checkinParameter, checkoutParameter, destParameter, roomParameter);
        }
    
        public virtual ObjectResult<disp_Result> disp()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<disp_Result>("disp");
        }
    }
}
