using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Management;

namespace WorkspaceAdminProject
{
    /////////////////////////
    //   done at 2020/11/5 //
    //   paulo emil        //
    //   01554148331       //
    //   fb./buglawer      //
    /////////////////////////
    class DataB
    {
        public string connectionstring { get; set; }
        string connection;
        SQLiteConnection con;
        public void getconnection()
        {
            connection = @"DataSource=paulo.db; Version=3;Pooling=true;";
            connectionstring = connection;
        }
        public DataB()
        {
            if (!File.Exists("./paulo.db"))
            {
                SQLiteConnection.CreateFile("./paulo.db");
                getconnection();
                con = new SQLiteConnection(connection);
                string query;
                #region DataBase Creation
                    query = "CREATE TABLE Admin (username TEXT,password    TEXT NOT NULL DEFAULT 'password',name TEXT NOT NULL,PRIMARY KEY(username))";
                    exe(query); // Admin Table

                    query = "CREATE TABLE Product (productID INTEGER PRIMARY KEY AUTOINCREMENT, productName   TEXT NOT NULL UNIQUE, productBuyPrice    REAL NOT NULL, productSellPrice  REAL NOT NULL, productQuantity   INTEGER NOT NULL)";
                    exe(query);

                    query = "CREATE TABLE Room (roomName	TEXT,roomChairsNo	INTEGER NOT NULL,roomPricePH	REAL NOT NULL,PRIMARY KEY(roomName))";
                    exe(query);

                    query = "CREATE TABLE hagz (hagzID	INTEGER PRIMARY KEY AUTOINCREMENT,Name	" +
                            "TEXT NOT NULL,username	TEXT NOT NULL,RoomName	TEXT,TimeTaken	TEXT NOT NULL," +
                            "TotalProduct	REAL NOT NULL,Totala	REAL NOT NULL,Time	TEXT NOT NULL," +
                            "Day	INTEGER NOT NULL,Month	INTEGER NOT NULL,Year	INTEGER NOT NULL," +
                            "FOREIGN KEY(username) REFERENCES Admin(username)," +
                            "FOREIGN KEY(RoomName) REFERENCES Room(roomName) ON UPDATE CASCADE)";
                    exe(query);

                    query = "CREATE TABLE productSold (ID	INTEGER PRIMARY KEY AUTOINCREMENT," +
                            "productID	INTEGER NOT NULL,hagzID	INTEGER NOT NULL," +
                            "day	INTEGER NOT NULL,month	INTEGER NOT NULL," +
                            "year	INTEGER NOT NULL,FOREIGN KEY(productID) REFERENCES Product(productID)," +
                            "FOREIGN KEY(hagzID) REFERENCES hagz(hagzID) ON DELETE CASCADE)";
                    exe(query);

                    query = "CREATE VIEW product_sold_view as select productSold.ID as 'م'," +
                            "Product.productName as 'إسم المنتج',Admin.name as 'المسؤول'," +
                            " hagz.Name as 'الحجز بإسم', Product.productBuyPrice as سعر_البيع," +
                            "Product.productSellPrice as 'سعر البيع'," +
                            "productSold.year||'/'||productSold.month||'/'||productSold.day as 'التاريخ' " +
                            "from Product,productSold, hagz, Admin " +
                            "where productSold.productID = Product.productID and" +
                            " hagz.hagzID = productSold.hagzID and hagz.username = Admin.username";
                    exe(query);

                    query = "CREATE VIEW hagzView as select hagzID as 'م'," +
                            " Name as 'الإسم',  username as 'المسؤول'," +
                            " RoomName as 'إسم الغرفة', TimeTaken as 'الوقت المحسوب'," +
                            " TotalProduct as 'حساب الطلبات', Totala as 'مجموع الحساب'," +
                            " Time as 'الوقت', year ||'/'|| month ||'/'|| day as 'التاريخ' from hagz";
                    exe(query);

                    query = "CREATE VIEW buySellPriceView as select Product.productBuyPrice," +
                            "Product.productSellPrice from Product," +
                            "productSold where productSold.productID = Product.productID";
                    exe(query);

                    
                    query = "INSERT INTO Admin (username, name) VALUES (0, 'Paulo')";
                    exe(query);

                    query = "INSERT INTO Product VALUES (null, 'CokaCola', 5, 15, 150);" +
                            "INSERT INTO Product VALUES (null, 'Ice Tea', 10, 25, 50);" +
                            "INSERT INTO Product VALUES (null, 'Green Tea', 1, 10, 500);" +
                            "INSERT INTO Product VALUES (null, 'Water (small)', 3, 10, 100);" +
                            "INSERT INTO Product VALUES (null, 'Water (big)', 5, 15, 5);";
                    exe(query);

                    query = "INSERT INTO Room VALUES ('Bomb room',50,500);" +
                            "INSERT INTO Room VALUES ('Techno room',10,130);" +
                            "INSERT INTO Room VALUES ('Space room',30,160);" +
                            "INSERT INTO Room VALUES ('Mazareta',200,150);" +
                            "INSERT INTO Room VALUES ('PC room',5,250);";
                    exe(query);

                    query = "INSERT INTO hagz VALUES (NULL,'dummie','0',NULL,'00:00:00','20','80','00:00:00',6,6,2000);";
                    exe(query);

                    //query = "INSERT INTO productSold VALUES (NULL, 1, 1, 6, 6, 2000)";
                    //exe(query);

                    //query = "";
                    //exe(query);

                    //query = "";
                    //exe(query);

                    query = "PRAGMA foreign_keys = ON;";
                    exe(query);
                //query = "";
                //exe(query);
                #endregion

            }
            else
            {
                getconnection();
                con = new SQLiteConnection(connection);
            }
        }
        public void exe(string q)
        {
            try
            {
                openConnection();
                SQLiteCommand command = new SQLiteCommand(q, con);
                command.ExecuteNonQuery();
            }
            catch (SQLiteException ee)
            {
                if (ee.ErrorCode == 19)
                {
                    MessageBox.Show("الإسم موجود مسبقاً");
                }
                else
                    MessageBox.Show(ee.ErrorCode.ToString() + " - " + ee.ToString());

            }
            finally
            {
                closeConnection();
            }
        }
        public SQLiteConnection Con
        {
            get { return this.con; }

        }
        public SQLiteDataReader readme(string q)
        {
            SQLiteCommand command = new SQLiteCommand(q, con);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }
        public void openConnection()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
        }
        public void closeConnection()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }
    }
}
