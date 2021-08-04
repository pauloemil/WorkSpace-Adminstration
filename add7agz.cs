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
    public partial class add7agz : Form
    {
        DataB db;
        
        double price;
        public double Price
        {
            get { return price; }
        }
        string name;
        public string theName
        {
            get { return name; }
        }
        bool ischair;
        public bool isChair
        {
            get { return ischair; }
        }
        string roomname = "";
        public string roomName
        {
            get { return roomname; }
        }
        double time = 0;
        public double Time
        {
            get { return time; }
        }
        bool open = true;
        public bool Open
        {
            get { return open; }
        }
        public add7agz()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                db.openConnection();
                hagzWindow ff = new hagzWindow();
                if (korseRB.Checked)
                {
                    
                    if (!ff.isAvailable)
                    {
                        MessageBox.Show("لا يوجد كراسي فارغه حالياً");
                        return;
                    }
                    ischair = true;
                    price = 30;
                }
                else 
                {
                    
                    ischair = false;
                    if (hagzcmbobx.Text != "")
                    {
                        roomname = hagzcmbobx.Text;
                        SQLiteDataReader reader;
                        reader = db.readme("SELECT roomPricePH FROM Room WHERE roomName = \"" + hagzcmbobx.Text + "\";");
                        reader.Read();
                        price = reader.GetDouble(0);
                    }
                    else
                    {
                        MessageBox.Show("يجب اختيار غرفة اولاً");
                        return;
                    }
                }
                

                name = nametxt.Text;
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(" - " + ee.ToString());
            }
            finally
            {
                db.closeConnection();
            }
            
            if (mo7adadchkbx.Checked == true)
            {
                if (!double.TryParse(timetxtbx.Text, out time))
                {
                    MessageBox.Show("ادخل قيمة صحيحة اولاً");
                    return;
                }
                time *= 60;
                if (hourchkbx.Checked == true)
                    time *= 60;
                open = false;
            }
            this.Close();
        }

        private void checkbox_changing(object sender, EventArgs e)
        {
            if (mo7adadchkbx.Checked == true)
                panel3.Enabled = true;
            else
                panel3.Enabled = false;
        }

        private void add7agz_Load(object sender, EventArgs e)
        {
            db = new DataB();
            db.getconnection();
            hagzWindow ff = new hagzWindow();
            roomRB.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            korseRB.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            hourchkbx.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            minchkbx.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            openchkbx.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            mo7adadchkbx.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            addbtn.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            label1.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);

            nametxt.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            nametxt.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            timetxtbx.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            timetxtbx.BackColor = ColorTranslator.FromHtml(hagzWindow.back);

            hagzcmbobx.ForeColor = ColorTranslator.FromHtml(hagzWindow.fore);
            hagzcmbobx.BackColor = ColorTranslator.FromHtml(hagzWindow.back);


            this.BackColor = ColorTranslator.FromHtml(hagzWindow.back);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SQLiteDataReader reader;
                hagzWindow ff = new hagzWindow();
                if (roomRB.Checked)
                {
                    reader = db.readme("select roomName FROM Room;");
                    hagzcmbobx.Items.Clear();
                    while (reader.Read())
                    {
                        if (!ff.busyPlacesList.Contains(reader.GetString(0)))
                        {
                            hagzcmbobx.Items.Add(reader.GetString(0));
                        }
                        
                    }
                    hagzcmbobx.Enabled = true;
                }
                else
                {
                    hagzcmbobx.Enabled = false;
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

        private void hagzcmbobx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
