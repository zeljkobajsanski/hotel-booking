﻿namespace HotelBooking.Shared.Models
{
    public class Room
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
    }
}
