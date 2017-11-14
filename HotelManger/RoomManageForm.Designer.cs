namespace HotelManger
{
    partial class RoomManageForm
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
            this.RoomList = new System.Windows.Forms.DataGridView();
            this.RoomNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumOfBeds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperItem = new System.Windows.Forms.TabControl();
            this.QueryItem = new System.Windows.Forms.TabPage();
            this.Query = new System.Windows.Forms.Button();
            this.QueryValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QueryType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChangeItem = new System.Windows.Forms.TabPage();
            this.SelectType = new System.Windows.Forms.ComboBox();
            this.ChangeValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangeType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Change = new System.Windows.Forms.Button();
            this.AddItem = new System.Windows.Forms.TabPage();
            this.NewRoomDesc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.NewRoomStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.NewNumCust = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NewBedNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.NewRoomType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NewRoomName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RemoveItem = new System.Windows.Forms.TabPage();
            this.DeleteRoom = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Init = new System.Windows.Forms.TabPage();
            this.Refresh = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RoomList)).BeginInit();
            this.OperItem.SuspendLayout();
            this.QueryItem.SuspendLayout();
            this.ChangeItem.SuspendLayout();
            this.AddItem.SuspendLayout();
            this.RemoveItem.SuspendLayout();
            this.Init.SuspendLayout();
            this.SuspendLayout();
            // 
            // RoomList
            // 
            this.RoomList.AllowUserToAddRows = false;
            this.RoomList.AllowUserToDeleteRows = false;
            this.RoomList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomNum,
            this.RoomType,
            this.NumOfBeds,
            this.MaxCust,
            this.RoomStatus,
            this.RoomDesc});
            this.RoomList.Location = new System.Drawing.Point(28, 12);
            this.RoomList.Name = "RoomList";
            this.RoomList.ReadOnly = true;
            this.RoomList.RowTemplate.Height = 23;
            this.RoomList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RoomList.Size = new System.Drawing.Size(643, 150);
            this.RoomList.TabIndex = 0;
            // 
            // RoomNum
            // 
            this.RoomNum.HeaderText = "房间号";
            this.RoomNum.Name = "RoomNum";
            this.RoomNum.ReadOnly = true;
            // 
            // RoomType
            // 
            this.RoomType.HeaderText = "房间类型";
            this.RoomType.Name = "RoomType";
            this.RoomType.ReadOnly = true;
            // 
            // NumOfBeds
            // 
            this.NumOfBeds.HeaderText = "床数";
            this.NumOfBeds.Name = "NumOfBeds";
            this.NumOfBeds.ReadOnly = true;
            // 
            // MaxCust
            // 
            this.MaxCust.HeaderText = "最大旅客数";
            this.MaxCust.Name = "MaxCust";
            this.MaxCust.ReadOnly = true;
            // 
            // RoomStatus
            // 
            this.RoomStatus.HeaderText = "房间状态";
            this.RoomStatus.Name = "RoomStatus";
            this.RoomStatus.ReadOnly = true;
            // 
            // RoomDesc
            // 
            this.RoomDesc.HeaderText = "房间描述";
            this.RoomDesc.Name = "RoomDesc";
            this.RoomDesc.ReadOnly = true;
            // 
            // OperItem
            // 
            this.OperItem.Controls.Add(this.QueryItem);
            this.OperItem.Controls.Add(this.ChangeItem);
            this.OperItem.Controls.Add(this.AddItem);
            this.OperItem.Controls.Add(this.RemoveItem);
            this.OperItem.Controls.Add(this.Init);
            this.OperItem.Location = new System.Drawing.Point(28, 169);
            this.OperItem.Name = "OperItem";
            this.OperItem.SelectedIndex = 0;
            this.OperItem.Size = new System.Drawing.Size(643, 138);
            this.OperItem.TabIndex = 1;
            this.OperItem.SelectedIndexChanged += new System.EventHandler(this.OperItem_SelectedIndexChanged);
            // 
            // QueryItem
            // 
            this.QueryItem.Controls.Add(this.label13);
            this.QueryItem.Controls.Add(this.Query);
            this.QueryItem.Controls.Add(this.QueryValue);
            this.QueryItem.Controls.Add(this.label2);
            this.QueryItem.Controls.Add(this.QueryType);
            this.QueryItem.Controls.Add(this.label1);
            this.QueryItem.Location = new System.Drawing.Point(4, 22);
            this.QueryItem.Name = "QueryItem";
            this.QueryItem.Padding = new System.Windows.Forms.Padding(3);
            this.QueryItem.Size = new System.Drawing.Size(635, 112);
            this.QueryItem.TabIndex = 0;
            this.QueryItem.Text = "查询";
            this.QueryItem.UseVisualStyleBackColor = true;
            // 
            // Query
            // 
            this.Query.Location = new System.Drawing.Point(503, 44);
            this.Query.Name = "Query";
            this.Query.Size = new System.Drawing.Size(75, 23);
            this.Query.TabIndex = 4;
            this.Query.Text = "查询";
            this.Query.UseVisualStyleBackColor = true;
            this.Query.Click += new System.EventHandler(this.Query_Click);
            // 
            // QueryValue
            // 
            this.QueryValue.Location = new System.Drawing.Point(376, 44);
            this.QueryValue.Name = "QueryValue";
            this.QueryValue.Size = new System.Drawing.Size(100, 21);
            this.QueryValue.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(306, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "查询值：";
            // 
            // QueryType
            // 
            this.QueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QueryType.FormattingEnabled = true;
            this.QueryType.Items.AddRange(new object[] {
            "房间号",
            "房间类型",
            "床数",
            "最大旅客数",
            "房间状态",
            "描述"});
            this.QueryType.Location = new System.Drawing.Point(164, 45);
            this.QueryType.Name = "QueryType";
            this.QueryType.Size = new System.Drawing.Size(121, 20);
            this.QueryType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(68, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询类型：";
            // 
            // ChangeItem
            // 
            this.ChangeItem.Controls.Add(this.SelectType);
            this.ChangeItem.Controls.Add(this.ChangeValue);
            this.ChangeItem.Controls.Add(this.label3);
            this.ChangeItem.Controls.Add(this.ChangeType);
            this.ChangeItem.Controls.Add(this.label4);
            this.ChangeItem.Controls.Add(this.Change);
            this.ChangeItem.Location = new System.Drawing.Point(4, 22);
            this.ChangeItem.Name = "ChangeItem";
            this.ChangeItem.Padding = new System.Windows.Forms.Padding(3);
            this.ChangeItem.Size = new System.Drawing.Size(635, 112);
            this.ChangeItem.TabIndex = 1;
            this.ChangeItem.Text = "修改";
            this.ChangeItem.UseVisualStyleBackColor = true;
            // 
            // SelectType
            // 
            this.SelectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectType.FormattingEnabled = true;
            this.SelectType.Location = new System.Drawing.Point(207, 40);
            this.SelectType.Name = "SelectType";
            this.SelectType.Size = new System.Drawing.Size(301, 20);
            this.SelectType.TabIndex = 8;
            this.SelectType.Visible = false;
            // 
            // ChangeValue
            // 
            this.ChangeValue.Location = new System.Drawing.Point(207, 40);
            this.ChangeValue.Name = "ChangeValue";
            this.ChangeValue.Size = new System.Drawing.Size(301, 21);
            this.ChangeValue.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(137, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "修改值：";
            // 
            // ChangeType
            // 
            this.ChangeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChangeType.FormattingEnabled = true;
            this.ChangeType.Items.AddRange(new object[] {
            "房间号",
            "房间类型",
            "床数",
            "最大旅客数",
            "房间状态",
            "描述"});
            this.ChangeType.Location = new System.Drawing.Point(233, 4);
            this.ChangeType.Name = "ChangeType";
            this.ChangeType.Size = new System.Drawing.Size(121, 20);
            this.ChangeType.TabIndex = 5;
            this.ChangeType.SelectedIndexChanged += new System.EventHandler(this.ChangeType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(137, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "修改类型：";
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(276, 83);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(75, 23);
            this.Change.TabIndex = 0;
            this.Change.Text = "修改";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // AddItem
            // 
            this.AddItem.Controls.Add(this.NewRoomDesc);
            this.AddItem.Controls.Add(this.label10);
            this.AddItem.Controls.Add(this.Add);
            this.AddItem.Controls.Add(this.NewRoomStatus);
            this.AddItem.Controls.Add(this.label9);
            this.AddItem.Controls.Add(this.NewNumCust);
            this.AddItem.Controls.Add(this.label8);
            this.AddItem.Controls.Add(this.NewBedNum);
            this.AddItem.Controls.Add(this.label7);
            this.AddItem.Controls.Add(this.NewRoomType);
            this.AddItem.Controls.Add(this.label6);
            this.AddItem.Controls.Add(this.NewRoomName);
            this.AddItem.Controls.Add(this.label5);
            this.AddItem.Location = new System.Drawing.Point(4, 22);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(635, 112);
            this.AddItem.TabIndex = 2;
            this.AddItem.Text = "添加";
            this.AddItem.UseVisualStyleBackColor = true;
            // 
            // NewRoomDesc
            // 
            this.NewRoomDesc.Location = new System.Drawing.Point(95, 84);
            this.NewRoomDesc.Name = "NewRoomDesc";
            this.NewRoomDesc.Size = new System.Drawing.Size(428, 21);
            this.NewRoomDesc.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(3, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 21);
            this.label10.TabIndex = 15;
            this.label10.Text = "房间描述：";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(529, 82);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 14;
            this.Add.Text = "添加";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // NewRoomStatus
            // 
            this.NewRoomStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NewRoomStatus.FormattingEnabled = true;
            this.NewRoomStatus.Location = new System.Drawing.Point(238, 43);
            this.NewRoomStatus.Name = "NewRoomStatus";
            this.NewRoomStatus.Size = new System.Drawing.Size(113, 20);
            this.NewRoomStatus.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(152, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 21);
            this.label9.TabIndex = 12;
            this.label9.Text = "房间状态：";
            // 
            // NewNumCust
            // 
            this.NewNumCust.Location = new System.Drawing.Point(529, 10);
            this.NewNumCust.Name = "NewNumCust";
            this.NewNumCust.Size = new System.Drawing.Size(59, 21);
            this.NewNumCust.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(417, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 21);
            this.label8.TabIndex = 10;
            this.label8.Text = "最大旅客数：";
            // 
            // NewBedNum
            // 
            this.NewBedNum.Location = new System.Drawing.Point(73, 42);
            this.NewBedNum.Name = "NewBedNum";
            this.NewBedNum.Size = new System.Drawing.Size(59, 21);
            this.NewBedNum.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(3, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 21);
            this.label7.TabIndex = 8;
            this.label7.Text = "床数：";
            // 
            // NewRoomType
            // 
            this.NewRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NewRoomType.FormattingEnabled = true;
            this.NewRoomType.Location = new System.Drawing.Point(275, 9);
            this.NewRoomType.Name = "NewRoomType";
            this.NewRoomType.Size = new System.Drawing.Size(113, 20);
            this.NewRoomType.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(189, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "房间类型：";
            // 
            // NewRoomName
            // 
            this.NewRoomName.Location = new System.Drawing.Point(73, 8);
            this.NewRoomName.Name = "NewRoomName";
            this.NewRoomName.Size = new System.Drawing.Size(100, 21);
            this.NewRoomName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "房间号：";
            // 
            // RemoveItem
            // 
            this.RemoveItem.Controls.Add(this.DeleteRoom);
            this.RemoveItem.Controls.Add(this.label11);
            this.RemoveItem.Location = new System.Drawing.Point(4, 22);
            this.RemoveItem.Name = "RemoveItem";
            this.RemoveItem.Size = new System.Drawing.Size(635, 112);
            this.RemoveItem.TabIndex = 3;
            this.RemoveItem.Text = "删除";
            this.RemoveItem.UseVisualStyleBackColor = true;
            // 
            // DeleteRoom
            // 
            this.DeleteRoom.Location = new System.Drawing.Point(279, 57);
            this.DeleteRoom.Name = "DeleteRoom";
            this.DeleteRoom.Size = new System.Drawing.Size(75, 23);
            this.DeleteRoom.TabIndex = 1;
            this.DeleteRoom.Text = "删除";
            this.DeleteRoom.UseVisualStyleBackColor = true;
            this.DeleteRoom.Click += new System.EventHandler(this.DeleteRoom_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(207, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(219, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "请仅选择一条记录后点击删除按钮";
            // 
            // Init
            // 
            this.Init.Controls.Add(this.label12);
            this.Init.Controls.Add(this.Refresh);
            this.Init.Location = new System.Drawing.Point(4, 22);
            this.Init.Name = "Init";
            this.Init.Size = new System.Drawing.Size(635, 112);
            this.Init.TabIndex = 4;
            this.Init.Text = "信息刷新";
            this.Init.UseVisualStyleBackColor = true;
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(274, 58);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(75, 23);
            this.Refresh.TabIndex = 0;
            this.Refresh.Text = "信息刷新";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(125, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(415, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "点击信息刷新按钮即可刷新数据，可能需要一定时间，请耐心等待";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(21, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(597, 20);
            this.label13.TabIndex = 5;
            this.label13.Text = "查询按钮基于最近一次刷新的数据为基础进行查询，如做过修改请进行信息刷新后再进行查询！";
            // 
            // RoomManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 319);
            this.Controls.Add(this.OperItem);
            this.Controls.Add(this.RoomList);
            this.Name = "RoomManageForm";
            this.Text = "RoomManageForm";
            ((System.ComponentModel.ISupportInitialize)(this.RoomList)).EndInit();
            this.OperItem.ResumeLayout(false);
            this.QueryItem.ResumeLayout(false);
            this.QueryItem.PerformLayout();
            this.ChangeItem.ResumeLayout(false);
            this.ChangeItem.PerformLayout();
            this.AddItem.ResumeLayout(false);
            this.AddItem.PerformLayout();
            this.RemoveItem.ResumeLayout(false);
            this.RemoveItem.PerformLayout();
            this.Init.ResumeLayout(false);
            this.Init.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView RoomList;
        private System.Windows.Forms.TabControl OperItem;
        private System.Windows.Forms.TabPage QueryItem;
        private System.Windows.Forms.Button Query;
        private System.Windows.Forms.TextBox QueryValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox QueryType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage ChangeItem;
        private System.Windows.Forms.TabPage AddItem;
        private System.Windows.Forms.TabPage RemoveItem;
        private System.Windows.Forms.TabPage Init;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ChangeType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ChangeValue;
        private System.Windows.Forms.ComboBox SelectType;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.ComboBox NewRoomStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NewNumCust;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NewBedNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox NewRoomType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NewRoomName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumOfBeds;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomDesc;
        private System.Windows.Forms.TextBox NewRoomDesc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button DeleteRoom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}