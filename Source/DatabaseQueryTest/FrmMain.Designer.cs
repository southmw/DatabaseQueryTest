namespace DatabaseQueryTest
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            txbDebug=new Serilog.Sinks.WinForms.Core.SimpleLogTextBox();
            plLog=new Panel();
            plCommand=new Panel();
            ckbResultView=new CheckBox();
            btnClearLog=new Button();
            ckbPwView=new CheckBox();
            btnClearQuery=new Button();
            btnExcuteQuery=new Button();
            txbQuery=new TextBox();
            label6=new Label();
            label5=new Label();
            label4=new Label();
            label3=new Label();
            label2=new Label();
            label1=new Label();
            txbTimeout=new TextBox();
            txbPassword=new TextBox();
            txbUserID=new TextBox();
            txbServerPort=new TextBox();
            txbDBName=new TextBox();
            txbServerIP=new TextBox();
            plResultGrid=new Panel();
            dgvResult=new DataGridView();
            btnSaveCfg=new Button();
            plLog.SuspendLayout();
            plCommand.SuspendLayout();
            plResultGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResult).BeginInit();
            SuspendLayout();
            // 
            // txbDebug
            // 
            txbDebug.AutoScroll=true;
            txbDebug.Dock=DockStyle.Fill;
            txbDebug.ForContext="";
            txbDebug.Location=new Point(0, 0);
            txbDebug.LogBorderStyle=BorderStyle.Fixed3D;
            txbDebug.LogPadding=new Padding(3);
            txbDebug.Margin=new Padding(5, 3, 5, 3);
            txbDebug.Name="txbDebug";
            txbDebug.ReadOnly=true;
            txbDebug.ScrollBars=ScrollBars.Both;
            txbDebug.Size=new Size(1022, 323);
            txbDebug.TabIndex=0;
            txbDebug.TabStop=false;
            // 
            // plLog
            // 
            plLog.BorderStyle=BorderStyle.FixedSingle;
            plLog.Controls.Add(txbDebug);
            plLog.Dock=DockStyle.Fill;
            plLog.Location=new Point(0, 169);
            plLog.Name="plLog";
            plLog.Size=new Size(1024, 325);
            plLog.TabIndex=1;
            // 
            // plCommand
            // 
            plCommand.BorderStyle=BorderStyle.FixedSingle;
            plCommand.Controls.Add(btnSaveCfg);
            plCommand.Controls.Add(ckbResultView);
            plCommand.Controls.Add(btnClearLog);
            plCommand.Controls.Add(ckbPwView);
            plCommand.Controls.Add(btnClearQuery);
            plCommand.Controls.Add(btnExcuteQuery);
            plCommand.Controls.Add(txbQuery);
            plCommand.Controls.Add(label6);
            plCommand.Controls.Add(label5);
            plCommand.Controls.Add(label4);
            plCommand.Controls.Add(label3);
            plCommand.Controls.Add(label2);
            plCommand.Controls.Add(label1);
            plCommand.Controls.Add(txbTimeout);
            plCommand.Controls.Add(txbPassword);
            plCommand.Controls.Add(txbUserID);
            plCommand.Controls.Add(txbServerPort);
            plCommand.Controls.Add(txbDBName);
            plCommand.Controls.Add(txbServerIP);
            plCommand.Dock=DockStyle.Top;
            plCommand.Location=new Point(0, 0);
            plCommand.Name="plCommand";
            plCommand.Size=new Size(1024, 169);
            plCommand.TabIndex=1;
            // 
            // ckbResultView
            // 
            ckbResultView.AutoSize=true;
            ckbResultView.Location=new Point(63, 138);
            ckbResultView.Name="ckbResultView";
            ckbResultView.Size=new Size(95, 21);
            ckbResultView.TabIndex=7;
            ckbResultView.Text="ResultView";
            ckbResultView.UseVisualStyleBackColor=true;
            ckbResultView.CheckedChanged+=CkbResultView_CheckedChanged;
            // 
            // btnClearLog
            // 
            btnClearLog.Location=new Point(925, 138);
            btnClearLog.Name="btnClearLog";
            btnClearLog.Size=new Size(87, 25);
            btnClearLog.TabIndex=6;
            btnClearLog.TabStop=false;
            btnClearLog.Text="Log Clear";
            btnClearLog.UseVisualStyleBackColor=true;
            btnClearLog.Click+=BtnClearLog_Click;
            // 
            // ckbPwView
            // 
            ckbPwView.AutoSize=true;
            ckbPwView.Location=new Point(865, 16);
            ckbPwView.Name="ckbPwView";
            ckbPwView.Size=new Size(15, 14);
            ckbPwView.TabIndex=5;
            ckbPwView.TabStop=false;
            ckbPwView.UseVisualStyleBackColor=true;
            ckbPwView.CheckedChanged+=CkbPwView_CheckedChanged;
            // 
            // btnClearQuery
            // 
            btnClearQuery.Location=new Point(940, 73);
            btnClearQuery.Name="btnClearQuery";
            btnClearQuery.Size=new Size(72, 25);
            btnClearQuery.TabIndex=4;
            btnClearQuery.TabStop=false;
            btnClearQuery.Text="Clear";
            btnClearQuery.UseVisualStyleBackColor=true;
            btnClearQuery.Click+=BtnClearQuery_Click;
            // 
            // btnExcuteQuery
            // 
            btnExcuteQuery.Location=new Point(940, 42);
            btnExcuteQuery.Name="btnExcuteQuery";
            btnExcuteQuery.Size=new Size(72, 25);
            btnExcuteQuery.TabIndex=4;
            btnExcuteQuery.TabStop=false;
            btnExcuteQuery.Text="Excute";
            btnExcuteQuery.UseVisualStyleBackColor=true;
            btnExcuteQuery.Click+=BtnExcuteQuery_Click;
            // 
            // txbQuery
            // 
            txbQuery.Location=new Point(63, 42);
            txbQuery.Multiline=true;
            txbQuery.Name="txbQuery";
            txbQuery.Size=new Size(871, 90);
            txbQuery.TabIndex=3;
            txbQuery.TabStop=false;
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(12, 45);
            label6.Name="label6";
            label6.Size=new Size(45, 17);
            label6.TabIndex=2;
            label6.Text="Query";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(886, 15);
            label5.Name="label5";
            label5.Size=new Size(60, 17);
            label5.TabIndex=1;
            label5.Text="Timeout";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(611, 15);
            label4.Name="label4";
            label4.Size=new Size(66, 17);
            label4.TabIndex=1;
            label4.Text="Password";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(436, 14);
            label3.Name="label3";
            label3.Size=new Size(55, 17);
            label3.TabIndex=1;
            label3.Text="User ID";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(253, 15);
            label2.Name="label2";
            label2.Size=new Size(67, 17);
            label2.TabIndex=1;
            label2.Text="DB Name";
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(11, 15);
            label1.Name="label1";
            label1.Size=new Size(46, 17);
            label1.TabIndex=1;
            label1.Text="Server";
            // 
            // txbTimeout
            // 
            txbTimeout.Location=new Point(952, 12);
            txbTimeout.Name="txbTimeout";
            txbTimeout.Size=new Size(60, 25);
            txbTimeout.TabIndex=0;
            txbTimeout.TabStop=false;
            txbTimeout.Text="30";
            txbTimeout.TextAlign=HorizontalAlignment.Center;
            // 
            // txbPassword
            // 
            txbPassword.Location=new Point(683, 11);
            txbPassword.Name="txbPassword";
            txbPassword.Size=new Size(176, 25);
            txbPassword.TabIndex=0;
            txbPassword.TabStop=false;
            txbPassword.TextAlign=HorizontalAlignment.Center;
            txbPassword.UseSystemPasswordChar=true;
            // 
            // txbUserID
            // 
            txbUserID.Location=new Point(497, 11);
            txbUserID.Name="txbUserID";
            txbUserID.Size=new Size(108, 25);
            txbUserID.TabIndex=0;
            txbUserID.TabStop=false;
            txbUserID.Text="sa";
            txbUserID.TextAlign=HorizontalAlignment.Center;
            // 
            // txbServerPort
            // 
            txbServerPort.Location=new Point(194, 11);
            txbServerPort.Name="txbServerPort";
            txbServerPort.Size=new Size(53, 25);
            txbServerPort.TabIndex=0;
            txbServerPort.TabStop=false;
            txbServerPort.Text="1433";
            txbServerPort.TextAlign=HorizontalAlignment.Center;
            // 
            // txbDBName
            // 
            txbDBName.Location=new Point(326, 11);
            txbDBName.Name="txbDBName";
            txbDBName.Size=new Size(104, 25);
            txbDBName.TabIndex=0;
            txbDBName.TabStop=false;
            txbDBName.Text="TESTDB";
            txbDBName.TextAlign=HorizontalAlignment.Center;
            // 
            // txbServerIP
            // 
            txbServerIP.Location=new Point(63, 11);
            txbServerIP.Name="txbServerIP";
            txbServerIP.Size=new Size(125, 25);
            txbServerIP.TabIndex=0;
            txbServerIP.TabStop=false;
            txbServerIP.Text="127.0.0.1";
            txbServerIP.TextAlign=HorizontalAlignment.Center;
            // 
            // plResultGrid
            // 
            plResultGrid.BorderStyle=BorderStyle.FixedSingle;
            plResultGrid.Controls.Add(dgvResult);
            plResultGrid.Dock=DockStyle.Bottom;
            plResultGrid.Location=new Point(0, 494);
            plResultGrid.Name="plResultGrid";
            plResultGrid.Size=new Size(1024, 274);
            plResultGrid.TabIndex=7;
            plResultGrid.Visible=false;
            // 
            // dgvResult
            // 
            dgvResult.AllowUserToAddRows=false;
            dgvResult.AllowUserToDeleteRows=false;
            dgvResult.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResult.Dock=DockStyle.Fill;
            dgvResult.Location=new Point(0, 0);
            dgvResult.MultiSelect=false;
            dgvResult.Name="dgvResult";
            dgvResult.ReadOnly=true;
            dgvResult.RowHeadersVisible=false;
            dgvResult.RowTemplate.Height=25;
            dgvResult.Size=new Size(1022, 272);
            dgvResult.TabIndex=0;
            // 
            // btnSaveCfg
            // 
            btnSaveCfg.Location=new Point(832, 138);
            btnSaveCfg.Name="btnSaveCfg";
            btnSaveCfg.Size=new Size(87, 25);
            btnSaveCfg.TabIndex=8;
            btnSaveCfg.Text="Save Cfg";
            btnSaveCfg.UseVisualStyleBackColor=true;
            btnSaveCfg.Click+=BtnSaveCfg_Click;
            // 
            // FrmMain
            // 
            AutoScaleMode=AutoScaleMode.None;
            BackColor=Color.White;
            ClientSize=new Size(1024, 768);
            Controls.Add(plLog);
            Controls.Add(plResultGrid);
            Controls.Add(plCommand);
            Font=new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle=FormBorderStyle.FixedSingle;
            Icon=(Icon)resources.GetObject("$this.Icon");
            Name="FrmMain";
            Text="MSSQL Query Test";
            Load+=FrmMain_Load;
            plLog.ResumeLayout(false);
            plCommand.ResumeLayout(false);
            plCommand.PerformLayout();
            plResultGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResult).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Serilog.Sinks.WinForms.Core.SimpleLogTextBox txbDebug;
        private Panel plLog;
        private Panel plCommand;
        private Label label1;
        private TextBox txbServerIP;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txbTimeout;
        private TextBox txbPassword;
        private TextBox txbUserID;
        private TextBox txbServerPort;
        private TextBox txbDBName;
        private Button btnClearQuery;
        private Button btnExcuteQuery;
        private TextBox txbQuery;
        private Label label6;
        private CheckBox ckbPwView;
        private Button btnClearLog;
        private Panel plResultGrid;
        private DataGridView dgvResult;
        private CheckBox ckbResultView;
        private Button btnSaveCfg;
    }
}