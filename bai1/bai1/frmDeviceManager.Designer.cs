namespace bai1
{
    partial class frmDeviceManager
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
            components = new System.ComponentModel.Container();
            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            grpInput = new GroupBox();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            cboCategory = new ComboBox();
            lblCategory = new Label();
            txtDeviceName = new TextBox();
            lblDeviceName = new Label();
            txtDeviceId = new TextBox();
            lblDeviceId = new Label();
            pnlButtons = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            grpDisplay = new GroupBox();
            dgvDevices = new DataGridView();
            errorProvider = new ErrorProvider(components);
            pnlHeader.SuspendLayout();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            pnlButtons.SuspendLayout();
            grpDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(24, 43, 73);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(964, 65);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.FromArgb(200, 220, 255);
            lblSubtitle.Location = new Point(22, 38);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(428, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Kỹ thuật Data Binding 2 chiều với BindingSource, BindingList<T> và ErrorProvider";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(452, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ DANH MỤC THIẾT BỊ ĐIỆN TỬ";
            // 
            // grpInput
            // 
            grpInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInput.Controls.Add(numQuantity);
            grpInput.Controls.Add(lblQuantity);
            grpInput.Controls.Add(txtPrice);
            grpInput.Controls.Add(lblPrice);
            grpInput.Controls.Add(cboCategory);
            grpInput.Controls.Add(lblCategory);
            grpInput.Controls.Add(txtDeviceName);
            grpInput.Controls.Add(lblDeviceName);
            grpInput.Controls.Add(txtDeviceId);
            grpInput.Controls.Add(lblDeviceId);
            grpInput.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpInput.ForeColor = Color.FromArgb(24, 43, 73);
            grpInput.Location = new Point(16, 75);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(932, 160);
            grpInput.TabIndex = 1;
            grpInput.TabStop = false;
            grpInput.Text = " Thông tin chi tiết thiết bị ";
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numQuantity.Location = new Point(145, 115);
            numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(270, 25);
            numQuantity.TabIndex = 5;
            numQuantity.TextAlign = HorizontalAlignment.Right;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantity.ForeColor = Color.Black;
            lblQuantity.Location = new Point(25, 117);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(86, 17);
            lblQuantity.TabIndex = 4;
            lblQuantity.Text = "Số lượng tồn:";
            // 
            // txtPrice
            // 
            txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrice.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(620, 73);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(270, 25);
            txtPrice.TabIndex = 7;
            txtPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.Black;
            lblPrice.Location = new Point(485, 76);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(116, 17);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Đơn giá (VNĐ) (*):";
            // 
            // cboCategory
            // 
            cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(620, 32);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(270, 25);
            cboCategory.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategory.ForeColor = Color.Black;
            lblCategory.Location = new Point(485, 35);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 17);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Loại thiết bị (*):";
            // 
            // txtDeviceName
            // 
            txtDeviceName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDeviceName.Location = new Point(145, 73);
            txtDeviceName.Name = "txtDeviceName";
            txtDeviceName.Size = new Size(270, 25);
            txtDeviceName.TabIndex = 3;
            // 
            // lblDeviceName
            // 
            lblDeviceName.AutoSize = true;
            lblDeviceName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDeviceName.ForeColor = Color.Black;
            lblDeviceName.Location = new Point(25, 76);
            lblDeviceName.Name = "lblDeviceName";
            lblDeviceName.Size = new Size(99, 17);
            lblDeviceName.TabIndex = 2;
            lblDeviceName.Text = "Tên thiết bị (*):";
            // 
            // txtDeviceId
            // 
            txtDeviceId.BackColor = Color.FromArgb(242, 244, 247);
            txtDeviceId.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDeviceId.Location = new Point(145, 32);
            txtDeviceId.Name = "txtDeviceId";
            txtDeviceId.ReadOnly = true;
            txtDeviceId.Size = new Size(270, 25);
            txtDeviceId.TabIndex = 1;
            // 
            // lblDeviceId
            // 
            lblDeviceId.AutoSize = true;
            lblDeviceId.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDeviceId.ForeColor = Color.Black;
            lblDeviceId.Location = new Point(25, 35);
            lblDeviceId.Name = "lblDeviceId";
            lblDeviceId.Size = new Size(74, 17);
            lblDeviceId.TabIndex = 0;
            lblDeviceId.Text = "Mã thiết bị:";
            // 
            // pnlButtons
            // 
            pnlButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Location = new Point(16, 243);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(932, 50);
            pnlButtons.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(570, 7);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(140, 36);
            btnClear.TabIndex = 3;
            btnClear.Text = "🔄 Làm mới / Hủy";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(420, 7);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 36);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 123, 255);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(270, 7);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(130, 36);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "💾 Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(120, 7);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 36);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "➕ Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // grpDisplay
            // 
            grpDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDisplay.Controls.Add(dgvDevices);
            grpDisplay.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDisplay.ForeColor = Color.FromArgb(24, 43, 73);
            grpDisplay.Location = new Point(16, 303);
            grpDisplay.Name = "grpDisplay";
            grpDisplay.Padding = new Padding(10);
            grpDisplay.Size = new Size(932, 345);
            grpDisplay.TabIndex = 3;
            grpDisplay.TabStop = false;
            grpDisplay.Text = " Danh sách thiết bị điện tử ";
            // 
            // dgvDevices
            // 
            dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevices.Dock = DockStyle.Fill;
            dgvDevices.Location = new Point(10, 28);
            dgvDevices.Name = "dgvDevices";
            dgvDevices.Size = new Size(912, 307);
            dgvDevices.TabIndex = 0;
            // 
            // errorProvider
            // 
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
            // 
            // frmDeviceManager
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 251);
            ClientSize = new Size(964, 661);
            Controls.Add(grpDisplay);
            Controls.Add(pnlButtons);
            Controls.Add(grpInput);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(900, 600);
            Name = "frmDeviceManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý danh mục thiết bị điện tử - [Bài 1]";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            pnlButtons.ResumeLayout(false);
            grpDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private GroupBox grpInput;
        private Label lblDeviceId;
        private TextBox txtDeviceId;
        private TextBox txtDeviceName;
        private Label lblDeviceName;
        private Label lblCategory;
        private ComboBox cboCategory;
        private TextBox txtPrice;
        private Label lblPrice;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Panel pnlButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private GroupBox grpDisplay;
        private DataGridView dgvDevices;
        private ErrorProvider errorProvider;
    }
}
