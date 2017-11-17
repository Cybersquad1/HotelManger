namespace HotelManger
{
    partial class BookRoom
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
            this.RoomInfo = new System.Windows.Forms.GroupBox();
            this.RoomDesc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxCustNum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bedNum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RoomType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RoomNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckOutTime = new System.Windows.Forms.DateTimePicker();
            this.CheckInTime = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Cash = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RoomPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CustCheckIn = new System.Windows.Forms.Button();
            this.CustIDNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CustName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Clear = new System.Windows.Forms.Button();
            this.DeleteInfo = new System.Windows.Forms.Button();
            this.CustInfo = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookIn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.RoomStatus = new System.Windows.Forms.ComboBox();
            this.RoomInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // RoomInfo
            // 
            this.RoomInfo.Controls.Add(this.RoomDesc);
            this.RoomInfo.Controls.Add(this.label2);
            this.RoomInfo.Controls.Add(this.MaxCustNum);
            this.RoomInfo.Controls.Add(this.label6);
            this.RoomInfo.Controls.Add(this.bedNum);
            this.RoomInfo.Controls.Add(this.label4);
            this.RoomInfo.Controls.Add(this.RoomType);
            this.RoomInfo.Controls.Add(this.label3);
            this.RoomInfo.Controls.Add(this.RoomNumber);
            this.RoomInfo.Controls.Add(this.label1);
            this.RoomInfo.Location = new System.Drawing.Point(13, 13);
            this.RoomInfo.Name = "RoomInfo";
            this.RoomInfo.Size = new System.Drawing.Size(241, 229);
            this.RoomInfo.TabIndex = 0;
            this.RoomInfo.TabStop = false;
            this.RoomInfo.Text = "房间信息";
            // 
            // RoomDesc
            // 
            this.RoomDesc.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RoomDesc.Location = new System.Drawing.Point(82, 138);
            this.RoomDesc.Name = "RoomDesc";
            this.RoomDesc.Size = new System.Drawing.Size(153, 91);
            this.RoomDesc.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "房间介绍：";
            // 
            // MaxCustNum
            // 
            this.MaxCustNum.AutoSize = true;
            this.MaxCustNum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaxCustNum.Location = new System.Drawing.Point(92, 109);
            this.MaxCustNum.Name = "MaxCustNum";
            this.MaxCustNum.Size = new System.Drawing.Size(0, 20);
            this.MaxCustNum.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(7, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "最大人数：";
            // 
            // bedNum
            // 
            this.bedNum.AutoSize = true;
            this.bedNum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bedNum.Location = new System.Drawing.Point(52, 79);
            this.bedNum.Name = "bedNum";
            this.bedNum.Size = new System.Drawing.Size(0, 20);
            this.bedNum.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(7, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "床数：";
            // 
            // RoomType
            // 
            this.RoomType.AutoSize = true;
            this.RoomType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RoomType.Location = new System.Drawing.Point(52, 50);
            this.RoomType.Name = "RoomType";
            this.RoomType.Size = new System.Drawing.Size(0, 20);
            this.RoomType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "类型：";
            // 
            // RoomNumber
            // 
            this.RoomNumber.AutoSize = true;
            this.RoomNumber.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RoomNumber.Location = new System.Drawing.Point(68, 21);
            this.RoomNumber.Name = "RoomNumber";
            this.RoomNumber.Size = new System.Drawing.Size(0, 20);
            this.RoomNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "房间号：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RoomStatus);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.CheckOutTime);
            this.groupBox1.Controls.Add(this.CheckInTime);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Cash);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.RoomPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(272, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 229);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "价格结算";
            // 
            // CheckOutTime
            // 
            this.CheckOutTime.CustomFormat = "yyyy-MM-dd hh:mm";
            this.CheckOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CheckOutTime.Location = new System.Drawing.Point(10, 161);
            this.CheckOutTime.Name = "CheckOutTime";
            this.CheckOutTime.Size = new System.Drawing.Size(200, 21);
            this.CheckOutTime.TabIndex = 15;
            // 
            // CheckInTime
            // 
            this.CheckInTime.CustomFormat = "yyyy-MM-dd hh:mm";
            this.CheckInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CheckInTime.Location = new System.Drawing.Point(10, 108);
            this.CheckInTime.Name = "CheckInTime";
            this.CheckInTime.Size = new System.Drawing.Size(200, 21);
            this.CheckInTime.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(6, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "退房时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "入住时间：";
            // 
            // Cash
            // 
            this.Cash.Location = new System.Drawing.Point(63, 49);
            this.Cash.Name = "Cash";
            this.Cash.Size = new System.Drawing.Size(57, 21);
            this.Cash.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(6, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "押金：";
            // 
            // RoomPrice
            // 
            this.RoomPrice.AutoSize = true;
            this.RoomPrice.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RoomPrice.Location = new System.Drawing.Point(63, 21);
            this.RoomPrice.Name = "RoomPrice";
            this.RoomPrice.Size = new System.Drawing.Size(0, 20);
            this.RoomPrice.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "房价：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CustCheckIn);
            this.groupBox2.Controls.Add(this.CustIDNumber);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.CustName);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 138);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入住旅客登记";
            // 
            // CustCheckIn
            // 
            this.CustCheckIn.Location = new System.Drawing.Point(86, 102);
            this.CustCheckIn.Name = "CustCheckIn";
            this.CustCheckIn.Size = new System.Drawing.Size(75, 23);
            this.CustCheckIn.TabIndex = 19;
            this.CustCheckIn.Text = "登记";
            this.CustCheckIn.UseVisualStyleBackColor = true;
            this.CustCheckIn.Click += new System.EventHandler(this.CustCheckIn_Click);
            // 
            // CustIDNumber
            // 
            this.CustIDNumber.Location = new System.Drawing.Point(95, 60);
            this.CustIDNumber.Name = "CustIDNumber";
            this.CustIDNumber.Size = new System.Drawing.Size(139, 21);
            this.CustIDNumber.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(6, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "身份证号码：";
            // 
            // CustName
            // 
            this.CustName.Location = new System.Drawing.Point(64, 27);
            this.CustName.Name = "CustName";
            this.CustName.Size = new System.Drawing.Size(171, 21);
            this.CustName.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(7, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "姓名：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Clear);
            this.groupBox3.Controls.Add(this.DeleteInfo);
            this.groupBox3.Controls.Add(this.CustInfo);
            this.groupBox3.Location = new System.Drawing.Point(271, 248);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 138);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "入住旅客信息确认";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(135, 104);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "清除";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // DeleteInfo
            // 
            this.DeleteInfo.Location = new System.Drawing.Point(26, 104);
            this.DeleteInfo.Name = "DeleteInfo";
            this.DeleteInfo.Size = new System.Drawing.Size(75, 23);
            this.DeleteInfo.TabIndex = 1;
            this.DeleteInfo.Text = "删除";
            this.DeleteInfo.UseVisualStyleBackColor = true;
            this.DeleteInfo.Click += new System.EventHandler(this.DeleteInfo_Click);
            // 
            // CustInfo
            // 
            this.CustInfo.AllowUserToAddRows = false;
            this.CustInfo.AllowUserToDeleteRows = false;
            this.CustInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.IDNumber});
            this.CustInfo.Location = new System.Drawing.Point(7, 21);
            this.CustInfo.Name = "CustInfo";
            this.CustInfo.ReadOnly = true;
            this.CustInfo.RowHeadersWidth = 20;
            this.CustInfo.RowTemplate.Height = 23;
            this.CustInfo.Size = new System.Drawing.Size(227, 77);
            this.CustInfo.TabIndex = 0;
            // 
            // Name
            // 
            this.Name.HeaderText = "姓名";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 75;
            // 
            // IDNumber
            // 
            this.IDNumber.HeaderText = "身份证号码";
            this.IDNumber.Name = "IDNumber";
            this.IDNumber.ReadOnly = true;
            this.IDNumber.Width = 130;
            // 
            // BookIn
            // 
            this.BookIn.Location = new System.Drawing.Point(227, 405);
            this.BookIn.Name = "BookIn";
            this.BookIn.Size = new System.Drawing.Size(75, 23);
            this.BookIn.TabIndex = 4;
            this.BookIn.Text = "入住登记";
            this.BookIn.UseVisualStyleBackColor = true;
            this.BookIn.Click += new System.EventHandler(this.BookIn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(6, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "房间状态：";
            // 
            // RoomStatus
            // 
            this.RoomStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoomStatus.FormattingEnabled = true;
            this.RoomStatus.Location = new System.Drawing.Point(88, 197);
            this.RoomStatus.Name = "RoomStatus";
            this.RoomStatus.Size = new System.Drawing.Size(121, 20);
            this.RoomStatus.TabIndex = 17;
            // 
            // BookRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 443);
            this.Controls.Add(this.BookIn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RoomInfo);
            //this.Name = "BookRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BookRoomForm_FormClosing);
            this.RoomInfo.ResumeLayout(false);
            this.RoomInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RoomInfo;
        private System.Windows.Forms.Label RoomDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MaxCustNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label bedNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label RoomType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RoomNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker CheckOutTime;
        private System.Windows.Forms.DateTimePicker CheckInTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Cash;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label RoomPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button CustCheckIn;
        private System.Windows.Forms.TextBox CustIDNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox CustName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button DeleteInfo;
        private System.Windows.Forms.DataGridView CustInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNumber;
        private System.Windows.Forms.Button BookIn;
        private System.Windows.Forms.ComboBox RoomStatus;
        private System.Windows.Forms.Label label12;
    }
}