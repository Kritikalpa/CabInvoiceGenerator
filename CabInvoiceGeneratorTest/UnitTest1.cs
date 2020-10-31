using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            Assert.AreEqual(expected, fare);
        }


        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary.totalFare, summary.totalFare);
        }

        [Test]
        public void GivenMultipleRidesShouldReturnEnhancedInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary, summary);
        }

        [Test]
        public void GivenUserIdShouldReturnEnhancedInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            invoiceGenerator.AddRides("1", rides);
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("1");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenDistanceAndTimeForPremiumShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;

            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;

            Assert.AreEqual(expected, fare);
        }
    }
}