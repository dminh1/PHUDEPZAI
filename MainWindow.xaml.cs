using System.Windows;
using System.Windows.Navigation;


namespace BTL_HeThongQuanLyDuLieuThienTai
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        quanlysatlo quanlysatlo1 = new quanlysatlo();
        



        private void tb_quanlyluquet_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new quanlyluquet();
        }

        private void tb_quanlybaocao_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new quanlybaocaothientai();
        }

        private void tb_quanlysatlo_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new quanlysatlo();

        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }


        
        
        
    }
}
