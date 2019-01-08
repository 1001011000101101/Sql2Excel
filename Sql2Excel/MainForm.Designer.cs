namespace Sql2Excel
{
    partial class MainForm
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
            this.btnCreateReport = new System.Windows.Forms.Button();
            this.cbReports = new System.Windows.Forms.ComboBox();
            this.lblReport = new System.Windows.Forms.Label();
            this.lblPeriodStart = new System.Windows.Forms.Label();
            this.lblPeriodEnd = new System.Windows.Forms.Label();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblObject = new System.Windows.Forms.Label();
            this.cbPlaces = new System.Windows.Forms.ComboBox();
            this.cbServers = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateReport
            // 
            this.btnCreateReport.Enabled = false;
            this.btnCreateReport.Location = new System.Drawing.Point(70, 194);
            this.btnCreateReport.Name = "btnCreateReport";
            this.btnCreateReport.Size = new System.Drawing.Size(116, 23);
            this.btnCreateReport.TabIndex = 0;
            this.btnCreateReport.Text = "Сформировать";
            this.btnCreateReport.UseVisualStyleBackColor = true;
            this.btnCreateReport.Click += new System.EventHandler(this.btnCreateReport_Click);
            // 
            // cbReports
            // 
            this.cbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReports.Enabled = false;
            this.cbReports.FormattingEnabled = true;
            this.cbReports.Location = new System.Drawing.Point(70, 81);
            this.cbReports.Name = "cbReports";
            this.cbReports.Size = new System.Drawing.Size(200, 21);
            this.cbReports.TabIndex = 1;
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Location = new System.Drawing.Point(25, 81);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(36, 13);
            this.lblReport.TabIndex = 2;
            this.lblReport.Text = "Отчет";
            // 
            // lblPeriodStart
            // 
            this.lblPeriodStart.AutoSize = true;
            this.lblPeriodStart.Location = new System.Drawing.Point(7, 108);
            this.lblPeriodStart.Name = "lblPeriodStart";
            this.lblPeriodStart.Size = new System.Drawing.Size(54, 13);
            this.lblPeriodStart.TabIndex = 3;
            this.lblPeriodStart.Text = "Период с";
            // 
            // lblPeriodEnd
            // 
            this.lblPeriodEnd.AutoSize = true;
            this.lblPeriodEnd.Location = new System.Drawing.Point(42, 138);
            this.lblPeriodEnd.Name = "lblPeriodEnd";
            this.lblPeriodEnd.Size = new System.Drawing.Size(19, 13);
            this.lblPeriodEnd.TabIndex = 4;
            this.lblPeriodEnd.Text = "до";
            // 
            // dtBegin
            // 
            this.dtBegin.Location = new System.Drawing.Point(70, 108);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(200, 20);
            this.dtBegin.TabIndex = 5;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(70, 138);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 20);
            this.dtEnd.TabIndex = 6;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(192, 194);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(78, 23);
            this.btnOpenFolder.TabIndex = 7;
            this.btnOpenFolder.Text = "Открыть";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 223);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(300, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lblObject
            // 
            this.lblObject.AutoSize = true;
            this.lblObject.Location = new System.Drawing.Point(25, 54);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(45, 13);
            this.lblObject.TabIndex = 9;
            this.lblObject.Text = "Объект";
            // 
            // cbPlaces
            // 
            this.cbPlaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlaces.Enabled = false;
            this.cbPlaces.FormattingEnabled = true;
            this.cbPlaces.Location = new System.Drawing.Point(70, 54);
            this.cbPlaces.Name = "cbPlaces";
            this.cbPlaces.Size = new System.Drawing.Size(200, 21);
            this.cbPlaces.TabIndex = 10;
            // 
            // cbServers
            // 
            this.cbServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServers.Enabled = false;
            this.cbServers.FormattingEnabled = true;
            this.cbServers.Location = new System.Drawing.Point(70, 27);
            this.cbServers.Name = "cbServers";
            this.cbServers.Size = new System.Drawing.Size(200, 21);
            this.cbServers.TabIndex = 11;
            this.cbServers.SelectedIndexChanged += new System.EventHandler(this.cbServers_SelectedIndexChanged);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(25, 27);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(44, 13);
            this.lblServer.TabIndex = 12;
            this.lblServer.Text = "Сервер";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 245);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.cbServers);
            this.Controls.Add(this.cbPlaces);
            this.Controls.Add(this.lblObject);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtBegin);
            this.Controls.Add(this.lblPeriodEnd);
            this.Controls.Add(this.lblPeriodStart);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.cbReports);
            this.Controls.Add(this.btnCreateReport);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(308, 272);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(308, 272);
            this.Name = "MainForm";
            this.Text = "Sql2Excel";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateReport;
        private System.Windows.Forms.ComboBox cbReports;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.Label lblPeriodStart;
        private System.Windows.Forms.Label lblPeriodEnd;
        private System.Windows.Forms.DateTimePicker dtBegin;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.ComboBox cbPlaces;
        private System.Windows.Forms.ComboBox cbServers;
        private System.Windows.Forms.Label lblServer;
    }
}

