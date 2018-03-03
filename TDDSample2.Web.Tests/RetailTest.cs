using TDDSample.Web.Models.Rentals;
using Xunit;

namespace TDDSample2.Web.Tests
{
    public class RetailTest
    {
        private readonly Movie _movie;
        private readonly Customer _customer;

        public RetailTest()
        {
            _movie = new Movie("スターウォーズVIII", MovieRentalType.NewRelease);
            _customer = new Customer("太郎");
        }

        [Fact]
        public void 新作を一泊借りたら300円()
        {
            _customer.AddRental(new Rental(_movie, 1));

            var result = _customer.RentelFee();
            
            Assert.Equal(300, result);
        }
        
        [Fact]
        public void 新作を四泊借りたら1200円()
        {
            _customer.AddRental(new Rental(_movie, 4));

            var result = _customer.Statement();
            
            Assert.Equal("1,200円", result);
        }

        [Fact]
        public  void 普通を2泊借りたら200円()
        {
            _customer.AddRental(new Rental(new Movie("スターウォーズVIII", MovieRentalType.Regular), 2));

            var result = _customer.RentelFee();
            
            Assert.Equal(200, result);
        }

        [Fact]
        public void 新作3泊と普通を2泊を借りたら1100円()
        {
            _customer.AddRental(new Rental(new Movie("スターウォーズVIII", MovieRentalType.NewRelease), 3));            
            _customer.AddRental(new Rental(new Movie("スターウォーズVIII", MovieRentalType.Regular), 2));

            var result = _customer.RentelFee();
            
            Assert.Equal(1100, result);
        }
    }
}