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
    public partial class 설비이력카드인쇄Form : Form
    {
        private 설비등록DS 설비등록DS;

        byte[] vs = { 0 };

        public 설비이력카드인쇄Form(string 관리코드)
        {
            InitializeComponent();
            Init(관리코드);
        }

        private void Init(string 관리코드)
        {
            설비등록DS = new 설비등록DS();
            ShowData(관리코드);
        }

        private void ShowData(string 관리코드)
        {
            //get설비이력카드출력정보
            DataSet dataSet = Erp.BusinessManager.설비.Get설비이력카드출력정보(관리코드);
            설비등록DS.설비.Merge(dataSet.Tables[0]);
            설비등록DS.보전이력.Merge(dataSet.Tables[2]);
            설비등록DS.설비가동고장집계.Merge(dataSet.Tables[3]);

            // 보전이력 table에 년도와 분기를 만든다.

            foreach(설비등록DS.보전이력Row 보전이력row in 설비등록DS.보전이력)
            {
                보전이력row.년도 = 보전이력row.수리일자.Year;
                보전이력row.분기 = Get분기(보전이력row.수리일자);
            }


            //sheet에 data를 보여준다
            Show설비Data(dataSet.Tables[0]);
            Show중요부품품목Data(dataSet.Tables[1]);
            Show보전이력Data(dataSet.Tables[2]);
         //   Show설비가동고장집계Data(dataSet.Tables[3]);

        }

        private void Show설비Data(DataTable datatable)
        {
            if (datatable.Rows.Count == 0)
            {
                MessageBox.Show("저장한 정보만 인쇄가 가능합니다. 저장 후에 다시 시도해주세요.", "저장하지 않은 정보 인쇄 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FarPoint.Win.Spread.SheetView sheetView = fpSpread설비이력.ActiveSheet;
            DataRow dataRow = datatable.Rows[0];
            sheetView.Cells["관리번호"].Value = dataRow["관리코드"].ToString();
            sheetView.Cells["설비명"].Value = dataRow["품명"].ToString();
            sheetView.Cells["형식또는규격"].Value = dataRow["규격"].ToString();
            sheetView.Cells["제조회사"].Value = dataRow["제조회사"].ToString();
            sheetView.Cells["구입일자"].Value = Convert.ToDateTime(dataRow["구입일자"]).ToString("yyyy-MM-dd");
            sheetView.Cells["구입금액"].Value = Convert.ToInt32(dataRow["금액"]);
            sheetView.Cells["설치장소"].Value = dataRow["설치장소"].ToString();
            sheetView.Cells["등급"].Value = "              " + dataRow["등급"].ToString();
            sheetView.Cells["관리자"].Value = dataRow["관리책임자"].ToString() + "       ";
            if (dataRow["사진"] != vs)
                sheetView.Cells["사진및약도"].Value = (byte[])dataRow["사진"];
        }

        private void Show중요부품품목Data(DataTable datatable)
        {
            FarPoint.Win.Spread.SheetView sheetView = fpSpread설비이력.ActiveSheet;
            int cnt = 0;
            foreach (DataRow dataRow in datatable.Rows)
            {
                cnt++;
                sheetView.Cells["번호" + cnt].Value = cnt;
                sheetView.Cells["품명" + cnt].Value = dataRow["품명"].ToString();
                sheetView.Cells["사양" + cnt].Value = dataRow["규격"].ToString();
            }
        }

        private void Show보전이력Data(DataTable datatable)
        {
            FarPoint.Win.Spread.SheetView sheetView = fpSpread설비이력.ActiveSheet;
            int cnt = 0;
            foreach (DataRow dataRow in datatable.Rows)
            {
                cnt++;
                sheetView.Cells["보전번호" + cnt].Value = cnt;
                sheetView.Cells["일자" + cnt].Value = Convert.ToDateTime(dataRow["수리일자"]).ToString("yyyy-MM-dd");
                sheetView.Cells["고장내용" + cnt].Value = dataRow["고장내용"].ToString();
                sheetView.Cells["수리점검내용" + cnt].Value = dataRow["수리내역"].ToString();
                sheetView.Cells["수리부품" + cnt].Value = dataRow["수리부품"].ToString();
                sheetView.Cells["수리처구매처" + cnt].Value = dataRow["수리처"].ToString();
                sheetView.Cells["비용" + cnt].Value = dataRow["비용"];
                sheetView.Cells["시간" + cnt].Value = dataRow["시간"];
            }
        }

        private void Show설비가동고장집계Data(DataTable datatable)
        {
            //var query = from o in db.Orders
            //            from p in db.Products
            //            join d in db.OrderDetails
            //                on new { o.OrderID, p.ProductID } equals new { d.OrderID, d.ProductID } into details
            //            from d in details
            //            select new { o.OrderID, p.ProductID, d.UnitPrice };

            //var query = from person in people
            //            join pet in pets on person equals pet.Owner into gj
            //            from subpet in gj.DefaultIfEmpty()
            //            select new { person.FirstName, PetName = subpet?.Name ?? String.Empty };

            //var leftOuterQuery2 =
            //  from category in categories
            //  join prod in products on category.ID equals prod.CategoryID into prodGroup
            //  from item in prodGroup.DefaultIfEmpty()
            //  select new { Name = item == null ? "Nothing!" : item.Name, CategoryID = category.ID };

            // 1. 설비.보전이력 정보를 사용하여 년도, 분기 별로 고장횟수, 수리시간을 구한다.
            // 
            // select  a.년도, b.분기, count(*) 고장횟수, sum(a.시간) 수리시간
            // from 보전이력 a left outer join 설비가동고장집계 b on a.년도 = b.년도 and a.분기 = b.분기
            // group by a.년도, b.분기
            // 
            // *** 아래 LINQ 질의 명령문은 위의 SQL문장을 LINQ로 구현한 것이다.
            var var보전이력 =
                from 보전이력 in 설비등록DS.보전이력
                group 보전이력 by new { 년도 = 보전이력.년도, 분기 = 보전이력.분기 } into group설비가동
                select new
                {
                    group설비가동.Key,
                    고장횟수 = group설비가동.Count(),
                    수리시간 = group설비가동.Sum(b => b.시간)
                };

  

            // var보전이력(설비등록DS.보전이력 table 정보를 년도,분기별로 groupby된 정보)를 설비등록DS.설비가동고장집계 로 left outer join한 LINQ절 
            var var설비가동정보2 =
                from 보전이력 in var보전이력
                join 설비가동고장집계 in 설비등록DS.설비가동고장집계
                    on new { 보전이력.Key.년도, 보전이력.Key.분기 } equals new { 설비가동고장집계.년도, 설비가동고장집계.분기 } into joined보전이력정보
                from joined보전이력 in joined보전이력정보.DefaultIfEmpty()
                select new
                {
                    보전이력.Key.년도,
                    보전이력.Key.분기,
                    보전이력.고장횟수,
                    보전이력.수리시간,
                    가동시간 = joined보전이력 == null ? 0 : joined보전이력.가동시간
                };

            foreach (var 설비가동정보2 in var설비가동정보2)
            {
                int 고장횟수 = 설비가동정보2.고장횟수;
                int 수리시간 = 설비가동정보2.수리시간;
            }

            FarPoint.Win.Spread.SheetView sheetView = fpSpread설비이력.ActiveSheet;
            int cnt = 0;
            foreach(var 설비가동정보2 in var설비가동정보2)
            {
                cnt++;
                sheetView.Cells["집계번호" + cnt].Value = cnt;
                sheetView.Cells["기호" + cnt].Value = "%";
                sheetView.Cells["년도" + cnt].Value = 설비가동정보2.년도;
                sheetView.Cells["분기" + cnt].Value = 설비가동정보2.분기;
                sheetView.Cells["가동시간" + cnt].Value = 설비가동정보2.가동시간;
                sheetView.Cells["고장횟수" + cnt].Value = 설비가동정보2.고장횟수;
                sheetView.Cells["수리시간" + cnt].Value = 설비가동정보2.수리시간;
                decimal 설비고장율 = 0;
                if(설비가동정보2.가동시간 > 0)
                    설비고장율 = 설비가동정보2.수리시간 / 설비가동정보2.가동시간 * 100;
                sheetView.Cells["설비고장율" + cnt].Value = 설비고장율;


            }
        }

        private int Get분기(DateTime dateTime)
        {
            switch (dateTime.Month)
            {
                case 1:
                case 2:
                case 3:
                    return 1;
                case 4:
                case 5:
                case 6:
                    return 2;
                case 7:
                case 8:
                case 9:
                    return 3;
                case 10:
                case 11:
                case 12:
                    return 4;
                default:
                    return -1;
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (this.fpSpread설비이력.ActiveSheet.RowCount < 1)
                return;

            Printer(fpSpread설비이력, "세로", 0);
        }

        public bool Printer(FpSpread fpSpread, string paperType, int rowCount)
        {
            try
            {
                FarPoint.Win.Spread.PrintInfo pi = new FarPoint.Win.Spread.PrintInfo();

                pi.Margin.Header = 15;
                pi.Margin.Bottom = 10;
                pi.Margin.Top = 70;
                pi.Margin.Left = 10;
                pi.Margin.Right = 10;
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
                //pi.RepeatColEnd = 12;
                //pi.RepeatColStart = 1;
                //pi.RepeatRowEnd = 4;
                //pi.RepeatRowStart = 1;

                //한 페이지에 출력이 가능하도록 맞춘다. 축소옵션
                pi.ZoomFactor = 0.9f;

                //정렬
                pi.Centering = FarPoint.Win.Spread.Centering.Horizontal;

                //PageNo 출력
                //pi.Footer = "/c- /p///pc -";
                pi.PrintType = FarPoint.Win.Spread.PrintType.All;

                //인쇄옵션 보기     
                pi.ShowPrintDialog = true;

                //인쇄미리보기
                pi.Preview = true;
                fpSpread설비이력.ActiveSheet.PrintInfo = pi;
                fpSpread설비이력.PrintSheet(fpSpread설비이력.ActiveSheet);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
