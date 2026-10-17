using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03_SupermarketMDI
{
    public partial class frmAsyncReport : Form
    {
        private CancellationTokenSource? _reportCts;
        private CancellationTokenSource? _syncCts;
        private bool _isSyncRunning = false;
        private int _syncSequence = 0;

        public frmAsyncReport()
        {
            InitializeComponent();
        }

        private void frmAsyncReport_Load(object? sender, EventArgs e)
        {
            ConfigureRevenueGrid();
        }

        private void ConfigureRevenueGrid()
        {
            dgvRevenue.AutoGenerateColumns = false;
            dgvRevenue.Columns.Clear();

            dgvRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Period",
                HeaderText = "Kỳ báo cáo",
                Width = 110
            });

            dgvRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Ngành hàng",
                Width = 170
            });

            dgvRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderCount",
                HeaderText = "Số đơn hàng",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalRevenue",
                HeaderText = "Doanh thu (VNĐ)",
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0 VNĐ",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalCost",
                HeaderText = "Chi phí vốn (VNĐ)",
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0 VNĐ",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvRevenue.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NetProfit",
                HeaderText = "Lợi nhuận ròng (VNĐ)",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0 VNĐ",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
        }

        #region Scenario B: Tải Báo Cáo Doanh Thu Bất Đồng Bộ (async / await & Task.Run)

        private async void btnLoadRevenueReport_Click(object? sender, EventArgs e)
        {
            _reportCts = new CancellationTokenSource();
            var token = _reportCts.Token;

            btnLoadRevenueReport.Enabled = false;
            btnCancelReport.Enabled = true;
            lblReportStatus.Text = "Trạng thái: Đang truy xuất & tính toán dữ liệu lớn (3-5 giây)...";
            lblReportStatus.ForeColor = Color.DarkOrange;

            var parent = this.MdiParent as frmMain;
            parent?.SetProgress(10, true, "Đang tải báo cáo doanh thu từ hệ thống cơ sở dữ liệu...");

            try
            {
                // Bắt buộc sử dụng async / await kết hợp Task.Run đẩy việc xử lý xuống background thread
                var reportData = await Task.Run(() => ComputeHeavyRevenueReport(token, (percent, msg) =>
                {
                    // Cập nhật tiến độ an toàn lên ProgressBar của Form Cha
                    parent?.SetProgress(percent, true, msg);
                }), token);

                // Sau khi hoàn thành trên UI thread, đổ dữ liệu vào DataGridView
                dgvRevenue.DataSource = reportData;

                lblReportStatus.Text = $"Trạng thái: Tải báo cáo thành công lúc {DateTime.Now:HH:mm:ss} ({reportData.Count} mục)!";
                lblReportStatus.ForeColor = Color.DarkGreen;
                parent?.ResetProgress("Trạng thái: Đã tải xong báo cáo doanh thu.");

                MessageBox.Show("Đã tải và tính toán báo cáo doanh thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                lblReportStatus.Text = "Trạng thái: Người dùng đã hủy thao tác tải báo cáo.";
                lblReportStatus.ForeColor = Color.DarkRed;
                parent?.ResetProgress("Trạng thái: Thao tác tải báo cáo đã bị hủy.");
            }
            catch (Exception ex)
            {
                lblReportStatus.Text = $"Trạng thái lỗi: {ex.Message}";
                lblReportStatus.ForeColor = Color.Red;
                parent?.ResetProgress("Trạng thái: Xảy ra lỗi khi tải báo cáo.");
                MessageBox.Show($"Lỗi tải báo cáo:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoadRevenueReport.Enabled = true;
                btnCancelReport.Enabled = false;
                _reportCts?.Dispose();
                _reportCts = null;
            }
        }

        private void btnCancelReport_Click(object? sender, EventArgs e)
        {
            _reportCts?.Cancel();
        }

        /// <summary>
        /// Giả lập tác vụ tính toán dữ liệu khối lượng lớn hoặc truy xuất CSDL tốn từ 3-5 giây trên background thread
        /// </summary>
        private List<RevenueRecord> ComputeHeavyRevenueReport(CancellationToken token, Action<int, string> progressCallback)
        {
            // Bước 1: Kết nối & truy vấn bảng tổng hợp (1.0 giây)
            token.ThrowIfCancellationRequested();
            progressCallback(25, "Đang kết nối kho dữ liệu siêu thị (25%)...");
            Thread.Sleep(1000);

            // Bước 2: Quét và xử lý hàng nghìn giao dịch chi tiết (1.5 giây)
            token.ThrowIfCancellationRequested();
            progressCallback(55, "Đang tổng hợp các hóa đơn bán hàng theo kỳ (55%)...");
            Thread.Sleep(1500);

            // Bước 3: Tính toán chiết khấu, lợi nhuận ròng & thuế (1.0 giây)
            token.ThrowIfCancellationRequested();
            progressCallback(85, "Đang tính toán doanh thu và chi phí vốn (85%)...");
            Thread.Sleep(1000);

            // Bước 4: Hoàn tất cấu trúc bảng (0.5 giây)
            token.ThrowIfCancellationRequested();
            progressCallback(100, "Hoàn tất tổng hợp báo cáo (100%)...");
            Thread.Sleep(500);

            var list = new List<RevenueRecord>
            {
                new RevenueRecord("Tháng 01/2026", "Thực phẩm tươi sống", 1420, 245000000m, 185000000m),
                new RevenueRecord("Tháng 01/2026", "Đồ uống & Giải khát", 980, 115000000m, 78000000m),
                new RevenueRecord("Tháng 01/2026", "Hóa mỹ phẩm & Tẩy rửa", 620, 98000000m, 62000000m),
                new RevenueRecord("Tháng 02/2026", "Thực phẩm tươi sống", 1680, 310000000m, 228000000m),
                new RevenueRecord("Tháng 02/2026", "Bánh kẹo & Đồ khô", 1120, 142000000m, 95000000m),
                new RevenueRecord("Tháng 02/2026", "Gia dụng & Tiện ích", 450, 89000000m, 58000000m),
                new RevenueRecord("Tháng 03/2026", "Đồ uống & Giải khát", 1310, 168000000m, 112000000m),
                new RevenueRecord("Tháng 03/2026", "Hóa mỹ phẩm & Tẩy rửa", 740, 105000000m, 66000000m)
            };

            return list;
        }

        #endregion

        #region Scenario C: Cập nhật UI an toàn từ Background Thread (Safe Cross-Thread)

        private void btnToggleSync_Click(object? sender, EventArgs e)
        {
            if (!_isSyncRunning)
            {
                StartBackgroundSync();
            }
            else
            {
                StopBackgroundSync();
            }
        }

        private void StartBackgroundSync()
        {
            _isSyncRunning = true;
            _syncCts = new CancellationTokenSource();
            var token = _syncCts.Token;

            btnToggleSync.Text = "Dừng đồng bộ ngầm";
            lblSyncStatus.Text = "Tiến trình đồng bộ: ĐANG CHẠY (chu kỳ 2 giây)";
            lblSyncStatus.ForeColor = Color.DarkGreen;

            // Chạy tiến trình ngầm định kỳ bằng Task.Run
            Task.Run(async () =>
            {
                var rand = new Random();
                string[] stores = new string[] { "Quầy thu ngân số 1", "Quầy thu ngân số 2", "Kênh Online Siêu thị", "Quầy thanh toán tự động" };
                string[] categories = new string[] { "Thực phẩm tươi", "Sữa & Nước ép", "Bánh kẹo", "Nước giặt & Gia dụng" };

                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        // Giả lập quét định kỳ mỗi 2 giây
                        await Task.Delay(2000, token);

                        _syncSequence++;
                        string store = stores[rand.Next(stores.Length)];
                        string cat = categories[rand.Next(categories.Length)];
                        decimal amount = rand.Next(50, 1200) * 1000m;
                        int orderNum = rand.Next(1000, 9999);

                        string logMessage = $"[{DateTime.Now:HH:mm:ss}] [Lần {_syncSequence}] Đồng bộ mới: Hóa đơn #HD{orderNum} từ '{store}' - Ngành '{cat}': +{amount:#,##0} VNĐ";

                        // ÁP DỤNG QUY TẮC THREAD SAFETY:
                        // Sử dụng Control.InvokeRequired / this.Invoke() để đưa ngữ cảnh về UI Thread
                        UpdateSyncLogSafe(logMessage);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
            }, token);
        }

        private void StopBackgroundSync()
        {
            _isSyncRunning = false;
            _syncCts?.Cancel();
            _syncCts?.Dispose();
            _syncCts = null;

            btnToggleSync.Text = "Bắt đầu đồng bộ ngầm (2s / lần)";
            lblSyncStatus.Text = "Tiến trình đồng bộ: ĐÃ DỪNG";
            lblSyncStatus.ForeColor = Color.Black;
        }

        /// <summary>
        /// Phương thức cập nhật Control từ Thread phụ tuân thủ an toàn luồng (Cross-Thread Safe)
        /// Cấm mọi hành vi truy cập trực tiếp Control từ Background Thread.
        /// </summary>
        private void UpdateSyncLogSafe(string message)
        {
            if (this.InvokeRequired)
            {
                // Đang ở Thread phụ -> Sử dụng this.Invoke để chuyển về UI Thread
                this.Invoke(new Action(() => UpdateSyncLogSafe(message)));
            }
            else
            {
                // Đã ở UI Thread an toàn -> Được phép thao tác trực tiếp với Control
                lstSyncLog.Items.Insert(0, message);

                // Giới hạn số dòng hiển thị để tránh đầy bộ nhớ
                if (lstSyncLog.Items.Count > 100)
                {
                    lstSyncLog.Items.RemoveAt(lstSyncLog.Items.Count - 1);
                }

                lblSyncStatus.Text = $"Tiến trình đồng bộ: ĐANG CHẠY (Vừa nhận dữ liệu lần {_syncSequence} lúc {DateTime.Now:HH:mm:ss})";
            }
        }

        #endregion

        private void frmAsyncReport_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Dọn dẹp token khi đóng form
            _reportCts?.Cancel();
            _syncCts?.Cancel();
            var parent = this.MdiParent as frmMain;
            parent?.ResetProgress();
        }
    }

    /// <summary>
    /// Model dữ liệu thống kê doanh thu
    /// </summary>
    public class RevenueRecord
    {
        public string Period { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int OrderCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal NetProfit => TotalRevenue - TotalCost;

        public RevenueRecord() { }

        public RevenueRecord(string period, string category, int orderCount, decimal totalRevenue, decimal totalCost)
        {
            Period = period;
            Category = category;
            OrderCount = orderCount;
            TotalRevenue = totalRevenue;
            TotalCost = totalCost;
        }
    }
}
