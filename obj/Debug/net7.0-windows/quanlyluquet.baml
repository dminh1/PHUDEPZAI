   M S B A M L   `   `   `  ����Z  VBTL_HeThongQuanLyDuLieuThienTai, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:BTL_HeThongQuanLyDuLieuThienTaiBTL_HeThongQuanLyDuLieuThienTai  5      2    ,BTL_HeThongQuanLyDuLieuThienTai.quanlyluquet   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      9local-clr-namespace:BTL_HeThongQuanLyDuLieuThienTai  5        N� Title$  quanlyluquet��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��47* �6   �� 5      $	��14* �6   .+�5   
   �� -   5         ��Name$ btn_add��5      $	��Add��6"   $��Center=�60   $��0,65,0,0q�6M   $	��Top=�6_   $	��140��6w   $��40��6�   $��1��6�   �� 5   
   -   5        $ 
btn_delete��5      $��Delete��6%   $��Center=�66   $��	0,159,0,0q�6S   $	��Top=�6f   $	��140��6~   $��40��6�   $��1��6�   �� 5   
   $
��Left=�6   $��	10,10,0,0q�6-    �� TextWrapping$
 Wrap=�6@   $��TextBox��6T   $	��Top=�6c   $	��360��6{   $��30��6�   � 5   
   $��0��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dgv_thongtinluquet��5      $��	0,60,0,10q�61   $��Center=�6D   $	��900��6a      AutoGenerateColumns$ False��6m      CanUserResizeColumns$ False��6�      CanUserResizeRows$ False��6�      
IsReadOnly$
 True��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$		 STT��6F   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 60 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
IDluquet+6S     5      $	 Địa Chỉ��6D   $	
 550 6U    6)   �� *DiaChi+6U     5      $	 Thời Gian��6F   $	
 100 6Y    6)   �� *
ThoiGian+6Y     5      $	 Mức Độ Thiên Tai��6K   $	
 150 6e    6)   �� *MucDoThienTai+6e   5      5      5      5       