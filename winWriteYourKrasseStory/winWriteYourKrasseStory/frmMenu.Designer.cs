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
            this.tblength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tClient = new System.Windows.Forms.TabPage();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPort2 = new System.Windows.Forms.TextBox();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.tbName1 = new System.Windows.Forms.TextBox();
            this.tbName2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tServer.SuspendLayout();
            this.tClient.SuspendLayout();
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
            this.tabControl.Size = new System.Drawing.Size(333, 221);
            this.tabControl.TabIndex = 0;
            // 
            // tServer
            // 
            this.tServer.Controls.Add(this.tbName1);
            this.tServer.Controls.Add(this.labelName);
            this.tServer.Controls.Add(this.tblength);
            this.tServer.Controls.Add(this.label5);
            this.tServer.Controls.Add(this.btnStart);
            this.tServer.Controls.Add(this.tbPort);
            this.tServer.Controls.Add(this.label3);
            this.tServer.Location = new System.Drawing.Point(4, 22);
            this.tServer.Name = "tServer";
            this.tServer.Padding = new System.Windows.Forms.Padding(3);
            this.tServer.Size = new System.Drawing.Size(325, 195);
            this.tServer.TabIndex = 0;
            this.tServer.Text = "Server";
            this.tServer.UseVisualStyleBackColor = true;
            this.tServer.Click += new System.EventHandler(this.tServer_Click);
            // 
            // tblength
            // 
            this.tblength.Location = new System.Drawing.Point(74, 64);
            this.tblength.Name = "tblength";
            this.tblength.Size = new System.Drawing.Size(100, 20);
            this.tblength.TabIndex = 4;
            this.tblength.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Max Lenght";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 106);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(139, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Server Starten";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStarten_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(74, 41);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Port";
            // 
            // tClient
            // 
            this.tClient.Controls.Add(this.tbName2);
            this.tClient.Controls.Add(this.label6);
            this.tClient.Controls.Add(this.btnConnect);
            this.tClient.Controls.Add(this.label4);
            this.tClient.Controls.Add(this.btnSearch);
            this.tClient.Controls.Add(this.label2);
            this.tClient.Controls.Add(this.tbPort2);
            this.tClient.Controls.Add(this.tbServerIP);
            this.tClient.Controls.Add(this.label1);
            this.tClient.Location = new System.Drawing.Point(4, 22);
            this.tClient.Name = "tClient";
            this.tClient.Padding = new System.Windows.Forms.Padding(3);
            this.tClient.Size = new System.Drawing.Size(325, 195);
            this.tClient.TabIndex = 1;
            this.tClient.Text = "Client";
            this.tClient.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(172, 108);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(123, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Verbinden";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Status";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 109);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(154, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Server Suchen";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // tbPort2
            // 
            this.tbPort2.Location = new System.Drawing.Point(65, 83);
            this.tbPort2.Name = "tbPort2";
            this.tbPort2.Size = new System.Drawing.Size(100, 20);
            this.tbPort2.TabIndex = 2;
            // 
            // tbServerIP
            // 
            this.tbServerIP.Location = new System.Drawing.Point(65, 56);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(100, 20);
            this.tbServerIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Spielername";
            // 
            // tbName1
            // 
            this.tbName1.Location = new System.Drawing.Point(74, 9);
            this.tbName1.Name = "tbName1";
            this.tbName1.Size = new System.Drawing.Size(100, 20);
            this.tbName1.TabIndex = 6;
            // 
            // tbName2
            // 
            this.tbName2.Location = new System.Drawing.Point(66, 19);
            this.tbName2.Name = "tbName2";
            this.tbName2.Size = new System.Drawing.Size(100, 20);
            this.tbName2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Spielername";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 221);
            this.Controls.Add(this.tabControl);
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.tabControl.ResumeLayout(false);
            this.tServer.ResumeLayout(false);
            this.tServer.PerformLayout();
            this.tClient.ResumeLayout(false);
            this.tClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tServer;
        private System.Windows.Forms.TabPage tClient;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPort2;
        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tblength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbName1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tbName2;
        private System.Windows.Forms.Label label6;
    }
}