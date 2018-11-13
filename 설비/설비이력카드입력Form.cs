using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Erp.YulChonMold.설비
{
    public partial class 설비이력카드입력Form : Form
    {
        List<Erp.BusinessLogic.설비관리.설비중요품목> 설비중요품목List { get; set; }
        List<Erp.BusinessLogic.설비관리.설비수리이력> 설비수리이력List { get; set; }
        설비등록DS.설비Row 설비row;

        private 설비이력카드입력Form()
        {
            InitializeComponent();
        }

        public 설비이력카드입력Form(설비등록DS.설비Row 설비row, 설비등록DS.중요부품Row[] 중요부품rows, 설비등록DS.보전이력Row[] 보전이력rows) : this()
        {
            this.설비row = 설비row;
            설비등록DS.설비Row new설비row = 설비등록DS1.설비.New설비Row();
            new설비row.관리코드 = 설비row.관리코드;
            new설비row.관리번호 = 설비row.관리번호;
            new설비row.관리순번 = 설비row.관리순번;
            new설비row.품명 = 설비row.품명;
            new설비row.규격 = 설비row.규격;
            new설비row.제조회사 = 설비row.제조회사;
            new설비row.구입일자 = 설비row.구입일자;
            new설비row.금액 = 설비row.금액;
            new설비row.설치장소 = 설비row.설치장소;
            new설비row.등급 = 설비row.등급;
            new설비row.관리부서 = 설비row.관리부서;
            new설비row.관리책임자 = 설비row.관리책임자;
            new설비row.수리업체 = 설비row.수리업체;
            new설비row.수리업체연락처 = 설비row.수리업체연락처;

            this.설비등록DS1.설비.Add설비Row(new설비row);
            
            foreach(설비등록DS.중요부품Row 중요부품row in 중요부품rows)
            {
                설비등록DS.중요부품Row new중요부품row = 설비등록DS1.중요부품.New중요부품Row();
                new중요부품row.관리코드 = 중요부품row.관리코드;
                new중요부품row.번호 = 중요부품row.번호;
                new중요부품row.품명 = 중요부품row.품명;
                new중요부품row.규격 = 중요부품row.규격;

                설비등록DS1.중요부품.Add중요부품Row(new중요부품row);
            }

            foreach(설비등록DS.보전이력Row 보전이력row in 보전이력rows)
            {
                설비등록DS.보전이력Row new보전이력row = 설비등록DS1.보전이력.New보전이력Row();
                new보전이력row.관리코드 = 보전이력row.관리코드;
                new보전이력row.순번 = 보전이력row.순번;
                new보전이력row.수리일자 = 보전이력row.수리일자;
                new보전이력row.고장내용 = 보전이력row.고장내용;
                new보전이력row.수리내역 = 보전이력row.수리내역;
                new보전이력row.수리부품 = 보전이력row.수리부품;
                new보전이력row.수리처 = 보전이력row.수리처;
                new보전이력row.비용 = 보전이력row.시간;
                new보전이력row.비용 = 보전이력row.시간;
                new보전이력row.확인 = 보전이력row.확인;
                new보전이력row.수리결과 = 보전이력row.수리결과;
                new보전이력row.불출일자 = 보전이력row.불출일자;
                new보전이력row.입고일자 = 보전이력row.입고일자;
                new보전이력row.년도 = 보전이력row.년도;
                new보전이력row.분기 = 보전이력row.분기;

                설비등록DS1.보전이력.Add보전이력Row(new보전이력row);
            }

            NumberFormatInfo NF = new CultureInfo("ko-KR", false).NumberFormat;

            textBox관리번호.Text = 설비row.관리번호;
            textBox설비명.Text = 설비row.품명;
            textBox형식규격.Text = 설비row.규격;
            textBox제조회사.Text = 설비row.제조회사;
            textBox구입일자.Text = 설비row.구입일자.ToString("yyyy-MM-dd");
            textBox구입금액.Text = 설비row.금액.ToString("C", NF);
            textBox설치장소.Text = 설비row.설치장소;
            textBox등급관리자.Text = 설비row.등급 + " / " + 설비row.관리책임자;

            //data가 있으면 조회
            ShowData();
            ShowPicture();
        }

        private void ShowData()
        {
            DataSet dataSet1 = Erp.BusinessManager.설비.Get중요품목(설비row.관리코드);
            설비등록DS1.중요부품.Merge(dataSet1.Tables[0]);
            DataSet dataSet2 = Erp.BusinessManager.설비.Get설비수리이력(설비row.관리코드);
            설비등록DS1.보전이력.Merge(dataSet2.Tables[0]);
        }

        private void ShowPicture()
        {
            Erp.BusinessManager.설비사진 설비사진 = Erp.BusinessManager.설비사진.GetByKey(설비row.관리코드, 1);
            if (설비사진 == null)
                return;
            if (설비사진.사진[0] == 0)
                return;
            MemoryStream memoryStream = new MemoryStream(설비사진.사진);
            this.picture사진약도.BackgroundImage = Image.FromStream(memoryStream);
        }


        private void buttonLoad_Click(object sender, EventArgs e)
        {
            FindPicture();
        }

        private void FindPicture()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(.jpg; .jpeg; .bmp; .gif; .png; .wmf)|*.jpg;*.jpeg;*.bmp;*.gif;*.png;*.wmf";
            //불러올 파일의 갯수
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.picture사진약도.BackgroundImageLayout = ImageLayout.Stretch;

                string[] fileName = openFile.FileName.Split('\\');
                int index = fileName.Length - 1;

                byte[] 사진Bytes = File.ReadAllBytes(openFile.FileName);
                MemoryStream memoryStream = new MemoryStream(사진Bytes);
                this.picture사진약도.BackgroundImage = Image.FromStream(memoryStream);

                //파일명만 보여줌
                textBox첨부파일이름.Text = fileName[index];

                //불러온 후 즉시 저장한다.
                Erp.BusinessManager.설비사진 설비사진 = Erp.BusinessManager.설비사진.GetByKey(설비row.관리코드, 1);
                if (설비사진 == null)
                {
                    Erp.BusinessManager.설비사진.Insert(설비row.관리코드, 1, 사진Bytes, textBox첨부파일이름.Text);
                }
                else
                {
                    설비사진.사진 = 사진Bytes;
                    설비사진.파일명 = textBox첨부파일이름.Text;
                    설비사진.Update();
                }
            }
        }

        private void button중요부품Add_Click(object sender, EventArgs e)
        {
            if (Exist추가행())
            {
                MessageBox.Show("추가한 행을 저장한 후에 실행하십시오.", "추가 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            설비등록DS.중요부품Row new중요부품row = 설비등록DS1.중요부품.New중요부품Row(); // row객체 생성
            new중요부품row.관리코드 = 설비row.관리코드;
            new중요부품row.품명 = "";
            new중요부품row.규격 = "";
            설비등록DS1.중요부품.Add중요부품Row(new중요부품row);

            //커서를 추가행으로 옮긴다.
            int rowIndex = 설비등록DS1.중요부품.Count - 1;
            SetActiveRow(fpSpread중요부품목록, rowIndex);
            fpSpread중요부품목록.ActiveSheet.ActiveRow.Locked = false;
            fpSpread중요부품목록.ActiveSheet.ActiveRow.BackColor = Color.White;

        }

        private bool Exist추가행()
        {
            foreach(설비등록DS.중요부품Row 중요부품row in 설비등록DS1.중요부품)
            {
                if (중요부품row.RowState == DataRowState.Added)
                    return true;
            }
            return false;
        }

        public void SetActiveRow(FarPoint.Win.Spread.FpSpread fpSpread, int rowIndex)
        {
            fpSpread.ActiveSheet.ActiveRowIndex = rowIndex;
            fpSpread.ActiveSheet.SetActiveCell(rowIndex, 0);
            //ActiveCell로 커서가 이동한 것을 화면에 보여줌
            fpSpread.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Nearest, FarPoint.Win.Spread.HorizontalPosition.Nearest);
        }

        private void button중요부품Save_Click(object sender, EventArgs e)
        {
            if (Check중요부품data() == false)
                return;

            List<Erp.BusinessLogic.설비관리.설비중요품목> 설비중요품목List = Make설비중요품목List();
            //if (설비중요품목List.Count == 0)
            //    return;

            try
            {
                Erp.BusinessLogic.Inventory.Update설비중요품목(설비중요품목List);
                MessageBox.Show("저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("설비중요품목을 저장하는 도중에 오류가 발생하였습니다. - " + ex.Message);
                return;
            }
            //저장작업을 종료 후 Rowstate를 Unchange로 변경한다.
            설비등록DS1.중요부품.AcceptChanges();
            fpSpread중요부품목록.ActiveSheet.ActiveRow.BackColor = Color.White;
        }

        private bool Check중요부품data()
        {
            foreach(설비등록DS.중요부품Row 중요부품row in 설비등록DS1.중요부품)
            {
                if (중요부품row.Is품명Null() || 중요부품row.품명 == "")
                {
                    MessageBox.Show("품명을 입력한 후에 다시 실행하십시오", 
                        "품명 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (중요부품row.Is규격Null() || 중요부품row.규격 == "")
                {
                    MessageBox.Show("규격을 입력한 후에 다시 실행하십시오",
                        "규격 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private List<Erp.BusinessLogic.설비관리.설비중요품목> Make설비중요품목List()
        {
           foreach(설비등록DS.중요부품Row 중요부품row in 설비등록DS1.중요부품)
            {
                중요부품row.EndEdit();
                if (중요부품row.RowState == DataRowState.Unchanged)
                    continue;

                this.설비중요품목List = new List<BusinessLogic.설비관리.설비중요품목>();
                Erp.BusinessLogic.설비관리.설비중요품목 new설비중요품목 = new BusinessLogic.설비관리.설비중요품목();

                new설비중요품목.관리코드 = 설비row.관리코드;
                new설비중요품목.번호 = 중요부품row.번호;
                new설비중요품목.품명 = 중요부품row.품명;
                new설비중요품목.규격 = 중요부품row.규격;
                설비중요품목List.Add(new설비중요품목);
            }
            return 설비중요품목List;
        }

        private void button중요부품Delete_Click(object sender, EventArgs e)
        {
            if (설비등록DS1.중요부품.Count == 0)
                return;
            설비등록DS.중요부품Row 중요부품row = 설비등록DS1.중요부품[fpSpread중요부품목록.ActiveSheet.ActiveRowIndex];

            //삭제를 할때는 삭제유무를 질문한 후에 실행한다.
            DialogResult result = MessageBox.Show("해당 중요부품을(를) 삭제하겠습니까? ", "중요부품 삭제유무", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // DB에 없는 정보를 삭제한다.
            if (중요부품row.RowState == DataRowState.Added)
            {
                설비등록DS1.중요부품.Remove중요부품Row(중요부품row);
                return;
            }

            // DB에 있는 정보를 삭제할 때는 try-catch를 쓴다.
            try
            {
                Erp.BusinessManager.설비중요품목.Delete(중요부품row.관리코드, 중요부품row.번호);
            } catch (Exception ex)
            {
                MessageBox.Show("중요부품 정보를 삭제하는 도중에 오류가 발생하였습니다. - " + ex.Message, "삭제 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            설비등록DS1.중요부품.Remove중요부품Row(중요부품row);
        }

        //////////// 보전이력 //////////////

        private void button보전이력Add_Click(object sender, EventArgs e)
        {
            if (Exist보전이력추가행())
            {
                MessageBox.Show("추가한 행을 저장한 후에 실행하십시오.", "추가 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            설비등록DS.보전이력Row new보전이력row = 설비등록DS1.보전이력.New보전이력Row();
            new보전이력row.관리코드 = 설비row.관리코드;
            new보전이력row.수리일자 = DateTime.Today;
            new보전이력row.고장내용 = "";
            new보전이력row.수리내역 = "";
            new보전이력row.수리부품 = "";
            new보전이력row.수리처 = "";
            new보전이력row.비용 = 0;
            new보전이력row.확인 = 0;
            new보전이력row.시간 = 0;
            new보전이력row.수리결과 = "";
            new보전이력row.불출일자 = DateTime.Today;
            new보전이력row.입고일자 = DateTime.Today;
            new보전이력row.년도 = new보전이력row.수리일자.Year;
            new보전이력row.분기 = Get분기(new보전이력row.수리일자);
            설비등록DS1.보전이력.Add보전이력Row(new보전이력row);

            int rowIndex = 설비등록DS1.보전이력.Count - 1;
            SetActiveRow(fpSpread보전이력, rowIndex);
            fpSpread보전이력.ActiveSheet.ActiveRow.Locked = false;
            fpSpread보전이력.ActiveSheet.ActiveRow.BackColor = Color.White;
        }

        private int Get분기(DateTime dateTime)
        {
            switch (dateTime.Month)
            {
                case 1: case 2: case 3:
                    return 1;
                case 4: case 5: case 6:
                    return 2;
                case 7: case 8: case 9:
                    return 3;
                case 10: case 11: case 12:
                    return 4;
                default:
                    return -1;
            }
        }

        private bool Exist보전이력추가행()
        {
            foreach (설비등록DS.보전이력Row 보전이력row in 설비등록DS1.보전이력)
            {
                if (보전이력row.RowState == DataRowState.Added)
                    return true;
            }
            return false;
        }

        private void button보전이력Save_Click(object sender, EventArgs e)
        {
            if (Check보전이력data() == false)
                return;

            List<Erp.BusinessLogic.설비관리.설비수리이력> 설비수리이력List = Make설비수리이력List();

            //if (설비수리이력List.Count == 0)
            //    return;

            try
            {
                Erp.BusinessLogic.Inventory.Update설비수리이력(설비수리이력List);
                MessageBox.Show("저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("설비수리이력을 저장하는 도중에 오류가 발생하였습니다. - " + ex.Message);
                return;
            }
            //저장작업을 종료 후 Rowstate를 Unchange로 변경한다.
            설비등록DS1.보전이력.AcceptChanges();
            fpSpread보전이력.ActiveSheet.ActiveRow.BackColor = Color.White;
        }

        private bool Check보전이력data()
        {
            foreach (설비등록DS.보전이력Row 보전이력row in 설비등록DS1.보전이력)
            {
                if (보전이력row.Is고장내용Null())
                {
                    MessageBox.Show("고장내용을 입력한 후에 다시 실행하십시오",
                        "고장내용 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (보전이력row.Is수리일자Null())
                {
                    MessageBox.Show("수리일자를 입력한 후에 다시 실행하십시오",
                        "수리일자 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (보전이력row.Is수리내역Null())
                    보전이력row.수리내역 = "";

                if (보전이력row.Is수리부품Null())
                    보전이력row.수리부품 = "";

                if (보전이력row.Is수리처Null())
                    보전이력row.수리처 = "";

                if (보전이력row.Is비용Null())
                    보전이력row.비용 = 0;

                if (보전이력row.Is시간Null())
                    보전이력row.시간 = 0;

            }
            return true;
        }

        private List<Erp.BusinessLogic.설비관리.설비수리이력> Make설비수리이력List()
        {
            foreach (설비등록DS.보전이력Row 보전이력row in 설비등록DS1.보전이력)
            {
                //수행중인 편집을 끝낸다.
                보전이력row.EndEdit();
                if (보전이력row.RowState == DataRowState.Unchanged)
                    continue;

                this.설비수리이력List = new List<Erp.BusinessLogic.설비관리.설비수리이력>();
                Erp.BusinessLogic.설비관리.설비수리이력 new설비수리이력 = new BusinessLogic.설비관리.설비수리이력();

                new설비수리이력.관리코드 = 보전이력row.관리코드;
                new설비수리이력.순번 = 보전이력row.순번;
                new설비수리이력.수리일자 = 보전이력row.수리일자;
                new설비수리이력.고장내용 = 보전이력row.고장내용;
                new설비수리이력.수리내역 = 보전이력row.수리내역;
                new설비수리이력.수리부품 = 보전이력row.수리부품;
                new설비수리이력.수리처 = 보전이력row.수리처;
                new설비수리이력.비용 = 보전이력row.비용;
                new설비수리이력.시간 = 보전이력row.시간;
                new설비수리이력.확인 = 보전이력row.확인;
                new설비수리이력.수리결과 = 보전이력row.수리결과;
                new설비수리이력.불출일자 = 보전이력row.불출일자;
                new설비수리이력.입고일자 = 보전이력row.입고일자;
                설비수리이력List.Add(new설비수리이력);
            }
            return 설비수리이력List;
        }

        private void button보전이력Delete_Click(object sender, EventArgs e)
        {
            if (설비등록DS1.보전이력.Count == 0)
                return;
            설비등록DS.보전이력Row 보전이력row = 설비등록DS1.보전이력[fpSpread보전이력.ActiveSheet.ActiveRowIndex];

            //삭제를 할때는 삭제유무를 질문한 후에 실행한다.
            DialogResult result = MessageBox.Show("해당 보전이력을(를) 삭제하겠습니까? ", "보전이력 삭제유무", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            //DB에 없는 정보를 삭제한다.
            if (보전이력row.RowState == DataRowState.Added)
            {
                설비등록DS1.보전이력.Remove보전이력Row(보전이력row);
                return;
            }

            //DB에 있는 정보를 삭제할 때는 try-catch를 쓴다.
            try
            {
                Erp.BusinessManager.설비수리이력.Delete(보전이력row.관리코드, 보전이력row.순번);
            }
            catch (Exception ex)
            {
                MessageBox.Show("보전이력 정보를 삭제하는 도중에 오류가 발생하였습니다. - " + ex.Message, "삭제 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            설비등록DS1.보전이력.Remove보전이력Row(보전이력row);
        }
    }
}
