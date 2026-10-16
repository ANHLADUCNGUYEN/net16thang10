using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Timers;
using System.Xml.Linq;

namespace InventoryManager
{
    public partial class frmInventoryManager : Form
    {
        private readonly BindingList<Product> products = new();
        private string currentImagePath = "";

        public frmInventoryManager()
        {
            InitializeComponent();

            cboCategory.SelectedIndex = 0;

            dgvProducts.DataSource = products;
            products.ListChanged += (s, e) => UpdateStatus();

            timer.Start();
            UpdateClock();
            UpdateStatus();
        }

        // ================= THANH TRẠNG THÁI =================
        private void timer_Tick(object? sender, EventArgs e) => UpdateClock();

        private void UpdateClock() =>
            lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        private void UpdateStatus()
        {
            int totalQty = products.Sum(p => p.Quantity);
            decimal totalValue = products.Sum(p => p.Total);
            lblCount.Text = $"Tổng SL: {totalQty:N0} ({products.Count} SP)";
            lblTotal.Text = $"Tổng giá trị kho: {totalValue:N0} VNĐ";
        }

        // ================= HÌNH ẢNH (OpenFileDialog) =================
        private void btnChooseImage_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh sản phẩm",
                Filter = "Image files (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            currentImagePath = ofd.FileName;
            ShowImage(currentImagePath);
        }

        private void ShowImage(string path)
        {
            picProductImage.Image?.Dispose();
            picProductImage.Image = null;
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return;

            try
            {
                // Đọc qua stream để không khóa file ảnh
                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                using var img = Image.FromStream(fs);
                picProductImage.Image = new Bitmap(img);
            }
            catch { /* file ảnh hỏng → để trống */ }
        }

        // ================= THÊM / SỬA / XÓA =================
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SP và Tên SP.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            if (products.Any(p => p.Id == txtId.Text.Trim()))
            {
                MessageBox.Show("Mã SP đã tồn tại.", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            products.Add(new Product
            {
                Id = txtId.Text.Trim(),
                Name = txtName.Text.Trim(),
                Category = cboCategory.Text,
                Quantity = (int)nudQuantity.Value,
                Price = nudPrice.Value,
                ImagePath = currentImagePath
            });
            ClearInputs();
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is not Product p)
            {
                MessageBox.Show("Hãy chọn một dòng để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInputs()) return;

            p.Id = txtId.Text.Trim();
            p.Name = txtName.Text.Trim();
            p.Category = cboCategory.Text;
            p.Quantity = (int)nudQuantity.Value;
            p.Price = nudPrice.Value;
            p.ImagePath = currentImagePath;

            products.ResetBindings();   // làm mới lưới + kích hoạt ListChanged → cập nhật StatusStrip
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is not Product p) return;
            if (MessageBox.Show($"Xóa sản phẩm '{p.Name}'?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                products.Remove(p);
        }

        private void btnClear_Click(object? sender, EventArgs e) => ClearInputs();

        private void ClearInputs()
        {
            txtId.Clear();
            txtName.Clear();
            cboCategory.SelectedIndex = 0;
            nudQuantity.Value = 0;
            nudPrice.Value = 0;
            currentImagePath = "";
            ShowImage("");
            txtId.Focus();
        }

        private void dgvProducts_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is not Product p) return;
            txtId.Text = p.Id;
            txtName.Text = p.Name;
            cboCategory.Text = p.Category;
            nudQuantity.Value = Math.Min(p.Quantity, nudQuantity.Maximum);
            nudPrice.Value = Math.Min(p.Price, nudPrice.Maximum);
            currentImagePath = p.ImagePath;
            ShowImage(p.ImagePath);
        }

        // ================= CSV =================
        private const char Sep = ';';

        private static string Esc(string s) =>
            s.Contains(Sep) || s.Contains('"') ? "\"" + s.Replace("\"", "\"\"") + "\"" : s;

        private void ExportCsv_Click(object? sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Title = "Xuất báo cáo",
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "BaoCaoKho.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine(string.Join(Sep, "Id", "Name", "Category", "Quantity", "Price", "ImagePath"));
                foreach (var p in products)
                    sb.AppendLine(string.Join(Sep, Esc(p.Id), Esc(p.Name), Esc(p.Category),
                        p.Quantity, p.Price.ToString(CultureInfo.InvariantCulture), Esc(p.ImagePath)));

                File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Xuất file thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static List<string> ParseLine(string line)
        {
            var result = new List<string>();
            var cur = new StringBuilder();
            bool inQuotes = false;
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (inQuotes)
                {
                    if (c == '"' && i + 1 < line.Length && line[i + 1] == '"') { cur.Append('"'); i++; }
                    else if (c == '"') inQuotes = false;
                    else cur.Append(c);
                }
                else if (c == '"') inQuotes = true;
                else if (c == Sep) { result.Add(cur.ToString()); cur.Clear(); }
                else cur.Append(c);
            }
            result.Add(cur.ToString());
            return result;
        }

        private void ImportCsv_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn file CSV",
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
                var loaded = new List<Product>();
                foreach (var line in lines.Skip(1))               // bỏ dòng tiêu đề
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var f = ParseLine(line);
                    if (f.Count < 6) continue;
                    loaded.Add(new Product
                    {
                        Id = f[0],
                        Name = f[1],
                        Category = f[2],
                        Quantity = int.Parse(f[3]),
                        Price = decimal.Parse(f[4], CultureInfo.InvariantCulture),
                        ImagePath = f[5]
                    });
                }
                products.Clear();
                foreach (var p in loaded) products.Add(p);
                MessageBox.Show($"Đã nhập {loaded.Count} sản phẩm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File không hợp lệ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= THOÁT =================
        private void Exit_Click(object? sender, EventArgs e) => Close();

        private void frmInventoryManager_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var r = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) e.Cancel = true;
        }
    }
}