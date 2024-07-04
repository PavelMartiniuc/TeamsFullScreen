using System.ComponentModel;

namespace TeamsFullScreen
{
    partial class frmMain
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
            if (disposing && (components != null))
            {
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
            gvProcesses = new DataGridView();
            Handle = new DataGridViewTextBoxColumn();
            Process = new DataGridViewTextBoxColumn();
            MainTitle = new DataGridViewTextBoxColumn();
            btnRefreshProcesses = new Button();
            btnFullScreen = new Button();
            btSetShow = new Button();
            btSetHide = new Button();
            btMoveLeft = new Button();
            btMoveRight = new Button();
            btMoveTop = new Button();
            btMoveButtom = new Button();
            label1 = new Label();
            btWidthUp = new Button();
            btWidthDown = new Button();
            label2 = new Label();
            btHeightDown = new Button();
            btHeightUp = new Button();
            label3 = new Label();
            lbX = new Label();
            lbY = new Label();
            lbWidth = new Label();
            lbHeight = new Label();
            btTeamsFullscreen = new Button();
            groupBox1 = new GroupBox();
            fsZoomed = new RadioButton();
            fsNormal = new RadioButton();
            lbProcessname = new Label();
            txtProcessName = new ComboBox();
            ((ISupportInitialize)gvProcesses).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // gvProcesses
            // 
            gvProcesses.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gvProcesses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvProcesses.Columns.AddRange(new DataGridViewColumn[] { Handle, Process, MainTitle });
            gvProcesses.Location = new Point(12, 52);
            gvProcesses.MultiSelect = false;
            gvProcesses.Name = "gvProcesses";
            gvProcesses.RowHeadersWidth = 47;
            gvProcesses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvProcesses.Size = new Size(776, 194);
            gvProcesses.TabIndex = 0;
            // 
            // Handle
            // 
            Handle.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Handle.DataPropertyName = "MainWindowHandle";
            Handle.HeaderText = "Handle";
            Handle.MinimumWidth = 6;
            Handle.Name = "Handle";
            Handle.Width = 70;
            // 
            // Process
            // 
            Process.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Process.DataPropertyName = "ProcessName";
            Process.HeaderText = "Process";
            Process.MinimumWidth = 6;
            Process.Name = "Process";
            Process.Width = 115;
            // 
            // MainTitle
            // 
            MainTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MainTitle.DataPropertyName = "MainWindowTitle";
            MainTitle.HeaderText = "Main window title";
            MainTitle.MinimumWidth = 6;
            MainTitle.Name = "MainTitle";
            // 
            // btnRefreshProcesses
            // 
            btnRefreshProcesses.Location = new Point(12, 12);
            btnRefreshProcesses.Name = "btnRefreshProcesses";
            btnRefreshProcesses.Size = new Size(86, 34);
            btnRefreshProcesses.TabIndex = 1;
            btnRefreshProcesses.Text = "Refresh";
            btnRefreshProcesses.UseVisualStyleBackColor = true;
            btnRefreshProcesses.Click += btnRefreshProcesses_Click;
            // 
            // btnFullScreen
            // 
            btnFullScreen.Location = new Point(104, 12);
            btnFullScreen.Name = "btnFullScreen";
            btnFullScreen.Size = new Size(100, 34);
            btnFullScreen.TabIndex = 2;
            btnFullScreen.Text = "Full screen";
            btnFullScreen.UseVisualStyleBackColor = true;
            btnFullScreen.Click += btnFullScreen_Click;
            // 
            // btSetShow
            // 
            btSetShow.Location = new Point(241, 12);
            btSetShow.Name = "btSetShow";
            btSetShow.Size = new Size(86, 26);
            btSetShow.TabIndex = 3;
            btSetShow.Text = "Show";
            btSetShow.UseVisualStyleBackColor = true;
            btSetShow.Visible = false;
            btSetShow.Click += btSetShow_Click;
            // 
            // btSetHide
            // 
            btSetHide.Location = new Point(343, 12);
            btSetHide.Name = "btSetHide";
            btSetHide.Size = new Size(86, 26);
            btSetHide.TabIndex = 4;
            btSetHide.Text = "Hide";
            btSetHide.UseVisualStyleBackColor = true;
            btSetHide.Visible = false;
            btSetHide.Click += button1_Click_1;
            // 
            // btMoveLeft
            // 
            btMoveLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btMoveLeft.Location = new Point(92, 331);
            btMoveLeft.Name = "btMoveLeft";
            btMoveLeft.Size = new Size(62, 58);
            btMoveLeft.TabIndex = 6;
            btMoveLeft.Text = "Left";
            btMoveLeft.UseVisualStyleBackColor = true;
            btMoveLeft.Click += btMoveLeft_Click;
            // 
            // btMoveRight
            // 
            btMoveRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btMoveRight.Location = new Point(242, 331);
            btMoveRight.Name = "btMoveRight";
            btMoveRight.Size = new Size(62, 58);
            btMoveRight.TabIndex = 7;
            btMoveRight.Text = "Right";
            btMoveRight.UseVisualStyleBackColor = true;
            btMoveRight.Click += btMoveRight_Click;
            // 
            // btMoveTop
            // 
            btMoveTop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btMoveTop.Location = new Point(167, 266);
            btMoveTop.Name = "btMoveTop";
            btMoveTop.Size = new Size(70, 57);
            btMoveTop.TabIndex = 8;
            btMoveTop.Text = "Top";
            btMoveTop.UseVisualStyleBackColor = true;
            btMoveTop.Click += btMoveTop_Click;
            // 
            // btMoveButtom
            // 
            btMoveButtom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btMoveButtom.Location = new Point(167, 402);
            btMoveButtom.Name = "btMoveButtom";
            btMoveButtom.Size = new Size(70, 54);
            btMoveButtom.TabIndex = 9;
            btMoveButtom.Text = "Bottom";
            btMoveButtom.UseVisualStyleBackColor = true;
            btMoveButtom.Click += btMoveButtom_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(172, 351);
            label1.Name = "label1";
            label1.Size = new Size(56, 19);
            label1.TabIndex = 10;
            label1.Text = "Moving";
            // 
            // btWidthUp
            // 
            btWidthUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btWidthUp.Location = new Point(717, 266);
            btWidthUp.Name = "btWidthUp";
            btWidthUp.Size = new Size(62, 57);
            btWidthUp.TabIndex = 11;
            btWidthUp.Text = "Up";
            btWidthUp.UseVisualStyleBackColor = true;
            btWidthUp.Click += btWidthUp_Click;
            // 
            // btWidthDown
            // 
            btWidthDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btWidthDown.Location = new Point(560, 266);
            btWidthDown.Name = "btWidthDown";
            btWidthDown.Size = new Size(62, 57);
            btWidthDown.TabIndex = 12;
            btWidthDown.Text = "Down";
            btWidthDown.UseVisualStyleBackColor = true;
            btWidthDown.Click += btWidthDown_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(646, 285);
            label2.Name = "label2";
            label2.Size = new Size(46, 19);
            label2.TabIndex = 13;
            label2.Text = "Width";
            // 
            // btHeightDown
            // 
            btHeightDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btHeightDown.Location = new Point(400, 266);
            btHeightDown.Name = "btHeightDown";
            btHeightDown.Size = new Size(62, 57);
            btHeightDown.TabIndex = 14;
            btHeightDown.Text = "Down";
            btHeightDown.UseVisualStyleBackColor = true;
            btHeightDown.Click += btHeightDown_Click;
            // 
            // btHeightUp
            // 
            btHeightUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btHeightUp.Location = new Point(400, 401);
            btHeightUp.Name = "btHeightUp";
            btHeightUp.Size = new Size(62, 57);
            btHeightUp.TabIndex = 15;
            btHeightUp.Text = "Up";
            btHeightUp.UseVisualStyleBackColor = true;
            btHeightUp.Click += btHeightUp_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(407, 351);
            label3.Name = "label3";
            label3.Size = new Size(50, 19);
            label3.TabIndex = 16;
            label3.Text = "Height";
            // 
            // lbX
            // 
            lbX.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbX.AutoSize = true;
            lbX.Location = new Point(560, 351);
            lbX.Name = "lbX";
            lbX.Size = new Size(24, 19);
            lbX.TabIndex = 17;
            lbX.Text = "X: ";
            // 
            // lbY
            // 
            lbY.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbY.AutoSize = true;
            lbY.Location = new Point(560, 392);
            lbY.Name = "lbY";
            lbY.Size = new Size(24, 19);
            lbY.TabIndex = 18;
            lbY.Text = "Y: ";
            // 
            // lbWidth
            // 
            lbWidth.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbWidth.AutoSize = true;
            lbWidth.Location = new Point(668, 351);
            lbWidth.Name = "lbWidth";
            lbWidth.Size = new Size(53, 19);
            lbWidth.TabIndex = 19;
            lbWidth.Text = "Width: ";
            // 
            // lbHeight
            // 
            lbHeight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbHeight.AutoSize = true;
            lbHeight.Location = new Point(668, 392);
            lbHeight.Name = "lbHeight";
            lbHeight.Size = new Size(57, 19);
            lbHeight.TabIndex = 20;
            lbHeight.Text = "Height: ";
            // 
            // btTeamsFullscreen
            // 
            btTeamsFullscreen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btTeamsFullscreen.Location = new Point(560, 422);
            btTeamsFullscreen.Name = "btTeamsFullscreen";
            btTeamsFullscreen.Size = new Size(219, 54);
            btTeamsFullscreen.TabIndex = 21;
            btTeamsFullscreen.Text = "Fullscreen for Teams";
            btTeamsFullscreen.UseVisualStyleBackColor = true;
            btTeamsFullscreen.Click += btTeamsFullscreen_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(fsZoomed);
            groupBox1.Controls.Add(fsNormal);
            groupBox1.Location = new Point(24, 458);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(264, 47);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Teams fullscreen preset";
            // 
            // fsZoomed
            // 
            fsZoomed.AutoSize = true;
            fsZoomed.Checked = true;
            fsZoomed.Location = new Point(157, 16);
            fsZoomed.Name = "fsZoomed";
            fsZoomed.Size = new Size(78, 23);
            fsZoomed.TabIndex = 24;
            fsZoomed.TabStop = true;
            fsZoomed.Text = "Zoomed";
            fsZoomed.UseVisualStyleBackColor = true;
            // 
            // fsNormal
            // 
            fsNormal.AutoSize = true;
            fsNormal.Location = new Point(22, 16);
            fsNormal.Name = "fsNormal";
            fsNormal.Size = new Size(72, 23);
            fsNormal.TabIndex = 23;
            fsNormal.Text = "Normal";
            fsNormal.UseVisualStyleBackColor = true;
            // 
            // lbProcessname
            // 
            lbProcessname.AutoSize = true;
            lbProcessname.Location = new Point(474, 16);
            lbProcessname.Name = "lbProcessname";
            lbProcessname.Size = new Size(93, 19);
            lbProcessname.TabIndex = 24;
            lbProcessname.Text = "Process name";
            // 
            // txtProcessName
            // 
            txtProcessName.FormattingEnabled = true;
            txtProcessName.Items.AddRange(new object[] { "firefox", "waterfox" });
            txtProcessName.Location = new Point(597, 12);
            txtProcessName.Name = "txtProcessName";
            txtProcessName.Size = new Size(182, 27);
            txtProcessName.TabIndex = 25;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 509);
            Controls.Add(txtProcessName);
            Controls.Add(lbProcessname);
            Controls.Add(btnFullScreen);
            Controls.Add(btnRefreshProcesses);
            Controls.Add(groupBox1);
            Controls.Add(btTeamsFullscreen);
            Controls.Add(lbHeight);
            Controls.Add(lbWidth);
            Controls.Add(lbY);
            Controls.Add(lbX);
            Controls.Add(label3);
            Controls.Add(btHeightUp);
            Controls.Add(btHeightDown);
            Controls.Add(label2);
            Controls.Add(btWidthDown);
            Controls.Add(btWidthUp);
            Controls.Add(label1);
            Controls.Add(btMoveButtom);
            Controls.Add(btMoveTop);
            Controls.Add(btMoveRight);
            Controls.Add(btMoveLeft);
            Controls.Add(btSetHide);
            Controls.Add(btSetShow);
            Controls.Add(gvProcesses);
            Name = "frmMain";
            Text = "Teams full screen for firefox";
            Load += Form1_Load;
            ((ISupportInitialize)gvProcesses).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gvProcesses;
        private Button btnRefreshProcesses;
        private Button btnFullScreen;
        private DataGridViewTextBoxColumn Handle;
        private DataGridViewTextBoxColumn Process;
        private DataGridViewTextBoxColumn MainTitle;
        private Label lbProcessname;
        private ComboBox txtProcessName;
    }
}
