using System;
using System.Windows.Forms;

namespace Bai03_SupermarketMDI
{
    public partial class frmMain : Form
    {
        private bool isClosingConfirmed = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object? sender, EventArgs e)
        {
            sslCurrentUser.Text = "Người dùng: Nguyễn  MInh ĐỨc (MSSV: 24810310259 - D19CNPM3)";
            sslStatus.Text = "Trạng thái: Sẵn sàng làm việc";
            this.Text = "Hệ thống Quản lý Siêu thị - MDI Architecture (Nguyễn Minh Đức - 24810310259)";
        }

        #region Scenario A: Kiến trúc Điều hướng MDI
        // Khi click vào menu tương ứng:
        // - Kiểm tra xem Form con đã mở hay chưa.
        // - Nếu đã mở thì Activate() mang Form đó lên trước.
        // - Nếu chưa thì tạo mới Instance, gán MdiParent = this và hiển thị (Show()).
        public void MoFormCon(Type loaiForm)
        {
            Form? formCon = null;

            // Duyệt danh sách các Form con đang mở trong Form cha MDI
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == loaiForm)
                {
                    formCon = f;
                    break;
                }
            }

            if (formCon != null)
            {
                // Nếu đã mở thì mang lên phía trước
                if (formCon.WindowState == FormWindowState.Minimized)
                {
                    formCon.WindowState = FormWindowState.Normal;
                }
                formCon.Activate();
                formCon.BringToFront();
            }
            else
            {
                // Nếu chưa mở thì tạo mới instance và gán MdiParent
                Form fMoi = (Form)Activator.CreateInstance(loaiForm)!;
                fMoi.MdiParent = this;
                fMoi.StartPosition = FormStartPosition.CenterScreen;
                fMoi.Show();
            }
        }
        #endregion

        #region Cập nhật ProgressBar trên StatusStrip của Form Cha (Dùng chung cho tác vụ nặng)
        public void CapNhatTienTrinh(int phanTram, bool hienThi = true, string thongBao = "")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => CapNhatTienTrinh(phanTram, hienThi, thongBao)));
                return;
            }

            tspbMainProgress.Visible = hienThi;
            tspbMainProgress.Value = Math.Max(0, Math.Min(100, phanTram));

            if (!string.IsNullOrEmpty(thongBao))
            {
                sslStatus.Text = thongBao;
            }
        }

        public void DatLaiTienTrinh(string thongBao = "Trạng thái: Sẵn sàng")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => DatLaiTienTrinh(thongBao)));
                return;
            }

            tspbMainProgress.Visible = false;
            tspbMainProgress.Value = 0;
            sslStatus.Text = thongBao;
        }

        public void SetProgress(int percent, bool visible = true, string statusText = "") => CapNhatTienTrinh(percent, visible, statusText);
        public void ResetProgress(string statusText = "Trạng thái: Sẵn sàng") => DatLaiTienTrinh(statusText);
        #endregion

        #region Xử lý Menu
        private void menuProductCatalog_Click(object? sender, EventArgs e)
        {
            MoFormCon(typeof(frmProductCatalog));
        }

        private void menuStockManager_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Tính năng Quản lý Nhập xuất hàng hóa đang liên kết với Danh mục sản phẩm.\nĐang mở giao diện Danh mục sản phẩm...",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            MoFormCon(typeof(frmProductCatalog));
        }

        private void menuAsyncReport_Click(object? sender, EventArgs e)
        {
            MoFormCon(typeof(frmAsyncReport));
        }

        private void menuCascade_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void menuTileHorizontal_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuTileVertical_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void menuLogout_Click(object? sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn đăng xuất khỏi phiên làm việc hiện tại?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                // Đóng tất cả các form con đang mở
                foreach (Form child in this.MdiChildren)
                {
                    child.Close();
                }

                sslCurrentUser.Text = "Người dùng: Đã đăng xuất";
                sslStatus.Text = "Trạng thái: Vui lòng đăng nhập lại để tiếp tục.";
                MessageBox.Show("Đã đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuExit_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (isClosingConfirmed)
                return;

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi Hệ thống Quản lý Siêu thị?",
                "Xác nhận thoát hệ thống",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                isClosingConfirmed = true;
            }
        }
        #endregion
    }
}
