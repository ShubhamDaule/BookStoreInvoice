
namespace Bookstore___Invoice_System
{
    partial class formAdminDashboard
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
            this.panelfooter = new System.Windows.Forms.Panel();
            this.labelfooter = new System.Windows.Forms.Label();
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealerAndCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.labelLoggedInEmployee = new System.Windows.Forms.Label();
            this.labelAppFirstName = new System.Windows.Forms.Label();
            this.labelAppLastName = new System.Windows.Forms.Label();
            this.labelSubHead = new System.Windows.Forms.Label();
            this.panelfooter.SuspendLayout();
            this.menuStripTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelfooter
            // 
            this.panelfooter.BackColor = System.Drawing.Color.DarkCyan;
            this.panelfooter.Controls.Add(this.labelfooter);
            this.panelfooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelfooter.Location = new System.Drawing.Point(0, 589);
            this.panelfooter.Name = "panelfooter";
            this.panelfooter.Size = new System.Drawing.Size(1275, 36);
            this.panelfooter.TabIndex = 0;
            // 
            // labelfooter
            // 
            this.labelfooter.AutoSize = true;
            this.labelfooter.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfooter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelfooter.Location = new System.Drawing.Point(540, 11);
            this.labelfooter.Name = "labelfooter";
            this.labelfooter.Size = new System.Drawing.Size(223, 25);
            this.labelfooter.TabIndex = 0;
            this.labelfooter.Text = "Developed by: Group 34";
            this.labelfooter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // menuStripTop
            // 
            this.menuStripTop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripTop.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripTop.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesToolStripMenuItem,
            this.genreToolStripMenuItem,
            this.booksToolStripMenuItem,
            this.dealerAndCustomerToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.transactionsToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(1275, 33);
            this.menuStripTop.TabIndex = 1;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.employeesToolStripMenuItem.Text = "Employees";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // genreToolStripMenuItem
            // 
            this.genreToolStripMenuItem.Name = "genreToolStripMenuItem";
            this.genreToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.genreToolStripMenuItem.Text = "Genres";
            this.genreToolStripMenuItem.Click += new System.EventHandler(this.genreToolStripMenuItem_Click);
            // 
            // booksToolStripMenuItem
            // 
            this.booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            this.booksToolStripMenuItem.Size = new System.Drawing.Size(77, 29);
            this.booksToolStripMenuItem.Text = "Books";
            this.booksToolStripMenuItem.Click += new System.EventHandler(this.booksToolStripMenuItem_Click);
            // 
            // dealerAndCustomerToolStripMenuItem
            // 
            this.dealerAndCustomerToolStripMenuItem.Name = "dealerAndCustomerToolStripMenuItem";
            this.dealerAndCustomerToolStripMenuItem.Size = new System.Drawing.Size(195, 29);
            this.dealerAndCustomerToolStripMenuItem.Text = "Dealer and Customer";
            this.dealerAndCustomerToolStripMenuItem.Click += new System.EventHandler(this.dealerAndCustomerToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(124, 29);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            this.transactionsToolStripMenuItem.Click += new System.EventHandler(this.transactionsToolStripMenuItem_Click);
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmployee.Location = new System.Drawing.Point(12, 35);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(102, 28);
            this.labelEmployee.TabIndex = 2;
            this.labelEmployee.Text = "Employee:";
            // 
            // labelLoggedInEmployee
            // 
            this.labelLoggedInEmployee.AutoSize = true;
            this.labelLoggedInEmployee.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoggedInEmployee.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelLoggedInEmployee.Location = new System.Drawing.Point(80, 35);
            this.labelLoggedInEmployee.Name = "labelLoggedInEmployee";
            this.labelLoggedInEmployee.Size = new System.Drawing.Size(0, 28);
            this.labelLoggedInEmployee.TabIndex = 3;
            this.labelLoggedInEmployee.Click += new System.EventHandler(this.labelLoggedInEmployee_Click);
            // 
            // labelAppFirstName
            // 
            this.labelAppFirstName.AutoSize = true;
            this.labelAppFirstName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppFirstName.Location = new System.Drawing.Point(554, 281);
            this.labelAppFirstName.Name = "labelAppFirstName";
            this.labelAppFirstName.Size = new System.Drawing.Size(112, 54);
            this.labelAppFirstName.TabIndex = 4;
            this.labelAppFirstName.Text = "Book";
            // 
            // labelAppLastName
            // 
            this.labelAppLastName.AutoSize = true;
            this.labelAppLastName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppLastName.Location = new System.Drawing.Point(627, 281);
            this.labelAppLastName.Name = "labelAppLastName";
            this.labelAppLastName.Size = new System.Drawing.Size(122, 54);
            this.labelAppLastName.TabIndex = 5;
            this.labelAppLastName.Text = "Store";
            // 
            // labelSubHead
            // 
            this.labelSubHead.AutoSize = true;
            this.labelSubHead.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubHead.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelSubHead.Location = new System.Drawing.Point(567, 318);
            this.labelSubHead.Name = "labelSubHead";
            this.labelSubHead.Size = new System.Drawing.Size(200, 38);
            this.labelSubHead.TabIndex = 6;
            this.labelSubHead.Text = "Invoice System";
            this.labelSubHead.Click += new System.EventHandler(this.labelSubHead_Click);
            // 
            // formAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 625);
            this.Controls.Add(this.labelSubHead);
            this.Controls.Add(this.labelAppLastName);
            this.Controls.Add(this.labelAppFirstName);
            this.Controls.Add(this.labelLoggedInEmployee);
            this.Controls.Add(this.labelEmployee);
            this.Controls.Add(this.panelfooter);
            this.Controls.Add(this.menuStripTop);
            this.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStripTop;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formAdminDashboard_FormClosed);
            this.Load += new System.EventHandler(this.formAdminDashboard_Load);
            this.panelfooter.ResumeLayout(false);
            this.panelfooter.PerformLayout();
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelfooter;
        private System.Windows.Forms.Label labelfooter;
        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.Label labelLoggedInEmployee;
        private System.Windows.Forms.Label labelAppFirstName;
        private System.Windows.Forms.Label labelAppLastName;
        private System.Windows.Forms.Label labelSubHead;
        private System.Windows.Forms.ToolStripMenuItem dealerAndCustomerToolStripMenuItem;
    }
}

