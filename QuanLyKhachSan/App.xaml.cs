using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.Store;
using System.Windows;

namespace QuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _mainNavigationStore;
        private readonly NavigationStore _subNavigationStore;

        public App()
        {
            _mainNavigationStore = new NavigationStore();
            _subNavigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _mainNavigationStore.CurrentViewModel = new LoginViewModel(_mainNavigationStore, CreateOverviewViewModel);
            //_mainNavigationStore.CurrentViewModel = new AddUpdateCustomerViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_mainNavigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private OverviewViewModel CreateOverviewViewModel()
        {
            return new OverviewViewModel(_mainNavigationStore);
        }

    }

}
