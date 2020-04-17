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
    public partial class Admin : Form
    {
        SqlConnection tableBD = new SqlConnection(@"Data Source=LAPTOP-14ARIIT9\SQLEXPRESS;Initial Catalog=Kursach;Integrated Security=True");
        
        bool ordInsert_or_upd = true;//insert - true
        public Admin()
        {
            InitializeComponent();
            lisssst.SelectedIndexChanged += lissssst_SelectedIndexChanged;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            //Order
            chooseIDOrdCB.SelectedIndexChanged += chooseIDOrdCB_SelectedIndexChanged;
            //Auto
            listBoxCompl.SelectedIndexChanged += ListBoxCompl_SelectedIndexChanged;
            listBoxSpecs.SelectedIndexChanged += ListBoxSpecs_SelectedIndexChanged;
            listBoxColour.SelectedIndexChanged += ListBoxColour_SelectedIndexChanged;
            //Modif
            СhooseMarkModifCB.SelectedIndexChanged += СhooseMarkModifCB_SelectedIndexChanged;
            ChooseModelModifCB.SelectedIndexChanged += ChooseModelModifCB_SelectedIndexChanged;
            //Stats
            comboBoxYearSt.SelectedIndexChanged += comboBoxYearSt_SelectedIndexChanged;
            comboBoxMonthSt.SelectedIndexChanged += comboBoxMonthSt_SelectedIndexChanged;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursachDataSet1.Storage". При необходимости она может быть перемещена или удалена.
            this.storageTableAdapter1.Fill(this.kursachDataSet1.Storage);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursachDataSet.Storage". При необходимости она может быть перемещена или удалена.
            this.storageTableAdapter.Fill(this.kursachDataSet.Storage);
            if (tableBD.State == ConnectionState.Open)
            {
                tableBD.Close();
            }
            tableBD.Open();
        }

        void CBquery(string query, ComboBox box)
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

        void ExecuteQuery(string query)
        {
            SqlCommand command = tableBD.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            int a = command.ExecuteNonQuery();
            if (a == 1)
                MessageBox.Show("Запись успешно добавлена.");
        }

        void lissssst_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = lisssst.SelectedItem.ToString();
            tabControl1.Show();
            if (selectedState == "Добавить Марку")
            {
                tabControl1.SelectTab("MarkTab");
                CountryCB.Items.Clear();
                string sqlExpression = "SELECT * FROM Country";
                CBquery(sqlExpression, CountryCB);
            }
            else if (selectedState == "Добавить Авто")
            {
                tabControl1.SelectTab("ModelTab");
                string sqlExpression = "SELECT Mark_auto FROM Mark";
                MarkAutoCB.Items.Clear();
                CBquery(sqlExpression, MarkAutoCB);
            }
            else if (selectedState == "Добавить Заказ")
            {
                tabControl1.SelectTab("OrderTab");

            }
            else if (selectedState == "Добавить цену для продажи")
            {
                string query = "select ID_Modification, Mark_auto, Model_auto, Colour, Complectation_Modification, Specs, Year FROM Modification inner join Automobile on Modification._ID_Auto = Automobile.ID_Auto Where Price IS NULL";
                tabControl1.SelectTab("SaleTab");
                SqlCommand command = new SqlCommand(query, tableBD);
                SqlDataReader reader = command.ExecuteReader();
                dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView1.RowsDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
                if (reader.HasRows)
                {
                    while (reader.Read())
                        dataGridView1.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString());
                }
                else
                    MessageBox.Show("Пока нечего добавлять!");
                reader.Close();
            }
            else if (selectedState == "Добавить Модификацию")
            {
                tabControl1.SelectTab("ModificationTab");
                СhooseMarkModifCB.Items.Clear();
                string sqlExpression = "SELECT Distinct Mark_auto FROM Automobile";
                CBquery(sqlExpression, СhooseMarkModifCB);
                ChooseModelModifCB.Items.Clear();
                sqlExpression = "SELECT Model_auto FROM Automobile";
                CBquery(sqlExpression, ChooseModelModifCB);
            }
            else if (selectedState == "Просмотр Наличия")
            {
                tabControl1.SelectTab("StorageTab");
            }
            else if (selectedState == "Отметить выдачу авто")
            {
                tabControl1.SelectTab("ReceiveTab");
                string query = "Select ID_Sale, Mark_auto, Model_auto, Login, Name, Date_Sale From ((Automobile inner join Modification on Automobile.ID_Auto = Modification._ID_Auto) inner join Sale on Modification.ID_Modification = Sale.ID_Modification) inner join Customer on Sale.ID_Customer = Customer.ID_Customer Where IsReceive = 0";
                SqlCommand command = new SqlCommand(query, tableBD);
                SqlDataReader reader = command.ExecuteReader();
                dataGridView2.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView2.RowsDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
                if (reader.HasRows)
                {
                    DateTime data;
                    while (reader.Read())
                    {
                        data = Convert.ToDateTime(reader.GetValue(5));
                        dataGridView2.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), data.ToString("d"));
                    }
                }
                else
                    MessageBox.Show("Пока нечего отмечать!");
                reader.Close();
            }
            else if (selectedState == "Посмотреть статистику")
            {
                tabControl1.SelectTab("Statistics");
                string query = "Select Distinct Year(Date_Receive) From Sale";
                CBquery(query, comboBoxYearSt);
                query = "Select Top 1 Mark_auto, Model_auto, count(*) From (Automobile inner join Modification on Automobile.ID_Auto = Modification._ID_Auto) inner join Sale on Modification.ID_Modification = Sale.ID_Modification Group by Mark_auto, Model_auto Order by count(*)";
                SqlCommand command = new SqlCommand(query, tableBD);
                SqlDataReader reader = command.ExecuteReader();
                dataGridViewPopularAuto.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                dataGridViewPopularAuto.RowsDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridViewPopularAuto.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString());
                    }
                }
                reader.Close();
                query = "Select Top 1 Mark_auto, Model_auto, Colour, Complectation_Modification, Specs, Year, count(*) From (Automobile inner join Modification on Automobile.ID_Auto = Modification._ID_Auto) inner join Sale on Modification.ID_Modification = Sale.ID_Modification Group by Mark_auto, Model_auto, Colour, Complectation_Modification, Specs, Year Order by count(*)";
                command = new SqlCommand(query, tableBD);
                reader = command.ExecuteReader();
                dataGridViewPopularModif.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                dataGridViewPopularModif.RowsDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridViewPopularModif.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(),reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString());
                    }
                }
                reader.Close();
                query = "Select Top 3 Mark_auto, Model_auto, Colour, Complectation_Modification, Specs, Year, Quantity From (Automobile inner join Modification on Automobile.ID_Auto = Modification._ID_Auto) inner join Storage on Modification.ID_Modification = Storage.ID_Modification Order by Quantity desc";
                command = new SqlCommand(query, tableBD);
                reader = command.ExecuteReader();
                dataGridViewStorageStats.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                dataGridViewStorageStats.RowsDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridViewStorageStats.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString());
                    }
                }
                reader.Close();
                query = "Select Top 3 Login, Name, count(*) From Sale inner join Customer on Sale.ID_Customer = Customer.ID_Customer Group by Login, Name Order by count(*) desc";
                command = new SqlCommand(query, tableBD);
                reader = command.ExecuteReader();
                dataGridViewClients.RowsDefaultCellStyle.SelectionBackColor = Color.White;
                dataGridViewClients.RowsDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridViewClients.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString());
                    }
                }
                reader.Close();
            }
        }
        ///////////////////////////////////////
        //////////////// ORDER ///////////////
        /////////////////////////////////////
        private void newOrd_Click(object sender, EventArgs e)
        {
            Quantity_auto.Show();
            getQuantityAutoOrd.Show();
            modif_choice.Show();
            CBmodif_ord.Show();
            orderPrimenit.Show();
            chooseIDOrdCB.Hide();
            chooseIdOrd.Hide();
            string sqlExpression = "SELECT ID_Modification FROM Storage Where Quantity IS NULL";
            CBquery(sqlExpression, CBmodif_ord);
        }

        private void newSuply_Click(object sender, EventArgs e)
        {
            chooseIdOrd.Show();
            chooseIDOrdCB.Show();
            Quantity_auto.Hide();
            getQuantityAutoOrd.Hide();
            modif_choice.Hide();
            CBmodif_ord.Hide();
            orderPrimenit.Hide();
            ordInsert_or_upd = false;
            string sqlExpression = "SELECT ID_Order FROM Order_Modification Where Date_supply Is Null";
            CBquery(sqlExpression, chooseIDOrdCB);

        }

        void chooseIDOrdCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            chooseIdOrd.Hide();
            chooseIDOrdCB.Hide();
            dataPostInput.Show();
            dataPostavkiLabel.Show();
            dataPostSegodnya.Show();
        }
        private void dataPostInput_Click(object sender, EventArgs e)
        {
            dateTimePickerOrder.Show();
            orderPrimenit.Show();
            dataPostInput.Hide();
            dataPostSegodnya.Hide();

        }

        private void dataPostSegodnya_Click(object sender, EventArgs e)
        {
            dataPostInput.Hide();
            dataPostSegodnya.Hide();
            orderPrimenit.Hide();
            dataPostavkiLabel.Hide();
            string query = "update Order_Modification set Date_supply = GetDate() Where ID_Order = " + Convert.ToInt32(chooseIDOrdCB.Text) + "";
            ExecuteQuery(query);
            query = "update Storage set Quantity = (select Number_auto from Order_Modification Where ID_Modification = Storage.ID_Modification) Where Quantity Is NULL";
            ExecuteQuery(query);
        }

        private void orderPrimenit_Click(object sender, EventArgs e)
        {
            if (ordInsert_or_upd)
            {
                string query = "insert into Order_Modification values(GetDate(),NULL," + Convert.ToInt32(getQuantityAutoOrd.Text) + "," + Convert.ToInt32(CBmodif_ord.Text) + ")";
                ExecuteQuery(query);
            }
            else
            {
                dateTimePickerOrder.Hide();
                dataPostavkiLabel.Hide();
                orderPrimenit.Hide();
                string query = "update Order_Modification set Date_supply = CAST( '" + dateTimePickerOrder.Text + "' as date ) Where ID_Order = " + Convert.ToInt32(chooseIDOrdCB.Text) + "";
                ExecuteQuery(query);
                query = "update Storage set Quantity = (select Number_auto from Order_Modification Where ID_Modification = Storage.ID_Modification) Where Quantity Is NULL";
                ExecuteQuery(query);
            }
        }

        ///////////////////////////////////////////////////
        //////////////////Storage/////////////////////////
        /////////////////////////////////////////////////

        private void buttonStorage_Click(object sender, EventArgs e)
        {
            dataFullStorage.Show();
        }

        private void buttonStorageNulls_Click(object sender, EventArgs e)
        {
            try
            {
                this.storageTableAdapter1.WhereNull(this.kursachDataSet1.Storage);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            dataGridStorageNulls.Show();
        }

        ///////////////////////////////////////////////////
        /////////////////Mark/////////////////////////////
        /////////////////////////////////////////////////
        private void Addmarkbutton_Click(object sender, EventArgs e)
        {
            string query = "insert into Mark values('"+ nameMark.Text + "' , '"+CountryCB.Text+"')";
            ExecuteQuery(query);
        }

        ///////////////////////////////////////////////////
        /////////////////Model////////////////////////////
        /////////////////////////////////////////////////
        private void addModelbutton_Click(object sender, EventArgs e)
        {
            textBoxModelInsert.Hide();
            MarkAutoCB.Hide();
            СhooseMarkLabel.Hide();
            TypeModelLabel.Hide();
            addModelbutton.Hide();
            NumDoorsSeats.Hide();
            textBoxSeats.Hide();
            textBoxDoors.Hide();
            Type_kuz.Hide();
            textBoxKuz.Hide();
            string query = "insert into Automobile values('" + MarkAutoCB.Text + "' , '" + textBoxModelInsert.Text + "','"+ textBoxKuz.Text + "',"+ textBoxDoors.Text + ", "+ textBoxSeats.Text + ")";
            ExecuteQuery(query);
            string LBquerystr = "SELECT Engine_type FROM Specifications";
            LBquery(LBquerystr, listBoxSpecs);
            LBquerystr = "SELECT Equipment FROM Complectation";
            LBquery(LBquerystr, listBoxCompl);
            LBquerystr = "SELECT * FROM Colour";
            LBquery(LBquerystr, listBoxColour);
            ChoosespecsLabel.Show();
            ChooseCompllabel.Show();
            ChooseColourLabel.Show();
            listBoxSpecs.Show();
            listBoxCompl.Show();
            listBoxColour.Show();
            readyAddModelButton.Show();
        }

        private void ListBoxCompl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "insert into Automobile_Complectation Values((select max(ID_Auto) from Automobile),'" + listBoxCompl.Text + "')";
            ExecuteQuery(query);
        }

        private void ListBoxSpecs_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string query = "insert into Automobile_Specification Values((select max(ID_Auto) from Automobile),'" + listBoxSpecs.Text + "')";
            ExecuteQuery(query);
        }
        private void ListBoxColour_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string query = "insert into Automobile_Colour Values((select max(ID_Auto) from Automobile),'" + listBoxColour.Text + "')";
            ExecuteQuery(query);
        }

        private void readyAddModelButton_Click(object sender, EventArgs e)
        {
            readyAddModelButton.Hide();
            ChoosespecsLabel.Hide();
            ChooseCompllabel.Hide();
            ChooseColourLabel.Hide();
            listBoxSpecs.Hide();
            listBoxCompl.Hide();
            listBoxColour.Hide();
            textBoxModelInsert.Show();
            MarkAutoCB.Show();
            СhooseMarkLabel.Show();
            TypeModelLabel.Show();
            addModelbutton.Show();
        }

        ///////////////////////////////////////////////////
        /////////////////Modification/////////////////////
        /////////////////////////////////////////////////

        int countChosenauto = 0;
        bool Mark = false;
        bool Model = false;

        private void СhooseMarkModifCB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChooseModelModifCB.Items.Clear();
            string sqlExpression = "SELECT Model_auto FROM Automobile Where Mark_auto = '"+ СhooseMarkModifCB.Text + "'";
            CBquery(sqlExpression, ChooseModelModifCB);
            if (!Mark)
            {
                ++countChosenauto;
                Mark = true;
            }
            if(countChosenauto == 2)
            {
                countChosenauto = 0;
                ColorModif.Show();
                EngineModif.Show();
                ComplectationModif.Show();
                YearModif.Show();
                YearTB.Show();
                Pricelbl.Show();
                PriceTB.Show();
                ModifButton.Show();
                ColorModifCB.Show();
                sqlExpression = "SELECT Colour FROM Automobile_colour Where _ID_Auto IN(select ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelModifCB.Text + "')";
                CBquery(sqlExpression, ColorModifCB);
                SpecsModifCB.Show();
                sqlExpression = "SELECT Engine_type FROM Automobile_Specification Where _ID_Auto IN(select ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelModifCB.Text + "')";
                CBquery(sqlExpression, SpecsModifCB);
                ComplectModifCB.Show();
                sqlExpression = "SELECT Equipment FROM Automobile_Complectation Where _ID_Auto IN(select ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelModifCB.Text + "')";
                CBquery(sqlExpression, ComplectModifCB);
                Mark = false;
            }
        }

        private void ChooseModelModifCB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            СhooseMarkModifCB.Items.Clear();
            string sqlExpression = "SELECT Mark_auto FROM Automobile Where Model_auto = '" + ChooseModelModifCB.Text + "'";
            CBquery(sqlExpression, СhooseMarkModifCB);
            if (!Model)
            {
                ++countChosenauto;
                Model = true;
            }
            if (countChosenauto == 2)
            {
                countChosenauto = 0;
                ColorModif.Show();
                EngineModif.Show();
                ComplectationModif.Show();
                YearModif.Show();
                YearTB.Show();
                Pricelbl.Show();
                PriceTB.Show();
                ModifButton.Show();
                ColorModifCB.Show();
                sqlExpression = "SELECT Colour FROM Automobile_colour Where _ID_Auto IN(select ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelModifCB.Text + "')";
                CBquery(sqlExpression, ColorModifCB);
                SpecsModifCB.Show();
                sqlExpression = "SELECT Engine_type FROM Automobile_Specification Where _ID_Auto IN(select ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelModifCB.Text + "')";
                CBquery(sqlExpression, SpecsModifCB);
                ComplectModifCB.Show();
                sqlExpression = "SELECT Equipment FROM Automobile_Complectation Where _ID_Auto IN(select ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelModifCB.Text + "')";
                CBquery(sqlExpression, ComplectModifCB);
                Model = false;
            }
        }

        private void ModifButton_Click(object sender, EventArgs e)
        {
            string sqlExpression = "Insert into Modification Values((select TOP 1 ID_Auto from Automobile Where Mark_Auto = '" + СhooseMarkModifCB.Text + "' AND Model_auto = '" + ChooseModelModifCB.Text + "'),'"+
                ColorModifCB.Text + "','"+ ComplectModifCB.Text + "','"+ SpecsModifCB.Text + "',"+ Convert.ToInt32(YearTB.Text) + "," + Convert.ToInt32(PriceTB.Text) + ", NULL)";
            ExecuteQuery(sqlExpression);
            sqlExpression = "insert into Storage Values((select max(ID_Modification) From Modification), NULL)";
            ExecuteQuery(sqlExpression);
            ColorModif.Hide();
            EngineModif.Hide();
            ComplectationModif.Hide();
            YearModif.Hide();
            YearTB.Hide();
            Pricelbl.Hide();
            PriceTB.Hide();
            ModifButton.Hide();
            ColorModifCB.Hide();
            SpecsModifCB.Hide();
            ComplectModifCB.Hide();
            СhooseMarkModifCB.Items.Clear();
            sqlExpression = "SELECT Distinct Mark_auto FROM Automobile";
            CBquery(sqlExpression, СhooseMarkModifCB);
            ChooseModelModifCB.Items.Clear();
            sqlExpression = "SELECT Model_auto FROM Automobile";
            CBquery(sqlExpression, ChooseModelModifCB);
        }

        ///////////////////////////////////////////////////
        /////////////////Price////////////////////////////
        /////////////////////////////////////////////////
        private void PriceInpButton_Click(object sender, EventArgs e)
        {
            string query = "update Modification set Price = "+ Convert.ToInt32(PriceInp.Text) + " Where ID_Modification = " + Convert.ToInt32(textBoxModifID.Text) + "";
            ExecuteQuery(query);
            query = "update Sale set Summa = (select Price*Overprice From Modification inner join Complectation on Modification.Complectation_Modification = Complectation.Equipment where ID_Modification = " + Convert.ToInt32(textBoxModifID.Text) + ") where ID_Modification = " + Convert.ToInt32(textBoxModifID.Text) + "";
            ExecuteQuery(query);
        }
        ///////////////////////////////////////////////////
        /////////////////Receive//////////////////////////
        /////////////////////////////////////////////////
        private void buttonPrimenitReceive_Click(object sender, EventArgs e)
        {
            string query = "update Sale set IsReceive = 1 Where ID_Sale = " + Convert.ToInt32(textBoxModifReceive.Text) + "";
            ExecuteQuery(query);
            query = "update Sale set Date_Receive = CAST( '" + dateTimePicker.Text + "' as date ) Where ID_Sale = " + Convert.ToInt32(textBoxModifReceive.Text) + "";
            ExecuteQuery(query);
        }

        ///////////////////////////////////////////////////
        /////////////////Stats////////////////////////////
        /////////////////////////////////////////////////

        private void comboBoxYearSt_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            comboBoxMonthSt.Items.Clear();
            string query = "SELECT Count(*) FROM Sale Where Year(Date_Receive) = '"+ comboBoxYearSt.Text + "'";
            SqlCommand command = new SqlCommand(query, tableBD);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                    YearStats.Text = reader.GetValue(0).ToString();
            }
            reader.Close();
            query = "Select Distinct Month(Date_Receive) From Sale Where Year(Date_Receive) = '" + comboBoxYearSt.Text + "'";
            CBquery(query, comboBoxMonthSt);
        }
        private void comboBoxMonthSt_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string query = "SELECT Count(*) FROM Sale Where Year(Date_Receive) = '" + comboBoxYearSt.Text + "' and Month(Date_Receive) = '"+ comboBoxMonthSt.Text + "'";
            SqlCommand command = new SqlCommand(query, tableBD);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                    MonthStat.Text = reader.GetValue(0).ToString();
            }
            reader.Close();
        }
    }
}
