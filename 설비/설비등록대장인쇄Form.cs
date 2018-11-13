using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FarPoint.Win.Spread;

namespace Erp.YulChonMold.설비
{
    public partial class 설비등록대장인쇄Form : Form
    {
        //row의 시작부분
        FarPoint.Win.ComplexBorder complexBorderStartLine = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.MediumLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), false, false);
        //row의 중간부분
        FarPoint.Win.ComplexBorder complexBorderCenterLine = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), false, false);
        //row의 끝부분
        FarPoint.Win.ComplexBorder complexBorderEndLine = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.MediumLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), false, false);
        //마지막 row의 시작부분
        FarPoint.Win.ComplexBorder complexBorderLastRowStartLine = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.MediumLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.MediumLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), false, false);
        //마지막 row의 중간부분
        FarPoint.Win.ComplexBorder complexBorderLastRowCenterLine = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.MediumLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), false, false);
        //마지막 row의 끝부분
        FarPoint.Win.ComplexBorder complexBorderLastRowEndLine = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.MediumLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.MediumLine, System.Drawing.Color.Black),
            new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), false, false);

        public 설비등록대장인쇄Form()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ShowData();
        }

        private void ShowData()
        {
            Cursor = Cursors.WaitCursor;
            DataSet dataSet = Erp.BusinessManager.설비.Get설비등록대장();
            FarPoint.Win.Spread.SheetView sheetView = fpSpread등록대장인쇄.ActiveSheet;

            sheetView.RowCount = 6;
            int lastrow = 0;
            int cnt = 1;

            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                int row = sheetView.RowCount++;

                sheetView.Cells[row, 0].Value = cnt++;
                sheetView.Cells[row, 1].Value = dataRow["관리번호"].ToString();
                sheetView.Cells[row, 2].Value = dataRow["품명"].ToString();
                sheetView.Cells[row, 3].Value = dataRow["규격"].ToString();
                sheetView.Cells[row, 4].Value = dataRow["제조회사"].ToString();
                sheetView.Cells[row, 5].Value = Convert.ToDateTime(dataRow["구입일자"]).ToString("yyyy-MM-dd");
                sheetView.Cells[row, 6].Value = Convert.ToInt32(dataRow["금액"]);
                sheetView.Cells[row, 7].Value = dataRow["설치장소"].ToString();
                sheetView.Cells[row, 8].Value = dataRow["등급"].ToString();
                sheetView.Cells[row, 9].Value = dataRow["관리부서"].ToString();
                sheetView.Cells[row, 10].Value = dataRow["관리책임자"].ToString();
                sheetView.Cells[row, 11].Value = dataRow["수리업체"].ToString();
                sheetView.Cells[row, 12].Value = dataRow["수리업체연락처"].ToString();
                DrawBorder(row);
                lastrow = row;
            }
            DrawLastRowBorder(lastrow);
            Cursor = Cursors.Default;

        }

        private void DrawBorder(int row)
        {
            //border 수동으로 그림
            fpSpread등록대장인쇄.ActiveSheet.Cells[row, 0, row, 0].Border = complexBorderStartLine;
            fpSpread등록대장인쇄.ActiveSheet.Cells[row, 1, row, 11].Border = complexBorderCenterLine;
            fpSpread등록대장인쇄.ActiveSheet.Cells[row, 12, row, 12].Border = complexBorderEndLine;

        }
        private void DrawLastRowBorder(int lastrow)
        {
            //border 수동으로 그림
            fpSpread등록대장인쇄.ActiveSheet.Cells[lastrow, 0, lastrow, 0].Border = complexBorderLastRowStartLine;
            fpSpread등록대장인쇄.ActiveSheet.Cells[lastrow, 1, lastrow, 11].Border = complexBorderLastRowCenterLine;
            fpSpread등록대장인쇄.ActiveSheet.Cells[lastrow, 12, lastrow, 12].Border = complexBorderLastRowEndLine;

        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (this.fpSpread등록대장인쇄.ActiveSheet.RowCount > 0)
                //저장할 엑셀의 파일명
                Excel(fpSpread등록대장인쇄, "설비등록대장_" + DateTime.Now.ToShortDateString());
            Cursor = Cursors.Default;
        }

        public static bool Excel(FarPoint.Win.Spread.FpSpread fpSpread, string fileName)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "excel files (*.xls)|*.xls|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 0;
                saveFileDialog1.Title = "Excel 파일저장";
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = fileName + ".xls";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //SaveFlags로 ColumnHeader를 Excel파일에 함께 저장함
                    fpSpread.SaveExcel(saveFileDialog1.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : [" + ex.Message + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (this.fpSpread등록대장인쇄.ActiveSheet.RowCount < 1)
                return;

            Printer(fpSpread등록대장인쇄, "가로", 0);
        }

        public bool Printer(FarPoint.Win.Spread.FpSpread fpSpread, string paperType, int rowCount)
        {
            try
            {
                FarPoint.Win.Spread.PrintInfo pi = new FarPoint.Win.Spread.PrintInfo();

                pi.Margin.Header = 20;
                pi.Margin.Bottom = 70;
                pi.Margin.Top = 100;
                pi.Margin.Left = 20;
                pi.Margin.Right = 20;
                pi.ColStart = fpSpread.ActiveSheet.Models.Selection.AnchorColumn;
                pi.ColEnd = fpSpread.ActiveSheet.Models.Selection.LeadColumn;
                pi.RowStart = fpSpread.ActiveSheet.Models.Selection.AnchorRow;
                pi.RowEnd = fpSpread.ActiveSheet.Models.Selection.LeadRow;
                if (paperType == "가로")
                    pi.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;
                if (paperType == "세로")
                    pi.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait;
                //Headr Show 설정
                pi.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide;
                pi.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Hide;
                pi.ShowBorder = false;
                pi.ShowGrid = false;

                //인쇄 페이지 마다 출력될 반복 페이지를 설정한다.
                pi.RepeatColEnd = 12;
                pi.RepeatColStart = 1;
                pi.RepeatRowEnd = 5;
                pi.RepeatRowStart = 4;

                //한 페이지에 출력이 가능하도록 맞춘다. 축소옵션
                pi.ZoomFactor = 0.9f;

                //정렬
                pi.Centering = FarPoint.Win.Spread.Centering.Horizontal;

                ////PageNo 출력
                pi.Footer = "/l       QP-751-04(Rev.1) /c(주)율촌 /rA4(210*297mm)      ";
                pi.PrintType = FarPoint.Win.Spread.PrintType.All;

                //인쇄옵션 보기     
                pi.ShowPrintDialog = true;

                //인쇄미리보기
                pi.Preview = true;
                fpSpread등록대장인쇄.ActiveSheet.PrintInfo = pi;
                fpSpread등록대장인쇄.PrintSheet(fpSpread등록대장인쇄.ActiveSheet);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
