namespace winWriteYourKrasseStory
{
    partial class frmStory
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbZeilen = new System.Windows.Forms.ListBox();
            this.lvSpieler = new System.Windows.Forms.ListView();
            this.tbZeile = new System.Windows.Forms.TextBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.2049F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.7951F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.lbZeilen, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lvSpieler, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.tbZeile, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.btnEnd, 1, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.33079F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.669211F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(653, 453);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lbZeilen
            // 
            this.lbZeilen.BackColor = System.Drawing.SystemColors.MenuText;
            this.lbZeilen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbZeilen.ForeColor = System.Drawing.SystemColors.Window;
            this.lbZeilen.FormattingEnabled = true;
            this.lbZeilen.Location = new System.Drawing.Point(3, 3);
            this.lbZeilen.Name = "lbZeilen";
            this.tableLayoutPanel.SetRowSpan(this.lbZeilen, 3);
            this.lbZeilen.Size = new System.Drawing.Size(472, 411);
            this.lbZeilen.TabIndex = 0;
            // 
            // lvSpieler
            // 
            this.lvSpieler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSpieler.Location = new System.Drawing.Point(481, 3);
            this.lvSpieler.Name = "lvSpieler";
            this.tableLayoutPanel.SetRowSpan(this.lvSpieler, 3);
            this.lvSpieler.Size = new System.Drawing.Size(169, 411);
            this.lvSpieler.TabIndex = 2;
            this.lvSpieler.UseCompatibleStateImageBehavior = false;
            // 
            // tbZeile
            // 
            this.tbZeile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbZeile.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbZeile.Location = new System.Drawing.Point(3, 420);
            this.tbZeile.MaxLength = 88;
            this.tbZeile.Name = "tbZeile";
            this.tbZeile.Size = new System.Drawing.Size(472, 20);
            this.tbZeile.TabIndex = 1;
            this.tbZeile.WordWrap = false;
            this.tbZeile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbZeile_KeyDown);
            // 
            // btnEnd
            // 
            this.btnEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnd.Location = new System.Drawing.Point(481, 420);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(169, 30);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.Text = "Beenden";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // frmStory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 453);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "frmStory";
            this.Text = "Write your Krasse Story";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStory_FormClosed);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ListBox lbZeilen;
        private System.Windows.Forms.TextBox tbZeile;
        private System.Windows.Forms.ListView lvSpieler;
        private System.Windows.Forms.Button btnEnd;
    }
}

