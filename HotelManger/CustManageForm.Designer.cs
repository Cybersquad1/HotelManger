namespace HotelManger
{
    partial class CustManageForm
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
            this.CustList = new System.Windows.Forms.DataGridView();
            this.CustName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustIDNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckInCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManageMenu = new System.Windows.Forms.TabControl();
            this.QueryTab = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.Query = new System.Windows.Forms.Button();
            this.QueryValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QueryType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChangeTab = new System.Windows.Forms.TabPage();
            this.SelectType = new System.Windows.Forms.ComboBox();
            this.ChangeValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChangeType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Change = new System.Windows.Forms.Button();
            this.AddTab = new System.Windows.Forms.TabPage();
            this.DeleteTab = new System.Windows.Forms.TabPage();
            this.RefreshTab = new System.Windows.Forms.TabPage();
            this.RefreshList = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.NewCustID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.NewCustDegree = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NewCustName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DeleteCust = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CustList)).BeginInit();
            this.ManageMenu.SuspendLayout();
            this.QueryTab.SuspendLayout();
            this.ChangeTab.SuspendLayout();
            this.AddTab.SuspendLayout();
            this.DeleteTab.SuspendLayout();
            this.RefreshTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // CustList
            // 
            this.CustList.AllowUserToAddRows = false;
            this.CustList.AllowUserToDeleteRows = false;
            this.CustList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustName,
            this.CustIDNumber,
            this.CustDegree,
            this.CustMoney,
            this.CheckInCount,
            this.CustStatus});
            this.CustList.Location = new System.Drawing.Point(25, 12);
            this.CustList.Name = "CustList";
            this.CustList.ReadOnly = true;
            this.CustList.RowTemplate.Height = 23;
            this.CustList.Size = new System.Drawing.Size(643, 150);
            this.CustList.TabIndex = 0;
            // 
            // CustName
            // 
            this.CustName.HeaderText = "姓名";
            this.CustName.Name = "CustName";
            this.CustName.ReadOnly = true;
            // 
            // CustIDNumber
            // 
            this.CustIDNumber.HeaderText = "身份证号";
            this.CustIDNumber.Name = "CustIDNumber";
            this.CustIDNumber.ReadOnly = true;
            // 
            // CustDegree
            // 
            this.CustDegree.HeaderText = "用户级别";
            this.CustDegree.Name = "CustDegree";
            this.CustDegree.ReadOnly = true;
            // 
            // CustMoney
            // 
            this.CustMoney.HeaderText = "总消费";
            this.CustMoney.Name = "CustMoney";
            this.CustMoney.ReadOnly = true;
            // 
            // CheckInCount
            // 
            this.CheckInCount.HeaderText = "入住次数";
            this.CheckInCount.Name = "CheckInCount";
            this.CheckInCount.ReadOnly = true;
            // 
            // CustStatus
            // 
            this.CustStatus.HeaderText = "客户状态";
            this.CustStatus.Name = "CustStatus";
            this.CustStatus.ReadOnly = true;
            // 
            // ManageMenu
            // 
            this.ManageMenu.Controls.Add(this.QueryTab);
            this.ManageMenu.Controls.Add(this.ChangeTab);
            this.ManageMenu.Controls.Add(this.AddTab);
            this.ManageMenu.Controls.Add(this.DeleteTab);
            this.ManageMenu.Controls.Add(this.RefreshTab);
            this.ManageMenu.Location = new System.Drawing.Point(25, 180);
            this.ManageMenu.Name = "ManageMenu";
            this.ManageMenu.SelectedIndex = 0;
            this.ManageMenu.Size = new System.Drawing.Size(643, 169);
            this.ManageMenu.TabIndex = 1;
            this.ManageMenu.SelectedIndexChanged += new System.EventHandler(this.ManageMenu_SelectedIndexChanged);
            // 
            // QueryTab
            // 
            this.QueryTab.Controls.Add(this.label13);
            this.QueryTab.Controls.Add(this.Query);
            this.QueryTab.Controls.Add(this.QueryValue);
            this.QueryTab.Controls.Add(this.label2);
            this.QueryTab.Controls.Add(this.QueryType);
            this.QueryTab.Controls.Add(this.label1);
            this.QueryTab.Location = new System.Drawing.Point(4, 22);
            this.QueryTab.Name = "QueryTab";
            this.QueryTab.Padding = new System.Windows.Forms.Padding(3);
            this.QueryTab.Size = new System.Drawing.Size(635, 143);
            this.QueryTab.TabIndex = 0;
            this.QueryTab.Text = "查询";
            this.QueryTab.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(19, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(597, 20);
            this.label13.TabIndex = 10;
            this.label13.Text = "查询按钮基于最近一次刷新的数据为基础进行查询，如做过修改请进行信息刷新后再进行查询！";
            // 
            // Query
            // 
            this.Query.Location = new System.Drawing.Point(497, 60);
            this.Query.Name = "Query";
            this.Query.Size = new System.Drawing.Size(75, 23);
            this.Query.TabIndex = 9;
            this.Query.Text = "查询";
            this.Query.UseVisualStyleBackColor = true;
            this.Query.Click += new System.EventHandler(this.Query_Click);
            // 
            // QueryValue
            // 
            this.QueryValue.Location = new System.Drawing.Point(370, 60);
            this.QueryValue.Name = "QueryValue";
            this.QueryValue.Size = new System.Drawing.Size(100, 21);
            this.QueryValue.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(300, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "查询值：";
            // 
            // QueryType
            // 
            this.QueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QueryType.FormattingEnabled = true;
            this.QueryType.Items.AddRange(new object[] {
            "姓名",
            "身份证号",
            "用户级别",
            "总消费",
            "入住次数",
            "客户状态"});
            this.QueryType.Location = new System.Drawing.Point(158, 61);
            this.QueryType.Name = "QueryType";
            this.QueryType.Size = new System.Drawing.Size(121, 20);
            this.QueryType.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(62, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "查询类型：";
            // 
            // ChangeTab
            // 
            this.ChangeTab.Controls.Add(this.SelectType);
            this.ChangeTab.Controls.Add(this.ChangeValue);
            this.ChangeTab.Controls.Add(this.label3);
            this.ChangeTab.Controls.Add(this.ChangeType);
            this.ChangeTab.Controls.Add(this.label4);
            this.ChangeTab.Controls.Add(this.Change);
            this.ChangeTab.Location = new System.Drawing.Point(4, 22);
            this.ChangeTab.Name = "ChangeTab";
            this.ChangeTab.Padding = new System.Windows.Forms.Padding(3);
            this.ChangeTab.Size = new System.Drawing.Size(635, 143);
            this.ChangeTab.TabIndex = 1;
            this.ChangeTab.Text = "修改";
            this.ChangeTab.UseVisualStyleBackColor = true;
            // 
            // SelectType
            // 
            this.SelectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectType.FormattingEnabled = true;
            this.SelectType.Location = new System.Drawing.Point(202, 57);
            this.SelectType.Name = "SelectType";
            this.SelectType.Size = new System.Drawing.Size(301, 20);
            this.SelectType.TabIndex = 14;
            this.SelectType.Visible = false;
            // 
            // ChangeValue
            // 
            this.ChangeValue.Location = new System.Drawing.Point(202, 57);
            this.ChangeValue.Name = "ChangeValue";
            this.ChangeValue.Size = new System.Drawing.Size(301, 21);
            this.ChangeValue.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(132, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "修改值：";
            // 
            // ChangeType
            // 
            this.ChangeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChangeType.FormattingEnabled = true;
            this.ChangeType.Items.AddRange(new object[] {
            "姓名",
            "用户级别",
            "总消费",
            "入住次数",
            "客户状态"});
            this.ChangeType.Location = new System.Drawing.Point(228, 21);
            this.ChangeType.Name = "ChangeType";
            this.ChangeType.Size = new System.Drawing.Size(121, 20);
            this.ChangeType.TabIndex = 11;
            this.ChangeType.SelectedIndexChanged += new System.EventHandler(this.ChangeType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(132, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "修改类型：";
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(271, 100);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(75, 23);
            this.Change.TabIndex = 9;
            this.Change.Text = "修改";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // AddTab
            // 
            this.AddTab.Controls.Add(this.label7);
            this.AddTab.Controls.Add(this.NewCustID);
            this.AddTab.Controls.Add(this.label10);
            this.AddTab.Controls.Add(this.Add);
            this.AddTab.Controls.Add(this.NewCustDegree);
            this.AddTab.Controls.Add(this.label6);
            this.AddTab.Controls.Add(this.NewCustName);
            this.AddTab.Controls.Add(this.label5);
            this.AddTab.Location = new System.Drawing.Point(4, 22);
            this.AddTab.Name = "AddTab";
            this.AddTab.Size = new System.Drawing.Size(635, 143);
            this.AddTab.TabIndex = 2;
            this.AddTab.Text = "添加";
            this.AddTab.UseVisualStyleBackColor = true;
            // 
            // DeleteTab
            // 
            this.DeleteTab.Controls.Add(this.DeleteCust);
            this.DeleteTab.Controls.Add(this.label11);
            this.DeleteTab.Location = new System.Drawing.Point(4, 22);
            this.DeleteTab.Name = "DeleteTab";
            this.DeleteTab.Size = new System.Drawing.Size(635, 143);
            this.DeleteTab.TabIndex = 3;
            this.DeleteTab.Text = "删除";
            this.DeleteTab.UseVisualStyleBackColor = true;
            // 
            // RefreshTab
            // 
            this.RefreshTab.Controls.Add(this.RefreshList);
            this.RefreshTab.Controls.Add(this.label12);
            this.RefreshTab.Location = new System.Drawing.Point(4, 22);
            this.RefreshTab.Name = "RefreshTab";
            this.RefreshTab.Size = new System.Drawing.Size(635, 143);
            this.RefreshTab.TabIndex = 4;
            this.RefreshTab.Text = "信息刷新";
            this.RefreshTab.UseVisualStyleBackColor = true;
            // 
            // RefreshList
            // 
            this.RefreshList.Location = new System.Drawing.Point(274, 73);
            this.RefreshList.Name = "RefreshList";
            this.RefreshList.Size = new System.Drawing.Size(75, 23);
            this.RefreshList.TabIndex = 3;
            this.RefreshList.Text = "信息刷新";
            this.RefreshList.UseVisualStyleBackColor = true;
            this.RefreshList.Click += new System.EventHandler(this.RefreshList_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(116, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(415, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "点击信息刷新按钮即可刷新数据，可能需要一定时间，请耐心等待";
            // 
            // NewCustID
            // 
            this.NewCustID.Location = new System.Drawing.Point(256, 58);
            this.NewCustID.Name = "NewCustID";
            this.NewCustID.Size = new System.Drawing.Size(154, 21);
            this.NewCustID.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(164, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 21);
            this.label10.TabIndex = 28;
            this.label10.Text = "身份证号：";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(282, 97);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 27;
            this.Add.Text = "添加";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // NewCustDegree
            // 
            this.NewCustDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NewCustDegree.FormattingEnabled = true;
            this.NewCustDegree.Location = new System.Drawing.Point(512, 58);
            this.NewCustDegree.Name = "NewCustDegree";
            this.NewCustDegree.Size = new System.Drawing.Size(113, 20);
            this.NewCustDegree.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(426, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "用户级别：";
            // 
            // NewCustName
            // 
            this.NewCustName.Location = new System.Drawing.Point(84, 58);
            this.NewCustName.Name = "NewCustName";
            this.NewCustName.Size = new System.Drawing.Size(74, 21);
            this.NewCustName.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(20, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "姓名：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(178, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "如果有相同身份证号，记录会无法插入！";
            // 
            // DeleteCust
            // 
            this.DeleteCust.Location = new System.Drawing.Point(280, 78);
            this.DeleteCust.Name = "DeleteCust";
            this.DeleteCust.Size = new System.Drawing.Size(75, 23);
            this.DeleteCust.TabIndex = 3;
            this.DeleteCust.Text = "删除";
            this.DeleteCust.UseVisualStyleBackColor = true;
            this.DeleteCust.Click += new System.EventHandler(this.DeleteCust_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(208, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(219, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "请仅选择一条记录后点击删除按钮";
            // 
            // CustManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 361);
            this.Controls.Add(this.ManageMenu);
            this.Controls.Add(this.CustList);
            this.Name = "CustManageForm";
            this.Text = "CustManageForm";
            ((System.ComponentModel.ISupportInitialize)(this.CustList)).EndInit();
            this.ManageMenu.ResumeLayout(false);
            this.QueryTab.ResumeLayout(false);
            this.QueryTab.PerformLayout();
            this.ChangeTab.ResumeLayout(false);
            this.ChangeTab.PerformLayout();
            this.AddTab.ResumeLayout(false);
            this.AddTab.PerformLayout();
            this.DeleteTab.ResumeLayout(false);
            this.DeleteTab.PerformLayout();
            this.RefreshTab.ResumeLayout(false);
            this.RefreshTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CustList;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustIDNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckInCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustStatus;
        private System.Windows.Forms.TabControl ManageMenu;
        private System.Windows.Forms.TabPage QueryTab;
        private System.Windows.Forms.TabPage ChangeTab;
        private System.Windows.Forms.TabPage AddTab;
        private System.Windows.Forms.TabPage DeleteTab;
        private System.Windows.Forms.TabPage RefreshTab;
        private System.Windows.Forms.Button RefreshList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button Query;
        private System.Windows.Forms.TextBox QueryValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox QueryType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox SelectType;
        private System.Windows.Forms.TextBox ChangeValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ChangeType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox NewCustID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.ComboBox NewCustDegree;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NewCustName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DeleteCust;
        private System.Windows.Forms.Label label11;
    }
}