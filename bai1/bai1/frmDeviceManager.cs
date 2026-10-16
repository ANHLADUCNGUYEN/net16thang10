using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using bai1.Models;

namespace bai1
{
    public partial class frmDeviceManager : Form
    {
        // Danh sách dữ liệu dùng BindingList<T> để tự động thông báo thay đổi tới DataGridView
        private BindingList<Device> _deviceList = new BindingList<Device>();

        // BindingSource làm cầu nối trung gian giữa nguồn dữ liệu và giao diện (DataGridView, Controls)
        private BindingSource _deviceBindingSource = new BindingSource();

        public frmDeviceManager()
        {
            InitializeComponent();
            Load += frmDeviceManager_Load;
        }

        private void frmDeviceManager_Load(object? sender, EventArgs e)
        {
            InitializeCategoryList();
            ConfigureDataGridView();
            InitializeDataAndBinding();
            AttachEventHandlers();

            // Nếu danh sách có dữ liệu, chọn dòng đầu tiên; ngược lại chuẩn bị form mới
            if (_deviceList.Count > 0)
            {
                _deviceBindingSource.Position = 0;
                SyncCurrentToControls();
            }
            else
            {
                PrepareNewDevice();
            }
        }

        /// <summary>
        /// 1. Khởi tạo danh sách danh mục vào cboCategory
        /// </summary>
        private void InitializeCategoryList()
        {
            cboCategory.Items.Clear();
            cboCategory.Items.AddRange(new object[]
            {
                "Điện thoại",
                "Laptop",
                "Máy tính bảng",
                "Phụ kiện",
                "Âm thanh",
                "Màn hình",
                "Thiết bị đeo"
            });
        }

        /// <summary>
        /// 1. Cấu hình DataGridView chuẩn chuyên nghiệp HOÀN TOÀN BẰNG CODE:
        /// - AutoGenerateColumns = false (không sinh cột tự động)
        /// - SelectionMode = FullRowSelect (chọn nguyên dòng)
        /// - ReadOnly = true (không cho sửa trực tiếp trên grid)
        /// - Phân bổ tỷ lệ cột hợp lý, định dạng tiền tệ cho Đơn giá
        /// </summary>
        private void ConfigureDataGridView()
        {
            dgvDevices.AutoGenerateColumns = false;
            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.MultiSelect = false;
            dgvDevices.ReadOnly = true;
            dgvDevices.AllowUserToAddRows = false;
            dgvDevices.AllowUserToDeleteRows = false;
            dgvDevices.AllowUserToResizeRows = false;
            dgvDevices.RowHeadersVisible = false;
            dgvDevices.BackgroundColor = Color.White;
            dgvDevices.BorderStyle = BorderStyle.Fixed3D;
            dgvDevices.EnableHeadersVisualStyles = false;
            dgvDevices.RowTemplate.Height = 32;

            // Cấu hình Header cột
            dgvDevices.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 50, 94);
            dgvDevices.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDevices.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgvDevices.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDevices.ColumnHeadersHeight = 38;
            dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Cấu hình màu dòng xen kẽ (Zebra striping) và màu khi chọn
            dgvDevices.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 248, 252);
            dgvDevices.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dgvDevices.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDevices.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);

            // Xóa toàn bộ cột cũ nếu có
            dgvDevices.Columns.Clear();

            // Cột 1: Mã thiết bị
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "colDeviceId",
                DataPropertyName = nameof(Device.DeviceId),
                HeaderText = "Mã thiết bị",
                Width = 120,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cột 2: Tên thiết bị (chiếm tỷ lệ co giãn lớn nhất)
            var colName = new DataGridViewTextBoxColumn
            {
                Name = "colDeviceName",
                DataPropertyName = nameof(Device.DeviceName),
                HeaderText = "Tên thiết bị",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 200,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
            colName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Cột 3: Loại thiết bị
            var colCategory = new DataGridViewTextBoxColumn
            {
                Name = "colCategory",
                DataPropertyName = nameof(Device.Category),
                HeaderText = "Loại thiết bị",
                Width = 140,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
            colCategory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cột 4: Đơn giá (định dạng tiền tệ chuẩn N0 và canh phải)
            var colPrice = new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                DataPropertyName = nameof(Device.Price),
                HeaderText = "Đơn giá (VNĐ)",
                Width = 150,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Cột 5: Số lượng tồn
            var colQuantity = new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                DataPropertyName = nameof(Device.Quantity),
                HeaderText = "Số lượng",
                Width = 110,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
            colQuantity.DefaultCellStyle.Format = "N0";
            colQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Gắn các cột vào DataGridView
            dgvDevices.Columns.AddRange(new DataGridViewColumn[]
            {
                colId,
                colName,
                colCategory,
                colPrice,
                colQuantity
            });
        }

        /// <summary>
        /// 1. Khởi tạo dữ liệu mẫu và thiết lập Data Binding 2 chiều
        /// </summary>
        private void InitializeDataAndBinding()
        {
            // Dữ liệu ban đầu
            _deviceList = new BindingList<Device>
            {
                new Device("TB001", "iPhone 15 Pro Max 256GB", "Điện thoại", 29990000m, 15),
                new Device("TB002", "Laptop Dell XPS 13 Plus", "Laptop", 36500000m, 8),
                new Device("TB003", "iPad Air 5 M1 64GB WiFi", "Máy tính bảng", 14890000m, 20),
                new Device("TB004", "Tai nghe Sony WH-1000XM5", "Âm thanh", 7490000m, 25),
                new Device("TB005", "Chuột Logitech MX Master 3S", "Phụ kiện", 2150000m, 40),
                new Device("TB006", "Màn hình Dell UltraSharp U2724D", "Màn hình", 10290000m, 12)
            };

            // Gán dữ liệu cho BindingSource và dgvDevices
            _deviceBindingSource.DataSource = _deviceList;
            dgvDevices.DataSource = _deviceBindingSource;

            // Thiết lập DataBinding 2 chiều cho các Control nhập liệu
            // Sử dụng DataSourceUpdateMode.Never để chỉ cập nhật nguồn khi người dùng bấm Cập nhật,
            // tránh làm thay đổi đối tượng khi đang gõ dở hoặc khi đang kiểm tra validation.
            txtDeviceId.DataBindings.Clear();
            txtDeviceName.DataBindings.Clear();
            cboCategory.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            numQuantity.DataBindings.Clear();

            txtDeviceId.DataBindings.Add("Text", _deviceBindingSource, nameof(Device.DeviceId), true, DataSourceUpdateMode.Never);
            txtDeviceName.DataBindings.Add("Text", _deviceBindingSource, nameof(Device.DeviceName), true, DataSourceUpdateMode.Never);
            cboCategory.DataBindings.Add("SelectedItem", _deviceBindingSource, nameof(Device.Category), true, DataSourceUpdateMode.Never);

            var priceBinding = new Binding("Text", _deviceBindingSource, nameof(Device.Price), true, DataSourceUpdateMode.Never, 0, "N0");
            txtPrice.DataBindings.Add(priceBinding);

            numQuantity.DataBindings.Add("Value", _deviceBindingSource, nameof(Device.Quantity), true, DataSourceUpdateMode.Never);
        }

        /// <summary>
        /// Đăng ký các sự kiện tương tác người dùng
        /// </summary>
        private void AttachEventHandlers()
        {
            // Nút chức năng
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;

            // Sự kiện DataGridView & BindingSource
            dgvDevices.CellClick += dgvDevices_CellClick;
            _deviceBindingSource.CurrentChanged += DeviceBindingSource_CurrentChanged;

            // Xóa thông báo lỗi thời gian thực khi người dùng nhập dữ liệu hợp lệ
            txtDeviceName.TextChanged += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtDeviceName.Text))
                {
                    errorProvider.SetError(txtDeviceName, string.Empty);
                }
            };

            cboCategory.SelectedIndexChanged += (s, e) =>
            {
                if (cboCategory.SelectedIndex != -1)
                {
                    errorProvider.SetError(cboCategory, string.Empty);
                }
            };

            txtPrice.TextChanged += (s, e) =>
            {
                string cleaned = txtPrice.Text.Replace(".", "").Replace(",", "").Trim();
                if (decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val) && val >= 0)
                {
                    errorProvider.SetError(txtPrice, string.Empty);
                }
            };

            // Định dạng tiền tệ khi rời khỏi ô Đơn giá
            txtPrice.Leave += (s, e) =>
            {
                string cleaned = txtPrice.Text.Replace(".", "").Replace(",", "").Trim();
                if (decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val) && val >= 0)
                {
                    txtPrice.Text = val.ToString("N0");
                }
            };

            txtPrice.Enter += (s, e) =>
            {
                txtPrice.SelectAll();
            };
        }

        /// <summary>
        /// 2. Kiểm soát dữ liệu đầu vào (Validation) sử dụng ErrorProvider
        /// </summary>
        /// <returns>True nếu toàn bộ thông tin hợp lệ, False nếu có lỗi</returns>
        private bool ValidateInputs()
        {
            bool isValid = true;
            Control? firstInvalidControl = null;

            // 1. Tên thiết bị không được để trống
            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                errorProvider.SetError(txtDeviceName, "Tên thiết bị không được để trống!");
                isValid = false;
                firstInvalidControl ??= txtDeviceName;
            }
            else
            {
                errorProvider.SetError(txtDeviceName, string.Empty);
            }

            // 2. Chưa chọn loại thiết bị
            if (cboCategory.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cboCategory.Text))
            {
                errorProvider.SetError(cboCategory, "Vui lòng chọn loại thiết bị!");
                isValid = false;
                firstInvalidControl ??= cboCategory;
            }
            else
            {
                errorProvider.SetError(cboCategory, string.Empty);
            }

            // 3. Đơn giá không phải là số hợp lệ hoặc nhỏ hơn 0
            string cleanedPrice = txtPrice.Text.Replace(".", "").Replace(",", "").Trim();
            if (string.IsNullOrWhiteSpace(cleanedPrice))
            {
                errorProvider.SetError(txtPrice, "Đơn giá không được để trống!");
                isValid = false;
                firstInvalidControl ??= txtPrice;
            }
            else if (!decimal.TryParse(cleanedPrice, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price) || price < 0)
            {
                errorProvider.SetError(txtPrice, "Đơn giá phải là số hợp lệ và lớn hơn hoặc bằng 0!");
                isValid = false;
                firstInvalidControl ??= txtPrice;
            }
            else
            {
                errorProvider.SetError(txtPrice, string.Empty);
            }

            // Đưa con trỏ vào ô lỗi đầu tiên để người dùng tiện sửa
            firstInvalidControl?.Focus();

            return isValid;
        }

        /// <summary>
        /// Chuyển đổi chuỗi tiền tệ từ ô txtPrice sang decimal an toàn
        /// </summary>
        private decimal ParsePrice(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;
            string cleaned = text.Replace(".", "").Replace(",", "").Replace("VNĐ", "").Replace("đ", "").Trim();
            if (decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val))
            {
                return val;
            }
            return 0;
        }

        /// <summary>
        /// Tạo mã thiết bị tự động dạng TBxxx tiếp theo dựa trên danh sách hiện tại
        /// </summary>
        private string GenerateNextDeviceId()
        {
            int maxId = 0;
            foreach (var item in _deviceList)
            {
                if (!string.IsNullOrEmpty(item.DeviceId))
                {
                    Match match = Regex.Match(item.DeviceId, @"\d+");
                    if (match.Success && int.TryParse(match.Value, out int id))
                    {
                        if (id > maxId) maxId = id;
                    }
                }
            }
            return $"TB{(maxId + 1):D3}";
        }

        /// <summary>
        /// Đổ dữ liệu từ đối tượng được chọn sang các Control thông qua Binding.ReadValue()
        /// </summary>
        private void SyncCurrentToControls()
        {
            if (_deviceBindingSource.Current is Device current)
            {
                foreach (Binding b in txtDeviceId.DataBindings) b.ReadValue();
                foreach (Binding b in txtDeviceName.DataBindings) b.ReadValue();
                foreach (Binding b in cboCategory.DataBindings) b.ReadValue();
                foreach (Binding b in txtPrice.DataBindings) b.ReadValue();
                foreach (Binding b in numQuantity.DataBindings) b.ReadValue();

                // Đảm bảo txtPrice luôn hiển thị đúng định dạng
                txtPrice.Text = current.Price.ToString("N0");
            }
        }

        /// <summary>
        /// Xóa trắng các ô nhập liệu và chuẩn bị tạo mới thiết bị
        /// </summary>
        private void PrepareNewDevice()
        {
            errorProvider.Clear();
            dgvDevices.ClearSelection();

            txtDeviceId.Text = GenerateNextDeviceId();
            txtDeviceName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;

            txtDeviceName.Focus();
        }

        #region Event Handlers

        /// <summary>
        /// 3. Đồng bộ khi click chọn một dòng trên DataGridView:
        /// Toàn bộ thông tin của đối tượng đó phải lập tức đổ ngược lên các Control nhập liệu.
        /// </summary>
        private void dgvDevices_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                errorProvider.Clear();
                SyncCurrentToControls();
            }
        }

        private void DeviceBindingSource_CurrentChanged(object? sender, EventArgs e)
        {
            if (_deviceBindingSource.Current is Device)
            {
                errorProvider.Clear();
                SyncCurrentToControls();
            }
        }

        /// <summary>
        /// 3. Thêm mới:
        /// Đối tượng được thêm vào BindingList<T> phải hiển thị ngay lên DataGridView
        /// mà KHÔNG CẦN gọi lại hàm nạp dữ liệu.
        /// </summary>
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            // Lấy mã thiết bị (nếu đã trùng hoặc trống thì sinh tự động)
            string deviceId = txtDeviceId.Text.Trim();
            if (string.IsNullOrWhiteSpace(deviceId) || _deviceList.Any(d => d.DeviceId.Equals(deviceId, StringComparison.OrdinalIgnoreCase)))
            {
                deviceId = GenerateNextDeviceId();
            }

            var newDevice = new Device
            {
                DeviceId = deviceId,
                DeviceName = txtDeviceName.Text.Trim(),
                Category = cboCategory.SelectedItem?.ToString() ?? cboCategory.Text.Trim(),
                Price = ParsePrice(txtPrice.Text),
                Quantity = (int)numQuantity.Value
            };

            // Thêm trực tiếp vào BindingList<T> -> BindingSource tự động thông báo DataGridView hiển thị
            _deviceList.Add(newDevice);

            // Di chuyển con trỏ chọn đến phần tử vừa thêm
            _deviceBindingSource.Position = _deviceList.IndexOf(newDevice);
            SyncCurrentToControls();

            MessageBox.Show(
                $"Thêm mới thiết bị \"{newDevice.DeviceName}\" (Mã: {newDevice.DeviceId}) thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// 3. Cập nhật:
        /// Thông tin chỉnh sửa trên Form phải tự động đồng bộ xuống danh sách và cập nhật trên Grid.
        /// </summary>
        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang được chọn hay không
            if (_deviceBindingSource.Current is not Device currentDevice || dgvDevices.CurrentRow == null || !dgvDevices.CurrentRow.Selected)
            {
                MessageBox.Show(
                    "Vui lòng chọn một thiết bị từ danh sách để cập nhật!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs())
            {
                return;
            }

            // Cập nhật các thuộc tính của đối tượng hiện tại
            // Vì Device hỗ trợ INotifyPropertyChanged nên BindingList<T> sẽ tự động phát hiện thay đổi
            currentDevice.DeviceName = txtDeviceName.Text.Trim();
            currentDevice.Category = cboCategory.SelectedItem?.ToString() ?? cboCategory.Text.Trim();
            currentDevice.Price = ParsePrice(txtPrice.Text);
            currentDevice.Quantity = (int)numQuantity.Value;

            // Đồng bộ lại BindingSource để DataGridView vẽ lại ngay lập tức
            _deviceBindingSource.ResetCurrentItem();

            // Định dạng lại hiển thị đơn giá
            txtPrice.Text = currentDevice.Price.ToString("N0");

            MessageBox.Show(
                $"Cập nhật thông tin thiết bị \"{currentDevice.DeviceName}\" thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// 3. Xóa:
        /// Hiển thị MessageBox xác nhận (Yes/No). Nếu chọn Yes, tiến hành xóa khỏi danh sách.
        /// </summary>
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_deviceBindingSource.Current is not Device currentDevice || dgvDevices.CurrentRow == null || !dgvDevices.CurrentRow.Selected)
            {
                MessageBox.Show(
                    "Vui lòng chọn thiết bị cần xóa trong danh sách!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thiết bị \"{currentDevice.DeviceName}\" (Mã: {currentDevice.DeviceId}) không?",
                "Xác nhận xóa thiết bị",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (confirm == DialogResult.Yes)
            {
                string deletedName = currentDevice.DeviceName;

                // Xóa khỏi BindingList<T> -> Grid tự động cập nhật xóa dòng
                _deviceList.Remove(currentDevice);

                MessageBox.Show(
                    $"Đã xóa thiết bị \"{deletedName}\" thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (_deviceList.Count == 0)
                {
                    PrepareNewDevice();
                }
                else
                {
                    SyncCurrentToControls();
                }
            }
        }

        /// <summary>
        /// Làm mới / Hủy:
        /// Xóa dữ liệu trên Form, xóa cảnh báo lỗi và chuẩn bị cho việc nhập mới thiết bị.
        /// </summary>
        private void btnClear_Click(object? sender, EventArgs e)
        {
            PrepareNewDevice();
        }

        #endregion
    }
}
