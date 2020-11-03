using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Player.UserControls
{
    public partial class Question : UserControl
    {
        public Question()
        {
            InitializeComponent();

            //btnConnect.Visible = false;
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //ConnectServer();
            Thread thread = new Thread(ConnectServer);
            thread.Start();

            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
        }
        TcpClient _client = null;
        Thread _thread = null;
        NetworkStream _ns = null;
        void ConnectServer()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 1900;
            _client = new TcpClient();
            _client.Connect(ip, port);

            Console.WriteLine("Player connected!");
            _ns = _client.GetStream();
            _thread = new Thread(o => ReceiveData((TcpClient)o));
            _thread.Start(_client);

            //string s;
            //while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            //{
            //    byte[] buffer = Encoding.ASCII.GetBytes(s);
            //    ns.Write(buffer, 0, buffer.Length);
            //}


        }

        void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                string data = Encoding.Unicode.GetString(receivedBytes, 0, byte_count);
                string[] M = data.Split(new string[] { "@@" }
                , StringSplitOptions.RemoveEmptyEntries);

                if (M.Length > 0)
                {
                    isReset = false;

                    btnMaskA.Visible = false;
                    btnMaskB.Visible = false;
                    btnMaskC.Visible = false;
                    btnMaskD.Visible = false;

                    btnA.Text = "";
                    btnB.Text = "";
                    btnC.Text = "";
                    btnD.Text = "";
                    btnCorrectAnswer.Text = "";
                    btnA.Enabled = false;
                    btnB.Enabled = false;
                    btnC.Enabled = false;
                    btnD.Enabled = false;
                    btnA.Inactive1 = Color.DeepSkyBlue;
                    btnA.Inactive2 = Color.RoyalBlue;
                    btnB.Inactive1 = Color.DeepSkyBlue;
                    btnB.Inactive2 = Color.RoyalBlue;
                    btnC.Inactive1 = Color.DeepSkyBlue;
                    btnC.Inactive2 = Color.RoyalBlue;
                    btnD.Inactive1 = Color.DeepSkyBlue;
                    btnD.Inactive2 = Color.RoyalBlue;

                    //Object rm = Properties.Resources.ResourceManager.GetObject("pic.Image");

                    lbSocau.Invoke((MethodInvoker)(()
                        => lbSocau.Text = M[0]));
                    lblQuestion.Invoke((MethodInvoker)(()
                        => lblQuestion.Text = M[1]));
                    pic.Invoke((MethodInvoker)(()
                        => pic.ImageLocation = M[2]));

                    Thread.Sleep(5000);
                    btnA.Invoke((MethodInvoker)(()
                        => btnA.Text = M[3]));
                    Thread.Sleep(1000);
                    btnB.Invoke((MethodInvoker)(()
                       => btnB.Text = M[4]));
                    Thread.Sleep(1000);
                    btnC.Invoke((MethodInvoker)(()
                       => btnC.Text = M[5]));
                    Thread.Sleep(1000);
                    btnD.Invoke((MethodInvoker)(()
                       => btnD.Text = M[6]));
                    btnCorrectAnswer.Invoke((MethodInvoker)(()
                       => btnCorrectAnswer.Text = M[7]));


                    btn5050.Visible = true;
                    btnGoiDT.Visible = true;
                    btnHoiKG.Visible = true;

                    if (num_correct == 5 && lbSocau.Text == "Câu 6:")
                    {
                        Thread.Sleep(10500);
                        Audio.batAmThanh_wav("New Tro giup Tu van tai cho");

                        Thread.Sleep(3500);
                        btnAdvice.Visible = true;
                    }

                    Thread.Sleep(1000);
                    btnA.Enabled = true;
                    btnB.Enabled = true;
                    btnC.Enabled = true;
                    btnD.Enabled = true;

                    if (check_used_50_50 == true) btn5050.Enabled = false;
                    else btn5050.Enabled = true;
                    if (check_used_GoiDT == true) btnGoiDT.Enabled = false;
                    else btnGoiDT.Enabled = true;
                    if (check_used_HoiKG == true) btnHoiKG.Enabled = false;
                    else btnHoiKG.Enabled = true;
                    if (check_used_Advice == true) btnAdvice.Enabled = false;
                    else btnAdvice.Enabled = true;

                    isReset = true;
                    lbCountDown.Visible = true;
                    check_choose = false;
                }
            }
        }

        private void Question_Load(object sender, EventArgs e)
        {
            pnLogin.Location = new Point(0, 0);
            pnLogin.Visible = true;

            btnMaskConnect.Visible = false;
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            btnCorrectAnswer.Visible = false;
            lbCountDown.Visible = false;
            btnAdvice.Visible = false;

            btn5050.Visible = false;
            btnGoiDT.Visible = false;
            btnHoiKG.Visible = false;

            btnMaskA.Visible = false;
            btnMaskB.Visible = false;
            btnMaskC.Visible = false;
            btnMaskD.Visible = false;

            pnHelp_Call.Visible = false;
            panelChart.Visible = false;
            panelAdvice.Visible = false;
            pnCongratulation.Visible = false;
            lbKhongdungchoidungluc.Visible = false;

            lbTextCorrect.Visible = false;
            lbNumCorrect.Visible = false;
            lbTienThuongTamThoi.Visible = false;
            lbTienTamThoi.Visible = false;

            //btnConnect.PerformClick();
        }
        bool check_dungchoi = false;
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _client.Client.Shutdown(SocketShutdown.Send);
            _thread.Join();
            _ns.Close();
            _client.Close();

            check_dungchoi = true;

            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
            timer1.Enabled = false;
            lbCountDown.Visible = false;

            btnMaskA.Visible = false;
            btnMaskB.Visible = false;
            btnMaskC.Visible = false;
            btnMaskD.Visible = false;

            TraLoiSai();
        }

        int seconds = 15;
        bool isReset = false;
        bool check_HetTG = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isReset == true)
            {
                if (seconds <= 0)
                {
                    if (check_choose == false)
                    {
                        Audio.batAmThanh("het_thoi_gian");

                        check_HetTG = true;
                        btnA.Enabled = false;
                        btnB.Enabled = false;
                        btnC.Enabled = false;
                        btnD.Enabled = false;

                        //MessageBox.Show("Hết thời gian!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        timer1.Enabled = false;
                        //btnDisconnect.PerformClick();
                        btnMaskConnect.Visible = true;
                        TraLoiSai();
                        lbHetTG.Visible = true;
                    }
                    timer1.Enabled = false;
                    isReset = false;
                }
                lbCountDown.Text = seconds.ToString();
                seconds--;
            }
            if (isReset == false)
            {
                seconds = 15;
                timer1.Enabled = true;
                //lbCountDown.Visible = true;
            }
        }
        private void TraLoiSai()
        {
            if (num_correct > 0 && num_correct < 5)
            {
                if (check_dungchoi == true)
                {
                    if (num_correct == 1) lbMoney.Text = "200.000 VNĐ";
                    if (num_correct == 2) lbMoney.Text = "400.000 VNĐ";
                    if (num_correct == 3) lbMoney.Text = "600.000 VNĐ";
                    if (num_correct == 4) lbMoney.Text = "1.000.000 VNĐ";
                }
                else
                {
                    lbKhongdungchoidungluc.Visible = true;
                    lbMoney.Text = "0 VNĐ";
                }
            }
            if (num_correct == 5) lbMoney.Text = "2.000.000 VNĐ";
            if (num_correct > 5 && num_correct < 10)
            {
                if (check_dungchoi == true)
                {
                    if (num_correct == 6) lbMoney.Text = "3.000.000 VNĐ";
                    if (num_correct == 7) lbMoney.Text = "6.000.000 VNĐ";
                    if (num_correct == 8) lbMoney.Text = "10.000.000 VNĐ";
                    if (num_correct == 9) lbMoney.Text = "14.000.000 VNĐ";
                }
                else
                {
                    lbKhongdungchoidungluc.Visible = true;
                    lbMoney.Text = "2.000.000 VNĐ";
                }
            }
            if (num_correct == 10) lbMoney.Text = "22.000.000 VNĐ";
            if (num_correct > 10 && num_correct < 15)
            {
                if (check_dungchoi == true)
                {
                    if (num_correct == 11) lbMoney.Text = "30.000.000 VNĐ";
                    if (num_correct == 12) lbMoney.Text = "40.000.000 VNĐ";
                    if (num_correct == 13) lbMoney.Text = "60.000.000 VNĐ";
                    if (num_correct == 14) lbMoney.Text = "85.000.000 VNĐ";
                }
                else
                {
                    lbKhongdungchoidungluc.Visible = true;
                    lbMoney.Text = "22.000.000 VNĐ";
                }
            }


            lbUsername_Quit.Text = lbUsername_login.Text;
            lbNum_Correct_C.Text = lbNumCorrect.Text;
            pnCongratulation.Location = new Point(0, 0);
            pnCongratulation.Visible = true;

            btnMaskConnect.Visible = true;
            //btnDisconnect.PerformClick();
        }
        private void TraloiDung_15Cau()
        {
            if (num_correct == 15)
            {
                lbMoney.Text = "150.000.000 VNĐ";

                lbUsername_Quit.Text = lbUsername_login.Text;
                lbNum_Correct_C.Text = lbNumCorrect.Text;
                pnCongratulation.Location = new Point(0, 0);
                pnCongratulation.Visible = true;

                btnMaskConnect.Visible = true;
                btnDisconnect.PerformClick();
            }
        }
        private void TienThuongTamThoi()
        {
            if (num_correct == 1) lbTienTamThoi.Text = "200.000 VNĐ";
            if (num_correct == 2) lbTienTamThoi.Text = "400.000 VNĐ";
            if (num_correct == 3) lbTienTamThoi.Text = "600.000 VNĐ";
            if (num_correct == 4) lbTienTamThoi.Text = "1.000.000 VNĐ";
            if (num_correct == 5) lbTienTamThoi.Text = "2.000.000 VNĐ";
            if (num_correct == 6) lbTienTamThoi.Text = "3.000.000 VNĐ";
            if (num_correct == 7) lbTienTamThoi.Text = "6.000.000 VNĐ";
            if (num_correct == 8) lbTienTamThoi.Text = "10.000.000 VNĐ";
            if (num_correct == 9) lbTienTamThoi.Text = "14.000.000 VNĐ";
            if (num_correct == 10) lbTienTamThoi.Text = "22.000.000 VNĐ";
            if (num_correct == 11) lbTienTamThoi.Text = "30.000.000 VNĐ";
            if (num_correct == 12) lbTienTamThoi.Text = "40.000.000 VNĐ";
            if (num_correct == 13) lbTienTamThoi.Text = "60.000.000 VNĐ";
            if (num_correct == 14) lbTienTamThoi.Text = "85.000.000 VNĐ";
        }
        bool check_choose = false;
        int num_correct = 0;
        private void btnA_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("A có phải là câu trả lời cuối cùng của bạn?", "Ai Là Triệu Phú", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                check_choose = true;
                lbCountDown.Visible = false;

                //đổi màu nút chọn A
                btnA.Active1 = Color.Blue;
                btnA.Active2 = Color.DarkBlue;

                btnMaskA.Visible = true;
                btnMaskA.Active1 = Color.Blue;
                btnMaskA.Active2 = Color.DarkBlue;
                btnMaskA.Text = btnA.Text;

                btnB.Enabled = false;
                btnC.Enabled = false;
                btnD.Enabled = false;

                btn5050.Enabled = false;
                btnGoiDT.Enabled = false;
                btnHoiKG.Enabled = false;
                btnAdvice.Enabled = false;

                //MC -  Bây giờ là lúc chúng tôi đưa ra câu trả lời đúng
                Audio.batAmThanh_wav("duaracautraloidung");
                Thread.Sleep(2000);

                if (btnA.Text == btnCorrectAnswer.Text)
                {
                    Audio.batAmThanh(btnCorrectAnswer.Text);

                    btnMaskA.Text = btnA.Text;
                    btnMaskA.Visible = true;
                    btnMaskA.Inactive1 = Color.DarkOrange;
                    btnMaskA.Inactive2 = Color.DarkSalmon;

                    num_correct++;
                    lbNumCorrect.Text = num_correct.ToString();
                    lbTextCorrect.Visible = true;
                    lbNumCorrect.Visible = true;
                    lbTienThuongTamThoi.Visible = true;
                    lbTienTamThoi.Visible = true;
                    TienThuongTamThoi();

                    //Vuot 5, 10 cau hoi
                    if (num_correct == 5) Audio.batAmThanh("vuot5");
                    if (num_correct == 10) Audio.batAmThanh("vuot10");

                    TraloiDung_15Cau();
                }
                else
                {
                    if (btnB.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh_wav("lose_b");

                        Thread.Sleep(2000);
                        btnMaskB.Text = btnB.Text;
                        btnMaskB.Visible = true;
                        btnMaskB.Inactive1 = Color.DarkOrange;
                        btnMaskB.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                    if (btnC.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh_wav("lose_c");

                        Thread.Sleep(2000);
                        btnMaskC.Text = btnC.Text;
                        btnMaskC.Visible = true;
                        btnMaskC.Inactive1 = Color.DarkOrange;
                        btnMaskC.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                    if (btnD.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh_wav("lose_d");

                        Thread.Sleep(2000);
                        btnMaskD.Text = btnD.Text;
                        btnMaskD.Visible = true;
                        btnMaskD.Inactive1 = Color.DarkOrange;
                        btnMaskD.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                }
            }
        }
        private void btnB_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("B có phải là câu trả lời cuối cùng của bạn?", "Ai Là Triệu Phú", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                check_choose = true;
                lbCountDown.Visible = false;

                //đổi màu nút chọn B
                btnB.Active1 = Color.Blue;
                btnB.Active2 = Color.DarkBlue;

                btnMaskB.Visible = true;
                btnMaskB.Active1 = Color.Blue;
                btnMaskB.Active2 = Color.DarkBlue;
                btnMaskB.Text = btnB.Text;

                btnA.Enabled = false;
                btnC.Enabled = false;
                btnD.Enabled = false;

                btn5050.Enabled = false;
                btnGoiDT.Enabled = false;
                btnHoiKG.Enabled = false;
                btnAdvice.Enabled = false;

                //MC -  Bây giờ là lúc chúng tôi đưa ra câu trả lời đúng
                Audio.batAmThanh("duaracautraloidung");
                Thread.Sleep(2000);

                if (btnB.Text == btnCorrectAnswer.Text)
                {
                    Audio.batAmThanh(btnCorrectAnswer.Text);

                    btnMaskB.Text = btnB.Text;
                    btnMaskB.Visible = true;
                    btnMaskB.Inactive1 = Color.DarkOrange;
                    btnMaskB.Inactive2 = Color.DarkSalmon;

                    num_correct++;
                    lbNumCorrect.Text = num_correct.ToString();
                    lbTextCorrect.Visible = true;
                    lbNumCorrect.Visible = true;
                    lbTienThuongTamThoi.Visible = true;
                    lbTienTamThoi.Visible = true;
                    TienThuongTamThoi();

                    //Vuot 5, 10 cau hoi
                    if (num_correct == 5) Audio.batAmThanh("vuot5");
                    if (num_correct == 10) Audio.batAmThanh("vuot10");

                    TraloiDung_15Cau();
                }
                else
                {
                    if (btnA.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh("lose_a");

                        Thread.Sleep(2000);
                        btnMaskA.Text = btnA.Text;
                        btnMaskA.Visible = true;
                        btnMaskA.Inactive1 = Color.DarkOrange;
                        btnMaskA.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                    if (btnC.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh("lose_c");

                        Thread.Sleep(2000);
                        btnMaskC.Text = btnC.Text;
                        btnMaskC.Visible = true;
                        btnMaskC.Inactive1 = Color.DarkOrange;
                        btnMaskC.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                    if (btnD.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh("lose_d");

                        Thread.Sleep(2000);
                        btnMaskD.Text = btnD.Text;
                        btnMaskD.Visible = true;
                        btnMaskD.Inactive1 = Color.DarkOrange;
                        btnMaskD.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                }
            }
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("C có phải là câu trả lời cuối cùng của bạn?", "Ai Là Triệu Phú", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                check_choose = true;
                lbCountDown.Visible = false;

                //đổi màu nút chọn C
                btnC.Active1 = Color.Blue;
                btnC.Active2 = Color.DarkBlue;

                btnMaskC.Visible = true;
                btnMaskC.Active1 = Color.Blue;
                btnMaskC.Active2 = Color.DarkBlue;
                btnMaskC.Text = btnC.Text;

                btnA.Enabled = false;
                btnB.Enabled = false;
                btnD.Enabled = false;

                btn5050.Enabled = false;
                btnGoiDT.Enabled = false;
                btnHoiKG.Enabled = false;
                btnAdvice.Enabled = false;

                //MC -  Bây giờ là lúc chúng tôi đưa ra câu trả lời đúng
                Audio.batAmThanh("duaracautraloidung");
                Thread.Sleep(2000);

                if (btnC.Text == btnCorrectAnswer.Text)
                {
                    Audio.batAmThanh(btnCorrectAnswer.Text);

                    btnMaskC.Text = btnC.Text;
                    btnMaskC.Visible = true;
                    btnMaskC.Inactive1 = Color.DarkOrange;
                    btnMaskC.Inactive2 = Color.DarkSalmon;

                    num_correct++;
                    lbNumCorrect.Text = num_correct.ToString();
                    lbTextCorrect.Visible = true;
                    lbNumCorrect.Visible = true;
                    lbTienThuongTamThoi.Visible = true;
                    lbTienTamThoi.Visible = true;
                    TienThuongTamThoi();

                    //Vuot 5, 10 cau hoi
                    if (num_correct == 5) Audio.batAmThanh("vuot5");
                    if (num_correct == 10) Audio.batAmThanh("vuot10");

                    TraloiDung_15Cau();
                }
                else
                {
                    if (btnA.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh("lose_a");

                        Thread.Sleep(2000);
                        btnMaskA.Text = btnA.Text;
                        btnMaskA.Visible = true;
                        btnMaskA.Inactive1 = Color.DarkOrange;
                        btnMaskA.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                    if (btnB.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh("lose_b");

                        Thread.Sleep(2000);
                        btnMaskB.Text = btnB.Text;
                        btnMaskB.Visible = true;
                        btnMaskB.Inactive1 = Color.DarkOrange;
                        btnMaskB.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                    if (btnD.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh("lose_d");

                        Thread.Sleep(2000);
                        btnMaskD.Text = btnD.Text;
                        btnMaskD.Visible = true;
                        btnMaskD.Inactive1 = Color.DarkOrange;
                        btnMaskD.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                }

            }
        }
        private void btnD_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("D có phải là câu trả lời cuối cùng của bạn?", "Ai Là Triệu Phú", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                check_choose = true;
                lbCountDown.Visible = false;

                //đổi màu nút chọn C
                btnD.Active1 = Color.Blue;
                btnD.Active2 = Color.DarkBlue;

                btnMaskD.Visible = true;
                btnMaskD.Active1 = Color.Blue;
                btnMaskD.Active2 = Color.DarkBlue;
                btnMaskD.Text = btnD.Text;

                btnA.Enabled = false;
                btnB.Enabled = false;
                btnC.Enabled = false;

                btn5050.Enabled = false;
                btnGoiDT.Enabled = false;
                btnHoiKG.Enabled = false;
                btnAdvice.Enabled = false;

                //MC -  Bây giờ là lúc chúng tôi đưa ra câu trả lời đúng
                Audio.batAmThanh("duaracautraloidung");
                Thread.Sleep(2000);

                if (btnD.Text == btnCorrectAnswer.Text)
                {
                    Audio.batAmThanh(btnCorrectAnswer.Text);

                    btnMaskD.Text = btnD.Text;
                    btnMaskD.Visible = true;
                    btnMaskD.Inactive1 = Color.DarkOrange;
                    btnMaskD.Inactive2 = Color.DarkSalmon;

                    num_correct++;
                    lbNumCorrect.Text = num_correct.ToString();
                    lbTextCorrect.Visible = true;
                    lbNumCorrect.Visible = true;
                    lbTienThuongTamThoi.Visible = true;
                    lbTienTamThoi.Visible = true;
                    TienThuongTamThoi();

                    //Vuot 5, 10 cau hoi
                    if (num_correct == 5) Audio.batAmThanh("vuot5");
                    if (num_correct == 10) Audio.batAmThanh("vuot10");

                    TraloiDung_15Cau();
                }
                else
                {
                    if (btnA.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh("lose_a");

                        Thread.Sleep(2000);
                        btnMaskA.Text = btnA.Text;
                        btnMaskA.Visible = true;
                        btnMaskA.Inactive1 = Color.DarkOrange;
                        btnMaskA.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                    if (btnB.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh("lose_b");

                        Thread.Sleep(2000);
                        btnMaskB.Text = btnB.Text;
                        btnMaskB.Visible = true;
                        btnMaskB.Inactive1 = Color.DarkOrange;
                        btnMaskB.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                    if (btnC.Text == btnCorrectAnswer.Text)
                    {
                        Audio.batAmThanh("lose_c");

                        Thread.Sleep(2000);
                        btnMaskC.Text = btnC.Text;
                        btnMaskC.Visible = true;
                        btnMaskC.Inactive1 = Color.DarkOrange;
                        btnMaskC.Inactive2 = Color.DarkSalmon;

                        Thread.Sleep(5000);
                        TraLoiSai();
                    }
                }
            }
        }
        bool check_used_50_50 = false;
        private void btn5050_Click(object sender, EventArgs e)
        {
            check_used_50_50 = true;

            Audio.batAmThanh_wav("Tro giup 50-50");
            Thread.Sleep(3000);

            Random rnd = new Random();
            int k = rnd.Next(0, 9);

            if (btnA.Text == btnCorrectAnswer.Text)
            {
                if (k % 2 == 0)
                {
                    btnB.Enabled = false;
                    btnC.Enabled = false;
                }
                else
                {
                    btnC.Enabled = false;
                    btnD.Enabled = false;
                }
                btn5050.Enabled = false;
            }
            if (btnB.Text == btnCorrectAnswer.Text)
            {
                if (k % 2 == 0)
                {
                    btnA.Enabled = false;
                    btnC.Enabled = false;
                }
                else
                {
                    btnC.Enabled = false;
                    btnD.Enabled = false;
                }
                btn5050.Enabled = false;
            }
            if (btnC.Text == btnCorrectAnswer.Text)
            {
                if (k % 2 == 0)
                {
                    btnA.Enabled = false;
                    btnB.Enabled = false;
                }
                else
                {
                    btnB.Enabled = false;
                    btnD.Enabled = false;
                }
                btn5050.Enabled = false;
            }
            if (btnD.Text == btnCorrectAnswer.Text)
            {
                if (k % 2 == 0)
                {
                    btnA.Enabled = false;
                    btnB.Enabled = false;
                }
                else
                {
                    btnB.Enabled = false;
                    btnC.Enabled = false;
                }
                btn5050.Enabled = false;
            }
            seconds = 15;
        }

        bool check_used_GoiDT = false;
        private void btnGoiDT_Click(object sender, EventArgs e)
        {
            check_used_GoiDT = true;
            btnGoiDT.Enabled = false;
            pnHelp_Call.Location = new Point(0,0);

            Audio.batAmThanh_wav("Tro giup Call");
            Thread.Sleep(2000);

            pnHelp_Call.Visible = true;
            timerHelp_Call.Enabled = true;

            lbChatPlayer_3_Cauhoi.Text = lblQuestion.Text;
            lbChatPlayer_4_ABCD.Text = "A - " + btnA.Text + "," + " B - " + btnB.Text + "," + " C - " + btnC.Text + "," + " D - " + btnD.Text;
            lbChatPeople_4_Dapan.Text = btnCorrectAnswer.Text + " đó cháu!";

            seconds = 40;
        }
        int counter_call = 30;
        private void timerHelp_Call_Tick(object sender, EventArgs e)
        {
            if (counter_call < 0)
            {
                timerHelp_Call.Enabled = false;
                DialogResult dialog_call = MessageBox.Show("Hết thời gian gọi...!", "Ai Là Triệu Phú", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (dialog_call == DialogResult.OK)
                {
                    pnHelp_Call.Visible = false;
                }
            }
            lbCoundown_helpcall.Text = counter_call.ToString();
            counter_call--;   
        }

        private void btnEndCall_Click(object sender, EventArgs e)
        {
            pnHelp_Call.Visible = false;
            timerHelp_Call.Enabled = false;
        }
        bool check_used_HoiKG = false;
        private void btnHoiKG_Click(object sender, EventArgs e)
        {
            check_used_HoiKG = true;
            btnHoiKG.Enabled = false;
            panelChart.Location = new Point(0, 0);

            Audio.batAmThanh_wav("Tro giup Hoi YKKG");
            Thread.Sleep(2000);

            panelChart.Visible = true;

            if (btnA.Text == btnCorrectAnswer.Text)
            {
                this.chart1.Series["Câu trả lời"].Points.AddXY("A",67);
                this.chart1.Series["Câu trả lời"].Points.AddXY("B", 13);
                this.chart1.Series["Câu trả lời"].Points.AddXY("C", 11);
                this.chart1.Series["Câu trả lời"].Points.AddXY("D", 9);
            }
            if (btnB.Text == btnCorrectAnswer.Text)
            {
                this.chart1.Series["Câu trả lời"].Points.AddXY("A", 10);
                this.chart1.Series["Câu trả lời"].Points.AddXY("B", 67);
                this.chart1.Series["Câu trả lời"].Points.AddXY("C", 12);
                this.chart1.Series["Câu trả lời"].Points.AddXY("D", 11);
            }
            if (btnC.Text == btnCorrectAnswer.Text)
            {
                this.chart1.Series["Câu trả lời"].Points.AddXY("A", 7);
                this.chart1.Series["Câu trả lời"].Points.AddXY("B", 5);
                this.chart1.Series["Câu trả lời"].Points.AddXY("C", 78);
                this.chart1.Series["Câu trả lời"].Points.AddXY("D", 10);
            }
            if (btnD.Text == btnCorrectAnswer.Text)
            {
                this.chart1.Series["Câu trả lời"].Points.AddXY("A", 10);
                this.chart1.Series["Câu trả lời"].Points.AddXY("B", 13);
                this.chart1.Series["Câu trả lời"].Points.AddXY("C", 12);
                this.chart1.Series["Câu trả lời"].Points.AddXY("D", 65);
            }
            seconds = 40;
        }
        private void btnCloseChart_Click(object sender, EventArgs e)
        {
            panelChart.Visible = false;
        }
        bool check_used_Advice = false;
        private void btnAdvice_Click(object sender, EventArgs e)
        {
            check_used_Advice = true;
            btnAdvice.Enabled = false;
            panelAdvice.Location = new Point(0, 0);

            Audio.batAmThanh_wav("Tro giup Tu van tai cho");
            Thread.Sleep(7000);

            panelAdvice.Visible = true;

            lbTVTT_Cauhoi.Text = lblQuestion.Text;
            lbTVTT_CauTraLoi.Text = "A - " + btnA.Text + "," + " B - " + btnB.Text + "," + " C - " + btnC.Text + "," + " D - " + btnD.Text;

            seconds = 40;
        }
        private void btn_Advice_Dong_Click(object sender, EventArgs e)
        {
            panelAdvice.Visible = false;
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbUsername.Text))
                MessageBox.Show("Nhập vào Username!", "Ai Là Triệu Phú", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                lbUsername_login.Text = txbUsername.Text;
                pnLogin.Visible = false;
            }
            btnConnect.PerformClick();
        }
    }
}