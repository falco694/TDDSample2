using System;
using System.Collections.Generic;

namespace TDDSample.Web.Models.Rentals
{
    public sealed class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        /**
         * レンタル金額を円で返す。
         */
        public string Statement()
        {
            var fee = RentelFee();
            return $"{fee:N0}円";
            // return "300円";
        }

        public int RentelFee()
        {
            var fee = 0;
            foreach (var rental in _rentals)
            {
                fee += RentelFee(rental);
            }

            return fee;
        }

        private static int RentelFee(Rental rental)
        {
            if (rental.Movie.RentalType == MovieRentalType.NewRelease)
            {
                return rental.DaysRented * 300;
            }
            
            if (rental.Movie.RentalType == MovieRentalType.Regular)
            {
                return 200;
            }

            throw  new InvalidOperationException();
        }
    }
}