
namespace Bookstore___Invoice_System
{
    partial class formEmployeeDashboard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.purchaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealerAndCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSubHead = new System.Windows.Forms.Label();
            this.labelAppLastName = new System.Windows.Forms.Label();
            this.labelAppFirstName = new System.Windows.Forms.Label();
            this.labelLoggedInEmployee = new System.Windows.Forms.Label();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.panelfooter = new System.Windows.Forms.Panel();
            this.labelfooter = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelfooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaceToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.dealerAndCustomerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1308, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // purchaceToolStripMenuItem
            // 
            this.purchaceToolStripMenuItem.Name = "purchaceToolStripMenuItem";
            this.purchaceToolStripMenuItem.Size = new System.Drawing.Size(106, 29);
            this.purchaceToolStripMenuItem.Text = "Purchases";
            this.purchaceToolStripMenuItem.Click += new System.EventHandler(this.purchaceToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(68, 29);
            this.salesToolStripMenuItem.Text = "Sales";
            this.salesToolStripMenuItem.Click += new System.EventHandler(this.salesToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.transactionsToolStripMenuItem.Text = "Inventory";
            this.transactionsToolStripMenuItem.Click += new System.EventHandler(this.transactionsToolStripMenuItem_Click);
            // 
            // dealerAndCustomerToolStripMenuItem
            // 
            this.dealerAndCustomerToolStripMenuItem.Name = "dealerAndCustomerToolStripMenuItem";
            this.dealerAndCustomerToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.dealerAndCustomerToolStripMenuItem.Text = "Customer";
            this.dealerAndCustomerToolStripMenuItem.Click += new System.EventHandler(this.dealerAndCustomerToolStripMenuItem_Click);
            // 
            // labelSubHead
            // 
            this.labelSubHead.AutoSize = true;
            this.labelSubHead.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubHead.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelSubHead.Location = new System.Drawing.Point(850, 486);
            this.labelSubHead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSubHead.Name = "labelSubHead";
            this.labelSubHead.Size = new System.Drawing.Size(200, 38);
            this.labelSubHead.TabIndex = 12;
            this.labelSubHead.Text = "Invoice System";
            // 
            // labelAppLastName
            // 
            this.labelAppLastName.AutoSize = true;
            this.labelAppLastName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppLastName.Location = new System.Drawing.Point(940, 429);
            this.labelAppLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppLastName.Name = "labelAppLastName";
            this.labelAppLastName.Size = new System.Drawing.Size(122, 54);
            this.labelAppLastName.TabIndex = 11;
            this.labelAppLastName.Text = "Store";
            // 
            // labelAppFirstName
            // 
            this.labelAppFirstName.AutoSize = true;
            this.labelAppFirstName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppFirstName.Location = new System.Drawing.Point(831, 429);
            this.labelAppFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppFirstName.Name = "labelAppFirstName";
            this.labelAppFirstName.Size = new System.Drawing.Size(112, 54);
            this.labelAppFirstName.TabIndex = 10;
            this.labelAppFirstName.Text = "Book";
            // 
            // labelLoggedInEmployee
            // 
            this.labelLoggedInEmployee.AutoSize = true;
            this.labelLoggedInEmployee.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoggedInEmployee.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelLoggedInEmployee.Location = new System.Drawing.Point(120, 51);
            this.labelLoggedInEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLoggedInEmployee.Name = "labelLoggedInEmployee";
            this.labelLoggedInEmployee.Size = new System.Drawing.Size(0, 28);
            this.labelLoggedInEmployee.TabIndex = 9;
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmployee.Location = new System.Drawing.Point(18, 51);
            this.labelEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(102, 28);
            this.labelEmployee.TabIndex = 8;
            this.labelEmployee.Text = "Employee:";
            // 
            // panelfooter
            // 
            this.panelfooter.BackColor = System.Drawing.Color.DarkCyan;
            this.panelfooter.Controls.Add(this.labelfooter);
            this.panelfooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelfooter.Location = new System.Drawing.Point(0, 547);
            this.panelfooter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelfooter.Name = "panelfooter";
            this.panelfooter.Size = new System.Drawing.Size(1308, 55);
            this.panelfooter.TabIndex = 7;
            // 
            // labelfooter
            // 
            this.labelfooter.AutoSize = true;
            this.labelfooter.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfooter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelfooter.Location = new System.Drawing.Point(810, 17);
            this.labelfooter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelfooter.Name = "labelfooter";
            this.labelfooter.Size = new System.Drawing.Size(223, 25);
            this.labelfooter.TabIndex = 0;
            this.labelfooter.Text = "Developed by: Group 34";
            this.labelfooter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // formEmployeeDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 602);
            this.Controls.Add(this.labelSubHead);
            this.Controls.Add(this.labelAppLastName);
            this.Controls.Add(this.labelAppFirstName);
            this.Controls.Add(this.labelLoggedInEmployee);
            this.Controls.Add(this.labelEmployee);
            this.Controls.Add(this.panelfooter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "formEmployeeDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formEmployeeDashboard_FormClosed);
            this.Load += new System.EventHandler(this.formEmployeeDashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelfooter.ResumeLayout(false);
            this.panelfooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem purchaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.Label labelSubHead;
        private System.Windows.Forms.Label labelAppLastName;
        private System.Windows.Forms.Label labelAppFirstName;
        private System.Windows.Forms.Label labelLoggedInEmployee;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.Panel panelfooter;
        private System.Windows.Forms.Label labelfooter;
        private System.Windows.Forms.ToolStripMenuItem dealerAndCustomerToolStripMenuItem;
    }
}