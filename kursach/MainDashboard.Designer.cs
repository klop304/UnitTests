namespace kursach
{
    partial class MainDashboard
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnPolicies = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.labelMainMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(365, 392);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(111, 23);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Выход из системы";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Location = new System.Drawing.Point(579, 157);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(125, 35);
            this.btnManageUsers.TabIndex = 10;
            this.btnManageUsers.Text = "Управление пользователей\r\n\r\n";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnPolicies
            // 
            this.btnPolicies.Location = new System.Drawing.Point(328, 157);
            this.btnPolicies.Name = "btnPolicies";
            this.btnPolicies.Size = new System.Drawing.Size(125, 35);
            this.btnPolicies.TabIndex = 9;
            this.btnPolicies.Text = "Работа с договорами";
            this.btnPolicies.UseVisualStyleBackColor = true;
            this.btnPolicies.Click += new System.EventHandler(this.btnPolicies_Click);
            // 
            // btnClients
            // 
            this.btnClients.Location = new System.Drawing.Point(96, 157);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(125, 35);
            this.btnClients.TabIndex = 8;
            this.btnClients.Text = "Работа с клиентами";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // labelMainMenu
            // 
            this.labelMainMenu.AutoSize = true;
            this.labelMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMainMenu.Location = new System.Drawing.Point(334, 36);
            this.labelMainMenu.Name = "labelMainMenu";
            this.labelMainMenu.Size = new System.Drawing.Size(151, 24);
            this.labelMainMenu.TabIndex = 7;
            this.labelMainMenu.Text = "Главное меню";
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnPolicies);
            this.Controls.Add(this.btnClients);
            this.Controls.Add(this.labelMainMenu);
            this.Name = "MainDashboard";
            this.Text = "MainDashboard";
            this.Load += new System.EventHandler(this.MainDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnPolicies;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Label labelMainMenu;
    }
}