using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Bai03_SupermarketMDI
{
    public partial class frmProductCatalog : Form
    {
        private BindingList<Product> _productList = new BindingList<Product>();
        private BindingSource _bindingSource = new BindingSource();
        private int _autoIdCounter = 1;

        public frmProductCatalog()
        {
            InitializeComponent();
        }

        private void frmProductCatalog_Load(object? sender, EventArgs e)
        {
            cboCategory.Items.AddRange(new object[] {
                "Thực phẩm tươi sống",
                "Đồ uống & Giải khát",
                "Hóa mỹ phẩm & Tẩy rửa",
                "Bánh kẹo & Đồ khô",
                "Gia dụng & Tiện ích"
            });
            cboCategory.SelectedIndex = 0;

            ConfigureDataGridView();

            _bindingSource.DataSource = _productList;
            dgvProducts.DataSource = _bindingSource;

            SeedData();

            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;

            ClearForm();
        }

        private void ConfigureDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.ProductId),
                HeaderText = "Mã SP",
                Name = "colProductId",
                Width = 90
            };

            var colName = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.ProductName),
                HeaderText = "Tên sản phẩm",
                Name = "colProductName",
                Width = 190
            };

            var colCategory = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.Category),
                HeaderText = "Danh mục",
                Name = "colCategory",
                Width = 140
            };

            var colPrice = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.Price),
                HeaderText = "Đơn giá (VNĐ)",
                Name = "colPrice",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0 VNĐ",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };

            var colQty = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.Quantity),
                HeaderText = "Số lượng",
                Name = "colQuantity",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            var colTotal = new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.TotalValue),
                HeaderText = "Thành tiền",
                Name = "colTotalValue",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0 VNĐ",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };

            dgvProducts.Columns.AddRange(new DataGridViewColumn[] {
                colId, colName, colCategory, colPrice, colQty, colTotal
            });
        }

        private void SeedData()
        {
            _productList.Add(new Product("SP001", "Gạo ST25 Ông Cua 5kg", "Thực phẩm tươi sống", 195000m, 50));
            _productList.Add(new Product("SP002", "Sữa tươi TH True Milk 1L", "Đồ uống & Giải khát", 38000m, 120));
            _productList.Add(new Product("SP003", "Nước giặt OMO Matic 3.6kg", "Hóa mỹ phẩm & Tẩy rửa", 225000m, 35));
            _productList.Add(new Product("SP004", "Bánh Cosy quy bơ 336g", "Bánh kẹo & Đồ khô", 48000m, 80));
            _productList.Add(new Product("SP005", "Chảo chống dính Sunhouse 26cm", "Gia dụng & Tiện ích", 165000m, 25));
            _autoIdCounter = 6;
        }

        private void dgvProducts_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is Product selectedProduct)
            {
                txtProductId.Text = selectedProduct.ProductId;
                txtProductName.Text = selectedProduct.ProductName;
                cboCategory.SelectedItem = selectedProduct.Category;
                txtPrice.Text = selectedProduct.Price.ToString("G29", CultureInfo.InvariantCulture);
                numQuantity.Value = Math.Min(numQuantity.Maximum, Math.Max(numQuantity.Minimum, selectedProduct.Quantity));

                errorProvider1.Clear();
            }
        }

        private bool ValidateInput(out decimal price)
        {
            bool isValid = true;
            errorProvider1.Clear();
            price = 0;

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider1.SetError(txtProductName, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            if (cboCategory.SelectedItem == null)
            {
                errorProvider1.SetError(cboCategory, "Vui lòng chọn danh mục!");
                isValid = false;
            }

            string rawPrice = txtPrice.Text.Trim().Replace(",", "");
            if (!decimal.TryParse(rawPrice, NumberStyles.Any, CultureInfo.InvariantCulture, out price) || price < 0)
            {
                if (!decimal.TryParse(txtPrice.Text.Trim(), out price) || price < 0)
                {
                    errorProvider1.SetError(txtPrice, "Đơn giá phải là số hợp lệ và lớn hơn hoặc bằng 0!");
                    isValid = false;
                }
            }

            return isValid;
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(out decimal price))
                return;

            string newId = $"SP{_autoIdCounter:D3}";
            _autoIdCounter++;

            var newProduct = new Product
            {
                ProductId = newId,
                ProductName = txtProductName.Text.Trim(),
                Category = cboCategory.SelectedItem?.ToString() ?? "",
                Price = price,
                Quantity = (int)numQuantity.Value
            };

            _productList.Add(newProduct);
            _bindingSource.Position = _productList.Count - 1;

            MessageBox.Show($"Thêm sản phẩm '{newProduct.ProductName}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is Product selectedProduct)
            {
                if (!ValidateInput(out decimal price))
                    return;

                selectedProduct.ProductName = txtProductName.Text.Trim();
                selectedProduct.Category = cboCategory.SelectedItem?.ToString() ?? "";
                selectedProduct.Price = price;
                selectedProduct.Quantity = (int)numQuantity.Value;

                _bindingSource.ResetBindings(false);
                MessageBox.Show($"Cập nhật sản phẩm '{selectedProduct.ProductId}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is Product selectedProduct)
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sản phẩm [{selectedProduct.ProductId}] - {selectedProduct.ProductName}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    _productList.Remove(selectedProduct);
                    ClearForm();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            dgvProducts.ClearSelection();
            txtProductId.Text = $"SP{_autoIdCounter:D3} (Tự động)";
            txtProductName.Clear();
            if (cboCategory.Items.Count > 0)
                cboCategory.SelectedIndex = 0;
            txtPrice.Clear();
            numQuantity.Value = 0;
            errorProvider1.Clear();
        }
    }
}
