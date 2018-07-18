using System;

namespace CleanCode.NestedConditionals
{
    public class Customer
    {
        public int LoyaltyPoints { get; set; }
    }
    // Yohana Espinoza, James Ordinola
    public class Reservation
    {
        public DateTime ReservationDate { get; set; }
        public Customer Customer { get; set; }

        public Reservation(Customer customer, DateTime dateTime)
        {
            ReservationDate = dateTime;
            Customer = customer;
        }

        public bool IsCanceled { get; set; }

        public void CancelReservation()
        {
            EvaluateReservationTime();

            IsCanceled = true;
        }

        public void EvaluateReservationTime()
        {
            var minimumHours = GetMinimumHoursByLoyaltyPoints(Customer.LoyaltyPoints);

            if ((DateTime.Now > ReservationDate) || (ReservationDate - DateTime.Now).TotalHours < minimumHours)
            {
                throw new InvalidOperationException("It's too late to cancel.");
            }
        }

        public int GetMinimumHoursByLoyaltyPoints(int loyaltyPoints)
        {
            return loyaltyPoints > 100 ? 24 : 48;
        }
    }
}
