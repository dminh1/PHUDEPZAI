using System;
using Microsoft.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BTL_HeThongQuanLyDuLieuThienTai
{
    /// <summary>
    /// Interaction logic for ThongTinChiTietDiemLuQuet.xaml
    /// </summary>
    public partial class ThongTinChiTietDiemLuQuet : Window
    {
        public ThongTinChiTietDiemLuQuet()
        {
            InitializeComponent();
        }
        string sqlConnectString = @"Data Source=LAPTOP-0N111REN;Initial Catalog=quanlythongtinthientai;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        SqlConnection connect_sql;


        private void Thongtindiemluquet_loaded(object sender, RoutedEventArgs e)
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

        /*  private void cbo_select_Tinh(object sender, SelectionChangedEventArgs e)
        {
            if (cbo_Tinh.SelectedIndex == 1)
            {
                cbo_quanhuyen.Items.Clear();
                cbo_quanhuyen.Items.Add("Huyện Quỳnh Lưu");
                cbo_quanhuyen.Items.Add("Thị Xã Hoàng Mai");
            }

            if (cbo_Tinh.SelectedIndex == 2)
            {
                cbo_quanhuyen.Items.Clear();
                cbo_quanhuyen.Items.Add("Quận Hoàng Mai");
                cbo_quanhuyen.Items.Add("Quận Thanh Xuân");
            }
        }

        
        private void select_quanhuyen(object sender, SelectionChangedEventArgs e)
        {
            if (cbo_Tinh.SelectedIndex == 1)
            {
                if(cbo_quanhuyen.SelectedIndex == 1)
                {
                    cbo_xaphuong.Items.Clear();
                    cbo_xaphuong.Items.Add("Xã Quỳnh Bảng");
                    cbo_xaphuong.Items.Add("Xã Quỳnh Đôi");
                }
                else
                {
                    if (cbo_Tinh.SelectedIndex == 2)
                    {
                        cbo_xaphuong.Items.Clear();
                        cbo_xaphuong.Items.Add("Xã Quỳnh Liên");
                        cbo_xaphuong.Items.Add("Phường Quỳnh Liên");
                    }
                }
                
                
            }else
            {
                if (cbo_quanhuyen.SelectedIndex == 2)
                {
                    if (cbo_Tinh.SelectedIndex == 1)
                    {
                        cbo_xaphuong.Items.Clear();
                        cbo_xaphuong.Items.Add("Phường Tân Mai");
                        cbo_xaphuong.Items.Add("Phường Giáp Bát");
                    }
                    else
                    {
                        if (cbo_Tinh.SelectedIndex == 2)
                        {
                            cbo_xaphuong.Items.Clear();
                            cbo_xaphuong.Items.Add("Phường Khương Đình");
                            cbo_xaphuong.Items.Add("Phường Hạ Đình");
                        }
                    }

                }
            }

        }*/

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            string add_data_quanlybaocao = string.Format(@"INSERT INTO quanlybaocaothientai(tenfile,linkbaibaothientai) VALUES (N'{0}',N'{1}')", cbo_Tinh.Text.ToString() + "-" + dtp_real.Text.ToString() + "- Lũ quét " + cbo_mucdothientai.Text.ToString(), tb_linkbaibao.Text.ToString());
            string selectLastIDBaoCao = @"SELECT SCOPE_IDENTITY() AS LastID";

            using (connect_sql = new SqlConnection(sqlConnectString))
            {
                connect_sql.Open();



                // Thực hiện câu lệnh INSERT
                using (SqlCommand insertDataQuanLyBaoCaoThienTai = new SqlCommand(add_data_quanlybaocao, connect_sql))
                {
                    int result = insertDataQuanLyBaoCaoThienTai.ExecuteNonQuery();
                    if (result == 1)
                    {
                        // Nếu chèn thành công, thực hiện câu lệnh SELECT để lấy ID mới
                        using (SqlCommand selectCommand = new SqlCommand(selectLastIDBaoCao, connect_sql))
                        {
                            object lastID = selectCommand.ExecuteScalar();

                            if (lastID != null)
                            {
                                int newID = Convert.ToInt32(lastID);
                                string add_data_quanlydiemluquet = string.Format("INSERT INTO quanlythongtinluquet(IDbaocao,DiaChi,ThoiGian,MucDoThienTai) VALUES (N'{0}',N'{1}',N'{2}',N'{3}')", newID,
                                                                                                                                                                                                cbo_xomkhoi.Text.ToString() + "," +
                                                                                                                                                                                                cbo_xaphuong.Text.ToString() + "," +
                                                                                                                                                                                                cbo_quanhuyen.Text.ToString() + "," +
                                                                                                                                                                                                cbo_Tinh.Text.ToString(),
                                                                                                                                                                                                dtp_real.Text.ToString(),
                                                                                                                                                                                                cbo_mucdothientai.Text.ToString());
                                using (SqlCommand insertDataQuanlyDiemSatLo = new SqlCommand(add_data_quanlydiemluquet, connect_sql))
                                {
                                    if (insertDataQuanlyDiemSatLo.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Add data successfully !");
                                    }
                                }


                            }
                            else
                            {
                                MessageBox.Show("Failed to retrieve the new ID.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert data.");
                    }
                }
            }
            this.Close();
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

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
