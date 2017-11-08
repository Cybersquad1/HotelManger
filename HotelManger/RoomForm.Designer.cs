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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView RoomTypeList;
        private System.Windows.Forms.ListView RoomsList;
        private System.Windows.Forms.ImageList RoomPics;

    }
}