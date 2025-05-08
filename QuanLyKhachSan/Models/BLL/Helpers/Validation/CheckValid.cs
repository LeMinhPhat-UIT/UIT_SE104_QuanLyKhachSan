using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Azure.Cosmos.Spatial;
using QuanLyKhachSan.Models.Core.Entities;

namespace QuanLyKhachSan.Models.BLL.Helpers.Validation
{
    public class CheckValid
    {
        public static bool IsCustomerValid(Customer cus)
        {
            try
            {
                if (cus.IdentityNumber.Length != 12)
                    throw new ArgumentException("IdentityNumber must be 12 characters.");
                if (cus.PhoneNumber.Length != 10)
                    throw new ArgumentException("PhoneNumber must be 10 characters.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Record" , MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public static bool IsRoomValid(Room room)
        {
            try
            {
                var tierPrice = Service.RoomTierService.GetById((int)room.RoomTierID).RoomTierPrice;
                var varlidState = new List<string> { "Available", "Occupied" };
                if (room.PricePerDay < tierPrice)
                    throw new ArgumentException("PricePerDay must be greater than referenced RoomTierPrice.");
                if (!varlidState.Any(x => x.Equals(room.RoomState)))
                    throw new ArgumentException("RoomState is invalid.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Record", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public static bool IsReservationValid(Reservation rental)
        {
            try
            {
                var validStatus = new List<string> { "Pending", "CheckIn", "CheckOut", "Cancelled" };
                if (rental.CheckInDate > rental.CheckOutDate)
                    throw new ArgumentException("CheckOutDate must be greater than CheckInDate.");
                if (!validStatus.Any(x => x.Equals(rental.Status)))
                    throw new ArgumentException("Status is invalid.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Record", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public static bool IsInvoiceValid(Invoice invoice)
        {
            var reservation = Service.ReservationService.GetById(invoice.ReservationID);
            var totalDays = (reservation.CheckOutDate - reservation.CheckInDate).Days;
            var pricePerDay=Service.RoomService.GetById(reservation.RoomID).PricePerDay;
            try
            {
                if (invoice.TotalAmount != totalDays * pricePerDay * (100 + invoice.SurchargeRate) / 100)
                    throw new ArgumentException("TotalAmount is invalid");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Record", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public static bool IsUserValid(User usr)
        {
            try
            {
                if (usr.IdentityNumber.Length != 12)
                    throw new ArgumentException("IdentityNumber must be 12 characters.");
                if (usr.PhoneNumber.Length != 10)
                    throw new ArgumentException("PhoneNumber must be 10 characters.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Record", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
