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
            mConnection = new MySqlConnection(url);
            mCommand = new MySqlCommand();
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
            listView1.Columns.Add("Num", 40);
            listView1.Columns.Add("English", 200);
            listView1.Columns.Add("Korea", 200);
            Reload();
            mConnection.Close();
            
        }

        public void Reload()
        {

            mConnection = new MySqlConnection(url);

            mCommand = new MySqlCommand();

            mCommand.Connection = mConnection;



            mCommand.CommandText = "SELECT * FROM en";

            mConnection.Open();

            mDataReader = mCommand.ExecuteReader();

            while (mDataReader.Read())

            {
                string num = mDataReader["num"].ToString();

                string english = mDataReader["english"].ToString();

                string korea = mDataReader["korea"].ToString();

                ListViewItem item = new ListViewItem(num);
                item.SubItems.Add(english);
                item.SubItems.Add(korea);
                listView1.Items.Add(item);

                textBox3.Text += "<<" + num + ">>   [[" + english + "]]   ((" + korea + ")) <hr> \r\n"; 
            }

            mConnection.Close();

        }
            private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }
        }
    }
