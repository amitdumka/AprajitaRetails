namespace AprajitaRetails.Forms
{
    partial class DailySaleForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TLPInvoiceDetails = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTInvoiceNo = new System.Windows.Forms.TextBox();
            this.CBMobileNo = new System.Windows.Forms.ComboBox();
            this.TXTCustomerName = new System.Windows.Forms.TextBox();
            this.NUDRmz = new System.Windows.Forms.NumericUpDown();
            this.NUDFabric = new System.Windows.Forms.NumericUpDown();
            this.NUDTailoring = new System.Windows.Forms.NumericUpDown();
            this.TXTBillAmount = new System.Windows.Forms.TextBox();
            this.TXTDiscount = new System.Windows.Forms.TextBox();
            this.CBPaymentMode = new System.Windows.Forms.ComboBox();
            this.CKNewCustomer = new System.Windows.Forms.CheckBox();
            this.CKPostDated = new System.Windows.Forms.CheckBox();
            this.DTPDate = new System.Windows.Forms.DateTimePicker();
            this.GBControls = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTNAdd = new System.Windows.Forms.Button();
            this.BTNDelete = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.BTNUpdate = new System.Windows.Forms.Button();
            this.GBSaleReport = new System.Windows.Forms.GroupBox();
            this.TLPSaleReport = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LBTodaySale = new System.Windows.Forms.Label();
            this.LBMontlySale = new System.Windows.Forms.Label();
            this.LBYearlySale = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LVSaleList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.TLPInvoiceDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDRmz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDFabric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTailoring)).BeginInit();
            this.GBControls.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.GBSaleReport.SuspendLayout();
            this.TLPSaleReport.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.TLPInvoiceDetails);
            this.groupBox1.Location = new System.Drawing.Point(41, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1872, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Details";
            // 
            // TLPInvoiceDetails
            // 
            this.TLPInvoiceDetails.AutoScroll = true;
            this.TLPInvoiceDetails.AutoSize = true;
            this.TLPInvoiceDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLPInvoiceDetails.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.TLPInvoiceDetails.ColumnCount = 7;
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPInvoiceDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPInvoiceDetails.Controls.Add(this.label1, 0, 0);
            this.TLPInvoiceDetails.Controls.Add(this.label4, 0, 1);
            this.TLPInvoiceDetails.Controls.Add(this.label5, 2, 1);
            this.TLPInvoiceDetails.Controls.Add(this.label6, 4, 1);
            this.TLPInvoiceDetails.Controls.Add(this.label7, 0, 2);
            this.TLPInvoiceDetails.Controls.Add(this.label8, 2, 2);
            this.TLPInvoiceDetails.Controls.Add(this.label9, 4, 2);
            this.TLPInvoiceDetails.Controls.Add(this.label3, 2, 0);
            this.TLPInvoiceDetails.Controls.Add(this.label2, 4, 0);
            this.TLPInvoiceDetails.Controls.Add(this.TXTInvoiceNo, 1, 0);
            this.TLPInvoiceDetails.Controls.Add(this.CBMobileNo, 3, 0);
            this.TLPInvoiceDetails.Controls.Add(this.TXTCustomerName, 5, 0);
            this.TLPInvoiceDetails.Controls.Add(this.NUDRmz, 1, 1);
            this.TLPInvoiceDetails.Controls.Add(this.NUDFabric, 3, 1);
            this.TLPInvoiceDetails.Controls.Add(this.NUDTailoring, 5, 1);
            this.TLPInvoiceDetails.Controls.Add(this.TXTBillAmount, 1, 2);
            this.TLPInvoiceDetails.Controls.Add(this.TXTDiscount, 3, 2);
            this.TLPInvoiceDetails.Controls.Add(this.CBPaymentMode, 5, 2);
            this.TLPInvoiceDetails.Controls.Add(this.CKNewCustomer, 6, 0);
            this.TLPInvoiceDetails.Controls.Add(this.CKPostDated, 6, 1);
            this.TLPInvoiceDetails.Controls.Add(this.DTPDate, 6, 2);
            this.TLPInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPInvoiceDetails.Location = new System.Drawing.Point(5, 36);
            this.TLPInvoiceDetails.Margin = new System.Windows.Forms.Padding(5, 5, 5, 155);
            this.TLPInvoiceDetails.Name = "TLPInvoiceDetails";
            this.TLPInvoiceDetails.RowCount = 3;
            this.TLPInvoiceDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPInvoiceDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPInvoiceDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPInvoiceDetails.Size = new System.Drawing.Size(1862, 154);
            this.TLPInvoiceDetails.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "InvoiceNo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "RMZ No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(477, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fabric No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(996, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tailoring";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 103);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 32);
            this.label7.TabIndex = 6;
            this.label7.Text = "Bill Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(477, 103);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 32);
            this.label8.TabIndex = 7;
            this.label8.Text = "Discounts";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(996, 103);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 32);
            this.label9.TabIndex = 8;
            this.label9.Text = "Payment Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "MobileNo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(996, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer Name";
            // 
            // TXTInvoiceNo
            // 
            this.TXTInvoiceNo.Location = new System.Drawing.Point(179, 7);
            this.TXTInvoiceNo.Margin = new System.Windows.Forms.Padding(5);
            this.TXTInvoiceNo.Name = "TXTInvoiceNo";
            this.TXTInvoiceNo.Size = new System.Drawing.Size(283, 38);
            this.TXTInvoiceNo.TabIndex = 9;
            // 
            // CBMobileNo
            // 
            this.CBMobileNo.FormattingEnabled = true;
            this.CBMobileNo.Location = new System.Drawing.Point(671, 7);
            this.CBMobileNo.Margin = new System.Windows.Forms.Padding(5);
            this.CBMobileNo.Name = "CBMobileNo";
            this.CBMobileNo.Size = new System.Drawing.Size(310, 39);
            this.CBMobileNo.TabIndex = 10;
            this.CBMobileNo.SelectedIndexChanged += new System.EventHandler(this.CBMobileNo_SelectedIndexChanged);
            this.CBMobileNo.TextUpdate += new System.EventHandler(this.CBMobileNo_SelectedIndexChanged);
            this.CBMobileNo.SelectedValueChanged += new System.EventHandler(this.CBMobileNo_SelectedIndexChanged);
            this.CBMobileNo.TextChanged += new System.EventHandler(this.CBMobileNo_SelectedIndexChanged);
            // 
            // TXTCustomerName
            // 
            this.TXTCustomerName.Location = new System.Drawing.Point(1227, 7);
            this.TXTCustomerName.Margin = new System.Windows.Forms.Padding(5);
            this.TXTCustomerName.Name = "TXTCustomerName";
            this.TXTCustomerName.Size = new System.Drawing.Size(378, 38);
            this.TXTCustomerName.TabIndex = 11;
            // 
            // NUDRmz
            // 
            this.NUDRmz.Location = new System.Drawing.Point(179, 58);
            this.NUDRmz.Margin = new System.Windows.Forms.Padding(5);
            this.NUDRmz.Name = "NUDRmz";
            this.NUDRmz.Size = new System.Drawing.Size(286, 38);
            this.NUDRmz.TabIndex = 12;
            // 
            // NUDFabric
            // 
            this.NUDFabric.Location = new System.Drawing.Point(671, 58);
            this.NUDFabric.Margin = new System.Windows.Forms.Padding(5);
            this.NUDFabric.Name = "NUDFabric";
            this.NUDFabric.Size = new System.Drawing.Size(313, 38);
            this.NUDFabric.TabIndex = 13;
            // 
            // NUDTailoring
            // 
            this.NUDTailoring.Location = new System.Drawing.Point(1227, 58);
            this.NUDTailoring.Margin = new System.Windows.Forms.Padding(5);
            this.NUDTailoring.Name = "NUDTailoring";
            this.NUDTailoring.Size = new System.Drawing.Size(213, 38);
            this.NUDTailoring.TabIndex = 14;
            // 
            // TXTBillAmount
            // 
            this.TXTBillAmount.Location = new System.Drawing.Point(179, 108);
            this.TXTBillAmount.Margin = new System.Windows.Forms.Padding(5);
            this.TXTBillAmount.Name = "TXTBillAmount";
            this.TXTBillAmount.Size = new System.Drawing.Size(283, 38);
            this.TXTBillAmount.TabIndex = 15;
            // 
            // TXTDiscount
            // 
            this.TXTDiscount.Location = new System.Drawing.Point(671, 108);
            this.TXTDiscount.Margin = new System.Windows.Forms.Padding(5);
            this.TXTDiscount.Name = "TXTDiscount";
            this.TXTDiscount.Size = new System.Drawing.Size(310, 38);
            this.TXTDiscount.TabIndex = 16;
            // 
            // CBPaymentMode
            // 
            this.CBPaymentMode.FormattingEnabled = true;
            this.CBPaymentMode.Location = new System.Drawing.Point(1227, 108);
            this.CBPaymentMode.Margin = new System.Windows.Forms.Padding(5);
            this.CBPaymentMode.Name = "CBPaymentMode";
            this.CBPaymentMode.Size = new System.Drawing.Size(212, 39);
            this.CBPaymentMode.TabIndex = 17;
            this.CBPaymentMode.SelectedIndexChanged += new System.EventHandler(this.CBPaymentMode_SelectedIndexChanged);
            // 
            // CKNewCustomer
            // 
            this.CKNewCustomer.AutoSize = true;
            this.CKNewCustomer.Location = new System.Drawing.Point(1617, 7);
            this.CKNewCustomer.Margin = new System.Windows.Forms.Padding(5);
            this.CKNewCustomer.Name = "CKNewCustomer";
            this.CKNewCustomer.Size = new System.Drawing.Size(238, 36);
            this.CKNewCustomer.TabIndex = 18;
            this.CKNewCustomer.Text = "New Customer";
            this.CKNewCustomer.UseVisualStyleBackColor = true;
            // 
            // CKPostDated
            // 
            this.CKPostDated.AutoSize = true;
            this.CKPostDated.Location = new System.Drawing.Point(1615, 56);
            this.CKPostDated.Name = "CKPostDated";
            this.CKPostDated.Size = new System.Drawing.Size(193, 36);
            this.CKPostDated.TabIndex = 19;
            this.CKPostDated.Text = "Post Dated";
            this.CKPostDated.UseVisualStyleBackColor = true;
            // 
            // DTPDate
            // 
            this.DTPDate.Location = new System.Drawing.Point(1615, 106);
            this.DTPDate.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.DTPDate.Name = "DTPDate";
            this.DTPDate.Size = new System.Drawing.Size(200, 38);
            this.DTPDate.TabIndex = 20;
            // 
            // GBControls
            // 
            this.GBControls.AutoSize = true;
            this.GBControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBControls.Controls.Add(this.flowLayoutPanel2);
            this.GBControls.Location = new System.Drawing.Point(41, 352);
            this.GBControls.Margin = new System.Windows.Forms.Padding(5);
            this.GBControls.Name = "GBControls";
            this.GBControls.Padding = new System.Windows.Forms.Padding(5);
            this.GBControls.Size = new System.Drawing.Size(806, 116);
            this.GBControls.TabIndex = 4;
            this.GBControls.TabStop = false;
            this.GBControls.Text = "Controls";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.BTNAdd);
            this.flowLayoutPanel2.Controls.Add(this.BTNDelete);
            this.flowLayoutPanel2.Controls.Add(this.Cancel);
            this.flowLayoutPanel2.Controls.Add(this.BTNUpdate);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 36);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(796, 75);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // BTNAdd
            // 
            this.BTNAdd.AutoSize = true;
            this.BTNAdd.Location = new System.Drawing.Point(5, 5);
            this.BTNAdd.Margin = new System.Windows.Forms.Padding(5);
            this.BTNAdd.Name = "BTNAdd";
            this.BTNAdd.Size = new System.Drawing.Size(135, 65);
            this.BTNAdd.TabIndex = 4;
            this.BTNAdd.Text = "Add";
            this.BTNAdd.UseVisualStyleBackColor = true;
            this.BTNAdd.Click += new System.EventHandler(this.BTNAdd_Click);
            // 
            // BTNDelete
            // 
            this.BTNDelete.AutoSize = true;
            this.BTNDelete.Location = new System.Drawing.Point(150, 5);
            this.BTNDelete.Margin = new System.Windows.Forms.Padding(5);
            this.BTNDelete.Name = "BTNDelete";
            this.BTNDelete.Size = new System.Drawing.Size(210, 65);
            this.BTNDelete.TabIndex = 6;
            this.BTNDelete.Text = "New Customer";
            this.BTNDelete.UseVisualStyleBackColor = true;
            this.BTNDelete.Click += new System.EventHandler(this.BTNDelete_Click);
            // 
            // Cancel
            // 
            this.Cancel.AutoSize = true;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(370, 5);
            this.Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(203, 65);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // BTNUpdate
            // 
            this.BTNUpdate.AutoSize = true;
            this.BTNUpdate.Location = new System.Drawing.Point(583, 5);
            this.BTNUpdate.Margin = new System.Windows.Forms.Padding(5);
            this.BTNUpdate.Name = "BTNUpdate";
            this.BTNUpdate.Size = new System.Drawing.Size(208, 65);
            this.BTNUpdate.TabIndex = 5;
            this.BTNUpdate.Text = "Update";
            this.BTNUpdate.UseVisualStyleBackColor = true;
            // 
            // GBSaleReport
            // 
            this.GBSaleReport.AutoSize = true;
            this.GBSaleReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GBSaleReport.Controls.Add(this.TLPSaleReport);
            this.GBSaleReport.Location = new System.Drawing.Point(892, 307);
            this.GBSaleReport.Name = "GBSaleReport";
            this.GBSaleReport.Size = new System.Drawing.Size(301, 175);
            this.GBSaleReport.TabIndex = 5;
            this.GBSaleReport.TabStop = false;
            this.GBSaleReport.Text = "Sale Info";
            // 
            // TLPSaleReport
            // 
            this.TLPSaleReport.AutoSize = true;
            this.TLPSaleReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLPSaleReport.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.TLPSaleReport.ColumnCount = 2;
            this.TLPSaleReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPSaleReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLPSaleReport.Controls.Add(this.label10, 0, 0);
            this.TLPSaleReport.Controls.Add(this.label11, 0, 1);
            this.TLPSaleReport.Controls.Add(this.label12, 0, 2);
            this.TLPSaleReport.Controls.Add(this.LBTodaySale, 1, 0);
            this.TLPSaleReport.Controls.Add(this.LBMontlySale, 1, 1);
            this.TLPSaleReport.Controls.Add(this.LBYearlySale, 1, 2);
            this.TLPSaleReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPSaleReport.Location = new System.Drawing.Point(3, 34);
            this.TLPSaleReport.Name = "TLPSaleReport";
            this.TLPSaleReport.RowCount = 3;
            this.TLPSaleReport.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPSaleReport.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPSaleReport.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLPSaleReport.Size = new System.Drawing.Size(295, 138);
            this.TLPSaleReport.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(6, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(218, 42);
            this.label10.TabIndex = 0;
            this.label10.Text = "Today Sale";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(6, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(234, 42);
            this.label11.TabIndex = 1;
            this.label11.Text = "Monthly Sale";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(6, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(209, 42);
            this.label12.TabIndex = 2;
            this.label12.Text = "Yearly Sale";
            // 
            // LBTodaySale
            // 
            this.LBTodaySale.AutoSize = true;
            this.LBTodaySale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTodaySale.ForeColor = System.Drawing.Color.Red;
            this.LBTodaySale.Location = new System.Drawing.Point(249, 3);
            this.LBTodaySale.Name = "LBTodaySale";
            this.LBTodaySale.Size = new System.Drawing.Size(40, 42);
            this.LBTodaySale.TabIndex = 3;
            this.LBTodaySale.Text = "0";
            // 
            // LBMontlySale
            // 
            this.LBMontlySale.AutoSize = true;
            this.LBMontlySale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBMontlySale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LBMontlySale.Location = new System.Drawing.Point(249, 48);
            this.LBMontlySale.Name = "LBMontlySale";
            this.LBMontlySale.Size = new System.Drawing.Size(40, 42);
            this.LBMontlySale.TabIndex = 4;
            this.LBMontlySale.Text = "0";
            // 
            // LBYearlySale
            // 
            this.LBYearlySale.AutoSize = true;
            this.LBYearlySale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBYearlySale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LBYearlySale.Location = new System.Drawing.Point(249, 93);
            this.LBYearlySale.Name = "LBYearlySale";
            this.LBYearlySale.Size = new System.Drawing.Size(40, 42);
            this.LBYearlySale.TabIndex = 5;
            this.LBYearlySale.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LVSaleList);
            this.groupBox2.Location = new System.Drawing.Point(1478, 307);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 844);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Invoice List";
            // 
            // LVSaleList
            // 
            this.LVSaleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LVSaleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LVSaleList.FullRowSelect = true;
            this.LVSaleList.GridLines = true;
            this.LVSaleList.Location = new System.Drawing.Point(3, 34);
            this.LVSaleList.Name = "LVSaleList";
            this.LVSaleList.Size = new System.Drawing.Size(494, 807);
            this.LVSaleList.TabIndex = 0;
            this.LVSaleList.UseCompatibleStateImageBehavior = false;
            this.LVSaleList.View = System.Windows.Forms.View.Details;
            this.LVSaleList.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "InvoiceDate";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Amount";
            this.columnHeader2.Width = 100;
            // 
            // DailySaleForm
            // 
            this.AcceptButton = this.BTNAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(2108, 1157);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GBSaleReport);
            this.Controls.Add(this.GBControls);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DailySaleForm";
            this.Text = "Daily Sales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DailySaleForm_Load);
            this.Shown += new System.EventHandler(this.DailySaleForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TLPInvoiceDetails.ResumeLayout(false);
            this.TLPInvoiceDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDRmz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDFabric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTailoring)).EndInit();
            this.GBControls.ResumeLayout(false);
            this.GBControls.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.GBSaleReport.ResumeLayout(false);
            this.GBSaleReport.PerformLayout();
            this.TLPSaleReport.ResumeLayout(false);
            this.TLPSaleReport.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel TLPInvoiceDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTInvoiceNo;
        private System.Windows.Forms.ComboBox CBMobileNo;
        private System.Windows.Forms.TextBox TXTCustomerName;
        private System.Windows.Forms.NumericUpDown NUDRmz;
        private System.Windows.Forms.NumericUpDown NUDFabric;
        private System.Windows.Forms.NumericUpDown NUDTailoring;
        private System.Windows.Forms.TextBox TXTBillAmount;
        private System.Windows.Forms.TextBox TXTDiscount;
        private System.Windows.Forms.ComboBox CBPaymentMode;
        private System.Windows.Forms.CheckBox CKNewCustomer;
        private System.Windows.Forms.CheckBox CKPostDated;
        private System.Windows.Forms.DateTimePicker DTPDate;
        private System.Windows.Forms.GroupBox GBControls;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button BTNAdd;
        private System.Windows.Forms.Button BTNDelete;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button BTNUpdate;
        private System.Windows.Forms.GroupBox GBSaleReport;
        private System.Windows.Forms.TableLayoutPanel TLPSaleReport;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LBTodaySale;
        private System.Windows.Forms.Label LBMontlySale;
        private System.Windows.Forms.Label LBYearlySale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView LVSaleList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}