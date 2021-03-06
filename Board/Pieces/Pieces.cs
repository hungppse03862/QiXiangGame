using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace Board
{
    class Pieces
    {
        public int Hang;
        public int Cot;
        public string Ten;//Ten quan co {Tuong,Sy,Tinh,Xe,Phao,Ma,Chot}
        public int Phe;//Phe=0 || Phe=1 || Phe=2 (Tại ô đó ko có quân cờ)
        public string ThuTu="";//VD: quan Ma phia ben Trai, quan Ma phia ben Phai.
        public int TrangThai;// Trangthai=1: QuanCo van con song | TrangThai=0: QuanCo da bi an
        public PictureBox picQuanCo = new PictureBox();
        public bool Khoa = false;

        public Pieces()
        {
            Hang = 10;
            Cot = 10;
            Ten = "";
            Phe = 2;
            ThuTu = "";
            TrangThai = 0;
            Khoa = true;
        }
        
        //Khởi tạo quân cờ
        public void KhoiTao(int phe, string name, string thutu, int stt, bool khoa, int x, int y) //Khoi tao quan co voi Phe=phe, Ten=name, TrangThai=stt, Khoa=khoa, Vi Tri=[x,y])
        {
            Hang = x;
            Cot = y;
            Ten = name;
            TrangThai = stt;
            Phe = phe;
            ThuTu = thutu;
            Khoa = khoa;
            ChessBoards.ViTri[x, y].Hang = x;
            ChessBoards.ViTri[x, y].Cot = y;
            ChessBoards.ViTri[x, y].Ten = name;
            ChessBoards.ViTri[x, y].ThuTu = thutu;
            ChessBoards.ViTri[x, y].Phe = phe;
            ChessBoards.ViTri[x, y].Trong = false;
            picQuanCo.MouseClick += new MouseEventHandler(picQuanCo_MouseClick);
            
        }
        
        //Hàm vẽ quân cờ
        public void draw()
        {
            if (Phe == 0)
            {
                if (Ten == "tuong") picQuanCo.Image = Board.Properties.Resources._1tuong;
                if (Ten == "sy") picQuanCo.Image = Board.Properties.Resources._1sy;
                if (Ten == "tinh") picQuanCo.Image = Board.Properties.Resources._1tinh;
                if (Ten == "xe") picQuanCo.Image = Board.Properties.Resources._1xe;
                if (Ten == "phao") picQuanCo.Image = Board.Properties.Resources._1phao;
                if (Ten == "ma") picQuanCo.Image = Board.Properties.Resources._1ma;
                if (Ten == "chot") picQuanCo.Image = Board.Properties.Resources._1chot;
            }
            if (Phe == 1)
            {
                if (Ten == "tuong") picQuanCo.Image = Board.Properties.Resources._2tuong;
                if (Ten == "sy") picQuanCo.Image = Board.Properties.Resources._2sy;
                if (Ten == "tinh") picQuanCo.Image = Board.Properties.Resources._2tinh;
                if (Ten == "xe") picQuanCo.Image = Board.Properties.Resources._2xe;
                if (Ten == "phao") picQuanCo.Image = Board.Properties.Resources._2phao;
                if (Ten == "ma") picQuanCo.Image = Board.Properties.Resources._2ma;
                if (Ten == "chot") picQuanCo.Image = Board.Properties.Resources._2chot;
            }

            //Vẽ quân cờ
            picQuanCo.Width = 42;
            picQuanCo.Height = 42;
            picQuanCo.Cursor = Cursors.Hand;
            picQuanCo.Top = Hang * 53 + 80;
            picQuanCo.Left = Cot * 53 + 61;
            picQuanCo.BackColor = Color.Transparent;
            

            //Thiết lập quân cờ trên Bàn Cờ
            ChessBoards.ViTri[Hang, Cot].Hang = Hang;
            ChessBoards.ViTri[Hang, Cot].Cot = Cot;
            ChessBoards.ViTri[Hang, Cot].Trong = false;
            ChessBoards.ViTri[Hang, Cot].Ten = Ten;
            ChessBoards.ViTri[Hang, Cot].ThuTu = ThuTu;
            ChessBoards.ViTri[Hang, Cot].Phe = Phe;            
        }


        public virtual int KiemTra(int i,int j)
        {
            return 0;
        }

        public virtual int TuongAnToan(int i, int j)
        {
            return 0;
        }     
       
        //------------Thao tác trên quân cờ-------------------------//
        private void picQuanCo_MouseClick(Object sender, MouseEventArgs e)
        {
            if (VanCo.Chap)
            {
                if (this.Ten != "tuong") VanCo.AnQuanCo(this);
                ChessBoards.ViTri[this.Hang, this.Cot].Trong = true;
                ChessBoards.ViTri[this.Hang, this.Cot].Phe = 2;
                ChessBoards.ViTri[this.Hang, this.Cot].ThuTu = "";
                ChessBoards.ViTri[this.Hang, this.Cot].Ten = "";

            }
            else
            {
                switch (VanCo.Marked)
                {
                    case true:
                        if (this.TrangThai == 1)
                        {
                            if (this.Phe == VanCo.DanhDau.Phe)
                            {
                                VanCo.Marked = false;
                                if (VanCo.DanhDau.Phe == 0)
                                {
                                    if (VanCo.DanhDau.Ten == "tuong") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1tuong;
                                    if (VanCo.DanhDau.Ten == "sy") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1sy;
                                    if (VanCo.DanhDau.Ten == "tinh") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1tinh;
                                    if (VanCo.DanhDau.Ten == "xe") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1xe;
                                    if (VanCo.DanhDau.Ten == "phao") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1phao;
                                    if (VanCo.DanhDau.Ten == "ma") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1ma;
                                    if (VanCo.DanhDau.Ten == "chot") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1chot;
                                }
                                if (VanCo.DanhDau.Phe == 1)
                                {
                                    if (VanCo.DanhDau.Ten == "tuong") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2tuong;
                                    if (VanCo.DanhDau.Ten == "sy") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2sy;
                                    if (VanCo.DanhDau.Ten == "tinh") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2tinh;
                                    if (VanCo.DanhDau.Ten == "xe") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2xe;
                                    if (VanCo.DanhDau.Ten == "phao") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2phao;
                                    if (VanCo.DanhDau.Ten == "ma") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2ma;
                                    if (VanCo.DanhDau.Ten == "chot") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2chot;
                                }
                                ChessBoards.ResetCanMove();
                            }
                            if (this.Phe != VanCo.DanhDau.Phe)
                            {
                                if (VanCo.DanhDau.KiemTra(this.Hang, this.Cot) == 1 && VanCo.DanhDau.TuongAnToan(this.Hang, this.Cot) == 1)//Nếu nước đi hợp lệ
                                {
                                    //Ghi thông tin nước đi vào GameLog
                                    VanCo.LuuVaoGameLog(sender, this);

                                    //Ăn quân cờ của đối phương
                                    VanCo.AnQuanCo(this);

                                    //Trả lại ô cờ trống
                                    VanCo.OCoTrong(VanCo.DanhDau.Hang, VanCo.DanhDau.Cot);

                                    //Thiết lập quân cờ đã chọn vào bàn cờ
                                    VanCo.DatQuanCo(sender, VanCo.DanhDau, this.Hang, this.Cot);


                                    //Tiếng động
                                    if (VanCo.AmThanh) VanCo.ClickSound(VanCo.DanhDau.Ten);

                                    //Kiểm tra chiếu tướng
                                    VanCo.KiemTraChieuTuong();

                                    //Thay đổi lượt đi                            
                                    VanCo.DoiLuotDi();

                                    //Kiểm tra quân Tướng của đối phương đã bị ăn chưa
                                    VanCo.KiemTraChieuBi();
                                    if (VanCo.winner != 2)
                                    {
                                        VanCo.ThongBaoChieuTuong.Visible = false;
                                        VanCo.ChieuBi.Visible = true;
                                    }
                                    else VanCo.ChieuBi.Visible = false;


                                    ChessBoards.ResetCanMove();
                                }
                                VanCo.Marked = false;

                                if (VanCo.DanhDau.Phe == 0)
                                {
                                    if (VanCo.DanhDau.Ten == "tuong") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1tuong;
                                    if (VanCo.DanhDau.Ten == "sy") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1sy;
                                    if (VanCo.DanhDau.Ten == "tinh") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1tinh;
                                    if (VanCo.DanhDau.Ten == "xe") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1xe;
                                    if (VanCo.DanhDau.Ten == "phao") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1phao;
                                    if (VanCo.DanhDau.Ten == "ma") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1ma;
                                    if (VanCo.DanhDau.Ten == "chot") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._1chot;
                                }
                                if (VanCo.DanhDau.Phe == 1)
                                {
                                    if (VanCo.DanhDau.Ten == "tuong") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2tuong;
                                    if (VanCo.DanhDau.Ten == "sy") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2sy;
                                    if (VanCo.DanhDau.Ten == "tinh") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2tinh;
                                    if (VanCo.DanhDau.Ten == "xe") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2xe;
                                    if (VanCo.DanhDau.Ten == "phao") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2phao;
                                    if (VanCo.DanhDau.Ten == "ma") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2ma;
                                    if (VanCo.DanhDau.Ten == "chot") VanCo.DanhDau.picQuanCo.Image = Board.Properties.Resources._2chot;
                                }
                                ChessBoards.ResetCanMove();
                            }
                        }
                        break;
                    case false:
                        if (this.TrangThai == 1)
                        {
                            if (this.Khoa == false)
                            {
                                //Đánh dấu quân cờ được chọn
                                VanCo.Marked = true;
                                VanCo.DanhDau = new Pieces();
                                VanCo.DanhDau = this;

                                if (Phe == 0)
                                {
                                    if (Ten == "tuong") picQuanCo.Image = Board.Properties.Resources._1tuong_marked;
                                    if (Ten == "sy") picQuanCo.Image = Board.Properties.Resources._1sy_marked;
                                    if (Ten == "tinh") picQuanCo.Image = Board.Properties.Resources._1tinh_marked;
                                    if (Ten == "xe") picQuanCo.Image = Board.Properties.Resources._1xe_marked;
                                    if (Ten == "phao") picQuanCo.Image = Board.Properties.Resources._1phao_marked;
                                    if (Ten == "ma") picQuanCo.Image = Board.Properties.Resources._1ma_marked;
                                    if (Ten == "chot") picQuanCo.Image = Board.Properties.Resources._1chot_marked;
                                }
                                if (Phe == 1)
                                {
                                    if (Ten == "tuong") picQuanCo.Image = Board.Properties.Resources._2tuong_marked;
                                    if (Ten == "sy") picQuanCo.Image = Board.Properties.Resources._2sy_marked;
                                    if (Ten == "tinh") picQuanCo.Image = Board.Properties.Resources._2tinh_marked;
                                    if (Ten == "xe") picQuanCo.Image = Board.Properties.Resources._2xe_marked;
                                    if (Ten == "phao") picQuanCo.Image = Board.Properties.Resources._2phao_marked;
                                    if (Ten == "ma") picQuanCo.Image = Board.Properties.Resources._2ma_marked;
                                    if (Ten == "chot") picQuanCo.Image = Board.Properties.Resources._2chot_marked;
                                }
                                for (int i = 0; i <= 9; i++)
                                {
                                    for (int j = 0; j <= 8; j++)
                                    {
                                        if (i != Hang || j != Cot)
                                            if (this.KiemTra(i, j) == 1 && this.TuongAnToan(i, j) == 1) ChessBoards.ViTri[i, j].CanMove.Visible = true;
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}
