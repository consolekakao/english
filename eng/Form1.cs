using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace eng
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        public static String url = "SERVER=183.111.199.157; USER=alpacao; DATABASE=alpacao; PORT=3306; PASSWORD=alpaca16;";


        private MySqlConnection mConnection; 

        private MySqlCommand mCommand;

        private MySqlDataReader mDataReader; 

        private void button1_Click(object sender, EventArgs e)
        {




            mConnection = new MySqlConnection(url); // DB접속

            mCommand = new MySqlCommand(); // 쿼리문 생성

            mCommand.Connection = mConnection;



            mCommand.CommandText = "insert into en values('',\"" + textBox1.Text + "\",'" + textBox2.Text + "')";

            mConnection.Open();

            mDataReader = mCommand.ExecuteReader();
            mConnection.Close();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
