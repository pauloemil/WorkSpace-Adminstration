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
    public partial class grdWindow : Form
    {
        DataB db;
        public grdWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productGridView.Visible = true;
            roomGridView.Visible = false;
            ProductSoldGridView.Visible = false;
            hagzGridView.Visible = false;
            productGridView.Rows.Clear();
            try
            {
                db.openConnection();
                SQLiteDataReader reader;
                reader = db.readme("select * FROM Product;");
                while (reader.Read())
                {
                    var index = productGridView.Rows.Add();
                    productGridView.Rows[index].Cells[0].Value = reader.GetInt32(0).ToString();
                    productGridView.Rows[index].Cells[1].Value = reader.GetString(1);
                    productGridView.Rows[index].Cells[2].Value = reader.GetDouble(2).ToString();
                    productGridView.Rows[index].Cells[3].Value = reader.GetDouble(3).ToString();
                    productGridView.Rows[index].Cells[4].Value = reader.GetInt32(4).ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void grdWindow_Load(object sender, EventArgs e)
        {
            db = new DataB();
            db.getconnection();
            this.BackColor = ColorTranslator.FromHtml(hagzWindow.back);
            button1.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            button2.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            button3.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            button4.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            hagzGridView.BackgroundColor = ColorTranslator.FromHtml(hagzWindow.back);
            productGridView.BackgroundColor = ColorTranslator.FromHtml(hagzWindow.back);
            roomGridView.BackgroundColor = ColorTranslator.FromHtml(hagzWindow.back);
            ProductSoldGridView.BackgroundColor = ColorTranslator.FromHtml(hagzWindow.back);

            

            hagzGridView.GridColor = ColorTranslator.FromHtml(hagzWindow.back);
            productGridView.GridColor = ColorTranslator.FromHtml(hagzWindow.back);
            roomGridView.GridColor = ColorTranslator.FromHtml(hagzWindow.back);
            ProductSoldGridView.GridColor = ColorTranslator.FromHtml(hagzWindow.back);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            productGridView.Visible = false;
            roomGridView.Visible = true;
            ProductSoldGridView.Visible = false;
            hagzGridView.Visible = false;
            roomGridView.Rows.Clear();
            try
            {
                db.openConnection();
                SQLiteDataReader reader;
                reader = db.readme("select * FROM Room;");
                while (reader.Read())
                {
                    var index = roomGridView.Rows.Add();
                    roomGridView.Rows[index].Cells[0].Value = reader.GetString(0);
                    roomGridView.Rows[index].Cells[1].Value = reader.GetInt32(1).ToString();
                    roomGridView.Rows[index].Cells[2].Value = reader.GetDouble(2).ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            productGridView.Visible = false;
            roomGridView.Visible = false;
            ProductSoldGridView.Visible = false;
            hagzGridView.Visible = true;
            //hagzGridView.Rows.Clear();
            try
            {
                DataTable ds = new DataTable();
                SQLiteDataReader reader;
                db.openConnection();
                reader = db.readme("select * from hagzView;");
                try
                {
                    if (reader.Read())
                    {
                        ds.Load(reader);
                    }
                    hagzGridView.DataSource = ds;
                    hagzGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    hagzGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }

            }
            catch (InvalidCastException)
            {
                MessageBox.Show("No data to show yet.");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }
            /*try
            {
                db.openConnection();
                DataTable dt = new DataTable();
                SQLiteDataReader reader;
                db.openConnection();
                reader = db.readme("select * from hagzView;");
                if (reader.Read())
                {
                    dt.Load(reader);
                    hagzGridView.DataSource = dt;
                    hagzGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    hagzGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                
            
                //while(reader.Read())
                //{
                //    var index = hagzGridView.Rows.Add();
                //    hagzGridView.Rows[index].Cells[0].Value = reader.GetInt32(0).ToString();
                //    hagzGridView.Rows[index].Cells[1].Value = reader.GetString(1);
                //    hagzGridView.Rows[index].Cells[2].Value = reader.GetString(2);
                //    hagzGridView.Rows[index].Cells[3].Value = reader.GetString(3);
                //    hagzGridView.Rows[index].Cells[4].Value = reader.GetDouble(4).ToString();
                //    hagzGridView.Rows[index].Cells[5].Value = reader.GetDouble(5).ToString();
                //    hagzGridView.Rows[index].Cells[6].Value = reader.GetDouble(6);
                //    hagzGridView.Rows[index].Cells[7].Value = reader.GetString(7);
                //    hagzGridView.Rows[index].Cells[8].Value = reader.GetDouble(10).ToString() + "/" + reader.GetDouble(9).ToString() + "/" + reader.GetDouble(8).ToString();
                //}
        }
            catch (InvalidCastException ee)
            {
                MessageBox.Show("No data to show yet.");
            }
            catch (ArgumentOutOfRangeException ee)
            {
                MessageBox.Show("No data to show yet.");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            productGridView.Visible = false;
            roomGridView.Visible = false;
            ProductSoldGridView.Visible = true;
            hagzGridView.Visible = false;
            

            try
            {
                DataTable ds = new DataTable();
                SQLiteDataReader reader;
                db.openConnection();
                reader = db.readme("select * from product_sold_view;");
                if (reader.Read())
                {
                    ds.Load(reader);
                }

                reader = db.readme("select sum(productBuyPrice), sum(productSellPrice), sum(productSellPrice) - sum(productBuyPrice) from buySellPriceView;");
                if (reader.Read())
                {
                    float buyPrice = reader.GetFloat(0);
                    float sellPrice = reader.GetFloat(1);
                    float total = reader.GetFloat(2);
                    try
                    {
                        DataRow row1 = ds.NewRow();
                        row1[0] = 0;
                        row1[1] = 0;
                        row1[2] = 0;
                        row1[3] = 0;
                        row1[4] = 0;
                        row1[5] = 0;
                        row1[6] = 0;
                        ds.Rows.Add(row1);

                        DataRow row2 = ds.NewRow();
                        row2[0] = 0;
                        row2[1] = 0;
                        row2[2] = 0;
                        row2[3] = 0;
                        row2[4] = buyPrice;
                        row2[5] = sellPrice;
                        row2[6] = total;
                        ds.Rows.Add(row2);
                        ProductSoldGridView.DataSource = ds;
                        ProductSoldGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        ProductSoldGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.ToString());
                    }

                }
                



            }
            catch (InvalidCastException)
            {
                MessageBox.Show("No data to show yet.");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }
            /*try
            {
                db.openConnection();
                SQLiteDataReader reader, secReader;
                //reader = db.readme("select * FROM productSold;");
                reader = db.readme("SELECT * from product_sold_view; ");
                var index = ProductSoldGridView.Rows.Add();
                while (reader.Read())
                {
                    //secReader = db.readme("SELECT * FROM Product WHERE productID = "+reader.GetInt32(1)+";");
                    //secReader.Read();
                    
                    ProductSoldGridView.Rows[index].Cells[0].Value = reader.GetInt32(0).ToString();
                    ProductSoldGridView.Rows[index].Cells[1].Value = reader.GetInt32(1).ToString();
                    ProductSoldGridView.Rows[index].Cells[2].Value = reader.GetString(2);
                    ProductSoldGridView.Rows[index].Cells[3].Value = reader.GetDouble(3).ToString();
                    ProductSoldGridView.Rows[index].Cells[4].Value = reader.GetDouble(4).ToString();
                    ProductSoldGridView.Rows[index].Cells[5].Value = reader.GetString(5);

                    index = ProductSoldGridView.Rows.Add();
                }
                
                reader = db.readme("select sum(productBuyPrice), sum(productSellPrice), sum(productSellPrice) - sum(productBuyPrice) from product_sold_view;");
                if(reader.Read())
                {
                    ProductSoldGridView.Rows[index].Cells[3].Value = "إجمالي سعر الشراء";
                    ProductSoldGridView.Rows[index].Cells[4].Value = "إجمالي سعر البيع";
                    ProductSoldGridView.Rows[index].Cells[5].Value = "الربح";
                    index = ProductSoldGridView.Rows.Add();
                    try
                    {
                        ProductSoldGridView.Rows[index].Cells[3].Value = reader.GetFloat(0).ToString();
                        ProductSoldGridView.Rows[index].Cells[4].Value = reader.GetFloat(1).ToString();
                        ProductSoldGridView.Rows[index].Cells[5].Value = reader.GetFloat(2).ToString();
                    }
                    catch(InvalidCastException ee)
                    {
                        
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }

                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }*/
        }

        private void hagzGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
