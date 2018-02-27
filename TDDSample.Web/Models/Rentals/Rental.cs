﻿namespace TDDSample.Web.Models.Rentals
{
    public sealed class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public Movie Movie { get; }
        public int DaysRented { get; }
    }
}