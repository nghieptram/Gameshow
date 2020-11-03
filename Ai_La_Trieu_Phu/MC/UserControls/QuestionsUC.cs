using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace MC.UserControls
{
    public partial class QuestionsUC : UserControl
    {
        public QuestionsUC()
        {
            InitializeComponent();

            //btnConnect.Visible = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(ConnectServer);
            thread.Start();

            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            btnLoadQuestions.Enabled = true;
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

            Console.WriteLine("MC connected!");
            _ns = _client.GetStream();
            _thread = new Thread(o => ReceiveData((TcpClient)o));
            _thread.Start(_client);

            //string s;
            //while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            //{
                //byte[] buffer = Encoding.ASCII.GetBytes(s);
                //ns.Write(buffer, 0, buffer.Length);
            //}

            //client.Client.Shutdown(SocketShutdown.Send);
            //thread.Join();
            //ns.Close();
            //client.Close();
        }
        static void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                Console.Write(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
            }
        }

        private void btnSendQA_Click(object sender, EventArgs e)
        {
            string num_question = lbSocau.Text;
            string question = rtbQuestion.Text;
            string imagelink = txtImageLink.Text;

            string _num_question = num_question.Remove(num_question.Length - 1);
            Audio.batAmThanh(_num_question);

            string a = txtA.Text;
            string b = txtB.Text;
            string c = txtC.Text;
            string d = txtD.Text;
            string correct_answer = txtCorrectAnswer.Text;

            string data = string.Format("{0}@@{1}@@{2}@@{3}@@{4}@@{5}@@{6}@@{7}@@"
                , num_question, question, imagelink, a, b, c, d, correct_answer);
            byte[] buffer = Encoding.Unicode.GetBytes(data);
            _ns.Write(buffer, 0, buffer.Length);

            btnSendQA.Enabled = false;
        }

        List<Question> _lstQuestions;
        private void btnLoadQuestions_Click(object sender, EventArgs e)
        {
            Audio.batAmThanh("load_cau_hoi");

            btnLoadQuestions.Enabled = false;
            btnNext.Enabled = true;

            // Read a text file line by line.  
            string path = "../../Questions.txt";
            string[] lines = File.ReadAllLines(path);

            _lstQuestions = new List<Question>();
            Question question = null;
            foreach (string line in lines)
            {
                if (line.StartsWith("``"))//Number Question
                {
                    question = new Question();
                    question.NumberQ = line.Substring(2);
                }
                if (line.StartsWith("@@"))//Question
                {
                    question.Content = line.Substring(2);
                }
                if (line.StartsWith("--"))//Image
                {
                    question.ImageLink = line.Substring(2);
                }
                if (line.StartsWith("$$"))//Answer
                {
                    Answer answer = new Answer();
                    string[] M = line.Substring(2).Split(new char[] { '.' });
                    answer.Id = M[0];
                    answer.Content = M[1];

                    question.ListAnswers.Add(answer);
                }
                if (line.StartsWith("**"))//Correct Answer
                {
                    question.CorrectAnswer = line.Substring(2);
                }
                if (line.StartsWith("%%"))
                    _lstQuestions.Add(question);
            }
            if(MessageBox.Show("Chúng ta bắt đầu đi tìm Ai Là Triệu Phú!", "Tất cả người chơi đã sẵn sàng", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                btnNext.PerformClick();
            btnSendQA.Enabled = true;
        }

        int index = 0;
        private void btnNext_Click(object sender, EventArgs e)
        {
            Question question = _lstQuestions[index];

            lbSocau.Text = question.NumberQ + ":";
            rtbQuestion.Text = question.Content;
            txtImageLink.Text = question.ImageLink;
            txtA.Text = question.ListAnswers[0].Content;
            txtB.Text = question.ListAnswers[1].Content;
            txtC.Text = question.ListAnswers[2].Content;
            txtD.Text = question.ListAnswers[3].Content;
            txtCorrectAnswer.Text = question.CorrectAnswer;

            index++;

            if(index == 15) btnNext.Enabled = false;
            btnSendQA.Enabled = true;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _client.Client.Shutdown(SocketShutdown.Send);
            _thread.Join();
            _ns.Close();
            _client.Close();

            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
            btnLoadQuestions.Enabled = false;
            btnNext.Enabled = false;
            btnSendQA.Enabled = false;
        }

        private void QuestionsUC_Load(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            btnLoadQuestions.Enabled = false;
            btnNext.Enabled = false;
            btnSendQA.Enabled = false;
            txtCorrectAnswer.Visible = false;
        }
    }
}
