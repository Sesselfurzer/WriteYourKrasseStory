namespace winWriteYourKrasseStory
{
    partial class frmMenu
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tServer = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelName = new System.Windows.Forms.Label();
            this.tblength = new System.Windows.Forms.TextBox();
            this.tbNameServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tClient = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbNameClient = new System.Windows.Forms.TextBox();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tServer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tClient.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tServer);
            this.tabControl.Controls.Add(this.tClient);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(478, 143);
            this.tabControl.TabIndex = 0;
            this.tabControl.TabStop = false;
            // 
            // tServer
            // 
            this.tServer.Controls.Add(this.tableLayoutPanel1);
            this.tServer.Location = new System.Drawing.Point(4, 22);
            this.tServer.Name = "tServer";
            this.tServer.Padding = new System.Windows.Forms.Padding(3);
            this.tServer.Size = new System.Drawing.Size(470, 117);
            this.tServer.TabIndex = 0;
            this.tServer.Text = "Server";
            this.tServer.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tblength, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbNameServer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 111);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Location = new System.Drawing.Point(3, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(74, 34);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Spielername";
            // 
            // tblength
            // 
            this.tblength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblength.Location = new System.Drawing.Point(83, 37);
            this.tblength.Name = "tblength";
            this.tblength.Size = new System.Drawing.Size(378, 20);
            this.tblength.TabIndex = 2;
            this.tblength.Text = "100";
            this.tblength.Visible = false;
            // 
            // tbNameServer
            // 
            this.tbNameServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNameServer.Location = new System.Drawing.Point(83, 3);
            this.tbNameServer.Name = "tbNameServer";
            this.tbNameServer.Size = new System.Drawing.Size(378, 20);
            this.tbNameServer.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 34);
            this.label5.TabIndex = 3;
            this.label5.Text = "Max Lenght";
            this.label5.Visible = false;
            // 
            // btnStart
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnStart, 2);
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(3, 71);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(458, 37);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Server Starten";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStarten_Click);
            // 
            // tClient
            // 
            this.tClient.Controls.Add(this.tableLayoutPanel2);
            this.tClient.Location = new System.Drawing.Point(4, 22);
            this.tClient.Name = "tClient";
            this.tClient.Padding = new System.Windows.Forms.Padding(3);
            this.tClient.Size = new System.Drawing.Size(470, 117);
            this.tClient.TabIndex = 1;
            this.tClient.Text = "Client";
            this.tClient.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbNameClient, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbServerIP, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(464, 111);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Spielername";
            // 
            // btnSearch
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.btnSearch, 2);
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(3, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(458, 47);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Server Suchen";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnClientStart_Click);
            // 
            // tbNameClient
            // 
            this.tbNameClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNameClient.Location = new System.Drawing.Point(83, 3);
            this.tbNameClient.Name = "tbNameClient";
            this.tbNameClient.Size = new System.Drawing.Size(378, 20);
            this.tbNameClient.TabIndex = 1;
            // 
            // tbServerIP
            // 
            this.tbServerIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbServerIP.Location = new System.Drawing.Point(83, 32);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(378, 20);
            this.tbServerIP.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 143);
            this.Controls.Add(this.tabControl);
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.tabControl.ResumeLayout(false);
            this.tServer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tClient.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tServer;
        private System.Windows.Forms.TabPage tClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tblength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNameServer;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tbNameClient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}