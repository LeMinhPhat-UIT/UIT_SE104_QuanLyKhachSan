using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.BLL.Helpers.FinanceHelpers
{
    public class FinanceHelper
    {
        public static decimal CalculateInvoiceAmount(DateTime CheckInDate, DateTime CheckOutDate, decimal PricePerDay, int SurchargeRate)
            => (CheckOutDate - CheckInDate).Days * PricePerDay * (100 + SurchargeRate) / 100;
    }
}
