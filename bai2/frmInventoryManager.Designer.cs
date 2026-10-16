namespace InventoryManager
{
    partial class frmInventoryManager
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
            components = new System.ComponentModel.Container();

            // ---- khởi tạo control ----
            menuStrip = new MenuStrip();
            mnuSystem = new ToolStripMenuItem();
            miOpen = new ToolStripMenuItem();
            miSave = new ToolStripMenuItem();
            miSep = new ToolStripSeparator();
            miExit = new ToolStripMenuItem();
            mnuTools = new ToolStripMenuItem();
            miImport = new ToolStripMenuItem();
            miExport = new ToolStripMenuItem();

            toolStrip = new ToolStrip();
            tsbOpen = new ToolStripButton();
            tsbSave = new ToolStripButton();
            tsSep1 = new ToolStripSeparator();
            tsbImport = new ToolStripButton();
            tsbExport = new ToolStripButton();
            tsSep2 = new ToolStripSeparator();
            tsbExit = new ToolStripButton();

            statusStrip = new StatusStrip();
            lblCount = new ToolStripStatusLabel();
            lblTotal = new ToolStripStatusLabel();
            lblSpring = new ToolStripStatusLabel();
            lblClock = new ToolStripStatusLabel();

            timer = new System.Windows.Forms.Timer(components);

            pnlInput = new Panel();
            lblId = new Label();
            lblName = new Label();
            lblCategory = new Label();
            lblQuantity = new Label();
            lblPrice = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            cboCategory = new ComboBox();
            nudQuantity = new NumericUpDown();
            nudPrice = new NumericUpDown();
            picProductImage = new PictureBox();
            btnChooseImage = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();

            dgvProducts = new DataGridView();

            menuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();

            // ---- menuStrip ----
            menuStrip.Items.AddRange(new ToolStripItem[] { mnuSystem, mnuTools });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.TabIndex = 0;

            mnuSystem.DropDownItems.AddRange(new ToolStripItem[] { miOpen, miSave, miSep, miExit });
            mnuSystem.Name = "mnuSystem";
            mnuSystem.Text = "System";

            miOpen.Name = "miOpen";
            miOpen.ShortcutKeys = Keys.Control | Keys.O;
            miOpen.Text = "Open File";
            miOpen.Click += ImportCsv_Click;

            miSave.Name = "miSave";
            miSave.ShortcutKeys = Keys.Control | Keys.S;
            miSave.Text = "Save Report";
            miSave.Click += ExportCsv_Click;

            miSep.Name = "miSep";

            miExit.Name = "miExit";
            miExit.Text = "Exit";
            miExit.Click += Exit_Click;

            mnuTools.DropDownItems.AddRange(new ToolStripItem[] { miImport, miExport });
            mnuTools.Name = "mnuTools";
            mnuTools.Text = "Tools";

            miImport.Name = "miImport";
            miImport.Text = "Import CSV";
            miImport.Click += ImportCsv_Click;

            miExport.Name = "miExport";
            miExport.Text = "Export CSV";
            miExport.Click += ExportCsv_Click;

            // ---- toolStrip ----
            toolStrip.ImageScalingSize = new Size(24, 24);
            toolStrip.Items.AddRange(new ToolStripItem[] { tsbOpen, tsbSave, tsSep1, tsbImport, tsbExport, tsSep2, tsbExit });
            toolStrip.Name = "toolStrip";
            toolStrip.TabIndex = 1;

            tsbOpen.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbOpen.Name = "tsbOpen";
            tsbOpen.Text = "Open";
            tsbOpen.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbOpen.Click += ImportCsv_Click;

            tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbSave.Name = "tsbSave";
            tsbSave.Text = "Save";
            tsbSave.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbSave.Click += ExportCsv_Click;

            tsSep1.Name = "tsSep1";

            tsbImport.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbImport.Name = "tsbImport";
            tsbImport.Text = "Import";
            tsbImport.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbImport.Click += ImportCsv_Click;

            tsbExport.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbExport.Name = "tsbExport";
            tsbExport.Text = "Export";
            tsbExport.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbExport.Click += ExportCsv_Click;

            tsSep2.Name = "tsSep2";

            tsbExit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbExit.Name = "tsbExit";
            tsbExit.Text = "Exit";
            tsbExit.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbExit.Click += Exit_Click;

            // ---- statusStrip ----
            statusStrip.Items.AddRange(new ToolStripItem[] { lblCount, lblTotal, lblSpring, lblClock });
            statusStrip.Name = "statusStrip";
            statusStrip.TabIndex = 2;

            lblCount.Name = "lblCount";
            lblCount.Text = "Tổng SL: 0";

            lblTotal.Name = "lblTotal";
            lblTotal.Text = "Tổng giá trị: 0";

            lblSpring.Name = "lblSpring";
            lblSpring.Spring = true;

            lblClock.Name = "lblClock";
            lblClock.Text = "00/00/0000 00:00:00";

            // ---- timer ----
            timer.Interval = 1000;
            timer.Tick += timer_Tick;

            // ---- pnlInput ----
            pnlInput.Controls.Add(lblId);
            pnlInput.Controls.Add(lblName);
            pnlInput.Controls.Add(lblCategory);
            pnlInput.Controls.Add(lblQuantity);
            pnlInput.Controls.Add(lblPrice);
            pnlInput.Controls.Add(txtId);
            pnlInput.Controls.Add(txtName);
            pnlInput.Controls.Add(cboCategory);
            pnlInput.Controls.Add(nudQuantity);
            pnlInput.Controls.Add(nudPrice);
            pnlInput.Controls.Add(picProductImage);
            pnlInput.Controls.Add(btnChooseImage);
            pnlInput.Controls.Add(btnAdd);
            pnlInput.Controls.Add(btnUpdate);
            pnlInput.Controls.Add(btnDelete);
            pnlInput.Controls.Add(btnClear);
            pnlInput.Dock = DockStyle.Top;
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(1000, 230);
            pnlInput.TabIndex = 3;

            lblId.Location = new Point(15, 19);
            lblId.Name = "lblId";
            lblId.Size = new Size(90, 23);
            lblId.Text = "Mã SP:";

            lblName.Location = new Point(15, 54);
            lblName.Name = "lblName";
            lblName.Size = new Size(90, 23);
            lblName.Text = "Tên SP:";

            lblCategory.Location = new Point(15, 89);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(90, 23);
            lblCategory.Text = "Danh mục:";

            lblQuantity.Location = new Point(15, 124);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(90, 23);
            lblQuantity.Text = "Số lượng:";

            lblPrice.Location = new Point(15, 159);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(90, 23);
            lblPrice.Text = "Đơn giá:";

            txtId.Location = new Point(110, 15);
            txtId.Name = "txtId";
            txtId.Size = new Size(250, 27);
            txtId.TabIndex = 0;

            txtName.Location = new Point(110, 50);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 27);
            txtName.TabIndex = 1;

            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Items.AddRange(new object[] { "Điện tử", "Gia dụng", "Thực phẩm", "Khác" });
            cboCategory.Location = new Point(110, 85);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(250, 28);
            cboCategory.TabIndex = 2;

            nudQuantity.Location = new Point(110, 120);
            nudQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(250, 27);
            nudQuantity.TabIndex = 3;

            nudPrice.Location = new Point(110, 155);
            nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(250, 27);
            nudPrice.TabIndex = 4;
            nudPrice.ThousandsSeparator = true;

            picProductImage.BorderStyle = BorderStyle.FixedSingle;
            picProductImage.Location = new Point(400, 15);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(180, 150);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabStop = false;

            btnChooseImage.Location = new Point(400, 172);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(180, 30);
            btnChooseImage.TabIndex = 5;
            btnChooseImage.Text = "Chọn ảnh";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;

            btnAdd.Location = new Point(620, 15);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 32);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            btnUpdate.Location = new Point(620, 55);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 32);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Location = new Point(620, 95);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 32);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            btnClear.Location = new Point(620, 135);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 32);
            btnClear.TabIndex = 9;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            // ---- dgvProducts ----
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.TabIndex = 4;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;

            // ---- frmInventoryManager ----
            // LƯU Ý THỨ TỰ: Fill phải add trước, rồi tới Top, cuối cùng mới tới các Strip
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(dgvProducts);
            Controls.Add(pnlInput);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            MainMenuStrip = menuStrip;
            Name = "frmInventoryManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý kho hàng";
            FormClosing += frmInventoryManager_FormClosing;

            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuSystem;
        private ToolStripMenuItem miOpen;
        private ToolStripMenuItem miSave;
        private ToolStripSeparator miSep;
        private ToolStripMenuItem miExit;
        private ToolStripMenuItem mnuTools;
        private ToolStripMenuItem miImport;
        private ToolStripMenuItem miExport;

        private ToolStrip toolStrip;
        private ToolStripButton tsbOpen;
        private ToolStripButton tsbSave;
        private ToolStripSeparator tsSep1;
        private ToolStripButton tsbImport;
        private ToolStripButton tsbExport;
        private ToolStripSeparator tsSep2;
        private ToolStripButton tsbExit;

        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblCount;
        private ToolStripStatusLabel lblTotal;
        private ToolStripStatusLabel lblSpring;
        private ToolStripStatusLabel lblClock;

        private System.Windows.Forms.Timer timer;

        private Panel pnlInput;
        private Label lblId;
        private Label lblName;
        private Label lblCategory;
        private Label lblQuantity;
        private Label lblPrice;
        private TextBox txtId;
        private TextBox txtName;
        private ComboBox cboCategory;
        private NumericUpDown nudQuantity;
        private NumericUpDown nudPrice;
        private PictureBox picProductImage;
        private Button btnChooseImage;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;

        private DataGridView dgvProducts;
    }
}