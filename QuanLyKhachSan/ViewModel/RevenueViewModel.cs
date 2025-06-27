using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Azure.Cosmos.Linq;
using QuanLyKhachSan.Model.BLL.Helpers.ReportHelpers;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using QuanLyKhachSan.ViewModel.Store;
using SkiaSharp;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuanLyKhachSan.ViewModel
{
    public class PieChartSegment
    {
        public RoomTierViewModel Tier { get; set; }
        public double Value { get; set; }
        public SolidColorPaint Fill { get; set; }
        public Brush Brush => ToBrush();
        public Brush ToBrush()
        {
            if (Fill == null || Fill.Color == null)
                return Brushes.Transparent;

            var color = Fill.Color;
            return new SolidColorBrush(Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue));
        }
    }

    public class RevenueViewModel : BaseViewModel
    {
        private NavigationStore _navigationStore;
        private SidebarCommand _sidebarCommand;
        private UserViewModel _user;
        private ObservableCollection<ISeries> _pieChart;
        private ObservableCollection<ISeries> _columnChart;
        private ObservableCollection<ISeries> _lineChart;
        private ObservableCollection<Axis> _columnXAxis;
        private ObservableCollection<Axis> _columnYAxis;
        private ObservableCollection<Axis> _lineXAxis;
        private ObservableCollection<Axis> _lineYAxis;
        private ObservableCollection<PieChartSegment> _pieChartItems;
        private string _selectedPieChartView;
        private string _selectedLineChartView;
        private string _selectedTotalRevenue;
        private double _totalRevenue;

        public SidebarCommand SidebarCommand => _sidebarCommand;
        public IEnumerable<PieChartSegment> PieChartItems => _pieChartItems;
        public List<string> ChartView { get; set; } = new List<string>()
        {
            "Tuần",
            "Tháng",
            "Năm",
        };
        public string SelectedPieChartView { get => _selectedPieChartView; set { _selectedPieChartView = value; OnPropertyChanged(nameof(SelectedPieChartView)); } }
        public string SelectedLineChartView { get => _selectedLineChartView; set { _selectedLineChartView = value; OnPropertyChanged(nameof(SelectedLineChartView)); } }
        public string SelectedTotalRevenue { get => _selectedTotalRevenue; set { _selectedTotalRevenue = value; OnPropertyChanged(nameof(SelectedLineChartView)); } } 
        public IEnumerable<ISeries> PieChart => _pieChart;
        public IEnumerable<ISeries> ColumnChart => _columnChart;
        public IEnumerable<ISeries> LineChart => _lineChart;
        public IEnumerable<Axis> ColumnXAxis => _columnXAxis;
        public IEnumerable<Axis> ColumnYAxis => _columnYAxis;   
        public IEnumerable<Axis> LineXAxis => _lineXAxis;
        public IEnumerable<Axis> LineYAxis => _lineYAxis;
        public UserViewModel User { get => _user; set { _user = value; OnPropertyChanged(nameof(User)); } }
        public int ReservationCount { get; set; }
        public double TotalRevenue { get => _totalRevenue; set { _totalRevenue = value; OnPropertyChanged(nameof(TotalRevenue)); } }

        public ICommand TotalRevenueViewChanged { get; }
        public ICommand PieChartViewChanged { get; }
        public ICommand LineChartViewChanged { get; }

        public RevenueViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _sidebarCommand = new SidebarCommand(navigationStore);
            _user = navigationStore.User;
            _selectedPieChartView = ChartView[0];
            _selectedLineChartView = ChartView[0];
            _selectedTotalRevenue = ChartView[0];
            _pieChart = new ObservableCollection<ISeries>();
            _columnChart = new ObservableCollection<ISeries>();
            _pieChartItems = new ObservableCollection<PieChartSegment>();

            ReservationCount = QuanLyKhachSan.Models.BLL.Service.ReservationService.GetAllData().Count(x => x.CheckInDate.Date.Year == DateTime.Now.Year);

            QuanLyKhachSan.Models.BLL.Service.RoomTierService.GetAllData().ForEach(x => _pieChartItems.Add(new PieChartSegment
            {
                Tier = new RoomTierViewModel(x),
                Value = 0,
                Fill = GetRandomColorPaint(),
            }));

            PieChartViewChanged = new RevenueCommand(this, _ => SetPieChart());
            TotalRevenueViewChanged = new RevenueCommand(this, _ => GetRevenue());
            SetLineChart();
            SetColumnChart();
        }

        private void SetPieChart()
        {
            var revenueList = QuanLyKhachSan.Models.BLL.Service.RevenueService.GetAllData();
            IEnumerable<RevenueReport> filteredRevenue = Enumerable.Empty<RevenueReport>();

            if (SelectedPieChartView == ChartView[0])
            {
                var listOfDate = DateTimeHelper.GetFullWeekFromDate(DateTime.Now);
                filteredRevenue = revenueList
                    .Where(x => x.RevenueDate.Date >= listOfDate.First().Date && x.RevenueDate.Date <= listOfDate.Last().Date);
            }
            else if (SelectedPieChartView == ChartView[1])
            {
                filteredRevenue = revenueList
                    .Where(x => x.RevenueDate.Month == DateTime.Now.Month && x.RevenueDate.Year == DateTime.Now.Year);
            }
            else if (SelectedPieChartView == ChartView[2])
            {
                filteredRevenue = revenueList
                    .Where(x => x.RevenueDate.Year == DateTime.Now.Year);
            }

            var totalRevenue = filteredRevenue.Sum(x => x.TotalRevenue);

            foreach (var item in _pieChartItems)
            {
                var tierRevenue = filteredRevenue
                    .Where(r => r.RoomTierID == item.Tier.ID)
                    .Sum(r => r.TotalRevenue);

                item.Value = totalRevenue > 0 ? Math.Round((double)(100*tierRevenue/totalRevenue), 2) : 0;
            }

            //_pieChart.Clear();
            //foreach (var item in _pieChartItems)
            //{
            //    _pieChart.Add(new PieSeries<double>
            //    {
            //        Name = item.Tier.RoomTierName,
            //        Values = new[] { item.Value },
            //        Fill = item.Fill,
            //        IsVisible = item.Value > 0,
            //        IsHoverable = item.Value > 0
            //    });
            //}

            for (int i = 0; i < _pieChartItems.Count; i++)
            {
                var value = _pieChartItems[i].Value;

                if (i >= _pieChart.Count)
                {
                    _pieChart.Add(new PieSeries<double>
                    {
                        Name = _pieChartItems[i].Tier.RoomTierName,
                        Values = new[] { value },
                        Fill = _pieChartItems[i].Fill,
                        IsHoverable = value > 0
                    });
                }
                else
                {
                    var series = _pieChart[i] as PieSeries<double>;
                    series.Values = new[] { value };
                    series.Name = _pieChartItems[i].Tier.RoomTierName;
                    series.Fill = _pieChartItems[i].Fill;
                    series.IsHoverable = value > 0;
                }
            }

            while (_pieChart.Count > _pieChartItems.Count)
            {
                _pieChart.RemoveAt(_pieChart.Count - 1);
            }
        }

        private void SetColumnChart()
        {
            var revenueList = QuanLyKhachSan.Models.BLL.Service.RevenueService.GetAllData()
                .Where(x => x.RevenueDate.Year == DateTime.Now.Year);

            var chartValues = revenueList.GroupBy(x => x.RevenueDate.Month).Select(gr => new
            {
                Month = gr.Key,
                Revenue = (double)gr.Sum(x => x.TotalRevenue),
            }).OrderBy(x => x.Month).ToList();

            var maxValue = chartValues.Select(x => x.Revenue).DefaultIfEmpty(0).Max();
            var valueBackground = Enumerable.Repeat(maxValue, 12).ToList();
            List<double> valueForground = new List<double>();

            for (int i = 1; i <= 12; i++)
            {
                var revenue = chartValues.FirstOrDefault(x => x.Month == i);
                if (revenue != null)
                    valueForground.Add(revenue.Revenue);
                else valueForground.Add(0);
            }

            _columnChart.Add(new ColumnSeries<double>
            {
                Values = Enumerable.Repeat(maxValue, 12).ToList(),
                Fill = new SolidColorPaint(SKColors.LightGray),
                Stroke = null,
                IgnoresBarPosition = true,
                ZIndex = 0,
                Rx = 10,
                Ry = 10,
                IsHoverable = false,
            });

            _columnChart.Add(new ColumnSeries<double>
            {
                Values = valueForground,
                Fill = new SolidColorPaint(SKColors.DodgerBlue),
                Stroke = null,
                IgnoresBarPosition = true,
                ZIndex = 1,
                Rx = 10,
                Ry = 10,
                IsHoverable = true,
            });

            _columnXAxis = new ObservableCollection<Axis>
            {
                new Axis
                {
                    Labels = CultureInfo.InvariantCulture.DateTimeFormat.AbbreviatedMonthNames,
                    TextSize = 15,
                },
            };

            _columnYAxis = new ObservableCollection<Axis>
            {
                new Axis
                {
                    MinLimit = 0,
                    MaxLimit = maxValue,
                    IsVisible = false,
                }
            };
        }

        private void SetLineChart()
        {
            var revenueList = QuanLyKhachSan.Models.BLL.Service.RevenueService.GetAllData()
                .Where(x => x.RevenueDate.Year == DateTime.Now.Year)
                .ToList();

            var roomTiers = revenueList
                .Select(x => x.RoomTierID)
                .Distinct()
                .ToList();

            _lineChart = new ObservableCollection<ISeries>();
            double maxValue = 0;

            foreach (var tierID in roomTiers)
            {
                var roomTier = QuanLyKhachSan.Models.BLL.Service.RoomTierService.GetById(tierID);
                if (roomTier == null) continue;

                var monthlyRevenue = new double[12]; 

                var dataByMonth = revenueList
                    .Where(x => x.RoomTierID == tierID)
                    .GroupBy(x => x.RevenueDate.Month)
                    .Select(gr => new
                    {
                        Month = gr.Key,
                        Revenue = gr.Sum(x => x.TotalRevenue)
                    });

                foreach (var item in dataByMonth)
                {
                    monthlyRevenue[item.Month - 1] = (double)item.Revenue;
                    if ((double)item.Revenue > maxValue) maxValue = (double) item.Revenue;
                }

                var baseColor = _pieChartItems.First(x => x.Tier.ID == roomTier.RoomTierID).Fill.Color;
                var color = new SKColor(baseColor.Red, baseColor.Green, baseColor.Blue, 80);
                _lineChart.Add(new LineSeries<double>
                {
                    Name = roomTier.RoomTierName,
                    Values = monthlyRevenue,
                    Stroke = new SolidColorPaint { Color = color, StrokeThickness = 5},
                    Fill = null,
                    GeometrySize = 8
                });
            }

            _lineXAxis = new ObservableCollection<Axis>
            {
                new Axis
                {
                    Labels = CultureInfo.InvariantCulture.DateTimeFormat.AbbreviatedMonthNames,
                    TextSize = 15,
                },
            };

            //_lineYAxis = new ObservableCollection<Axis>
            //{
            //    new Axis
            //    {
            //        MinLimit = 0,
            //        MaxLimit = maxValue,
            //        IsVisible = false,
            //    }
            //};
        }

        private void GetRevenue()
        {
            if(SelectedTotalRevenue == ChartView[0])
            {
                var listOfWeek = DateTimeHelper.GetFullWeekFromDate(DateTime.Now);
                TotalRevenue = (double)QuanLyKhachSan.Models.BLL.Service.RevenueService.GetAllData()
                    .Where(x => x.RevenueDate.Date>=listOfWeek.First() && x.RevenueDate.Date<=DateTime.Now.Date).Sum(x => x.TotalRevenue);
            }
            else if(SelectedTotalRevenue == ChartView[1])
                TotalRevenue = (double)QuanLyKhachSan.Models.BLL.Service.RevenueService.GetAllData()
                    .Where(x => x.RevenueDate.Month==DateTime.Now.Month && x.RevenueDate.Year==DateTime.Now.Year).Sum(x => x.TotalRevenue);
            else
                TotalRevenue = (double)QuanLyKhachSan.Models.BLL.Service.RevenueService.GetAllData()
                    .Where(x => x.RevenueDate.Year == DateTime.Now.Year).Sum(x => x.TotalRevenue);
        }

        private SolidColorPaint GetRandomColorPaint()
        {
            var random = new Random();

            double hue = random.NextDouble() * 360.0; // 0 - 360 độ
            double saturation = random.NextDouble() * 0.4 + 0.6; // 0.6 - 1.0 (màu tươi)
            double lightness = random.NextDouble() * 0.2 + 0.6; // 0.6 - 0.8 (màu sáng)

            var rgb = HSLToRGB(hue, saturation, lightness);
            var skColor = new SKColor(rgb.r, rgb.g, rgb.b);
            return new SolidColorPaint(skColor);
        }

        private (byte r, byte g, byte b) HSLToRGB(double h, double s, double l)
        {
            double c = (1 - Math.Abs(2 * l - 1)) * s;
            double x = c * (1 - Math.Abs((h / 60.0) % 2 - 1));
            double m = l - c / 2;

            double r1 = 0, g1 = 0, b1 = 0;

            if (h < 60) { r1 = c; g1 = x; b1 = 0; }
            else if (h < 120) { r1 = x; g1 = c; b1 = 0; }
            else if (h < 180) { r1 = 0; g1 = c; b1 = x; }
            else if (h < 240) { r1 = 0; g1 = x; b1 = c; }
            else if (h < 300) { r1 = x; g1 = 0; b1 = c; }
            else { r1 = c; g1 = 0; b1 = x; }

            byte r = (byte)((r1 + m) * 255);
            byte g = (byte)((g1 + m) * 255);
            byte b = (byte)((b1 + m) * 255);
            return (r, g, b);
        }
    }
}
