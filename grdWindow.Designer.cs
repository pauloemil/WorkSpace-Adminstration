namespace WorkspaceAdminProject
{
    partial class grdWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.productGridView = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomGridView = new System.Windows.Forms.DataGridView();
            this.roomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomChairsNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomPricePH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductSoldGridView = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.hagzGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductSoldGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hagzGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(939, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "المنتجات";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(818, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 53);
            this.button2.TabIndex = 1;
            this.button2.Text = "الغرف";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(697, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 53);
            this.button3.TabIndex = 2;
            this.button3.Text = "المبيعات";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // productGridView
            // 
            this.productGridView.AllowUserToAddRows = false;
            this.productGridView.AllowUserToDeleteRows = false;
            this.productGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.productGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.productName,
            this.productBuyPrice,
            this.productSellPrice,
            this.productQuantity});
            this.productGridView.Location = new System.Drawing.Point(12, 71);
            this.productGridView.Name = "productGridView";
            this.productGridView.ReadOnly = true;
            this.productGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.productGridView.Size = new System.Drawing.Size(1042, 534);
            this.productGridView.TabIndex = 3;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "رقم التعريف";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            // 
            // productName
            // 
            this.productName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productName.HeaderText = "إسم المنتج";
            this.productName.Name = "productName";
            this.productName.ReadOnly = true;
            // 
            // productBuyPrice
            // 
            this.productBuyPrice.HeaderText = "سعر الشراء";
            this.productBuyPrice.Name = "productBuyPrice";
            this.productBuyPrice.ReadOnly = true;
            // 
            // productSellPrice
            // 
            this.productSellPrice.HeaderText = "سعر البييع";
            this.productSellPrice.Name = "productSellPrice";
            this.productSellPrice.ReadOnly = true;
            // 
            // productQuantity
            // 
            this.productQuantity.HeaderText = "الكمية";
            this.productQuantity.Name = "productQuantity";
            this.productQuantity.ReadOnly = true;
            // 
            // roomGridView
            // 
            this.roomGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.roomGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roomGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roomName,
            this.roomChairsNo,
            this.roomPricePH});
            this.roomGridView.Location = new System.Drawing.Point(13, 71);
            this.roomGridView.Name = "roomGridView";
            this.roomGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.roomGridView.Size = new System.Drawing.Size(1041, 534);
            this.roomGridView.TabIndex = 4;
            // 
            // roomName
            // 
            this.roomName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.roomName.HeaderText = "إسم الغرفة";
            this.roomName.Name = "roomName";
            // 
            // roomChairsNo
            // 
            this.roomChairsNo.HeaderText = "عدد الكراسي";
            this.roomChairsNo.Name = "roomChairsNo";
            // 
            // roomPricePH
            // 
            this.roomPricePH.HeaderText = "سعر الساعة";
            this.roomPricePH.Name = "roomPricePH";
            // 
            // ProductSoldGridView
            // 
            this.ProductSoldGridView.AllowUserToAddRows = false;
            this.ProductSoldGridView.AllowUserToDeleteRows = false;
            this.ProductSoldGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ProductSoldGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductSoldGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductSoldGridView.Location = new System.Drawing.Point(13, 71);
            this.ProductSoldGridView.Name = "ProductSoldGridView";
            this.ProductSoldGridView.ReadOnly = true;
            this.ProductSoldGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ProductSoldGridView.Size = new System.Drawing.Size(1041, 534);
            this.ProductSoldGridView.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(576, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 53);
            this.button4.TabIndex = 6;
            this.button4.Text = "الحجز";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // hagzGridView
            // 
            this.hagzGridView.AllowUserToAddRows = false;
            this.hagzGridView.AllowUserToDeleteRows = false;
            this.hagzGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.hagzGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hagzGridView.Location = new System.Drawing.Point(13, 71);
            this.hagzGridView.Name = "hagzGridView";
            this.hagzGridView.ReadOnly = true;
            this.hagzGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.hagzGridView.Size = new System.Drawing.Size(1041, 534);
            this.hagzGridView.TabIndex = 7;
            // 
            // grdWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1066, 617);
            this.Controls.Add(this.hagzGridView);
            this.Controls.Add(this.ProductSoldGridView);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.roomGridView);
            this.Controls.Add(this.productGridView);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "grdWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الجرد";
            this.Load += new System.EventHandler(this.grdWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductSoldGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hagzGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView productGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn productBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn productSellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn productQuantity;
        private System.Windows.Forms.DataGridView roomGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomChairsNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomPricePH;
        private System.Windows.Forms.DataGridView ProductSoldGridView;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView hagzGridView;
    }
}