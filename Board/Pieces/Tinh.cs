using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    class Tinh:Pieces
    {
        public override int KiemTra(int i, int j)
        {
            bool turn = false;
            if (Phe == 0)
            {
                if (i >= 0 && i <= 4 && j >= 0 && j <= 8)
                    if ((i == Hang - 2 && j == Cot - 2 && ChessBoards.ViTri[Hang - 1, Cot - 1].Trong == true) || (i == Hang - 2 && j == Cot + 2 && ChessBoards.ViTri[Hang - 1, Cot + 1].Trong == true) || (i == Hang + 2 && j == Cot - 2 && ChessBoards.ViTri[Hang + 1, Cot - 1].Trong == true) || (i == Hang + 2 && j == Cot + 2 && ChessBoards.ViTri[Hang + 1, Cot + 1].Trong == true))
                    {
                        if (ChessBoards.ViTri[i, j].Trong == true) turn = true;
                        if (ChessBoards.ViTri[i, j].Trong == false)
                            if (ChessBoards.ViTri[i, j].Phe != this.Phe) turn = true;
                    }
            }
            if (Phe == 1)
            {
                if (i >= 5 && i <= 9 && j >= 0 && j <= 8)
                    if ((i == Hang - 2 && j == Cot - 2 && ChessBoards.ViTri[Hang - 1, Cot - 1].Trong == true) || (i == Hang - 2 && j == Cot + 2 && ChessBoards.ViTri[Hang - 1, Cot + 1].Trong == true) || (i == Hang + 2 && j == Cot - 2 && ChessBoards.ViTri[Hang + 1, Cot - 1].Trong == true) || (i == Hang + 2 && j == Cot + 2 && ChessBoards.ViTri[Hang + 1, Cot + 1].Trong == true))
                    {
                        if (ChessBoards.ViTri[i, j].Trong == true) turn = true;
                        if (ChessBoards.ViTri[i, j].Trong == false)
                            if (ChessBoards.ViTri[i, j].Phe != this.Phe) turn = true;
                    }
            }            
            
            if (VanCo.Player[0].qTuong.Cot == VanCo.Player[1].qTuong.Cot && Cot == VanCo.Player[1].qTuong.Cot)
            {
                int ct = 0;
                if (j != Cot)
                {
                    VanCo.OCoTrong(Hang, Cot);
                    for (int t = VanCo.Player[0].qTuong.Hang + 1; t < VanCo.Player[1].qTuong.Hang; t++)
                    {
                        if (ChessBoards.ViTri[t, Cot].Trong == false) ct++;
                    }
                    if (ct == 0) turn = false;
                    ChessBoards.ViTri[Hang, Cot].Trong = false;
                    ChessBoards.ViTri[Hang, Cot].Ten = this.Ten;
                    ChessBoards.ViTri[Hang, Cot].Phe = this.Phe;
                    ChessBoards.ViTri[Hang, Cot].ThuTu = this.ThuTu;
                }
            }
            //Trả về kết quả
            if (turn) return 1;
            else return 0;
        }

        public override int TuongAnToan(int i, int j)
        {
            bool turn = true;

            //Kiểm tra tướng an toàn
            if (turn == true)
            {
                int ho, co;
                Pieces temp;
                temp = new Pieces();

                ho = this.Hang;
                co = this.Cot;

                if (ChessBoards.ViTri[i, j].Trong == false)
                {
                    if (ChessBoards.ViTri[i, j].Ten == "tuong") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qTuong;
                    if (ChessBoards.ViTri[i, j].Ten == "sy")
                    {
                        if (ChessBoards.ViTri[i, j].ThuTu == "0") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qSy[0];
                        if (ChessBoards.ViTri[i, j].ThuTu == "1") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qSy[1];
                    }
                    if (ChessBoards.ViTri[i, j].Ten == "tinh")
                    {
                        if (ChessBoards.ViTri[i, j].ThuTu == "0") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qTinh[0];
                        if (ChessBoards.ViTri[i, j].ThuTu == "1") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qTinh[1];
                    }
                    if (ChessBoards.ViTri[i, j].Ten == "xe")
                    {
                        if (ChessBoards.ViTri[i, j].ThuTu == "0") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qXe[0];
                        if (ChessBoards.ViTri[i, j].ThuTu == "1") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qXe[1];
                    }
                    if (ChessBoards.ViTri[i, j].Ten == "phao")
                    {
                        if (ChessBoards.ViTri[i, j].ThuTu == "0") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qPhao[0];
                        if (ChessBoards.ViTri[i, j].ThuTu == "1") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qPhao[1];
                    }
                    if (ChessBoards.ViTri[i, j].Ten == "ma")
                    {
                        if (ChessBoards.ViTri[i, j].ThuTu == "0") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qMa[0];
                        if (ChessBoards.ViTri[i, j].ThuTu == "1") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qMa[1];
                    }
                    if (ChessBoards.ViTri[i, j].Ten == "chot")
                    {
                        if (ChessBoards.ViTri[i, j].ThuTu == "0") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qChot[0];
                        if (ChessBoards.ViTri[i, j].ThuTu == "1") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qChot[1];
                        if (ChessBoards.ViTri[i, j].ThuTu == "2") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qChot[2];
                        if (ChessBoards.ViTri[i, j].ThuTu == "3") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qChot[3];
                        if (ChessBoards.ViTri[i, j].ThuTu == "4") temp = VanCo.Player[ChessBoards.ViTri[i, j].Phe].qChot[4];
                    }
                }
                //Giả sử quân cờ được đi để kiểm tra Tướng mình có bị chiếu ko
                VanCo.OCoTrong(Hang, Cot);
                ChessBoards.ViTri[i, j].Trong = false;
                ChessBoards.ViTri[i, j].Phe = Phe;
                ChessBoards.ViTri[i, j].Ten = Ten;
                ChessBoards.ViTri[i, j].ThuTu = ThuTu;
                this.Hang = i;
                this.Cot = j;
                if (temp.Phe != 2)
                {
                    temp.TrangThai = 0;
                    temp.picQuanCo.Visible = false;
                }

                //Kiểm tra
                if (VanCo.ChieuTuong(VanCo.Player[Phe].qTuong) == true) turn = false;

                //Trả lại những gì đã giả sử ở trên ^^!
                this.Hang = ho;
                this.Cot = co;
                VanCo.OCoTrong(i, j);
                ChessBoards.ViTri[ho, co].Trong = false;
                ChessBoards.ViTri[ho, co].Phe = Phe;
                ChessBoards.ViTri[ho, co].Ten = Ten;
                ChessBoards.ViTri[ho, co].ThuTu = ThuTu;
                if (temp.Phe != 2)
                {
                    temp.TrangThai = 1;
                    temp.picQuanCo.Visible = true;
                    ChessBoards.ViTri[i, j].Trong = false;
                    ChessBoards.ViTri[i, j].Ten = temp.Ten;
                    ChessBoards.ViTri[i, j].Phe = temp.Phe;
                    ChessBoards.ViTri[i, j].ThuTu = temp.ThuTu;
                }
            } 
            //Trả về kết quả
            if(turn) return 1;
            else return 0;
        }
    }
}

