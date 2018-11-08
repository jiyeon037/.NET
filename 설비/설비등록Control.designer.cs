namespace Erp.YulChonMold.설비
{
    partial class 설비등록Control
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer enhancedFocusIndicatorRenderer1 = new FarPoint.Win.Spread.EnhancedFocusIndicatorRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(설비등록Control));
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.button이력카드등록 = new System.Windows.Forms.Button();
            this.button이력카드인쇄 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fpSpread설비등록 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread설비등록_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.설비BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.설비등록DS = new Erp.YulChonMold.설비.설비등록DS();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread설비등록)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread설비등록_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.설비BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.설비등록DS)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(106)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonPrint);
            this.panel1.Controls.Add(this.buttonExcel);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.button이력카드등록);
            this.panel1.Controls.Add(this.button이력카드인쇄);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 58);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "설비 등록";
            // 
            // buttonExit
            // 
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(884, 10);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(85, 42);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "종료";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // buttonPrint
            // 
            this.buttonPrint.FlatAppearance.BorderSize = 0;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonPrint.ForeColor = System.Drawing.Color.White;
            this.buttonPrint.Location = new System.Drawing.Point(807, 10);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(85, 42);
            this.buttonPrint.TabIndex = 2;
            this.buttonPrint.Text = "인쇄";
            this.buttonPrint.UseVisualStyleBackColor = true;
            // 
            // buttonExcel
            // 
            this.buttonExcel.FlatAppearance.BorderSize = 0;
            this.buttonExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonExcel.ForeColor = System.Drawing.Color.White;
            this.buttonExcel.Location = new System.Drawing.Point(727, 10);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(85, 42);
            this.buttonExcel.TabIndex = 3;
            this.buttonExcel.Text = "엑셀";
            this.buttonExcel.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(649, 10);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(85, 42);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "삭제";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(572, 10);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(85, 42);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "저장";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(493, 10);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(85, 42);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "추가";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // button이력카드등록
            // 
            this.button이력카드등록.FlatAppearance.BorderSize = 0;
            this.button이력카드등록.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button이력카드등록.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button이력카드등록.ForeColor = System.Drawing.Color.White;
            this.button이력카드등록.Location = new System.Drawing.Point(237, 10);
            this.button이력카드등록.Name = "button이력카드등록";
            this.button이력카드등록.Size = new System.Drawing.Size(118, 42);
            this.button이력카드등록.TabIndex = 7;
            this.button이력카드등록.Text = "이력카드등록";
            this.button이력카드등록.UseVisualStyleBackColor = true;
            this.button이력카드등록.Click += new System.EventHandler(this.button이력카드등록_Click);
            // 
            // button이력카드인쇄
            // 
            this.button이력카드인쇄.FlatAppearance.BorderSize = 0;
            this.button이력카드인쇄.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button이력카드인쇄.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button이력카드인쇄.ForeColor = System.Drawing.Color.White;
            this.button이력카드인쇄.Location = new System.Drawing.Point(368, 10);
            this.button이력카드인쇄.Name = "button이력카드인쇄";
            this.button이력카드인쇄.Size = new System.Drawing.Size(119, 42);
            this.button이력카드인쇄.TabIndex = 8;
            this.button이력카드인쇄.Text = "이력카드인쇄";
            this.button이력카드인쇄.UseVisualStyleBackColor = true;
            this.button이력카드인쇄.Click += new System.EventHandler(this.button이력카드인쇄_Click);
            // 
            // fpSpread설비등록
            // 
            this.fpSpread설비등록.AccessibleDescription = "";
            this.fpSpread설비등록.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.ColumnHeaders;
            this.fpSpread설비등록.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpSpread설비등록.EditModeReplace = true;
            this.fpSpread설비등록.FocusRenderer = enhancedFocusIndicatorRenderer1;
            this.fpSpread설비등록.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fpSpread설비등록.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpSpread설비등록.HorizontalScrollBar.Name = "";
            enhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.Silver;
            enhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.DimGray;
            enhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.DimGray;
            enhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.Gray;
            enhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.Gray;
            this.fpSpread설비등록.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.fpSpread설비등록.HorizontalScrollBar.TabIndex = 48;
            this.fpSpread설비등록.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread설비등록.Location = new System.Drawing.Point(0, 58);
            this.fpSpread설비등록.Name = "fpSpread설비등록";
            this.fpSpread설비등록.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread설비등록_Sheet1});
            this.fpSpread설비등록.Size = new System.Drawing.Size(985, 469);
            this.fpSpread설비등록.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Metallic;
            this.fpSpread설비등록.TabIndex = 1;
            this.fpSpread설비등록.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpSpread설비등록.VerticalScrollBar.Name = "";
            enhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.Black;
            enhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.Silver;
            enhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.DimGray;
            enhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.DimGray;
            enhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.Gray;
            enhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.DarkGray;
            enhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.Gray;
            this.fpSpread설비등록.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.fpSpread설비등록.VerticalScrollBar.TabIndex = 49;
            this.fpSpread설비등록.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpSpread설비등록.EditModeOff += new System.EventHandler(this.fpSpread1_EditModeOff);
            // 
            // fpSpread설비등록_Sheet1
            // 
            this.fpSpread설비등록_Sheet1.Reset();
            this.fpSpread설비등록_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread설비등록_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread설비등록_Sheet1.ColumnCount = 15;
            this.fpSpread설비등록_Sheet1.ActiveColumnIndex = -1;
            this.fpSpread설비등록_Sheet1.ActiveRowIndex = -1;
            this.fpSpread설비등록_Sheet1.ColumnFooter.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSpread설비등록_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread설비등록_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnHeaderMetallic";
            this.fpSpread설비등록_Sheet1.ColumnFooter.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSpread설비등록_Sheet1.ColumnFooterSheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSpread설비등록_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread설비등록_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerMetallic";
            this.fpSpread설비등록_Sheet1.ColumnFooterSheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSpread설비등록_Sheet1.ColumnHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSpread설비등록_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread설비등록_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderMetallic";
            this.fpSpread설비등록_Sheet1.ColumnHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSpread설비등록_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this.fpSpread설비등록_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.LightYellow;
            textCellType1.AllowEditorVerticalAlign = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpSpread설비등록_Sheet1.Columns.Get(0).DataField = "관리코드";
            this.fpSpread설비등록_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.fpSpread설비등록_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(0).Locked = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(0).Width = 138F;
            this.fpSpread설비등록_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.LightYellow;
            textCellType2.AllowEditorVerticalAlign = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpSpread설비등록_Sheet1.Columns.Get(1).DataField = "관리번호";
            this.fpSpread설비등록_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.fpSpread설비등록_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(1).Locked = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(1).Width = 135F;
            textCellType3.AllowEditorVerticalAlign = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.fpSpread설비등록_Sheet1.Columns.Get(2).DataField = "품명";
            this.fpSpread설비등록_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.fpSpread설비등록_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(2).Width = 113F;
            textCellType4.AllowEditorVerticalAlign = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.fpSpread설비등록_Sheet1.Columns.Get(3).DataField = "규격";
            this.fpSpread설비등록_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.fpSpread설비등록_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(3).Width = 156F;
            textCellType5.AllowEditorVerticalAlign = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(4).CellType = textCellType5;
            this.fpSpread설비등록_Sheet1.Columns.Get(4).DataField = "제조회사";
            this.fpSpread설비등록_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.fpSpread설비등록_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(4).Width = 156F;
            dateTimeCellType1.AllowEditorVerticalAlign = true;
            dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType1.CalendarSurroundingDaysColor = System.Drawing.SystemColors.GrayText;
            dateTimeCellType1.MaximumTime = System.TimeSpan.Parse("23:59:59.9999999");
            dateTimeCellType1.TimeDefault = new System.DateTime(2018, 11, 8, 17, 13, 16, 0);
            this.fpSpread설비등록_Sheet1.Columns.Get(5).CellType = dateTimeCellType1;
            this.fpSpread설비등록_Sheet1.Columns.Get(5).DataField = "구입일자";
            this.fpSpread설비등록_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.fpSpread설비등록_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(5).Width = 156F;
            numberCellType1.AllowEditorVerticalAlign = true;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.Yes;
            numberCellType1.MaximumValue = 2147483647D;
            numberCellType1.MinimumValue = -2147483648D;
            numberCellType1.ShowSeparator = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(6).CellType = numberCellType1;
            this.fpSpread설비등록_Sheet1.Columns.Get(6).DataField = "금액";
            this.fpSpread설비등록_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.fpSpread설비등록_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(6).Width = 127F;
            textCellType6.AllowEditorVerticalAlign = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(7).CellType = textCellType6;
            this.fpSpread설비등록_Sheet1.Columns.Get(7).DataField = "설치장소";
            this.fpSpread설비등록_Sheet1.Columns.Get(7).Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.fpSpread설비등록_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(7).Width = 102F;
            textCellType7.AllowEditorVerticalAlign = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(8).CellType = textCellType7;
            this.fpSpread설비등록_Sheet1.Columns.Get(8).DataField = "등급";
            this.fpSpread설비등록_Sheet1.Columns.Get(8).Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.fpSpread설비등록_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(8).Width = 64F;
            textCellType8.AllowEditorVerticalAlign = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(9).CellType = textCellType8;
            this.fpSpread설비등록_Sheet1.Columns.Get(9).DataField = "관리부서";
            this.fpSpread설비등록_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(9).Width = 120F;
            textCellType9.AllowEditorVerticalAlign = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(10).CellType = textCellType9;
            this.fpSpread설비등록_Sheet1.Columns.Get(10).DataField = "관리책임자";
            this.fpSpread설비등록_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(10).Width = 135F;
            textCellType10.AllowEditorVerticalAlign = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(11).CellType = textCellType10;
            this.fpSpread설비등록_Sheet1.Columns.Get(11).DataField = "수리업체";
            this.fpSpread설비등록_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(11).Width = 126F;
            textCellType11.AllowEditorVerticalAlign = true;
            this.fpSpread설비등록_Sheet1.Columns.Get(12).CellType = textCellType11;
            this.fpSpread설비등록_Sheet1.Columns.Get(12).DataField = "수리업체연락처";
            this.fpSpread설비등록_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpSpread설비등록_Sheet1.Columns.Get(12).Width = 135F;
            numberCellType2.AllowEditorVerticalAlign = true;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.Yes;
            numberCellType2.MaximumValue = 2147483647D;
            numberCellType2.MinimumValue = -2147483648D;
            this.fpSpread설비등록_Sheet1.Columns.Get(13).CellType = numberCellType2;
            this.fpSpread설비등록_Sheet1.Columns.Get(13).DataField = "관리순번";
            this.fpSpread설비등록_Sheet1.Columns.Get(13).Visible = false;
            this.fpSpread설비등록_Sheet1.Columns.Get(13).Width = 135F;
            numberCellType3.AllowEditorVerticalAlign = true;
            numberCellType3.DecimalPlaces = 0;
            numberCellType3.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.Yes;
            numberCellType3.MaximumValue = 2147483647D;
            numberCellType3.MinimumValue = -2147483648D;
            this.fpSpread설비등록_Sheet1.Columns.Get(14).CellType = numberCellType3;
            this.fpSpread설비등록_Sheet1.Columns.Get(14).DataField = "설비종류";
            this.fpSpread설비등록_Sheet1.Columns.Get(14).Visible = false;
            this.fpSpread설비등록_Sheet1.Columns.Get(14).Width = 102F;
            this.fpSpread설비등록_Sheet1.DataAutoCellTypes = false;
            this.fpSpread설비등록_Sheet1.DataAutoSizeColumns = false;
            this.fpSpread설비등록_Sheet1.DataSource = this.설비BindingSource;
            this.fpSpread설비등록_Sheet1.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSpread설비등록_Sheet1.DefaultStyle.Locked = false;
            this.fpSpread설비등록_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread설비등록_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.fpSpread설비등록_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSpread설비등록_Sheet1.DisplayZero = false;
            this.fpSpread설비등록_Sheet1.FilterBar.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSpread설비등록_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread설비등록_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarMetallic";
            this.fpSpread설비등록_Sheet1.FilterBar.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSpread설비등록_Sheet1.FilterBarHeaderStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSpread설비등록_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread설비등록_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderMetallic";
            this.fpSpread설비등록_Sheet1.FilterBarHeaderStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSpread설비등록_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.fpSpread설비등록_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread설비등록_Sheet1.RowHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSpread설비등록_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread설비등록_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderMetallic";
            this.fpSpread설비등록_Sheet1.RowHeader.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSpread설비등록_Sheet1.RowHeader.Visible = false;
            this.fpSpread설비등록_Sheet1.SheetCornerStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.fpSpread설비등록_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread설비등록_Sheet1.SheetCornerStyle.Parent = "CornerMetallic";
            this.fpSpread설비등록_Sheet1.SheetCornerStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.fpSpread설비등록_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // 설비BindingSource
            // 
            this.설비BindingSource.DataMember = "설비";
            this.설비BindingSource.DataSource = this.설비등록DS;
            // 
            // 설비등록DS
            // 
            this.설비등록DS.DataSetName = "설비등록DS";
            this.설비등록DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // 설비등록Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fpSpread설비등록);
            this.Controls.Add(this.panel1);
            this.Name = "설비등록Control";
            this.Size = new System.Drawing.Size(985, 527);
            this.Load += new System.EventHandler(this.설비등록_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread설비등록)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread설비등록_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.설비BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.설비등록DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private FarPoint.Win.Spread.FpSpread fpSpread설비등록;
        private FarPoint.Win.Spread.SheetView fpSpread설비등록_Sheet1;
        private 설비등록DS 설비등록DS;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button button이력카드등록;
        private System.Windows.Forms.Button button이력카드인쇄;
        private System.Windows.Forms.BindingSource 설비BindingSource;
        private System.Windows.Forms.Label label1;
    }
}
