using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Erp.BusinessLogic.설비관리;

namespace Erp.YulChonMold.설비
{
    public partial class 설비등록Control : UserControl
    {
        byte[] vs = { 0 };
        public 설비등록Control()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            // 필터 등록
            fpSpread설비등록.ActiveSheet.Columns[0, 12].AllowAutoFilter = true; // 범위지정시는 [x, y]로
            fpSpread설비등록.Sheets[0].AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

            // 시작할 때 전체 data 조회
            ShowData();
            string[] 등급str = { "A", "B", "C" };

            // 등급에 COMBOBOX 코딩 넣기
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType = MakeComboBoxCellType(등급str, 등급str);
            int 등급col = FindColumnIndex("등급");
            fpSpread설비등록.ActiveSheet.Columns[등급col].CellType = comboBoxCellType;
        }

        /// <summary>
        /// 전체 data 조회
        /// </summary>
        private void ShowData()
        {
            DataSet dataSet = BusinessManager.설비.Get설비정보();
            설비등록DS.설비.Merge(dataSet.Tables[0]);
         }

        private void 설비등록_Load(object sender, EventArgs e)
        {

        }

        private void button이력카드등록_Click(object sender, EventArgs e)
        {
            if (설비등록DS.설비.Count == 0)
                return;
            설비등록DS.설비Row 설비row = 설비등록DS.설비[fpSpread설비등록.ActiveSheet.ActiveRowIndex];

            if(설비row.RowState == DataRowState.Added)
            {
                MessageBox.Show("입력한 설비 정보를 저장 후에 다시 실행하십시오.", "설비 정보 미저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            설비이력카드입력Form 설비이력카드입력form = new 설비이력카드입력Form(설비row, 설비row.Get중요부품Rows(), 설비row.Get보전이력Rows());
            //대기중일때 커서 모양 바꾸기
            this.Cursor = Cursors.WaitCursor;
            DialogResult result = 설비이력카드입력form.ShowDialog();

            //완료하면 다시 커서 모양 바꾸기
            this.Cursor = Cursors.Default;

            if (result == DialogResult.Cancel)
                return;
        }
        /// <summary>
        /// 관리번호의 Max관리순번을 구한다.
        /// </summary>
        /// <param name="관리번호"></param>
        /// <returns></returns>
        private int GetNext관리순번(string 관리번호)
        {
            var max관리순번 =
                (from 설비data in 설비등록DS.설비
                 where 설비data.관리번호 == 관리번호
                 select 설비data).Max(설비data => 설비data.관리순번);

            return max관리순번 + 1;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // 추가 행을 연속적으로 두 번 이상 입력 할 수 없도록 이미 행이 추가되어 있는지를 묻는다.
            if (Exist추가행())
            {
                MessageBox.Show("추가한 행을 저장한 후에 실행하십시오.", "추가 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // 비어있는 행 추가
            설비등록DS.설비Row new설비row = 설비등록DS.설비.New설비Row(); // 객체 생성 메소드
            new설비row.관리코드 = "";
            new설비row.관리번호 = "";
            new설비row.품명 = null;
            new설비row.규격 = null;
            new설비row.제조회사 = "";
//             new설비row.구입일자 = ;
            new설비row.금액 = 0;
            new설비row.설치장소 = "";
            new설비row.등급 = "";
            new설비row.관리부서 = "";
            new설비row.관리책임자 = "";
            new설비row.수리업체 = "";
            new설비row.수리업체연락처 = "";
            new설비row.관리순번 = 0;
            new설비row.설비종류 = 1; // 1 : 설비
          
            // 새로운 행을 추가한다
            설비등록DS.설비.Add설비Row(new설비row);
            // 추가된 행에 커서를 옮긴다
            int rowindex = fpSpread설비등록.ActiveSheet.RowCount - 1;
            SetActiveRow(fpSpread설비등록, rowindex);
            // 추가 시 관리번호를 입력받기 위해 속성을 바꿔준다.
            fpSpread설비등록.ActiveSheet.Cells[rowindex, 1].Locked = false;
            fpSpread설비등록.ActiveSheet.Cells[rowindex, 1].BackColor = Color.White;
        }

        private bool Exist추가행()
        {
            foreach (설비등록DS.설비Row 설비row in 설비등록DS.설비)
            {
                if (설비row.RowState == DataRowState.Added)
                    return true;
            }
            return false;
        }
       
        /// <summary>
        /// 지정된 rowIndex에 커서를 이동시킨다.
        /// </summary>
        /// <param name="fpSpread"></param>
        /// <param name="rowIndex"></param>
        public void SetActiveRow(FarPoint.Win.Spread.FpSpread fpSpread, int rowIndex)
        {
            fpSpread.ActiveSheet.ActiveRowIndex = rowIndex;
            fpSpread.ActiveSheet.SetActiveCell(rowIndex, 0);
            //ActiveCell로 커서가 이동한 것을 화면에 보여줌
            fpSpread.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Nearest, FarPoint.Win.Spread.HorizontalPosition.Nearest);
        }

        /// <summary>
        /// 관리번호를 입력한 후(EditModeOff)에 관리코드를 생성한다
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_EditModeOff(object sender, EventArgs e)
        {
            // 편집한 셀의 컬럼 인덱스를 구한다
            int colindex = fpSpread설비등록_Sheet1.ActiveColumnIndex;
            if (colindex == 1)
            {
                // 설비등록DS의 설비table의 row객체는 배열 순서로 저장되어 있다.
                // 그러므로 현재 선택된 행의 설비Row를 구하는 방법은 ActiveRowIdex 순서에 있는 행을 가져온다.
                설비등록DS.설비Row 설비row = 설비등록DS.설비[fpSpread설비등록.ActiveSheet.ActiveRowIndex];
                //관리번호

                if (설비row.Is관리번호Null())
                    return;

                설비row.관리순번 = 0;
                // 입력된 관리번호를 이용하여 다음 관리순번을 구한다.  
                설비row.관리순번 = GetNext관리순번(설비row.관리번호);
                설비row.관리코드 = 설비row.관리번호 + "-" + 설비row.관리순번;

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Check설비data() == false)
                return;

            List<Erp.BusinessLogic.설비관리.설비> 설비List = Make설비List();
            if (설비List.Count == 0)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                Erp.BusinessLogic.Inventory.Update설비(설비List);
                Cursor = Cursors.Default;
                MessageBox.Show("저장이 완료되었습니다.", "설비 정보 저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("설비 정보를 저장하는 도중에 오류가 발생하였습니다. - " + ex.Message,
                    "설비 정보 저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //작업이 끝난 후에는 rowstate를 unchange로 변경
            설비등록DS.설비.AcceptChanges();

            //관리번호 셀의 입력을 막고 배경색을 변경
            for(int row = 0; row < fpSpread설비등록.ActiveSheet.RowCount; row++)
            {
                fpSpread설비등록.ActiveSheet.Cells[row, 1].Locked = true;
                fpSpread설비등록.ActiveSheet.Cells[row, 1].BackColor = Color.LightYellow;
            }
        }

        private List<BusinessLogic.설비관리.설비> Make설비List()
        {
            List<Erp.BusinessLogic.설비관리.설비> 설비List = new List<BusinessLogic.설비관리.설비>();
            foreach(설비등록DS.설비Row 설비row in 설비등록DS.설비)
            {
                설비row.EndEdit(); // 쓰는거 종료
                if (설비row.RowState == DataRowState.Unchanged)
                    continue;
                Erp.BusinessLogic.설비관리.설비 new설비 = new BusinessLogic.설비관리.설비();
                new설비.관리코드 = 설비row.관리코드;
                new설비.관리번호 = 설비row.관리번호;
                new설비.관리순번 = 설비row.관리순번;
                new설비.설비종류 = 1;
                new설비.품명 = 설비row.품명;
                new설비.규격 = 설비row.규격;
                new설비.제조회사 = 설비row.제조회사;
                new설비.구입일자 = 설비row.구입일자;
                new설비.금액 = 설비row.금액;
                new설비.설치장소 = 설비row.설치장소;
                new설비.등급 = 설비row.등급;
                new설비.관리부서 = 설비row.관리부서;
                new설비.관리책임자 = 설비row.관리책임자;
                new설비.가동상황 = "";
                new설비.검교정대상 = "";
                new설비.검교정주기 = "";
                new설비.검교정일자 = null;
                new설비.차기검교정일자 = null;
                new설비.검교정비고 = "";
                new설비.수리업체 = 설비row.수리업체;
                new설비.수리업체연락처 = 설비row.수리업체연락처;
                new설비.폐기판정 = 0;
                new설비.폐기일자 = null;
                new설비.폐기사유 = "";
                new설비.제원 = "";
                new설비.사진 = vs;
                new설비.파일명 = "";

                설비List.Add(new설비);
            }
            return 설비List;
        }

        private bool Check설비data()
        {
            foreach(설비등록DS.설비Row 설비row in 설비등록DS.설비)
            {
                if (설비row.Is관리번호Null())
                {
                    MessageBox.Show("해당 행의 관리번호를 입력한 후에 다시 실행하십시오",
                        "관리번호 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (설비row.Is품명Null())
                {
                    MessageBox.Show("관리코드[ "+설비row.관리코드+"]의 품명을 입력한 후에 다시 실행하십시오",
                        "설비명 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } // 등급 A,B,C 만드는거 COMBOBOX

                if (설비row.Is구입일자Null())
                {
                    MessageBox.Show("관리코드[ " + 설비row.관리코드 + "]의 구입일자를 입력한 후에 다시 실행하십시오",
                        "구입일자 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (설비row.Is규격Null())
                {
                    MessageBox.Show("관리코드[ " + 설비row.관리코드 + "]의 규격을 입력한 후에 다시 실행하십시오",
                        "규격 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (설비row.Is제조회사Null())
                {
                    설비row.제조회사 = "";
                }

                if (설비row.Is금액Null())
                {
                    설비row.금액 = 0;
                }

                if (설비row.Is설치장소Null())
                {
                    설비row.설치장소 = "";
                }

                if (설비row.Is관리부서Null())
                {
                    설비row.관리부서 = "";
                }

                if (설비row.Is관리책임자Null())
                {
                    설비row.관리책임자 = "";
                }

                if (설비row.Is수리업체Null())
                {
                    설비row.수리업체 = "";
                }

                if (설비row.Is수리업체연락처Null())
                {
                    설비row.수리업체연락처 = "";
                }
            }
            return true;
        }

        /// <summary>
        /// Sheet Column에 Binding된 DataField를 찾아 ColumnIndex를 리턴한다.
        /// </summary>
        /// <param name="dataField"></param>
        /// <returns></returns>
        private int FindColumnIndex(string dataField)
        {
            foreach(FarPoint.Win.Spread.Column column in fpSpread설비등록.ActiveSheet.Columns)
            {
                if(column.DataField == dataField)
                {
                    return column.Index;
                }
            }
            return -1;
        }

        /// <summary>
        /// cell에 지정한 combobox에 값을 넣어준다.
        /// </summary>
        /// <param name="comboItems"></param>
        /// <param name="comboItemData"></param>
        /// <returns></returns>
        private FarPoint.Win.Spread.CellType.ComboBoxCellType MakeComboBoxCellType(string[] comboItems, string[] comboItemData)
        {
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            comboBoxCellType.Items = comboItems;
            comboBoxCellType.ItemData = comboItemData;
            comboBoxCellType.MaxDrop = 20; // default 8을 늘림
            comboBoxCellType.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
            // 이 부분이 빠지면 안됨
            // comboBoxCellType.Editable = true; // 이러면 combobox에 입력이 가능해진다
            return comboBoxCellType;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (설비등록DS.설비.Count == 0)
                return;
            설비등록DS.설비Row 설비row = 설비등록DS.설비[fpSpread설비등록.ActiveSheet.ActiveRowIndex];

            DialogResult dialogResult = MessageBox.Show("관리코드(" + 설비row.관리코드 + ") 정보를 삭제하겠습니까?", "관리코드 삭제 유무",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
                return;

            // DS만 삭제
            if (설비row.RowState == DataRowState.Added)
            {
                설비등록DS.설비.Remove설비Row(설비row);
                return;
            }

            // DB정보도 삭제 (try-catch 사용)
            try
            {
                // 설비 table 정보를 삭제하려면 설비와 관련된 child 테이블(설비가동, 설비사진, 설비수리이력, 설비중요품목) 정보를 삭제한 후에 실행한다.
                Erp.BusinessManager.설비.Delete설비(설비row.관리코드);
                // BusinessMgr에 만들어져 있는 함수. Delete(기본키);
            } catch (Exception ex)
            {
                MessageBox.Show("설비 정보 삭제하는 도중에 오류가 발생하였습니다. - " + ex.Message, "삭제 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            설비등록DS.설비.Remove설비Row(설비row);
            // DS에 있는 함수
        }

        private void button이력카드인쇄_Click(object sender, EventArgs e)
        {
            if (설비등록DS.설비.Count == 0)
                return;
            설비등록DS.설비Row 설비row = 설비등록DS.설비[fpSpread설비등록.ActiveSheet.ActiveRowIndex];
            if (설비row.RowState == DataRowState.Added)
            {
                MessageBox.Show("입력한 설비 정보를 저장 후에 다시 실행하십시오.", "설비 정보 미저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            설비이력카드인쇄Form 설비이력카드인쇄form = new 설비이력카드인쇄Form(설비row.관리코드);

            //대기중일때 커서 모양 바꾸기
            this.Cursor = Cursors.WaitCursor;
            DialogResult result = 설비이력카드인쇄form.ShowDialog();

            //완료하면 다시 커서 모양 바꾸기
            this.Cursor = Cursors.Default;

            if (result == DialogResult.Cancel)
                return;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            설비등록대장인쇄Form 설비등록대장인쇄form = new 설비등록대장인쇄Form();

            //대기중일때 커서 모양 바꾸기
            this.Cursor = Cursors.WaitCursor;
            DialogResult result = 설비등록대장인쇄form.ShowDialog();

            //완료하면 다시 커서 모양 바꾸기
            this.Cursor = Cursors.Default;

            if (result == DialogResult.Cancel)
                return;
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (this.Parent is Form)
            {
                ((Form)this.Parent).Close();
            }
            else if (this.Parent.Parent is Form)
            {
                ((Form)this.Parent.Parent).Close();
            }
        }
    }
}
