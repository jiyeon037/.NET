using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erp.BasicEditorYulChon.Location
{
    public partial class LocationReport : UserControl
    {
        private int locationNo { get; set; }
        private string locationName { get; set; }

        public LocationReport()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, EventArgs e) // 메인 돋보기 버튼
        {
            findLocationForm flf = new findLocationForm();
            flf.ShowDialog();
            if(flf.DialogResult == DialogResult.OK)
            {
                locationNo = flf.locationNo;
                locationName = flf.locationName;

                SearchBox.Text = locationName;
                showData(locationNo);
            }
        }

        private void showData(int locationNo)
        {
            this.locationDS21.Location.Clear();
            DataSet ds = Erp.BusinessManager.Location.GetLocationData(locationNo);
            this.locationDS21.Location.Merge(ds.Tables[0]);
            this.locationDS21.Location.AcceptChanges();   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            if (this.fpSpread1.ActiveSheet.RowCount < 1)//스프레드에 보여지는 Row값이 1미만일경우 종료
                return;

            Printer(fpSpread1, "세로", 0, "", null); //프린터 기능 메소드
        }

        public bool Printer(FarPoint.Win.Spread.FpSpread fpSpread, string paperType, int rowCount, string paperName, string check부분인쇄)
        {
            try
            {
                FarPoint.Win.Spread.PrintInfo pi = new FarPoint.Win.Spread.PrintInfo();

                pi.Margin.Header = 10;//머리말 여백
                pi.Margin.Bottom = 10;
                pi.Margin.Top = 10;
                pi.Margin.Left = 0;
                pi.Margin.Right = 0;
                pi.Margin.Footer = 10;//꼬리말 여백


                pi.ColStart = fpSpread.ActiveSheet.Models.Selection.AnchorColumn;
                pi.ColEnd = fpSpread.ActiveSheet.Models.Selection.LeadColumn;

                pi.RowStart = fpSpread.ActiveSheet.Models.Selection.AnchorRow;
                pi.RowEnd = fpSpread.ActiveSheet.Models.Selection.LeadRow;
                if (paperType == "가로")
                    pi.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;
                if (paperType == "세로")
                    pi.Orientation = FarPoint.Win.Spread.PrintOrientation.Portrait;
                pi.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide;
                pi.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Hide;
                pi.ShowBorder = false;
                pi.ShowGrid = false;

                //인쇄 페이지 마다 헤더가 출력되게 반복되는 헤더의 범위를 설정한다.
                pi.RepeatColEnd = fpSpread.ActiveSheet.ColumnCount;
                pi.RepeatColStart = 0;
                pi.RepeatRowStart = 0;
                pi.RepeatRowEnd = 4;

                if (check부분인쇄 == "부분")
                {
                    pi.ZoomFactor = 0.7f;

                }
                if (check부분인쇄 == null)
                {
                    pi.ZoomFactor = 0.35f;
                    //가운데 정렬
                }
                pi.Centering = FarPoint.Win.Spread.Centering.Horizontal;

                //PageNo 출력
                pi.Footer = "/c- /p///pc -";
                pi.PrintType = FarPoint.Win.Spread.PrintType.All;

                if (paperName == "A3")
                {
                    pi.PaperSize = new System.Drawing.Printing.PaperSize("A3", 1169, 1653);
                    pi.ZoomFactor = 0.45f;
                }

                //한 페이지에 출력이 가능하도록 맞춘다. 축소옵션
                //인쇄옵션 보기     
                pi.ShowPrintDialog = true;
                pi.Preview = true;

                if (check부분인쇄 == "부분")
                {
                    fpSpread1.ActiveSheet.PrintInfo = pi;
                    fpSpread1.PrintSheet(fpSpread1_Sheet1);
                }
                else
                {
                    fpSpread1.ActiveSheet.PrintInfo = pi;
                    fpSpread1.PrintSheet(-1);
                }


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void ExcelBtn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.fpSpread1.ActiveSheet.RowCount > 0)
                //저장할 엑셀의 파일명
                Excel(fpSpread1, "Location현황" + DateTime.Now.ToShortDateString());
            this.Cursor = Cursors.Default;
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
                    fpSpread.SaveExcel(saveFileDialog1.FileName);
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

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (this.Parent is Form)
                ((Form)this.Parent).Close();
            else if (this.Parent.Parent is Form)
                ((Form)this.Parent.Parent).Close();
            else if (this.Parent.Parent.Parent is Form)
                ((Form)this.Parent.Parent.Parent).Close();
        }
    }
}
