using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using OpenTK.Graphics.OpenGL;
using QuanLyKhachSan.Model.BLL.Helpers.ReportHelpers;
using QuanLyKhachSan.Models.BLL;
using QuanLyKhachSan.Models.BLL.Helpers.QueryHelpers;
using QuanLyKhachSan.Models.BLL.Helpers.ReportHelpers;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using QuanLyKhachSan.ViewModel.Store;
using SkiaSharp;

namespace QuanLyKhachSan.ViewModel
{
    public class OverviewViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly UserViewModel _userViewModel;
        private readonly List<ReservationViewModel> _reservationList = new List<ReservationViewModel>();
        private readonly List<RoomViewModel> _roomList = new List<RoomViewModel>();
        private readonly List<RoomTierViewModel> _roomTierList = new List<RoomTierViewModel>();
        private readonly SidebarCommand _sidebarCommand;
        private ObservableCollection<ISeries> _series;
        private ObservableCollection<Axis> _xAxis;
        private ObservableCollection<Axis> _yAxis;

        public UserViewModel User => _userViewModel;
        public int CheckIn => _reservationList.Count(x => x.CheckIn.Date == DateTime.Now.Date && x.Status == "CheckIn");
        public int CheckOut => _reservationList.Count(x => x.CheckOut.Date == DateTime.Now.Date && x.Status == "CheckOut");
        public int Staying => _reservationList.Where(x => x.CheckIn.Date == DateTime.Now.Date && x.Status == "CheckIn").Sum(x => x.Customers.ToList().Count);
        public int AvailableRoom => _roomList.Count(x => x.RoomState == "Available");
        public int OccupiedRoom => _roomList.Count(x => x.RoomState == "Occupied");
        public IEnumerable<RoomTierViewModel> RoomTierList => _roomTierList;
        public SidebarCommand SidebarCommand => _sidebarCommand;
        public IEnumerable<ISeries> Series => _series;
        public IEnumerable<Axis> XAxis => _xAxis;
        public IEnumerable<Axis> YAxis => _yAxis;

        public OverviewViewModel(NavigationStore navigationStore) 
        {
            _sidebarCommand = new SidebarCommand(navigationStore);
            _navigationStore = navigationStore;
            _userViewModel = _navigationStore.User;
            QuanLyKhachSan.Models.BLL.Service.ReservationService.GetAllData().ForEach(x => _reservationList.Add(new ReservationViewModel(x)));
            QuanLyKhachSan.Models.BLL.Service.RoomService.GetAllData().ForEach(x => _roomList.Add(new RoomViewModel(x)));
            QuanLyKhachSan.Models.BLL.Service.RoomTierService.GetAllData().ForEach(x => _roomTierList.Add(new RoomTierViewModel(x)));

            SetStatistic();
            SetRevenue();
        }

        private void SetRevenue()
        {
            var lastReport = QuanLyKhachSan.Models.BLL.Service.RevenueService.GetAllData().Last();
            var roomTierIDList = QuanLyKhachSan.Models.BLL.Service.RoomTierService.GetAllData().Select(x => x.RoomTierID).ToList();
            if(lastReport.RevenueDate.Date < DateTime.Now.AddDays(-1).Date)
            {
                var diff = (DateTime.Now-lastReport.RevenueDate).Days-1;
                for(int i=1; i<=diff; ++i)
                {
                    roomTierIDList.ForEach(x =>
                    {
                        ReportHelper.GenerateReport(x, User.ID, lastReport.RevenueDate.AddDays(i).Date);
                    });
                }
            }
        }
        private void SetStatistic()
        {
            var listOfDate = DateTimeHelper.GetFullWeekFromDate(DateTime.Now);
            var revenueOfWeek = QuanLyKhachSan.Models.BLL.Service.RevenueService
                .GetAllData().Where(x => x.RevenueDate.Date >= listOfDate.First().Date && x.RevenueDate.Date <= listOfDate.Last().Date)
                .ToList();

            var chartValues = revenueOfWeek.GroupBy(x => (x.RoomTierID, x.RevenueDate)).Select(gr => new
            {
                RoomTierName = QuanLyKhachSan.Models.BLL.Service.RoomTierService.GetById(gr.Key.RoomTierID).RoomTierName,
                Day = gr.Key.RevenueDate.DayOfWeek,
                Revenue = (double)gr.Sum(x => x.TotalRevenue),
            }).OrderBy(x => x.Day).ToList();

            var maxValue = chartValues.Select(x => x.Revenue).DefaultIfEmpty(0).Max();
            var valueBackground = Enumerable.Repeat(maxValue, 7).ToList();
            var valueForground = listOfDate.Select(date =>
            {
                var revenue = chartValues.FirstOrDefault(x => x.Day == date.DayOfWeek);
                return revenue != null ? revenue.Revenue : 0;
            }).ToList();

            _series = new ObservableCollection<ISeries>
            {
                //new ColumnSeries<double>
                //{
                //    Values = Enumerable.Repeat(maxValue, 7).ToList(),
                //    Fill = new SolidColorPaint(SKColors.LightGray),
                //    Stroke = null,
                //    IgnoresBarPosition = true,
                //    ZIndex = 0,
                //    Rx = 15,
                //    Ry = 15,
                //    IsHoverable = false,
                //},

                new ColumnSeries<double>
                {
                    Values = valueForground,
                    Fill = new SolidColorPaint(SKColors.DodgerBlue),
                    IgnoresBarPosition = true,
                    ZIndex = 1,
                    //Rx = 15,
                    //Ry = 15,
                }
            };

            _yAxis = new ObservableCollection<Axis>
            {
                new Axis
                {
                    MinLimit = 0,
                    MaxLimit = maxValue,
                }
            };

            _xAxis = new ObservableCollection<Axis>
            {
                new Axis
                {
                    Labels = listOfDate.Select(x => x.DayOfWeek.ToString().Substring(0,3)).ToList(),
                }
            };
        }
    }
}
