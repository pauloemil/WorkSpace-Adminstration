using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WorkspaceAdminProject
{
    public partial class addingEditingItems : Form
    {
        DataB db;
        public addingEditingItems()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addingEditingItems_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml(hagzWindow.back);
            button1.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            button2.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            button3.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            button4.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            //button5.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            button6.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            button7.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);

            label1.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label2.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label3.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label4.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label5.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label6.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label7.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label8.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label9.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label10.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label11.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label12.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label13.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            //label15.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label16.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            //label17.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);

            groupBox1.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            groupBox2.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            groupBox3.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            groupBox4.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            //groupBox5.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);

            hagznameTxtbx.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            hagznameTxtbx.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            hagzPrice.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            hagzPrice.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            hagzroomChairNo.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            hagzroomChairNo.BackColor = ColorTranslator.FromHtml(hagzWindow.back);


            edithagzRoomChairsNo.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            edithagzRoomChairsNo.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            edithagzpriceTxtbx.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            edithagzpriceTxtbx.BackColor = ColorTranslator.FromHtml(hagzWindow.back);



            editproductBuyPrice.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            editproductBuyPrice.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            editproductQuantity.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            editproductQuantity.BackColor = ColorTranslator.FromHtml(hagzWindow.back);


            editproductSellPrice.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            editproductSellPrice.BackColor = ColorTranslator.FromHtml(hagzWindow.back);



            productBuyPrice.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            productBuyPrice.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            productName.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            productName.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            productQuantity.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            productQuantity.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            productSellingPrice.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            productSellingPrice.BackColor = ColorTranslator.FromHtml(hagzWindow.back);


            //chairNumber.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            //chairNumber.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            //chairPrice.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            //chairPrice.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            comboBox1.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            comboBox1.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            comboBox2.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            comboBox2.BackColor = ColorTranslator.FromHtml(hagzWindow.back);




            db = new DataB();
            db.getconnection();
            //SQLiteDataReader reader;
            //try
            //{
            //    db.openConnection();
            //    reader = db.readme("SELECT * FROM Chairs ORDER BY ROWID ASC LIMIT 1;");
            //    reader.Read();
            //    chairNumber.Text = reader.GetInt32(0).ToString();
            //    chairPrice.Text = reader.GetDouble(1).ToString();
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(" - " + ee.ToString());
            //}
            //finally
            //{
            //    db.closeConnection();
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int chairNumber;
            double chairPrice;
            if (int.TryParse(hagzroomChairNo.Text, out chairNumber) && double.TryParse(hagzPrice.Text, out chairPrice))
            {
                db.exe("INSERT INTO \"Room\"(\"roomName\",\"roomChairsNo\",\"roomPricePH\") " +
               "VALUES ('" + hagznameTxtbx.Text + "'," + chairNumber + "," + chairPrice + ");");
                hagznameTxtbx.Clear();
                hagzroomChairNo.Clear();
                hagzPrice.Clear();
            }
            else
                MessageBox.Show("خطأ في المدخلات");

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int productNumber;
            double productSelling;
            double productSBuy;
            if (int.TryParse(productQuantity.Text, out productNumber) &&
                double.TryParse(productSellingPrice.Text, out productSelling) &&
                double.TryParse(productBuyPrice.Text, out productSBuy))
            {
                db.exe("INSERT INTO \"Product\"(\"productName\",\"productBuyPrice\",\"productSellPrice\", \"productQuantity\") " +
                "VALUES ('" + productName.Text + "','" + productSBuy + "','" + productSelling + "'," + productNumber + ");");
                productQuantity.Clear();
                productSellingPrice.Clear();
                productBuyPrice.Clear();
                productName.Clear();
            }
            else
                MessageBox.Show("خطأ في المدخلات");
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                db.openConnection();
                SQLiteDataReader reader;
                reader = db.readme("select roomName FROM Room;");
                

                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
            }
            catch (SQLiteException ee)
            {
                MessageBox.Show(ee.ErrorCode + " - " + ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                db.openConnection();
                SQLiteDataReader reader;
                reader = db.readme("SELECT productName FROM Product;");


                comboBox2.Items.Clear();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString(0));
                }
            }
            catch (SQLiteException ee)
            {
                MessageBox.Show(ee.ErrorCode + " - " + ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                db.openConnection();
                SQLiteDataReader reader;
                reader = db.readme("SELECT * FROM Product WHERE productName = \"" + comboBox2.Text + "\";");
                reader.Read();
                editproductBuyPrice.Text = reader.GetDouble(2).ToString();
                editproductSellPrice.Text = reader.GetDouble(3).ToString();
                editproductQuantity.Text = reader.GetInt32(4).ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(" - " + ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SQLiteDataReader reader;
                reader = db.readme("SELECT * FROM Room WHERE roomName = \""+comboBox1.Text+"\";");
                reader.Read();
                edithagzRoomChairsNo.Text = reader.GetInt32(1).ToString();
                edithagzpriceTxtbx.Text = reader.GetDouble(2).ToString();
            }
            catch(Exception ee)
            {
                MessageBox.Show(" - " + ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }
        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    int Number;
        //    double Price;
        //    if (int.TryParse(chairNumber.Text, out Number) && double.TryParse(chairPrice.Text, out Price))
        //    {
        //        db.exe("UPDATE Chairs SET number = " + Number + ", price = " + Price + ";");
        //    }
        //    else
        //        MessageBox.Show("خطأ في المدخلات");
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            int chairNumber;
            double chairPrice;
            if (int.TryParse(edithagzRoomChairsNo.Text, out chairNumber) && double.TryParse(edithagzpriceTxtbx.Text, out chairPrice))
            {
                db.exe("UPDATE Room SET roomChairsNo = " + chairNumber +
                ", roomPricePH = " + chairPrice + " WHERE roomName = \"" + comboBox1.Text + "\";");
                edithagzRoomChairsNo.Clear();
                edithagzpriceTxtbx.Clear();
                comboBox1.Items.Clear();
            }
            else
                MessageBox.Show("خطأ في المدخلات");
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int productNumber;
            double productSelling;
            double productSBuy;
            if (int.TryParse(editproductQuantity.Text, out productNumber) &&
                double.TryParse(editproductSellPrice.Text, out productSelling) &&
                double.TryParse(editproductBuyPrice.Text, out productSBuy))
            {
                db.exe("UPDATE Product SET productBuyPrice = " + productSBuy + ", productSellPrice = "
                + productSelling + ", productQuantity = " +
                productNumber + " Where productName = \"" + comboBox2.Text + "\";");
                editproductQuantity.Clear();
                editproductSellPrice.Clear();
                editproductBuyPrice.Clear();
                comboBox2.Items.Clear();
            }
            else
                MessageBox.Show("خطأ في المدخلات");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.exe("DELETE FROM Product WHERE productName = \""+comboBox2.Text+"\";");
            editproductSellPrice.Clear();
            editproductQuantity.Clear();
            editproductBuyPrice.Clear();
            comboBox2.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            db.exe("DELETE FROM Room WHERE roomName = \""+comboBox1.Text+"\";");
            edithagzpriceTxtbx.Clear();
            edithagzRoomChairsNo.Clear();
            comboBox1.Items.Clear();
        }
    }
}
