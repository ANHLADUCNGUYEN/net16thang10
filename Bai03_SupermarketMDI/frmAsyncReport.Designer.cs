namespace Bai03_SupermarketMDI
{
    partial class frmAsyncReport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpAsyncReport = new GroupBox();
            lblReportStatus = new Label();
            btnCancelReport = new Button();
            btnLoadRevenueReport = new Button();
            dgvRevenue = new DataGridView();
            grpCrossThreadSync = new GroupBox();
            lblInvokeNote = new Label();
            lstSyncLog = new ListBox();
            lblSyncStatus = new Label();
            btnToggleSync = new Button();
            grpAsyncReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).BeginInit();
            grpCrossThreadSync.SuspendLayout();
            SuspendLayout();
            // 
            // grpAsyncReport
            // 
            grpAsyncReport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpAsyncReport.Controls.Add(lblReportStatus);
            grpAsyncReport.Controls.Add(btnCancelReport);
            grpAsyncReport.Controls.Add(btnLoadRevenueReport);
            grpAsyncReport.Controls.Add(dgvRevenue);
            grpAsyncReport.Location = new Point(15, 12);
            grpAsyncReport.Name = "grpAsyncReport";
            grpAsyncReport.Size = new Size(950, 310);
            grpAsyncReport.TabIndex = 0;
            grpAsyncReport.TabStop = false;
            grpAsyncReport.Text = "Scenario B: Báo cáo Thống kê Doanh thu (Async/Await & Multi-Threading không đơ UI)";
            // 
            // lblReportStatus
            // 
            lblReportStatus.AutoSize = true;
            lblReportStatus.Location = new Point(370, 35);
            lblReportStatus.Name = "lblReportStatus";
            lblReportStatus.Size = new Size(139, 20);
            lblReportStatus.TabIndex = 3;
            lblReportStatus.Text = "Trạng thái: Sẵn sàng";
            // 
            // btnCancelReport
            // 
            btnCancelReport.Enabled = false;
            btnCancelReport.Location = new Point(245, 27);
            btnCancelReport.Name = "btnCancelReport";
            btnCancelReport.Size = new Size(110, 36);
            btnCancelReport.TabIndex = 2;
            btnCancelReport.Text = "Hủy tác vụ";
            btnCancelReport.UseVisualStyleBackColor = true;
            btnCancelReport.Click += btnCancelReport_Click;
            // 
            // btnLoadRevenueReport
            // 
            btnLoadRevenueReport.Location = new Point(15, 27);
            btnLoadRevenueReport.Name = "btnLoadRevenueReport";
            btnLoadRevenueReport.Size = new Size(220, 36);
            btnLoadRevenueReport.TabIndex = 1;
            btnLoadRevenueReport.Text = "Tải Báo Cáo Doanh Thu (Async)";
            btnLoadRevenueReport.UseVisualStyleBackColor = true;
            btnLoadRevenueReport.Click += btnLoadRevenueReport_Click;
            // 
            // dgvRevenue
            // 
            dgvRevenue.AllowUserToAddRows = false;
            dgvRevenue.AllowUserToDeleteRows = false;
            dgvRevenue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRevenue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenue.Location = new Point(15, 75);
            dgvRevenue.Name = "dgvRevenue";
            dgvRevenue.ReadOnly = true;
            dgvRevenue.RowHeadersWidth = 35;
            dgvRevenue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRevenue.Size = new Size(920, 220);
            dgvRevenue.TabIndex = 0;
            // 
            // grpCrossThreadSync
            // 
            grpCrossThreadSync.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpCrossThreadSync.Controls.Add(lblInvokeNote);
            grpCrossThreadSync.Controls.Add(lstSyncLog);
            grpCrossThreadSync.Controls.Add(lblSyncStatus);
            grpCrossThreadSync.Controls.Add(btnToggleSync);
            grpCrossThreadSync.Location = new Point(15, 335);
            grpCrossThreadSync.Name = "grpCrossThreadSync";
            grpCrossThreadSync.Size = new Size(950, 245);
            grpCrossThreadSync.TabIndex = 1;
            grpCrossThreadSync.TabStop = false;
            grpCrossThreadSync.Text = "Scenario C: Cập nhật UI an toàn từ Background Thread (Safe Cross-Thread Invoke)";
            // 
            // lblInvokeNote
            // 
            lblInvokeNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInvokeNote.AutoSize = true;
            lblInvokeNote.ForeColor = Color.DarkBlue;
            lblInvokeNote.Location = new Point(570, 35);
            lblInvokeNote.Name = "lblInvokeNote";
            lblInvokeNote.Size = new Size(365, 20);
            lblInvokeNote.TabIndex = 3;
            lblInvokeNote.Text = "* Áp dụng InvokeRequired / this.Invoke() an toàn luồng";
            // 
            // lstSyncLog
            // 
            lstSyncLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstSyncLog.FormattingEnabled = true;
            lstSyncLog.ItemHeight = 20;
            lstSyncLog.Location = new Point(15, 75);
            lstSyncLog.Name = "lstSyncLog";
            lstSyncLog.Size = new Size(920, 144);
            lstSyncLog.TabIndex = 2;
            // 
            // lblSyncStatus
            // 
            lblSyncStatus.AutoSize = true;
            lblSyncStatus.Location = new Point(290, 35);
            lblSyncStatus.Name = "lblSyncStatus";
            lblSyncStatus.Size = new Size(205, 20);
            lblSyncStatus.TabIndex = 1;
            lblSyncStatus.Text = "Tiến trình đồng bộ: Đang dừng";
            // 
            // btnToggleSync
            // 
            btnToggleSync.Location = new Point(15, 27);
            btnToggleSync.Name = "btnToggleSync";
            btnToggleSync.Size = new Size(260, 36);
            btnToggleSync.TabIndex = 0;
            btnToggleSync.Text = "Bắt đầu đồng bộ ngầm (2s / lần)";
            btnToggleSync.UseVisualStyleBackColor = true;
            btnToggleSync.Click += btnToggleSync_Click;
            // 
            // frmAsyncReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 590);
            Controls.Add(grpCrossThreadSync);
            Controls.Add(grpAsyncReport);
            MinimumSize = new Size(900, 550);
            Name = "frmAsyncReport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Báo cáo Thống kê Doanh thu & Đồng bộ dữ liệu Bất đồng bộ";
            FormClosing += frmAsyncReport_FormClosing;
            Load += frmAsyncReport_Load;
            grpAsyncReport.ResumeLayout(false);
            grpAsyncReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).EndInit();
            grpCrossThreadSync.ResumeLayout(false);
            grpCrossThreadSync.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpAsyncReport;
        private DataGridView dgvRevenue;
        private Button btnLoadRevenueReport;
        private Button btnCancelReport;
        private Label lblReportStatus;
        private GroupBox grpCrossThreadSync;
        private Button btnToggleSync;
        private Label lblSyncStatus;
        private ListBox lstSyncLog;
        private Label lblInvokeNote;
    }
}
