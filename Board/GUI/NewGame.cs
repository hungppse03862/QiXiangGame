using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Board
{
    public partial class NewGame : Form
    {
        public NewGame()
        {
            InitializeComponent();
        }

        private void BatDau_MouseLeave(object sender, EventArgs e)
        {
            BatDau.Image = Board.Properties.Resources.BatDau;
        }

        private void BatDau_MouseEnter(object sender, EventArgs e)
        {
            BatDau.Image = Board.Properties.Resources.BatDau_MouseOver;
        }

        private void BatDau_Click(object sender, EventArgs e)
        {
            if (TenQuanDo.Text != "" && TenQuanDen.Text != "")
            {
                VanCo.PlayerName1 = TenQuanDo.Text;
                VanCo.PlayerName2 = TenQuanDen.Text;
                TenQuanDo.Text = "";
                TenQuanDen.Text = "";

                //Thiết lập lại bộ đếm thời gian
                //VanCo.NguoiChoi1_phut = 15;
                //VanCo.NguoiChoi1_giay = 0;
                //VanCo.NguoiChoi2_phut = 15;
                //VanCo.NguoiChoi2_giay = 0;
                
                //if (TinhThoiGian.Checked)
                //{
                //    VanCo.TinhThoiGian = true;
                //    if(ChonThoiGian.SelectedIndex==0)
                //    {
                //        VanCo.NguoiChoi1_phut = 5;
                //        VanCo.NguoiChoi2_phut = 5;
                //    }
                //    if (ChonThoiGian.SelectedIndex == 1)
                //    {
                //        VanCo.NguoiChoi1_phut = 10;
                //        VanCo.NguoiChoi2_phut = 10;
                //    }
                //    if (ChonThoiGian.SelectedIndex == 2)
                //    {
                //        VanCo.NguoiChoi1_phut = 15;
                //        VanCo.NguoiChoi2_phut = 15;
                //    }
                //}
                //else VanCo.TinhThoiGian = false;
                //VanCo.ThGian_NguoiChoi1.Text = "Thời gian còn: " + Convert.ToString(VanCo.NguoiChoi1_phut) + " : 00";
                //VanCo.ThGian_NguoiChoi2.Text = "Thời gian còn: " + Convert.ToString(VanCo.NguoiChoi2_phut) + " : 00";
                //ChessBoard.Timer_NguoiChoi1.Enabled = false;
                //ChessBoard.Timer_NguoiChoi2.Enabled = false;
                
                //tạo ván cờ mới
                VanCo.NewGame();                
                
                if (Chap.Checked) VanCo.Chap = true;
                else VanCo.Chap = false;
                if (VanCo.Chap) VanCo.ChapCo.Visible = true;
                //else if (VanCo.TinhThoiGian == true) ChessBoard.Timer_NguoiChoi1.Enabled = true;                
                this.Close();
            }
            else MessageBox.Show("Nhập tên 2 người chơi");
        }

        private void Close_NewGame_Form_MouseEnter(object sender, EventArgs e)
        {
            Close_NewGame_Form.Image = Board.Properties.Resources.cCancel_MouseOver;
        }

        private void Close_NewGame_Form_MouseLeave(object sender, EventArgs e)
        {
            Close_NewGame_Form.Image = Board.Properties.Resources.cCancel;
        }

        private void Close_NewGame_Form_Click(object sender, EventArgs e)
        {
            //Mở lại bộ đếm thời gian
            //if (VanCo.TinhThoiGian)
            //{
            //    if (VanCo.LuotDi == 0)
            //    {
            //        ChessBoard.Timer_NguoiChoi1.Enabled = true;
            //        ChessBoard.Timer_NguoiChoi2.Enabled = false;
            //    }
            //    if (VanCo.LuotDi == 1)
            //    {
            //        ChessBoard.Timer_NguoiChoi2.Enabled = true;
            //        ChessBoard.Timer_NguoiChoi1.Enabled = false;
            //    }
            //}

            //Mở lại bàn cờ
            if (VanCo.LuotDi == 0)
            {
                VanCo.LuotDi = 1;
                VanCo.DoiLuotDi();
            }
            else
            {
                VanCo.LuotDi = 0;
                VanCo.DoiLuotDi();
            }
            this.Close();
        }

        //private void TinhThoiGian_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (TinhThoiGian.Checked)
        //    {
        //        ChonThoiGian.Enabled = true;
        //    }
        //    else ChonThoiGian.Enabled = false;
        //}
    }
}