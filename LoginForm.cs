using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KursachBD
{
    public partial class LoginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-14ARIIT9\SQLEXPRESS;Initial Catalog=Kursach;Integrated Security=True");
        int counter = 0;
        public LoginForm()
        {
            InitializeComponent();
        }

        public string GetLogin
        {
            get { return textBox1.Text; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter = 0;
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                Admin adm = new Admin();

                adm.Show();
                this.Hide();
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Login_pass where Login = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable data = new DataTable();
                SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
                dataAd.Fill(data);
                counter = data.Rows.Count;
                if (counter == 0)
                {
                    MessageBox.Show("Wrong login or password");
                }
                else
                {
                    Autosalon autosal_user = new Autosalon();
                    autosal_user.Owner = this;
                    autosal_user.ShowDialog();
                    this.Hide();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void Registr_Click(object sender, EventArgs e)
        {
            Registr.Hide();
            textBox1.Hide();
            label1.Hide();
            label2.Hide();
            textBox2.Hide();
            button1.Hide();
            panelreg.Show();
            label3.Hide();
        }

        private void RegistrGo_Click(object sender, EventArgs e)
        {
            Registr.Show();
            textBox1.Show();
            label1.Show();
            label2.Show();
            textBox2.Show();
            button1.Show();
            panelreg.Hide();
            label3.Show();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Login_pass Values('"+ LoginTB.Text + "','"+PassTB.Text+"')";
            int a = cmd.ExecuteNonQuery();
            if(a != 1)
            {
                MessageBox.Show("Такой логин уже существует!");
            }
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "insert into Customer Values('" + NameTB.Text + "','" + AdressTB.Text + "','"+ SeriesTB.Text + "', "+ Convert.ToInt32(NumPassTB.Text) + ", '"+PhoneTB.Text + "', '"+ LoginTB.Text + "')";
            command.ExecuteNonQuery();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Registr.Show();
            textBox1.Show();
            label1.Show();
            label2.Show();
            textBox2.Show();
            button1.Show();
            label3.Show();
            panelreg.Hide();
        }
    }
}
