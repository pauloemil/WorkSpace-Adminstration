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
    public partial class hagzWindow : Form
    {
        string username;
        public static string fore = "#f2efea";
        //public static string fore = "#ff6768"; //red
        public static string back = "#556052";
        DataB db;
        static List<string> busyPlaces = new List<string>();
        public List<string> busyPlacesList
        {
            get{ return busyPlaces; }
        }
        static int chairsAvailable;
        public bool isAvailable
        {
            get { return chairsAvailable > 0; }
        }
        public hagzWindow()
        {
            InitializeComponent();
        }
        

        public GroupBox creatorGB(bool isChair, string roomName, string humanName, bool open, double time, double price)
        {
            string name;
            int hagzID;
            string curr_time;
            string day;
            string month;
            string year;
            if (isChair)
            {
                name = "Chair - " + humanName;
                chairsAvailable -= 1;
            }
            else
            {
                name = roomName + " - " + humanName;
                busyPlaces.Add(roomName);
            }
            var list = new List<Tuple<Tuple<int, string>, double>>();
            double sec = 0;
            int elapsedSec = 0;
            string startTime = DateTime.Now.ToString("h:mm tt");
            

            Button stop = new Button();
            Timer timer1 = new Timer();
            GroupBox gb1 = new GroupBox();
            ComboBox cb1 = new ComboBox();
            Label l1 = new Label();
            Button add = new Button();

            gb1.Size = new Size(229, 196);
            add.Size = new Size(213, 43);
            cb1.Size = new Size(213, 24);
            stop.Size = new Size(213, 43);

            l1.Location = new Point(92, 34);
            cb1.Location = new Point(9, 64);
            add.Location = new Point(9, 94);
            stop.Location = new Point(9, 143);

            stop.FlatStyle = FlatStyle.Flat;
            add.FlatStyle = FlatStyle.Flat;
            cb1.FlatStyle = FlatStyle.Flat;

            stop.ForeColor = ColorTranslator.FromHtml(fore);
            add.ForeColor = ColorTranslator.FromHtml(fore);
            l1.ForeColor = ColorTranslator.FromHtml(fore);
            cb1.ForeColor = ColorTranslator.FromHtml(fore);
            gb1.ForeColor = ColorTranslator.FromHtml(fore);
            //gb1.BackColor = Color.Transparent;
            cb1.BackColor = ColorTranslator.FromHtml(back);

            gb1.Text = name;
            l1.Text = "00:00:00";
            gb1.Controls.Add(l1);
            //gb1.BackgroundImage = Properties.Resources.images;
            timer1.Interval = 1000;
            if (open)
                timer1.Tick += (s, e) => { sec++; elapsedSec++; l1.Text = TimeSpan.FromSeconds(sec).ToString("hh\\:mm\\:ss"); };
            else
            {
                sec = time;
                timer1.Tick += (s, e) =>
                {
                    sec--;
                    elapsedSec++;
                    l1.Text = TimeSpan.FromSeconds(sec).ToString("hh\\:mm\\:ss");
                    if (sec <= 0)
                        stop.PerformClick();
                };
            }
            timer1.Start();
            cb1.Items.Clear();
            stop.Text = "إنهاء";
            gb1.Controls.Add(stop);

            try
            {
                db.openConnection();
                SQLiteDataReader reader;
                reader = db.readme("SELECT productName FROM Product;");
                while (reader.Read())
                {
                    cb1.Items.Add(reader.GetString(0));
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(" - " + ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }
            cb1.DropDownStyle = ComboBoxStyle.DropDownList;
            gb1.Controls.Add(cb1);

            add.Text = "اضف مشروب";
            gb1.Controls.Add(add);

            stop.Click += (s, e) =>
            {
                string chairRoom;
                
                busyPlaces.Remove(name);
                deleter(gb1.Text);
                double total = 0;
                double productTotal;
                string message = "";
                string messsnaks = "";
                foreach (Tuple<Tuple<int, string>, double> tata in list)
                {
                    message += tata.Item1.Item2 + " " + tata.Item2 + " جم\n";
                    messsnaks += tata.Item1.Item2 + " " + tata.Item2 + " جم - ";
                    total += tata.Item2;
                }
                productTotal = total;
                message += "حساب الطلبات: " + total.ToString() + " جم\n\n";
                message += "وقت البدء: " + startTime + "\n";
                timer1.Stop();
                string elapsedTime = TimeSpan.FromSeconds(elapsedSec).ToString("hh\\:mm\\:ss");
                message += "الوقت المستهلك: " + elapsedTime + "\n";
                //message += "النوع: " + ((isSingle) ? "سينجل" : "مالتي") + "\n";
                message += "سعر الساعة: " + price.ToString() + " جم\n";
                double cash = (((elapsedSec / 60.0) / 60.0) * price);
                
                message += "حساب الوقت: " + cash.ToString("0.0") + " جم\n\n";
                message += "الحساب: " + (cash + total).ToString("0.0") + " جم";
                curr_time = DateTime.Now.ToString("h: mm tt");
                day = DateTime.Now.ToString("dd");
                month = DateTime.Now.ToString("MM");
                year = DateTime.Now.ToString("yyyy");
                message += "\n\nName: " + name;
                
                if (isChair)
                {
                    chairsAvailable += 1;
                    db.exe("INSERT INTO \"hagz\" (\"Name\", \"username\", \"TimeTaken\", \"TotalProduct\", \"Totala\",  \"Time\", \"Day\", \"Month\", \"Year\") VALUES " +
                    "(\"" + humanName + "\", \"" + username + "\", \"" + elapsedTime + "\", " + productTotal + ", " + (cash + total).ToString("0.0") + ", \"" + curr_time + "\", " + day + ", " + month + ", " + year + ");");
                }
                else
                {
                    busyPlaces.Remove(roomName);
                    chairRoom = roomName;
                    db.exe("INSERT INTO \"hagz\" (\"Name\", \"username\", \"RoomName\", \"TimeTaken\", \"TotalProduct\", \"Totala\",  \"Time\", \"Day\", \"Month\", \"Year\") VALUES " +
                    "(\"" + humanName + "\", \"" + username + "\", \"" + chairRoom + "\", \"" + elapsedTime + "\", " + productTotal + ", " + (cash + total).ToString("0.0") + ", \"" + curr_time + "\", " + day + ", " + month + ", " + year + ");");
                }
                

                try
                {
                    db.openConnection();
                    SQLiteDataReader reader = db.readme("SELECT last_insert_rowid()");//SELECT MAX(ID)  FROM productSold");
                    reader.Read();
                    hagzID = reader.GetInt32(0);
                    //MessageBox.Show(hagzID.ToString());
                    MessageBox.Show(message, name);
                    foreach (Tuple<Tuple<int, string>, double> tata in list)
                    {
                        day = DateTime.Now.ToString("dd");
                        month = DateTime.Now.ToString("MM");
                        year = DateTime.Now.ToString("yyyy");
                        db.exe("INSERT INTO productSold VALUES (NULL, " + tata.Item1.Item1 + ", " + hagzID + ", " + day + ", " + month + ", " + year + ");");
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
                
            };

            add.Click += (s, e) =>
            {
                try
                {
                    db.openConnection();
                    SQLiteDataReader reader;
                    reader = db.readme("SELECT productID, productSellPrice, productQuantity FROM Product WHERE productName = \"" + cb1.Text+"\";");
                    
                    if (reader.Read())
                    {
                        if (reader.GetInt32(2) > 0)
                        {
                            int productID = reader.GetInt32(0);
                            list.Add(Tuple.Create(Tuple.Create(reader.GetInt32(0), cb1.Text), reader.GetDouble(1)));
                            db.exe("UPDATE Product SET productQuantity = " + (reader.GetInt32(2) - 1).ToString() + " WHERE \"productID\" = "+ reader.GetInt32(0) + ";");
                        }
                        else
                            MessageBox.Show("نفذت كمية هذا المنتج");
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(" - " + ee.ToString());
                }
                finally
                {
                    db.closeConnection();
                    //cb1.Text = "";
                }
                
            };
            busyPlaces.Add(name);
            return gb1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add7agz add7agzObj = new add7agz();
            add7agzObj.ShowDialog();
            if (!string.IsNullOrEmpty(add7agzObj.theName))
            {
                flowLayoutPanel1.Controls.Add(creatorGB(add7agzObj.isChair, add7agzObj.roomName, add7agzObj.theName, add7agzObj.Open, add7agzObj.Time, add7agzObj.Price));
            }
            else
                MessageBox.Show("ضع الإسم اولاً");
        }

        private void hagzWindow_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.BackColor = Color.Transparent;
            this.BackColor =  ColorTranslator.FromHtml(back);
            button1.ForeColor = ColorTranslator.FromHtml(fore);
            button2.ForeColor = ColorTranslator.FromHtml(fore);
            button3.ForeColor = ColorTranslator.FromHtml(fore);
            button4.ForeColor = ColorTranslator.FromHtml(fore);
            button5.ForeColor = ColorTranslator.FromHtml(fore);
            label1.ForeColor = ColorTranslator.FromHtml(fore);
            label2.ForeColor = ColorTranslator.FromHtml(fore);
            textBox1.ForeColor = ColorTranslator.FromHtml(fore);
            textBox2.ForeColor = ColorTranslator.FromHtml(fore);
            groupBox1.ForeColor = ColorTranslator.FromHtml(fore);
            textBox1.BackColor = ColorTranslator.FromHtml(back);
            textBox2.BackColor = ColorTranslator.FromHtml(back);

            
            db = new DataB();
            db.getconnection();
            chairsAvailable = 2;
        }
        void deleter(string name)
        {
            foreach (Control cont in flowLayoutPanel1.Controls)
            {
                if (cont.Text == name)
                {
                    flowLayoutPanel1.Controls.Remove(cont);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addingEditingItems addingEditingItemsobj = new addingEditingItems();
            addingEditingItemsobj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grdWindow grdWindowobj = new grdWindow();
            grdWindowobj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count != 0)
                MessageBox.Show("برجاء إيقاف الحجوزات اولاً");
            else
                Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SQLiteDataReader reader = db.readme("select password from Admin where username='"+textBox1.Text+"';");//SELECT MAX(ID)  FROM productSold");
                if(reader.Read())
                {
                    if(textBox2.Text.Equals(reader.GetString(0)))
                    {
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        groupBox1.Visible = false;
                        username = textBox1.Text;
                        return;
                    }
                }
                MessageBox.Show("البيانات المدخله خاطئه");
                
                
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
    }
}
