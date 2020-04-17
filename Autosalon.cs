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
    public partial class Autosalon : Form
    {
        SqlConnection tableBD = new SqlConnection(@"Data Source=LAPTOP-14ARIIT9\SQLEXPRESS;Initial Catalog=Kursach;Integrated Security=True");
        public Autosalon()
        {
            InitializeComponent();
            listBoxMark.SelectedIndexChanged += listBoxMark_SelectedIndexChanged;
            listBoxModel.SelectedIndexChanged += listBoxModel_SelectedIndexChanged;
            СhooseMarkModifCB.SelectedIndexChanged += СhooseMarkModifCB_SelectedIndexChanged;
            ChooseModelCB.SelectedIndexChanged += ChooseModelCB_SelectedIndexChanged;
            this.Location = new Point(100, 5);
            this.SuspendLayout();
        }
        private void Autosalon_Load(object sender, EventArgs e)
        {
            if (tableBD.State == ConnectionState.Open)
            {
                tableBD.Close();
            }
            tableBD.Open();
            LoginForm main = this.Owner as LoginForm;
            string a = main.GetLogin;
            Nick.Text = a;
        }

        void CBquery(string query, ComboBox box)
        {
            List<object> mas = new List<object>();
            SqlCommand com = new SqlCommand(query, tableBD);
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                    mas.Add(read.GetValue(0));
            }
            object[] new_mas = mas.ToArray();
            read.Close();
            box.Items.AddRange(new_mas);
        }

        void LBquery(string query, ListBox box)
        {
            List<object> mas = new List<object>();
            SqlCommand command = new SqlCommand(query, tableBD);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                    mas.Add(reader.GetValue(0));
            }
            object[] new_mas = mas.ToArray();
            reader.Close();
            box.Items.AddRange(new_mas);
        }

        void ExecuteQuery(string query, bool bl)
        {
            SqlCommand command = tableBD.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            int a = command.ExecuteNonQuery();
            if (a == 1 && bl)
                MessageBox.Show("Спасибо за заказ! В ближайшее время мы вам перезвоним.\nВы можете отследить заказ в личном кабинете кликнув по нику справа сверху");
        }


        private void LineupLabel_Click(object sender, EventArgs e)
        {
            panel2.Show();
            string LBquerystr = "SELECT Distinct Mark_auto FROM Automobile inner join Modification on Modification._ID_Auto = Automobile.ID_Auto";
            LBquery(LBquerystr, listBoxMark);
            LBquerystr = "SELECT Distinct Model_auto FROM Automobile inner join Modification on Modification._ID_Auto = Automobile.ID_Auto";
            LBquery(LBquerystr, listBoxModel);
        }

        private void KonfiguratorLabel_Click(object sender, EventArgs e)
        {
            panel3Modif.Show();
            Graphics graphics = panelMarkModel.CreateGraphics();
            ControlPaint.DrawBorder(graphics, panelMarkModel.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
            graphics = panelSpecs.CreateGraphics();
            ControlPaint.DrawBorder(graphics, panelMarkModel.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
            graphics = panelColor.CreateGraphics();
            ControlPaint.DrawBorder(graphics, panelMarkModel.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
            string sqlExpression = "SELECT Distinct Mark_auto FROM Automobile";
            CBquery(sqlExpression, СhooseMarkModifCB);
            sqlExpression = "SELECT Model_auto FROM Automobile";
            CBquery(sqlExpression, ChooseModelCB);
        }

        int countChosenauto = 0;
        bool Mark = false;
        bool Model = false;
        string SelectedMark;
        string SelectedModel;
        private void listBoxMark_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxModel.Items.Clear();
            string sqlExpression = "SELECT Distinct Model_auto FROM Automobile inner join Modification on Modification._ID_Auto = Automobile.ID_Auto Where Mark_auto = '" + listBoxMark.Text + "'";
            LBquery(sqlExpression, listBoxModel);
            SelectedMark = listBoxMark.SelectedItem.ToString();
            if (!Mark)
            {
                ++countChosenauto;
                Mark = true;
            }
            if (countChosenauto == 2)
            {
                countChosenauto = 0;
                Mark = false;
                Model = false;
                string query = "SELECT Mark_Auto, Model_auto, Modification.Colour, Specs, Complectation_Modification, Type_body, Doors_number, Seats_number, Year, Price FROM Modification inner join Automobile on Modification._ID_Auto = Automobile.ID_Auto Where Model_auto = '" + SelectedModel + "' and Mark_auto = '" + SelectedMark + "' Order by Price";
                SqlCommand command = new SqlCommand(query, tableBD);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    panelLabels.Show();
                    int i = 20;
                    SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-14ARIIT9\SQLEXPRESS;Initial Catalog=Kursach;Integrated Security=True");
                    connection.Open();
                    while (reader.Read())
                    {
                        Panel ModifPanels = new System.Windows.Forms.Panel();
                        Button СhooseBut = new System.Windows.Forms.Button();
                        Label Numplacespanel = new System.Windows.Forms.Label();
                        Label NumDoorsPanel = new System.Windows.Forms.Label();
                        Label YearLabel = new System.Windows.Forms.Label();
                        Label PanelTypeKuz = new System.Windows.Forms.Label();
                        Label PanelModif = new System.Windows.Forms.Label();
                        Label PanelSpecs = new System.Windows.Forms.Label();
                        Label PanelColour = new System.Windows.Forms.Label();
                        Label PanelModel = new System.Windows.Forms.Label();
                        Label PanelMark = new System.Windows.Forms.Label();
                        Label PricePanel = new System.Windows.Forms.Label();

                        this.Carousel.Controls.Add(ModifPanels);
                        // 
                        // ModifPanels
                        // 
                        ModifPanels.Controls.Add(PricePanel);
                        ModifPanels.Controls.Add(СhooseBut);
                        ModifPanels.Controls.Add(Numplacespanel);
                        ModifPanels.Controls.Add(NumDoorsPanel);
                        ModifPanels.Controls.Add(YearLabel);
                        ModifPanels.Controls.Add(PanelTypeKuz);
                        ModifPanels.Controls.Add(PanelModif);
                        ModifPanels.Controls.Add(PanelSpecs);
                        ModifPanels.Controls.Add(PanelColour);
                        ModifPanels.Controls.Add(PanelModel);
                        ModifPanels.Controls.Add(PanelMark);
                        ModifPanels.Location = new System.Drawing.Point(i, 3);
                        ModifPanels.Name = "ModifPanels";
                        ModifPanels.Size = new System.Drawing.Size(252, 215);
                        ModifPanels.TabIndex = 0;
                        ModifPanels.BackColor = Color.Black;
                        ModifPanels.BorderStyle = BorderStyle.None;

                        // 
                        // Numplacespanel
                        // 
                        Numplacespanel.AutoSize = true;
                        Numplacespanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        Numplacespanel.ForeColor = Color.White;
                        Numplacespanel.Location = new System.Drawing.Point(155, 145);
                        Numplacespanel.Name = "Numplacespanel";
                        Numplacespanel.Size = new System.Drawing.Size(53, 20);
                        Numplacespanel.TabIndex = 8;
                        Numplacespanel.Text = reader.GetValue(7).ToString();
                        // 
                        // NumDoorsPanel
                        // 
                        NumDoorsPanel.AutoSize = true;
                        NumDoorsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        NumDoorsPanel.Location = new System.Drawing.Point(94, 145);
                        NumDoorsPanel.ForeColor = Color.White;
                        NumDoorsPanel.Name = "NumDoorsPanel";
                        NumDoorsPanel.Size = new System.Drawing.Size(65, 20);
                        NumDoorsPanel.TabIndex = 7;
                        NumDoorsPanel.Text = reader.GetValue(6).ToString();
                        // 
                        // YearLabel
                        // 
                        YearLabel.AutoSize = true;
                        YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        YearLabel.Location = new System.Drawing.Point(193, 11);
                        YearLabel.ForeColor = Color.White;
                        YearLabel.Name = "YearLabel";
                        YearLabel.Size = new System.Drawing.Size(56, 25);
                        YearLabel.TabIndex = 6;
                        YearLabel.Text = reader.GetValue(8).ToString();
                        // 
                        // PanelTypeKuz
                        // 
                        PanelTypeKuz.AutoSize = true;
                        PanelTypeKuz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelTypeKuz.Location = new System.Drawing.Point(3, 120);
                        PanelTypeKuz.ForeColor = Color.White;
                        PanelTypeKuz.Name = "PanelTypeKuz";
                        PanelTypeKuz.Size = new System.Drawing.Size(53, 20);
                        PanelTypeKuz.TabIndex = 5;
                        PanelTypeKuz.Text = reader.GetValue(5).ToString();
                        // 
                        // PanelModif
                        // 
                        PanelModif.AutoSize = true;
                        PanelModif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelModif.Location = new System.Drawing.Point(3, 95);
                        PanelModif.ForeColor = Color.White;
                        PanelModif.Name = "PanelModif";
                        PanelModif.Size = new System.Drawing.Size(53, 20);
                        PanelModif.TabIndex = 4;
                        PanelModif.Text = reader.GetValue(4).ToString();
                        // 
                        // PanelSpecs
                        // 
                        PanelSpecs.AutoSize = true;
                        PanelSpecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelSpecs.Location = new System.Drawing.Point(3, 70);
                        PanelSpecs.ForeColor = Color.White;
                        PanelSpecs.Name = "PanelSpecs";
                        PanelSpecs.Size = new System.Drawing.Size(53, 20);
                        PanelSpecs.TabIndex = 3;
                        PanelSpecs.Text = reader.GetValue(3).ToString();
                        // 
                        // PanelColour
                        // 
                        PanelColour.AutoSize = true;
                        PanelColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelColour.Location = new System.Drawing.Point(3, 42);
                        PanelColour.ForeColor = Color.White;
                        PanelColour.Name = "PanelColour";
                        PanelColour.Size = new System.Drawing.Size(53, 20);
                        PanelColour.TabIndex = 2;
                        PanelColour.Text = reader.GetValue(2).ToString();
                        // 
                        // PanelModel
                        // 
                        PanelModel.AutoSize = true;
                        PanelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelModel.Location = new System.Drawing.Point(100, 11);
                        PanelModel.ForeColor = Color.White;
                        PanelModel.Name = "PanelModel";
                        PanelModel.Size = new System.Drawing.Size(64, 25);
                        PanelModel.TabIndex = 1;
                        PanelModel.Text = reader.GetValue(1).ToString();
                        // 
                        // PanelMark
                        // 
                        PanelMark.AutoSize = true;
                        PanelMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelMark.Location = new System.Drawing.Point(3, 11);
                        PanelMark.ForeColor = Color.White;
                        PanelMark.Name = "PanelMark";
                        PanelMark.Size = new System.Drawing.Size(64, 25);
                        PanelMark.TabIndex = 0;
                        PanelMark.Text = reader.GetValue(0).ToString();
                        // 
                        // PricePanel
                        // 
                        PricePanel.AutoSize = true;
                        PricePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PricePanel.Location = new System.Drawing.Point(3, 175);
                        PricePanel.ForeColor = Color.White;
                        PricePanel.Name = "PricePanel";
                        PricePanel.Size = new System.Drawing.Size(64, 25);
                        PricePanel.TabIndex = 10;
                        query = "select Price*Overprice From Modification inner join Complectation on Modification.Complectation_Modification = Complectation.Equipment where ID_Modification = " + reader.GetValue(9).ToString() + "";
                        SqlCommand commnd = new SqlCommand(query, connection);
                        SqlDataReader rdr = commnd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                                PricePanel.Text = rdr.GetValue(0).ToString() + " долл.";
                        }
                        rdr.Close();
                        // 
                        // СhooseBut
                        // 
                        СhooseBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        СhooseBut.Location = new System.Drawing.Point(155, 175);
                        СhooseBut.Name = PanelMark.Text + " " + PanelModel.Text + " " + PanelColour.Text + " " + PanelSpecs.Text + " " + PanelModif.Text + " " + YearLabel.Text;
                        СhooseBut.Size = new System.Drawing.Size(88, 26);
                        СhooseBut.TabIndex = 9;
                        СhooseBut.Text = "Выбрать";
                        СhooseBut.UseVisualStyleBackColor = true;
                        СhooseBut.Click += new System.EventHandler(СhooseBut_Click);

                        i += 300;
                        Pen boards = new Pen(Color.White, 4);
                        System.Drawing.Graphics graphics = ModifPanels.CreateGraphics();
                        Point l1 = new Point(0, 37);
                        Point l2 = new Point(252, 37);
                        graphics.DrawLine(boards, l1, l2);
                        boards.Width = 3;
                        l1 = new Point(130, 142);
                        l2 = new Point(130, 235);
                        graphics.DrawLine(boards, l1, l2);
                        boards.Width = 2;
                        int m = 67;
                        for (int a = 0; a < 5; ++a)
                        {
                            l1 = new Point(0, m);
                            l2 = new Point(252, m);
                            graphics.DrawLine(boards, l1, l2);
                            m += 25;
                        }
                        ControlPaint.DrawBorder(graphics, ModifPanels.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
                    }
                    connection.Close();
                }
                reader.Close();
            }

        }

        private void listBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxMark.Items.Clear();
            string sqlExpression = "SELECT Distinct Mark_auto FROM Automobile inner join Modification on Modification._ID_Auto = Automobile.ID_Auto Where Model_auto = '" + listBoxModel.Text + "'";
            LBquery(sqlExpression, listBoxMark);
            SelectedModel = listBoxModel.SelectedItem.ToString();
            if (!Model)
            {
                ++countChosenauto;
                Model = true;
            }
            if (countChosenauto == 2)
            {
                countChosenauto = 0;
                Model = false;
                Mark = false;
                string query = "SELECT Mark_Auto, Model_auto, Modification.Colour, Specs, Complectation_Modification, Type_body, Doors_number, Seats_number, Year, ID_Modification FROM Modification inner join Automobile on Modification._ID_Auto = Automobile.ID_Auto Where Model_auto = '" + SelectedModel + "' and Mark_auto = '" + SelectedMark + "' Order by Price";
                SqlCommand command = new SqlCommand(query, tableBD);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-14ARIIT9\SQLEXPRESS;Initial Catalog=Kursach;Integrated Security=True");
                    connection.Open(); 
                    panelLabels.Show();
                    int i = 20;
                    while (reader.Read())
                    {
                        Panel ModifPanels = new System.Windows.Forms.Panel();
                        Button СhooseBut = new System.Windows.Forms.Button();
                        Label Numplacespanel = new System.Windows.Forms.Label();
                        Label NumDoorsPanel = new System.Windows.Forms.Label();
                        Label YearLabel = new System.Windows.Forms.Label();
                        Label PanelTypeKuz = new System.Windows.Forms.Label();
                        Label PanelModif = new System.Windows.Forms.Label();
                        Label PanelSpecs = new System.Windows.Forms.Label();
                        Label PanelColour = new System.Windows.Forms.Label();
                        Label PanelModel = new System.Windows.Forms.Label();
                        Label PanelMark = new System.Windows.Forms.Label();
                        Label PricePanel = new System.Windows.Forms.Label();

                        this.Carousel.Controls.Add(ModifPanels);
                        // 
                        // ModifPanels
                        // 
                        ModifPanels.Controls.Add(PricePanel);
                        ModifPanels.Controls.Add(СhooseBut);
                        ModifPanels.Controls.Add(Numplacespanel);
                        ModifPanels.Controls.Add(NumDoorsPanel);
                        ModifPanels.Controls.Add(YearLabel);
                        ModifPanels.Controls.Add(PanelTypeKuz);
                        ModifPanels.Controls.Add(PanelModif);
                        ModifPanels.Controls.Add(PanelSpecs);
                        ModifPanels.Controls.Add(PanelColour);
                        ModifPanels.Controls.Add(PanelModel);
                        ModifPanels.Controls.Add(PanelMark);
                        ModifPanels.Location = new System.Drawing.Point(i, 3);
                        ModifPanels.Name = "ModifPanels";
                        ModifPanels.Size = new System.Drawing.Size(252, 215);
                        ModifPanels.TabIndex = 0;
                        ModifPanels.BackColor = Color.Black;
                        ModifPanels.BorderStyle = BorderStyle.None;

                        // 
                        // Numplacespanel
                        // 
                        Numplacespanel.AutoSize = true;
                        Numplacespanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        Numplacespanel.ForeColor = Color.White;
                        Numplacespanel.Location = new System.Drawing.Point(155, 145);
                        Numplacespanel.Name = "Numplacespanel";
                        Numplacespanel.Size = new System.Drawing.Size(53, 20);
                        Numplacespanel.TabIndex = 8;
                        Numplacespanel.Text = reader.GetValue(7).ToString();
                        // 
                        // NumDoorsPanel
                        // 
                        NumDoorsPanel.AutoSize = true;
                        NumDoorsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        NumDoorsPanel.Location = new System.Drawing.Point(94, 145);
                        NumDoorsPanel.ForeColor = Color.White;
                        NumDoorsPanel.Name = "NumDoorsPanel";
                        NumDoorsPanel.Size = new System.Drawing.Size(65, 20);
                        NumDoorsPanel.TabIndex = 7;
                        NumDoorsPanel.Text = reader.GetValue(6).ToString();
                        // 
                        // YearLabel
                        // 
                        YearLabel.AutoSize = true;
                        YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        YearLabel.Location = new System.Drawing.Point(193, 11);
                        YearLabel.ForeColor = Color.White;
                        YearLabel.Name = "YearLabel";
                        YearLabel.Size = new System.Drawing.Size(56, 25);
                        YearLabel.TabIndex = 6;
                        YearLabel.Text = reader.GetValue(8).ToString();
                        // 
                        // PanelTypeKuz
                        // 
                        PanelTypeKuz.AutoSize = true;
                        PanelTypeKuz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelTypeKuz.Location = new System.Drawing.Point(3, 120);
                        PanelTypeKuz.ForeColor = Color.White;
                        PanelTypeKuz.Name = "PanelTypeKuz";
                        PanelTypeKuz.Size = new System.Drawing.Size(53, 20);
                        PanelTypeKuz.TabIndex = 5;
                        PanelTypeKuz.Text = reader.GetValue(5).ToString();
                        // 
                        // PanelModif
                        // 
                        PanelModif.AutoSize = true;
                        PanelModif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelModif.Location = new System.Drawing.Point(3, 95);
                        PanelModif.ForeColor = Color.White;
                        PanelModif.Name = "PanelModif";
                        PanelModif.Size = new System.Drawing.Size(53, 20);
                        PanelModif.TabIndex = 4;
                        PanelModif.Text = reader.GetValue(4).ToString();
                        // 
                        // PanelSpecs
                        // 
                        PanelSpecs.AutoSize = true;
                        PanelSpecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelSpecs.Location = new System.Drawing.Point(3, 70);
                        PanelSpecs.ForeColor = Color.White;
                        PanelSpecs.Name = "PanelSpecs";
                        PanelSpecs.Size = new System.Drawing.Size(53, 20);
                        PanelSpecs.TabIndex = 3;
                        PanelSpecs.Text = reader.GetValue(3).ToString();
                        // 
                        // PanelColour
                        // 
                        PanelColour.AutoSize = true;
                        PanelColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelColour.Location = new System.Drawing.Point(3, 42);
                        PanelColour.ForeColor = Color.White;
                        PanelColour.Name = "PanelColour";
                        PanelColour.Size = new System.Drawing.Size(53, 20);
                        PanelColour.TabIndex = 2;
                        PanelColour.Text = reader.GetValue(2).ToString();
                        // 
                        // PanelModel
                        // 
                        PanelModel.AutoSize = true;
                        PanelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelModel.Location = new System.Drawing.Point(100, 11);
                        PanelModel.ForeColor = Color.White;
                        PanelModel.Name = "PanelModel";
                        PanelModel.Size = new System.Drawing.Size(64, 25);
                        PanelModel.TabIndex = 1;
                        PanelModel.Text = reader.GetValue(1).ToString();
                        // 
                        // PanelMark
                        // 
                        PanelMark.AutoSize = true;
                        PanelMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PanelMark.Location = new System.Drawing.Point(3, 11);
                        PanelMark.ForeColor = Color.White;
                        PanelMark.Name = "PanelMark";
                        PanelMark.Size = new System.Drawing.Size(64, 25);
                        PanelMark.TabIndex = 0;
                        PanelMark.Text = reader.GetValue(0).ToString();
                        // 
                        // PricePanel
                        // 
                        PricePanel.AutoSize = true;
                        PricePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        PricePanel.Location = new System.Drawing.Point(3, 175);
                        PricePanel.ForeColor = Color.White;
                        PricePanel.Name = "PricePanel";
                        PricePanel.Size = new System.Drawing.Size(64, 25);
                        PricePanel.TabIndex = 10;
                        query = "select Price*Overprice From Modification inner join Complectation on Modification.Complectation_Modification = Complectation.Equipment where ID_Modification = " + reader.GetValue(9).ToString() + "";
                        SqlCommand commnd = new SqlCommand(query, connection);
                        SqlDataReader rdr = commnd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                                PricePanel.Text = rdr.GetValue(0).ToString() + " долл.";
                        }
                        rdr.Close();
                        // 
                        // СhooseBut
                        // 
                        СhooseBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                        СhooseBut.Location = new System.Drawing.Point(155, 175);
                        СhooseBut.Name = PanelMark.Text + " " + PanelModel.Text + " " + PanelColour.Text + " " + PanelSpecs.Text + " " + PanelModif.Text + " " + YearLabel.Text;
                        СhooseBut.Size = new System.Drawing.Size(88, 26);
                        СhooseBut.TabIndex = 9;
                        СhooseBut.Text = "Выбрать";
                        СhooseBut.UseVisualStyleBackColor = true;
                        СhooseBut.Click += new System.EventHandler(СhooseBut_Click);

                        i += 300;
                        Pen boards = new Pen(Color.White, 4);
                        System.Drawing.Graphics graphics = ModifPanels.CreateGraphics();
                        Point l1 = new Point(0, 37);
                        Point l2 = new Point(252, 37);
                        graphics.DrawLine(boards, l1, l2);
                        boards.Width = 3;
                        l1 = new Point(130, 142);
                        l2 = new Point(130, 235);
                        graphics.DrawLine(boards, l1, l2);
                        boards.Width = 2;
                        int m = 67;
                        for (int a = 0; a < 5; ++a)
                        {
                            l1 = new Point(0, m);
                            l2 = new Point(252, m);
                            graphics.DrawLine(boards, l1, l2);
                            m += 25;
                        }
                        ControlPaint.DrawBorder(graphics, ModifPanels.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
                    }
                    connection.Close();
                }
                reader.Close();
            }
        }
        string id;
        private void СhooseBut_Click(object sender, EventArgs e)
        {
            string[] words = (sender as Button).Name.Split();
            string query = "select ID_Modification From Automobile inner join Modification on Modification._ID_Auto = Automobile.ID_Auto where Mark_auto = '" + words[0] + "' and Model_auto = '" + words[1] + "' and Colour = '" + words[2] + "' and Complectation_Modification = '" + words[4] + "' and Specs = '" + words[3] + "' and Year = " + Convert.ToInt32(words[5]) + "";
            SqlCommand com = new SqlCommand(query, tableBD);
            SqlDataReader read = com.ExecuteReader();

            if (read.HasRows)
            {
                while (read.Read())
                {
                    id = read.GetValue(0).ToString();
                }
            }
            read.Close();
            panelConfirm.Show();
        }
        private void Clearlabel_Click(object sender, EventArgs e)
        {
            listBoxModel.Items.Clear();
            listBoxMark.Items.Clear();
            string LBquerystr = "SELECT Distinct Mark_auto FROM Automobile";
            LBquery(LBquerystr, listBoxMark);
            LBquerystr = "SELECT Model_auto FROM Automobile";
            LBquery(LBquerystr, listBoxModel);
            Carousel.Controls.Clear();
            panelLabels.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Carousel.Controls.Clear();
            panelLabels.Hide();
            listBoxModel.Items.Clear();
            listBoxMark.Items.Clear();
            panel2.Hide();
            panel1.Show();
            string query = "insert into Sale Values(" + id + ",(select ID_Customer From Customer Where Login = '" + Nick.Text + "'),GetDate(),'" + DostavkaCB.Text + "','" + comboBoxOplata.Text + "', (select Price*Overprice From Modification inner join Complectation on Modification.Complectation_Modification = Complectation.Equipment where ID_Modification = " + id + "),NULL, 0)";
            ExecuteQuery(query, true);
        }
        private void buttonOtm_Click(object sender, EventArgs e)
        {
            panelConfirm.Hide();
        }

        private void ReturnMainMenu_Click(object sender, EventArgs e)
        {
            Carousel.Controls.Clear();
            panelLabels.Hide();
            listBoxModel.Items.Clear();
            listBoxMark.Items.Clear();
            panel2.Hide();
            panel1.Show();
        }

        /////////////////Konfigurator/////////////////////////////
        private void СhooseMarkModifCB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChooseModelCB.Items.Clear();
            string sqlExpression = "SELECT Model_auto FROM Automobile Where Mark_auto = '" + СhooseMarkModifCB.Text + "'";
            CBquery(sqlExpression, ChooseModelCB);
        }

        private void ChooseModelCB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            СhooseMarkModifCB.Items.Clear();
            string sqlExpression = "SELECT Mark_auto FROM Automobile Where Model_auto = '" + ChooseModelCB.Text + "'";
            CBquery(sqlExpression, СhooseMarkModifCB);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelArrow1.Show();
            Pen pen = new Pen(Color.Black, 12);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            Graphics graphics = panelArrow1.CreateGraphics();
            Point l1 = new Point(0, 50);
            Point l2 = new Point(209, 50);
            graphics.DrawLine(pen, l1, l2);
            string sqlExpression = "SELECT Engine_type FROM Automobile_Specification Where _ID_Auto IN(select ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelCB.Text + "')";
            CBquery(sqlExpression, SoberiSpecsCB);
            sqlExpression = "SELECT Equipment FROM Automobile_Complectation Where _ID_Auto IN(select ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelCB.Text + "')";
            CBquery(sqlExpression, SoberiComplCB);
            panelSpecs.Show();

        }

        private void buttonSoberi_Click(object sender, EventArgs e)
        {
            panelArrow2.Show();
            Pen pen = new Pen(Color.Black, 12);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            Graphics graphics = panelArrow2.CreateGraphics();
            Point l1 = new Point(0, 50);
            Point l2 = new Point(209, 50);
            graphics.DrawLine(pen, l1, l2);
            string sqlExpression = "SELECT Colour FROM Automobile_colour Where _ID_Auto IN(select ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelCB.Text + "')";
            CBquery(sqlExpression, SoberiColorCB);
            panelColor.Show();

        }

        private void buttonGotovoSoberi_Click(object sender, EventArgs e)
        {
            VashaModif.Show();
            panelLabless.Show();
            panelShowmodif.Show();
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-14ARIIT9\SQLEXPRESS;Initial Catalog=Kursach;Integrated Security=True");
            connection.Open();

            Panel ModifPanels = new System.Windows.Forms.Panel();
            Button СhooseBut1 = new System.Windows.Forms.Button();
            Label Numplacespanel = new System.Windows.Forms.Label();
            Label NumDoorsPanel = new System.Windows.Forms.Label();
            Label YearLabel = new System.Windows.Forms.Label();
            Label PanelTypeKuz = new System.Windows.Forms.Label();
            Label PanelModif = new System.Windows.Forms.Label();
            Label PanelSpecs = new System.Windows.Forms.Label();
            Label PanelColour = new System.Windows.Forms.Label();
            Label PanelModel = new System.Windows.Forms.Label();
            Label PanelMark = new System.Windows.Forms.Label();
            Label PricePanel = new System.Windows.Forms.Label();

            this.panelShowmodif.Controls.Add(ModifPanels);
            // 
            // ModifPanels
            // 
            ModifPanels.Controls.Add(PricePanel);
            ModifPanels.Controls.Add(СhooseBut1);
            ModifPanels.Controls.Add(Numplacespanel);
            ModifPanels.Controls.Add(NumDoorsPanel);
            ModifPanels.Controls.Add(YearLabel);
            ModifPanels.Controls.Add(PanelTypeKuz);
            ModifPanels.Controls.Add(PanelModif);
            ModifPanels.Controls.Add(PanelSpecs);
            ModifPanels.Controls.Add(PanelColour);
            ModifPanels.Controls.Add(PanelModel);
            ModifPanels.Controls.Add(PanelMark);
            ModifPanels.Location = new System.Drawing.Point(10, 25);
            ModifPanels.Name = "ModifPanels";
            ModifPanels.Size = new System.Drawing.Size(252, 205);
            ModifPanels.TabIndex = 0;
            ModifPanels.BackColor = Color.Black;
            ModifPanels.BorderStyle = BorderStyle.None;


            PricePanel.AutoSize = true;
            PricePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            PricePanel.Location = new System.Drawing.Point(6, 175);
            PricePanel.ForeColor = Color.White;
            PricePanel.Name = "PricePanel";
            PricePanel.Size = new System.Drawing.Size(64, 25);
            PricePanel.TabIndex = 10;
            string query = "select Top 1 Price*Overprice From (Modification inner join Complectation on Modification.Complectation_Modification = Complectation.Equipment) inner join Automobile on Automobile.ID_Auto =  Modification._ID_Auto  Where Mark_auto = '" + СhooseMarkModifCB.Text + "' and Model_auto = '" + ChooseModelCB.Text + "' and Specs = '"+SoberiSpecsCB.Text+ "' and Complectation_Modification = '"+ SoberiComplCB.Text + "' and Year = "+ SoberiYearCB.Text + "";
            SqlCommand commnd = new SqlCommand(query, connection);
            SqlDataReader rdr = commnd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                    PricePanel.Text = rdr.GetValue(0).ToString() + " долл.";
            }
            rdr.Close();

            // 
            // Numplacespanel
            // 
            Numplacespanel.AutoSize = true;
            Numplacespanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            Numplacespanel.ForeColor = Color.White;
            Numplacespanel.Location = new System.Drawing.Point(155, 145);
            Numplacespanel.Name = "Numplacespanel";
            Numplacespanel.Size = new System.Drawing.Size(53, 20);
            Numplacespanel.TabIndex = 8;
             query = "select Seats_number from Automobile Where Mark_auto = '" + СhooseMarkModifCB.Text + "' and Model_auto = '" + ChooseModelCB.Text + "'";
            int seats = 0;
            SqlCommand com = new SqlCommand(query, tableBD);
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                    seats = Convert.ToInt32(read.GetValue(0));
            }
            read.Close();
            Numplacespanel.Text = seats.ToString();
            // 
            // NumDoorsPanel
            // 
            NumDoorsPanel.AutoSize = true;
            NumDoorsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            NumDoorsPanel.Location = new System.Drawing.Point(94, 145);
            NumDoorsPanel.ForeColor = Color.White;
            NumDoorsPanel.Name = "NumDoorsPanel";
            NumDoorsPanel.Size = new System.Drawing.Size(65, 20);
            NumDoorsPanel.TabIndex = 7;
            query = "select Doors_number from Automobile Where Mark_auto = '" + СhooseMarkModifCB.Text + "' and Model_auto = '" + ChooseModelCB.Text + "'";
            int doors = 0;
            com = new SqlCommand(query, tableBD);
            read = com.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                    doors = Convert.ToInt32(read.GetValue(0));
            }
            read.Close();
            NumDoorsPanel.Text = doors.ToString();
            // 
            // YearLabel
            // 
            YearLabel.AutoSize = true;
            YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            YearLabel.Location = new System.Drawing.Point(193, 11);
            YearLabel.ForeColor = Color.White;
            YearLabel.Name = "YearLabel";
            YearLabel.Size = new System.Drawing.Size(56, 25);
            YearLabel.TabIndex = 6;
            YearLabel.Text = SoberiYearCB.Text;
            // 
            // PanelTypeKuz
            // 
            PanelTypeKuz.AutoSize = true;
            PanelTypeKuz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            PanelTypeKuz.Location = new System.Drawing.Point(3, 120);
            PanelTypeKuz.ForeColor = Color.White;
            PanelTypeKuz.Name = "PanelTypeKuz";
            PanelTypeKuz.Size = new System.Drawing.Size(53, 20);
            PanelTypeKuz.TabIndex = 5;
            query = "select Type_body from Automobile Where Mark_auto = '" + СhooseMarkModifCB.Text + "' and Model_auto = '" + ChooseModelCB.Text + "'";
            string Type_body = "";
            com = new SqlCommand(query, tableBD);
            read = com.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                    Type_body = read.GetValue(0).ToString();
            }
            read.Close();
            PanelTypeKuz.Text = Type_body;
            // 
            // PanelModif
            // 
            PanelModif.AutoSize = true;
            PanelModif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            PanelModif.Location = new System.Drawing.Point(3, 95);
            PanelModif.ForeColor = Color.White;
            PanelModif.Name = "PanelModif";
            PanelModif.Size = new System.Drawing.Size(53, 20);
            PanelModif.TabIndex = 4;
            PanelModif.Text = SoberiComplCB.Text;
            // 
            // PanelSpecs
            // 
            PanelSpecs.AutoSize = true;
            PanelSpecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            PanelSpecs.Location = new System.Drawing.Point(3, 70);
            PanelSpecs.ForeColor = Color.White;
            PanelSpecs.Name = "PanelSpecs";
            PanelSpecs.Size = new System.Drawing.Size(53, 20);
            PanelSpecs.TabIndex = 3;
            PanelSpecs.Text = SoberiSpecsCB.Text;
            // 
            // PanelColour
            // 
            PanelColour.AutoSize = true;
            PanelColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            PanelColour.Location = new System.Drawing.Point(3, 42);
            PanelColour.ForeColor = Color.White;
            PanelColour.Name = "PanelColour";
            PanelColour.Size = new System.Drawing.Size(53, 20);
            PanelColour.TabIndex = 2;
            PanelColour.Text = SoberiColorCB.Text;
            // 
            // PanelModel
            // 
            PanelModel.AutoSize = true;
            PanelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            PanelModel.Location = new System.Drawing.Point(100, 11);
            PanelModel.ForeColor = Color.White;
            PanelModel.Name = "PanelModel";
            PanelModel.Size = new System.Drawing.Size(64, 25);
            PanelModel.TabIndex = 1;
            PanelModel.Text = ChooseModelCB.Text;
            // 
            // PanelMark
            // 
            PanelMark.AutoSize = true;
            PanelMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            PanelMark.Location = new System.Drawing.Point(3, 11);
            PanelMark.ForeColor = Color.White;
            PanelMark.Name = "PanelMark";
            PanelMark.Size = new System.Drawing.Size(64, 25);
            PanelMark.TabIndex = 0;
            PanelMark.Text = СhooseMarkModifCB.Text;
            // 
            // СhooseBut1
            // 
            СhooseBut1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            СhooseBut1.Location = new System.Drawing.Point(155, 175);
            СhooseBut1.Name = "СhooseBut1";
            СhooseBut1.Size = new System.Drawing.Size(88, 26);
            СhooseBut1.TabIndex = 9;
            СhooseBut1.Text = "Выбрать";
            СhooseBut1.UseVisualStyleBackColor = true;
            СhooseBut1.Click += new System.EventHandler(СhooseBut1_Click);
            Pen boards = new Pen(Color.White, 4);
            System.Drawing.Graphics graphics = ModifPanels.CreateGraphics();
            Point l1 = new Point(0, 37);
            Point l2 = new Point(252, 37);
            graphics.DrawLine(boards, l1, l2);
            boards.Width = 3;
            l1 = new Point(130, 142);
            l2 = new Point(130, 235);
            graphics.DrawLine(boards, l1, l2);
            boards.Width = 2;
            int m = 67;
            for (int a = 0; a < 5; ++a)
            {
                l1 = new Point(0, m);
                l2 = new Point(252, m);
                graphics.DrawLine(boards, l1, l2);
                m += 25;
            }
            ControlPaint.DrawBorder(graphics, ModifPanels.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        int Id_modif_Exist = -1;
        private void СhooseBut1_Click(object sender, EventArgs e)
        {
            string query = "SELECT ID_Modification FROM Modification inner join Automobile on Modification._ID_Auto = Automobile.ID_Auto Where Mark_auto = '" +
                СhooseMarkModifCB.Text + "' and Model_auto = '" + ChooseModelCB.Text + "' and Colour = '" + SoberiColorCB.Text + "' and Complectation_Modification = '" + SoberiComplCB.Text +
                "' and Specs = '" + SoberiSpecsCB.Text + "' and Year = " + Convert.ToInt32(SoberiYearCB.Text) + "";
            SqlCommand command = new SqlCommand(query, tableBD);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                    Id_modif_Exist = reader.GetInt32(0);
            }
            reader.Close();
            panel4Conf.Show();
            panelLabless.Hide();
            VashaModif.Hide();
            panelShowmodif.Hide();
            panelMarkModel.Hide();
            PanelMainKonf.Hide();
            Retry.Hide();
        }

        private void ReturnToMenu_Click(object sender, EventArgs e)
        {
            СhooseMarkModifCB.Items.Clear();
            ChooseModelCB.Items.Clear();
            SoberiSpecsCB.Items.Clear();
            SoberiComplCB.Items.Clear();
            SoberiColorCB.Items.Clear();
            panelColor.Hide();
            panelArrow2.Hide();
            panelSpecs.Hide();
            panelArrow1.Hide();
            VashaModif.Hide();
            panelLabless.Hide();
            panelShowmodif.Controls.Clear();
            panelShowmodif.Hide();
            panel3Modif.Hide();
        }

        private void Retry_Click(object sender, EventArgs e)
        {
            СhooseMarkModifCB.Items.Clear();
            СhooseMarkModifCB.Text = "";
            ChooseModelCB.Items.Clear();
            ChooseModelCB.Text = "";
            SoberiSpecsCB.Items.Clear();
            SoberiSpecsCB.Text = "";
            SoberiComplCB.Items.Clear();
            SoberiComplCB.Text = "";
            SoberiColorCB.Items.Clear();
            SoberiColorCB.Text = "";
            SoberiYearCB.Text = "";
            string sqlExpression = "SELECT Distinct Mark_auto FROM Automobile";
            CBquery(sqlExpression, СhooseMarkModifCB);
            sqlExpression = "SELECT Model_auto FROM Automobile";
            CBquery(sqlExpression, ChooseModelCB);
            panelColor.Hide();
            panelArrow2.Hide();
            panelSpecs.Hide();
            panelArrow1.Hide();
            VashaModif.Hide();
            panelLabless.Hide();
            panelShowmodif.Controls.Clear();
            panelShowmodif.Hide();
        }

        private void Otmena_Click(object sender, EventArgs e)
        {
            panel4Conf.Hide();
            panelLabless.Show();
            VashaModif.Show();
            panelShowmodif.Show();
            panelMarkModel.Show();
            PanelMainKonf.Show();
            Retry.Show();
        }

        private void PodtvZakazButton_Click(object sender, EventArgs e)
        {
            if (Id_modif_Exist == -1)
            {
                string query = "select Top 1 Price FROM Modification inner join Automobile on Modification._ID_Auto = Automobile.ID_Auto Where Mark_auto = '" +
                    СhooseMarkModifCB.Text + "' and Model_auto = '" + ChooseModelCB.Text + "'  and Complectation_Modification = '" + SoberiComplCB.Text +
                    "' and Specs = '" + SoberiSpecsCB.Text + "' and Year = " + Convert.ToInt32(SoberiYearCB.Text) + "";
                SqlCommand command1 = new SqlCommand(query, tableBD);
                SqlDataReader reader2 = command1.ExecuteReader();
                int price = 0;
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                        price = reader2.GetInt32(0);
                    reader2.Close();
                    query = "insert into Modification Values((select TOP 1 ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelCB.Text + "'),'" +
                        SoberiColorCB.Text + "', '" + SoberiComplCB.Text + "','" + SoberiSpecsCB.Text + "', " + Convert.ToInt32(SoberiYearCB.Text) + "," + price + ")";
                    ExecuteQuery(query, false);
                    query = "insert into Sale values((select Max(Id_Modification) From Modification),(select ID_Customer From Customer Where Login = '" + Nick.Text + "'),GetDate(),'" + DeliveryCB.Text + "', '" +
                        OplataCB.Text + "',(select Price*Overprice From Modification inner join Complectation on Modification.Complectation_Modification = Complectation.Equipment where ID_Modification = (select max(ID_Modification) From Modification)),NULL, 0)";
                    ExecuteQuery(query, true);
                }
                else
                {
                    reader2.Close();
                    query = "insert into Modification Values((select TOP 1 ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelCB.Text + "'),'" +
                    SoberiColorCB.Text + "', '" + SoberiComplCB.Text + "','" + SoberiSpecsCB.Text + "', " + Convert.ToInt32(SoberiYearCB.Text) + ",NULL)";
                    ExecuteQuery(query, false);
                    query = "insert into Sale values((select Max(Id_Modification) From Modification),(select ID_Customer From Customer Where Login = '" + Nick.Text + "'),GetDate(),'" + DeliveryCB.Text + "', '" + OplataCB.Text + "',NULL, NULL, 0)";
                    ExecuteQuery(query, true);
                }
            }
            else
            {
                string query = "insert into Sale values(" + Id_modif_Exist + ",(select ID_Customer From Customer Where Login = '" + Nick.Text + "'),GetDate(),'" + DeliveryCB.Text + "', '" +
                OplataCB.Text + "',(select Price*Overprice From Modification inner join Complectation on Modification.Complectation_Modification = Complectation.Equipment where ID_Modification = " + Id_modif_Exist + ",NULL, 0)";
                ExecuteQuery(query, true);
            }

            СhooseMarkModifCB.Items.Clear();
            ChooseModelCB.Items.Clear();
            SoberiSpecsCB.Items.Clear();
            SoberiComplCB.Items.Clear();
            SoberiColorCB.Items.Clear();
            panelColor.Hide();
            panelArrow2.Hide();
            panelSpecs.Hide();
            panelArrow1.Hide();
            VashaModif.Hide();
            panelLabless.Hide();
            panelShowmodif.Controls.Clear();
            panelShowmodif.Hide();
            panel3Modif.Hide();
            panel4Conf.Hide();
        }


        ////////////////////////////////////
        /////////Kabinet///////////////////
        //////////////////////////////////
        private void Nick_Click(object sender, EventArgs e)
        {
            panel3Modif.Hide();
            panel2.Hide();
            panelLichnKab.Show();
            textBoxLogin.Text = Nick.Text;
            string query = "Select Password From Login_pass Where Login = '" + Nick.Text + "'";
            SqlCommand command1 = new SqlCommand(query, tableBD);
            SqlDataReader reader2 = command1.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                    textBoxPassw.Text = reader2.GetValue(0).ToString();
            }
            reader2.Close();
            query = "Select Name, Address, Series, Number_pass, Phone From Customer Where Login = '" + Nick.Text + "'";
            command1 = new SqlCommand(query, tableBD);
            reader2 = command1.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    textBoxFIO.Text = reader2.GetValue(0).ToString();
                    textBoxAdress.Text = reader2.GetValue(1).ToString();
                    textBoxSeriesPass.Text = reader2.GetValue(2).ToString();
                    textBoxNumPass.Text = reader2.GetValue(3).ToString();
                    textBoxNumPhone.Text = reader2.GetValue(4).ToString();
                }
            }
            reader2.Close();
            query = "Select Mark_auto, Model_auto, Specs, Colour, Complectation_Modification, Year, Date_Sale, Delivery, Payment, Summa From ((Automobile inner join Modification on Automobile.ID_Auto = Modification._ID_Auto) inner join Sale on Modification.ID_Modification = Sale.ID_Modification) inner join Customer on Sale.ID_Customer = Customer.ID_Customer Where Login = '" + Nick.Text + "'  and IsReceive = 0";
            command1 = new SqlCommand(query, tableBD);
            reader2 = command1.ExecuteReader();
            dataGridView.RowsDefaultCellStyle.SelectionBackColor = SystemColors.ButtonHighlight;
            dataGridView.RowsDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
            if (reader2.HasRows)
            {
                DateTime data;
                while (reader2.Read())
                {
                    data = Convert.ToDateTime(reader2.GetValue(6));
                    dataGridView.Rows.Add(reader2.GetString(0), reader2.GetString(1), reader2.GetString(2), reader2.GetString(3), reader2.GetString(4), reader2.GetValue(5).ToString(), data.ToString("d"), reader2.GetString(7), reader2.GetString(8), reader2.GetValue(9).ToString());

                }
            }
            else
            {
                NoOrders.Show();
            }
            reader2.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBoxPassw.UseSystemPasswordChar == true)
            {
                textBoxPassw.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassw.UseSystemPasswordChar = true;
            }
        }

        string prevLogin;
        string prevPassw;
        string prevFIO;
        string prevAdress;
        string prevSeriesPass;
        string prevNumPass;
        string prevNumPhone;
        private void LoginEdit_Click(object sender, EventArgs e)
        {
            ReadyEdit.Show();
            Edit.Hide();
            prevLogin = textBoxLogin.Text;
            prevPassw = textBoxPassw.Text;
            prevFIO = textBoxFIO.Text;
            prevAdress = textBoxAdress.Text;
            prevSeriesPass = textBoxSeriesPass.Text;
            prevNumPass = textBoxNumPass.Text;
            prevNumPhone = textBoxNumPhone.Text;
            textBoxLogin.ReadOnly = false;
            textBoxPassw.ReadOnly = false;
            textBoxFIO.ReadOnly = false;
            textBoxAdress.ReadOnly = false;
            textBoxSeriesPass.ReadOnly = false;
            textBoxNumPass.ReadOnly = false;
            textBoxNumPhone.ReadOnly = false;
        }

        void QueryGo(string query)
        {
            SqlCommand command1 = tableBD.CreateCommand();
            command1.CommandType = CommandType.Text;
            command1.CommandText = query;
            command1.ExecuteNonQuery();
        }
        private void ReadyLogin_Click(object sender, EventArgs e)
        {
            string query = "select * From Login_pass where Login = '" + textBoxLogin.Text + "'";
            SqlCommand command1 = new SqlCommand(query, tableBD);
            SqlDataReader reader2 = command1.ExecuteReader();
            if (reader2.HasRows && textBoxLogin.Text != prevLogin)
            {
                MessageBox.Show("Извините, но такой логин уже существует, попробуйте другой!");
                reader2.Close();
            }
            else
            {
                reader2.Close();
                ReadyEdit.Hide();
                Edit.Show();
                if (textBoxLogin.Text != prevLogin)
                {
                    query = "Update Login_pass set Login = '" + textBoxLogin.Text + "' where Login = '" + prevLogin + "'";
                    QueryGo(query);
                }
                if (textBoxPassw.Text != prevPassw)
                {
                    query = "Update Login_pass set Password = '" + textBoxLogin.Text + "' where Login = '" + textBoxLogin.Text + "'";
                    QueryGo(query);
                }
                if (textBoxFIO.Text != prevFIO)
                {
                    query = "Update Customer set Name = '" + textBoxFIO.Text + "' where Login = '" + textBoxLogin.Text + "'";
                    QueryGo(query);
                }
                if (textBoxAdress.Text != prevAdress)
                {
                    query = "Update Customer set Address = '" + textBoxAdress.Text + "' where Login = '" + textBoxLogin.Text + "'";
                    QueryGo(query);
                }
                if (textBoxSeriesPass.Text != prevSeriesPass)
                {
                    query = "Update Customer set Series = '" + textBoxSeriesPass.Text + "' where Login = '" + textBoxLogin.Text + "'";
                    QueryGo(query);
                }
                if (textBoxNumPass.Text != prevNumPass)
                {
                    query = "Update Customer set Number_pass = '" + textBoxNumPass.Text + "' where Login = '" + textBoxLogin.Text + "'";
                    QueryGo(query);
                }
                if (textBoxNumPhone.Text != prevNumPhone)
                {
                    query = "Update Customer set Phone = '" + textBoxNumPhone.Text + "' where Login = '" + textBoxLogin.Text + "'";
                    QueryGo(query);
                }
                textBoxLogin.ReadOnly = true;
                textBoxPassw.ReadOnly = true;
                textBoxFIO.ReadOnly = true;
                textBoxAdress.ReadOnly = true;
                textBoxSeriesPass.ReadOnly = true;
                textBoxNumPass.ReadOnly = true;
                textBoxNumPhone.ReadOnly = true;
                MessageBox.Show("Спасибо, данные изменены");
            }
        }

        private void Archive_Click(object sender, EventArgs e)
        {
            if (!dataGridView1.Visible)
            {
                dataGridView1.Rows.Clear();
                string query = "Select Mark_auto, Model_auto, Specs, Colour, Complectation_Modification, Year, Date_Sale, Date_Receive From ((Automobile inner join Modification on Automobile.ID_Auto = Modification._ID_Auto) inner join Sale on Modification.ID_Modification = Sale.ID_Modification) inner join Customer on Sale.ID_Customer = Customer.ID_Customer Where Login = '" + Nick.Text + "' and IsReceive = 1";
                SqlCommand command1 = new SqlCommand(query, tableBD);
                SqlDataReader reader2 = command1.ExecuteReader();
                dataGridView1.RowsDefaultCellStyle.SelectionBackColor = SystemColors.ButtonHighlight;
                dataGridView1.RowsDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
                DateTime data1, data2;
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        data1 = Convert.ToDateTime(reader2.GetValue(6));
                        data2 = Convert.ToDateTime(reader2.GetValue(7));
                        dataGridView1.Rows.Add(reader2.GetString(0), reader2.GetString(1), reader2.GetString(2), reader2.GetString(3), reader2.GetString(4), reader2.GetValue(5).ToString(), data1.ToString("d"), data2.ToString("d"));
                    }
                }
                else
                {
                    NoBuys.Show();
                }
                reader2.Close();
                dataGridView1.Show();
            }
            else
            {
                dataGridView1.Hide();
                NoBuys.Hide();
            }
        }

        private void ReturnMainMenulabl_Click(object sender, EventArgs e)
        {
            panelLichnKab.Hide();
        }
    }
}
