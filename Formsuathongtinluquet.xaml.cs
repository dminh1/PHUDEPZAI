using System;
using Microsoft.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace BTL_HeThongQuanLyDuLieuThienTai
{
    /// <summary>
    /// Interaction logic for Formsuathongtinluquet.xaml
    /// </summary>
    public partial class Formsuathongtinluquet : Window
    {

        private string sqlConnectString = @"Data Source=LAPTOP-0N111REN;Initial Catalog=quanlythongtinthientai;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private static SqlConnection connect_sql;
        private string selectedID;
        public Formsuathongtinluquet(string ID)
        {
            InitializeComponent();
            selectedID = ID;
        }


        private void Formsuathongtinluquet_loaded(object sender, RoutedEventArgs e)
        {
            cbo_Tinh.Items.Add("Nghệ An");
            cbo_Tinh.Items.Add("Hà Nội");

            cbo_xomkhoi.Items.Add("Khối 1");
            cbo_xomkhoi.Items.Add("Khối 2");
            cbo_xomkhoi.Items.Add("Khối 3");
            cbo_xomkhoi.Items.Add("Khối 4");
            cbo_xomkhoi.Items.Add("Khối 5");

            cbo_mucdothientai.Items.Add("Mức độ 1");
            cbo_mucdothientai.Items.Add("Mức độ 2");
            cbo_mucdothientai.Items.Add("Mức độ 3");
            cbo_mucdothientai.Items.Add("Mức độ 4");
            cbo_mucdothientai.Items.Add("Mức độ 5");
        }

        private void cbo_select_Tinh(object sender, SelectionChangedEventArgs e)
        {
            cbo_quanhuyen.Items.Clear(); // Clear quận huyện khi thay đổi tỉnh

            if (cbo_Tinh.SelectedIndex == 1) // Chọn Nghệ An
            {
                cbo_quanhuyen.Items.Add("Huyện Quỳnh Lưu");
                cbo_quanhuyen.Items.Add("Thị Xã Hoàng Mai");
            }
            else if (cbo_Tinh.SelectedIndex == 2) // Chọn Hà Nội
            {
                cbo_quanhuyen.Items.Add("Quận Hoàng Mai");
                cbo_quanhuyen.Items.Add("Quận Thanh Xuân");
            }
        }

        private void select_quanhuyen(object sender, SelectionChangedEventArgs e)
        {
            cbo_xaphuong.Items.Clear(); // Clear xã phường khi thay đổi quận huyện

            if (cbo_Tinh.SelectedIndex == 1) // Chọn Nghệ An
            {
                if (cbo_quanhuyen.SelectedIndex == 0) // Chọn Huyện Quỳnh Lưu
                {
                    cbo_xaphuong.Items.Add("Xã Quỳnh Bảng");
                    cbo_xaphuong.Items.Add("Xã Quỳnh Đôi");
                }
                else if (cbo_quanhuyen.SelectedIndex == 1) // Chọn Thị Xã Hoàng Mai
                {
                    // Thêm các xã phường cho Thị Xã Hoàng Mai
                    cbo_xaphuong.Items.Add("Phường Quỳnh Phương");
                    cbo_xaphuong.Items.Add("Phường Quỳnh Liên");
                }
            }
            else if (cbo_Tinh.SelectedIndex == 2) // Chọn Hà Nội
            {
                if (cbo_quanhuyen.SelectedIndex == 0) // Chọn Quận Hoàng Mai
                {
                    // Thêm các xã phường cho Quận Hoàng Mai
                    cbo_xaphuong.Items.Add("Phường Tân Mai");
                    cbo_xaphuong.Items.Add("Phường Giáp Bát");
                }
                else if (cbo_quanhuyen.SelectedIndex == 1) // Chọn Quận Thanh Xuân
                {
                    // Thêm các xã phường cho Quận Thanh Xuân
                    cbo_xaphuong.Items.Add("Phường Thượng Đình");
                    cbo_xaphuong.Items.Add("Phường Khương Đình");
                }
            }
        }




        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string update_query_luquet = "UPDATE quanlythongtinluquet SET DiaChi = @DiaChi, ThoiGian = @ThoiGian, MucDoThienTai = @MucDoThienTai WHERE IDbaocao = @IDbaocao";
                string update_query_baocao = "UPDATE quanlybaocaothientai SET linkbaibaothientai = @linkbaibao, tenfile = @tenbaocao WHERE IDbaocao = @IDbaocao";

                using (connect_sql = new SqlConnection(sqlConnectString))
                {
                    connect_sql.Open();

                    SqlCommand sqlcomand_dataluquet = new SqlCommand(update_query_luquet, connect_sql);
                    sqlcomand_dataluquet.Parameters.AddWithValue("@DiaChi", $"{cbo_xomkhoi.Text},{cbo_xaphuong.Text},{cbo_quanhuyen.Text},{cbo_Tinh.Text}");
                    sqlcomand_dataluquet.Parameters.AddWithValue("@ThoiGian", dtp_real.Text);
                    sqlcomand_dataluquet.Parameters.AddWithValue("@MucDoThienTai", cbo_mucdothientai.Text);
                    sqlcomand_dataluquet.Parameters.AddWithValue("@IDbaocao", selectedID);

                    string ten_bao_cao = string.Format(cbo_Tinh.Text.ToString() + "-" + dtp_real.Text.ToString() + "- Lũ quét " + cbo_mucdothientai.Text.ToString(), tb_linkbaibao.Text.ToString());

                    SqlCommand sqlcomand_databaocao = new SqlCommand(update_query_baocao, connect_sql);
                    sqlcomand_databaocao.Parameters.AddWithValue("@linkbaibao", tb_linkbaibao.Text);
                    sqlcomand_databaocao.Parameters.AddWithValue("@tenbaocao", ten_bao_cao);
                    sqlcomand_databaocao.Parameters.AddWithValue("@IDbaocao", selectedID);

                    if (sqlcomand_dataluquet.ExecuteNonQuery() == 1 && sqlcomand_databaocao.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Update successfully!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Update failed!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
