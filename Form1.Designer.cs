namespace rpgInvintory
{
    partial class Form1
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
            this.btnLoot = new System.Windows.Forms.Button();
            this.bagTimer = new System.Windows.Forms.Timer(this.components);
            this.picSelectedItem = new System.Windows.Forms.PictureBox();
            this.picOpenBagOne = new System.Windows.Forms.PictureBox();
            this.pnlBagOne = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenBagOne)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoot
            // 
            this.btnLoot.Location = new System.Drawing.Point(321, 63);
            this.btnLoot.Name = "btnLoot";
            this.btnLoot.Size = new System.Drawing.Size(45, 51);
            this.btnLoot.TabIndex = 2;
            this.btnLoot.Text = "Loot";
            this.btnLoot.UseVisualStyleBackColor = true;
            this.btnLoot.Click += new System.EventHandler(this.btnLoot_Click);
            // 
            // bagTimer
            // 
            this.bagTimer.Enabled = true;
            this.bagTimer.Tick += new System.EventHandler(this.bagTimer_Tick);
            // 
            // picSelectedItem
            // 
            this.picSelectedItem.Location = new System.Drawing.Point(326, 145);
            this.picSelectedItem.Name = "picSelectedItem";
            this.picSelectedItem.Size = new System.Drawing.Size(45, 45);
            this.picSelectedItem.TabIndex = 3;
            this.picSelectedItem.TabStop = false;
            this.picSelectedItem.Visible = false;
            this.picSelectedItem.Click += new System.EventHandler(this.picSelectedItem_Click);
            // 
            // picOpenBagOne
            // 
            this.picOpenBagOne.BackColor = System.Drawing.Color.DarkGray;
            this.picOpenBagOne.BackgroundImage = global::rpgInvintory.Properties.Resources.bagClosed;
            this.picOpenBagOne.Location = new System.Drawing.Point(321, 12);
            this.picOpenBagOne.Name = "picOpenBagOne";
            this.picOpenBagOne.Size = new System.Drawing.Size(45, 45);
            this.picOpenBagOne.TabIndex = 1;
            this.picOpenBagOne.TabStop = false;
            this.picOpenBagOne.Click += new System.EventHandler(this.picOpenBagOne_Click);
            // 
            // pnlBagOne
            // 
            this.pnlBagOne.BackColor = System.Drawing.Color.DarkGray;
            this.pnlBagOne.Location = new System.Drawing.Point(10, 10);
            this.pnlBagOne.Name = "pnlBagOne";
            this.pnlBagOne.Size = new System.Drawing.Size(305, 305);
            this.pnlBagOne.TabIndex = 0;
            this.pnlBagOne.Visible = false;
            this.pnlBagOne.Click += new System.EventHandler(this.pnlBagOne_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 327);
            this.Controls.Add(this.picSelectedItem);
            this.Controls.Add(this.btnLoot);
            this.Controls.Add(this.picOpenBagOne);
            this.Controls.Add(this.pnlBagOne);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSelectedItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenBagOne)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBagOne;
        private System.Windows.Forms.PictureBox picOpenBagOne;
        private System.Windows.Forms.Button btnLoot;
        private System.Windows.Forms.PictureBox picSelectedItem;
        private System.Windows.Forms.Timer bagTimer;
    }
}

