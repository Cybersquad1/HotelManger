namespace HotelManger
{
    partial class RoomForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomForm));
            this.RoomTypeList = new System.Windows.Forms.TreeView();
            this.RoomsList = new System.Windows.Forms.ListView();
            this.RoomPics = new System.Windows.Forms.ImageList(this.components);
            this.RoomMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BookIn = new System.Windows.Forms.ToolStripMenuItem();
            this.ReturnRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.RoomMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // RoomTypeList
            // 
            this.RoomTypeList.Location = new System.Drawing.Point(12, 12);
            this.RoomTypeList.Name = "RoomTypeList";
            this.RoomTypeList.Size = new System.Drawing.Size(121, 318);
            this.RoomTypeList.TabIndex = 1;
            this.RoomTypeList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RoomTypeList_AfterSelect);
            // 
            // RoomsList
            // 
            this.RoomsList.ContextMenuStrip = this.RoomMenu;
            this.RoomsList.LargeImageList = this.RoomPics;
            this.RoomsList.Location = new System.Drawing.Point(140, 12);
            this.RoomsList.Name = "RoomsList";
            this.RoomsList.ShowItemToolTips = true;
            this.RoomsList.Size = new System.Drawing.Size(338, 318);
            this.RoomsList.TabIndex = 2;
            this.RoomsList.UseCompatibleStateImageBehavior = false;
            // 
            // RoomPics
            // 
            this.RoomPics.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("RoomPics.ImageStream")));
            this.RoomPics.TransparentColor = System.Drawing.Color.Transparent;
            this.RoomPics.Images.SetKeyName(0, "1.png");
            this.RoomPics.Images.SetKeyName(1, "2.png");
            this.RoomPics.Images.SetKeyName(2, "3.png");
            this.RoomPics.Images.SetKeyName(3, "4.png");
            this.RoomPics.Images.SetKeyName(4, "5.png");
            // 
            // RoomMenu
            // 
            this.RoomMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BookIn,
            this.ReturnRoom,
            this.ChangeStatus});
            this.RoomMenu.Name = "RoomMenu";
            this.RoomMenu.Size = new System.Drawing.Size(153, 92);
            this.RoomMenu.Opening += new System.ComponentModel.CancelEventHandler(this.RoomMenu_Opening);
            // 
            // BookIn
            // 
            this.BookIn.Enabled = false;
            this.BookIn.Name = "BookIn";
            this.BookIn.Size = new System.Drawing.Size(152, 22);
            this.BookIn.Text = "入住";
            this.BookIn.Click += new System.EventHandler(this.BookIn_Click);
            // 
            // ReturnRoom
            // 
            this.ReturnRoom.Enabled = false;
            this.ReturnRoom.Name = "ReturnRoom";
            this.ReturnRoom.Size = new System.Drawing.Size(152, 22);
            this.ReturnRoom.Text = "退房";
            // 
            // ChangeStatus
            // 
            this.ChangeStatus.Enabled = false;
            this.ChangeStatus.Name = "ChangeStatus";
            this.ChangeStatus.Size = new System.Drawing.Size(152, 22);
            this.ChangeStatus.Text = "修改状态";
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 342);
            this.Controls.Add(this.RoomsList);
            this.Controls.Add(this.RoomTypeList);
            this.Name = "RoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoomForm";
            this.Load += new System.EventHandler(this.Init);
            this.RoomMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView RoomTypeList;
        private System.Windows.Forms.ListView RoomsList;
        private System.Windows.Forms.ImageList RoomPics;
        private System.Windows.Forms.ContextMenuStrip RoomMenu;
        private System.Windows.Forms.ToolStripMenuItem BookIn;
        private System.Windows.Forms.ToolStripMenuItem ReturnRoom;
        private System.Windows.Forms.ToolStripMenuItem ChangeStatus;

    }
}