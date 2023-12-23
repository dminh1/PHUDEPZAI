using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BTL_HeThongQuanLyDuLieuThienTai
{
    /// <summary>
    /// Interaction logic for quanlyluquet.xaml
    /// </summary>
    public partial class quanlyluquet : Page
    {
        public quanlyluquet()
        {
            InitializeComponent();
            loadData();
        }

        string sqlConnectString = @"Data Source=LAPTOP-0N111REN;Initial Catalog=quanlythongtinthientai;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        SqlConnection connect_sql;
        SqlCommand command;
        SqlDataAdapter data_adapter;


        public void loadData()
        {
            SqlConnection connect_sql = new SqlConnection(sqlConnectString);

            try
            {
                // Mở kết nối
                connect_sql.Open();

                // Kiểm tra kết nối có thành công hay không
                if (connect_sql.State == ConnectionState.Open)
                {
                    /*MessageBox.Show("Kết nối thành công!");*/

                    // Thực hiện truy vấn
                    SqlCommand command = new SqlCommand("SELECT IDluquet,quanlythongtinluquet.IDbaocao,DiaChi,ThoiGian,MucDoThienTai,linkbaibaothientai FROM quanlythongtinluquet JOIN quanlybaocaothientai ON quanlythongtinluquet.IDbaocao = quanlybaocaothientai.IDbaocao ", connect_sql);
                    SqlDataAdapter data_adapter = new SqlDataAdapter(command);
                    DataTable data_table = new DataTable();
                    data_adapter.Fill(data_table);

                    // Gán DataTable cho DataContext của DataGridView
                    dgv_thongtinluquet.ItemsSource = data_table.DefaultView;
                }
                else
                {
                    MessageBox.Show("Connect failded !");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi kết nối
                MessageBox.Show("Connect error: " + ex.Message);
            }
            finally
            {
                // Đảm bảo đóng kết nối sau khi sử dụng
                if (connect_sql.State == ConnectionState.Open)
                {
                    connect_sql.Close();
                }
            }
        }
        private void quanlyluquet_loaded(object sender, RoutedEventArgs e)
            {
                loadData();
                }
        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            ThongTinChiTietDiemLuQuet thongtinchitietdiemluquet = new ThongTinChiTietDiemLuQuet();
            thongtinchitietdiemluquet.ShowDialog();
            loadData();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (dgv_thongtinluquet.SelectedCells.Count > 0)
            {
                // Lấy hàng được chọn
                var selectedRow = dgv_thongtinluquet.SelectedItem as DataRowView;

                // Kiểm tra xem hàng có tồn tại và không phải là null không
                if (selectedRow != null)
                {
                    // Lấy giá trị từ cột "IDbaocao"
                    object selectedCellValue = selectedRow["IDbaocao"];

                    // Kiểm tra xem giá trị có tồn tại và không phải null không
                    if (selectedCellValue != null)
                    {
                        // Chuyển đổi giá trị sang kiểu string
                        string IDstring = selectedCellValue.ToString().Trim();

                        using (connect_sql = new SqlConnection(sqlConnectString))
                        {
                            connect_sql.Open();

                            // Thực hiện xóa dữ liệu từ bảng quanlythongtinsatlo
                            string queryDeleteDataQuanLyLuquet = $"DELETE FROM quanlythongtinluquet WHERE IDbaocao = {IDstring}";
                            SqlCommand deleteDataQuanLyLuquet = new SqlCommand(queryDeleteDataQuanLyLuquet, connect_sql);
                            int rowsAffectedLuquet = deleteDataQuanLyLuquet.ExecuteNonQuery();

                            // Thực hiện xóa dữ liệu từ bảng quanlybaocaothientai
                            string queryDeleteDataQuanLyBaoCao = $"DELETE FROM quanlybaocaothientai WHERE IDbaocao = {IDstring}";
                            SqlCommand deleteDataQuanLyBaoCao = new SqlCommand(queryDeleteDataQuanLyBaoCao, connect_sql);
                            int rowsAffectedBaoCao = deleteDataQuanLyBaoCao.ExecuteNonQuery();

                            // Kiểm tra xem cả hai bảng có bản ghi bị ảnh hưởng không
                            if (rowsAffectedLuquet > 0 && rowsAffectedBaoCao > 0)
                            {
                                MessageBox.Show("Delete successfully!");
                                loadData();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete data.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected cell value is null or empty.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete!");
            }
        }

        private void editdata_grid(object sender, MouseButtonEventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgv_thongtinluquet.SelectedItem != null)
            {
                // Lấy hàng được chọn
                var selectedRow = dgv_thongtinluquet.SelectedItem as DataRowView;

                // Kiểm tra xem có cột IDbaocao không
                if (selectedRow.DataView.Table.Columns.Contains("IDbaocao"))
                {
                    object selectedCellValue = selectedRow["IDbaocao"];
                    string IDstring = selectedCellValue.ToString().Trim();

                    Formsuathongtinluquet edit_data_luquet = new Formsuathongtinluquet(IDstring);
                    edit_data_luquet.ShowDialog();
                    loadData();
                }
                else
                {
                    MessageBox.Show("Selected row does not contain 'IDbaocao' column.");
                }
            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }
    }
 }
