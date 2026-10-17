namespace Bai03_SupermarketMDI
{
    partial class frmMain
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
            menuStrip1 = new MenuStrip();
            menuSystem = new ToolStripMenuItem();
            menuLogout = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuExit = new ToolStripMenuItem();
            menuCatalog = new ToolStripMenuItem();
            menuProductCatalog = new ToolStripMenuItem();
            menuStockManager = new ToolStripMenuItem();
            menuReport = new ToolStripMenuItem();
            menuAsyncReport = new ToolStripMenuItem();
            menuWindow = new ToolStripMenuItem();
            menuCascade = new ToolStripMenuItem();
            menuTileHorizontal = new ToolStripMenuItem();
            menuTileVertical = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            sslCurrentUser = new ToolStripStatusLabel();
            sslStatus = new ToolStripStatusLabel();
            tspbMainProgress = new ToolStripProgressBar();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuSystem, menuCatalog, menuReport, menuWindow });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MdiWindowListItem = menuWindow;
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1182, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuSystem
            // 
            menuSystem.DropDownItems.AddRange(new ToolStripItem[] { menuLogout, toolStripSeparator1, menuExit });
            menuSystem.Name = "menuSystem";
            menuSystem.Size = new Size(85, 24);
            menuSystem.Text = "Hệ thống";
            // 
            // menuLogout
            // 
            menuLogout.Name = "menuLogout";
            menuLogout.Size = new Size(160, 26);
            menuLogout.Text = "Đăng xuất";
            menuLogout.Click += menuLogout_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(157, 6);
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.ShortcutKeys = Keys.Alt | Keys.F4;
            menuExit.Size = new Size(160, 26);
            menuExit.Text = "Thoát";
            menuExit.Click += menuExit_Click;
            // 
            // menuCatalog
            // 
            menuCatalog.DropDownItems.AddRange(new ToolStripItem[] { menuProductCatalog, menuStockManager });
            menuCatalog.Name = "menuCatalog";
            menuCatalog.Size = new Size(90, 24);
            menuCatalog.Text = "Danh mục";
            // 
            // menuProductCatalog
            // 
            menuProductCatalog.Name = "menuProductCatalog";
            menuProductCatalog.ShortcutKeys = Keys.Control | Keys.P;
            menuProductCatalog.Size = new Size(265, 26);
            menuProductCatalog.Text = "Quản lý Sản phẩm";
            menuProductCatalog.Click += menuProductCatalog_Click;
            // 
            // menuStockManager
            // 
            menuStockManager.Name = "menuStockManager";
            menuStockManager.ShortcutKeys = Keys.Control | Keys.I;
            menuStockManager.Size = new Size(265, 26);
            menuStockManager.Text = "Quản lý Nhập xuất";
            menuStockManager.Click += menuStockManager_Click;
            // 
            // menuReport
            // 
            menuReport.DropDownItems.AddRange(new ToolStripItem[] { menuAsyncReport });
            menuReport.Name = "menuReport";
            menuReport.Size = new Size(77, 24);
            menuReport.Text = "Báo cáo";
            // 
            // menuAsyncReport
            // 
            menuAsyncReport.Name = "menuAsyncReport";
            menuAsyncReport.ShortcutKeys = Keys.Control | Keys.R;
            menuAsyncReport.Size = new Size(282, 26);
            menuAsyncReport.Text = "Thống kê Doanh thu";
            menuAsyncReport.Click += menuAsyncReport_Click;
            // 
            // menuWindow
            // 
            menuWindow.DropDownItems.AddRange(new ToolStripItem[] { menuCascade, menuTileHorizontal, menuTileVertical });
            menuWindow.Name = "menuWindow";
            menuWindow.Size = new Size(73, 24);
            menuWindow.Text = "Cửa sổ";
            // 
            // menuCascade
            // 
            menuCascade.Name = "menuCascade";
            menuCascade.Size = new Size(207, 26);
            menuCascade.Text = "Cascade";
            menuCascade.Click += menuCascade_Click;
            // 
            // menuTileHorizontal
            // 
            menuTileHorizontal.Name = "menuTileHorizontal";
            menuTileHorizontal.Size = new Size(207, 26);
            menuTileHorizontal.Text = "Tile Horizontal";
            menuTileHorizontal.Click += menuTileHorizontal_Click;
            // 
            // menuTileVertical
            // 
            menuTileVertical.Name = "menuTileVertical";
            menuTileVertical.Size = new Size(207, 26);
            menuTileVertical.Text = "Tile Vertical";
            menuTileVertical.Click += menuTileVertical_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { sslCurrentUser, sslStatus, tspbMainProgress });
            statusStrip1.Location = new Point(0, 727);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1182, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // sslCurrentUser
            // 
            sslCurrentUser.BorderSides = ToolStripStatusLabelBorderSides.Right;
            sslCurrentUser.Name = "sslCurrentUser";
            sslCurrentUser.Size = new Size(390, 20);
            sslCurrentUser.Text = "Người dùng: Lê Ngọc Quyền (MSSV: 24810310259 - D19CNPM3)";
            // 
            // sslStatus
            // 
            sslStatus.Name = "sslStatus";
            sslStatus.Size = new Size(140, 20);
            sslStatus.Text = "Trạng thái: Sẵn sàng";
            // 
            // tspbMainProgress
            // 
            tspbMainProgress.Alignment = ToolStripItemAlignment.Right;
            tspbMainProgress.Name = "tspbMainProgress";
            tspbMainProgress.Size = new Size(200, 18);
            tspbMainProgress.Visible = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1000, 650);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Siêu thị - MDI Architecture (Lê Ngọc Quyền - 24810310259)";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuSystem;
        private ToolStripMenuItem menuLogout;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menuExit;
        private ToolStripMenuItem menuCatalog;
        private ToolStripMenuItem menuProductCatalog;
        private ToolStripMenuItem menuStockManager;
        private ToolStripMenuItem menuReport;
        private ToolStripMenuItem menuAsyncReport;
        private ToolStripMenuItem menuWindow;
        private ToolStripMenuItem menuCascade;
        private ToolStripMenuItem menuTileHorizontal;
        private ToolStripMenuItem menuTileVertical;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel sslCurrentUser;
        private ToolStripStatusLabel sslStatus;
        private ToolStripProgressBar tspbMainProgress;
    }
}
