using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;
using System.Data;


namespace BTL_HeThongQuanLyDuLieuThienTai
{
    /// <summary>
    /// Interaction logic for quanlybaocaothientai.xaml
    /// </summary>
    public partial class quanlybaocaothientai : Page
    {
        public quanlybaocaothientai()
        {
            InitializeComponent();
            loadData();
        }

        string sqlConnectString = @"Data Source=LAPTOP-0N111REN;Initial Catalog=quanlythongtinthientai;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        SqlConnection connect_sql;

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
                    SqlCommand command = new SqlCommand("SELECT * FROM quanlybaocaothientai", connect_sql);
                    SqlDataAdapter data_adapter = new SqlDataAdapter(command);
                    DataTable data_table = new DataTable();
                    data_adapter.Fill(data_table);

                    // Gán DataTable cho DataContext của DataGridView
                    dgv_quanlybaocao.ItemsSource = data_table.DefaultView;
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
        private void quanlybaocao_loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {

            int rowsAffectedSatLo = 0;
            int rowsAffectedBaoCao = 0;
            int rowsAffectedLuQuet = 0;

            if (dgv_quanlybaocao.SelectedCells.Count > 0)
            {
                var selectedRow = dgv_quanlybaocao.SelectedItem as DataRowView;

                if (selectedRow != null)
                {
                    object selectedCellValue = selectedRow["IDbaocao"];

                    if (selectedCellValue != null)
                    {
                        string IDstring = selectedCellValue.ToString().Trim();

                        using (connect_sql = new SqlConnection(sqlConnectString))
                        {
                            connect_sql.Open();

                            // Thực hiện xóa dữ liệu từ bảng quanlybaocaothientai
                            string queryDeleteDataQuanLyBaoCao = "DELETE FROM quanlybaocaothientai WHERE IDbaocao = @IDbaocao";
                            SqlCommand deleteDataQuanLyBaoCao = new SqlCommand(queryDeleteDataQuanLyBaoCao, connect_sql);
                            deleteDataQuanLyBaoCao.Parameters.AddWithValue("@IDbaocao", IDstring);
                            rowsAffectedBaoCao = deleteDataQuanLyBaoCao.ExecuteNonQuery();

                            try
                            {
                                // Thực hiện xóa dữ liệu từ bảng quanlythongtinsatlo
                                string queryDeleteDataQuanLySatLo = "DELETE FROM quanlythongtinsatlo WHERE IDbaocao = @IDbaocao";
                                SqlCommand deleteDataQuanLySatLo = new SqlCommand(queryDeleteDataQuanLySatLo, connect_sql);
                                deleteDataQuanLySatLo.Parameters.AddWithValue("@IDbaocao", IDstring);
                                rowsAffectedSatLo = deleteDataQuanLySatLo.ExecuteNonQuery();
                            }
                            catch
                            {
                                // Thực hiện xóa dữ liệu từ bảng quanlythongtinluquet
                                string queryDeleteDataQuanLyLuQuet = "DELETE FROM quanlythongtinluquet WHERE IDbaocao = @IDbaocao";
                                SqlCommand deleteDataQuanLyLuQuet = new SqlCommand(queryDeleteDataQuanLyLuQuet, connect_sql);
                                deleteDataQuanLyLuQuet.Parameters.AddWithValue("@IDbaocao", IDstring);
                                rowsAffectedLuQuet = deleteDataQuanLyLuQuet.ExecuteNonQuery();
                            }

                            // Kiểm tra xem cả hai bảng có bản ghi bị ảnh hưởng không
                            if (rowsAffectedSatLo > 0 || rowsAffectedBaoCao > 0 || rowsAffectedLuQuet > 0)
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
    }
}
