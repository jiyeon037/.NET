using Erp.BusinessManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erp.BasicEditorYulChon.Location
{
    public partial class findLocationForm : Form
    {
        public int locationNo;
        public string locationName;

        public findLocationForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            fpSpread1.ActiveSheet.AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

            ShowData();

        }

        private void ShowData()
        {
            this.findLocationDS.FindLocation.Clear();
            DataSet dataSet = Erp.BusinessManager.Location.GetLocationName(); ////
            this.findLocationDS.FindLocation.Merge(dataSet.Tables[0]);
            this.findLocationDS.FindLocation.AcceptChanges();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
           ShowDataByTextBox(Convert.ToInt32(textBox1.Text));
        }

        private void ShowDataByTextBox(int locationNo)
        {
            this.findLocationDS.FindLocation.Clear();
            DataSet dataSet = Erp.BusinessManager.Location.GetLocationFromNo(Convert.ToInt32(textBox1.Text)); //매개변수줘야함
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("조회된 검색결과가 없습니다.", "검색 결과", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.findLocationDS.FindLocation.Merge(dataSet.Tables[0]);
            this.findLocationDS.FindLocation.AcceptChanges();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            int row = this.fpSpread1.ActiveSheet.ActiveRowIndex;
            int cnt = this.fpSpread1.ActiveSheet.RowCount;

            if (cnt < 1)
            {
                return;
            }

            int x;

            // this.locationNo = fpSpread1.ActiveSheet.Cells[row, 0].Text;
            Int32.TryParse(fpSpread1.ActiveSheet.Cells[row, 0].Text, out x);

            this.locationNo = x;
            this.locationName = fpSpread1.ActiveSheet.Cells[row, 1].Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int x;
                Int32.TryParse(textBox1.Text, out x);


                ShowDataByTextBox(x);
            }
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OKBtn.PerformClick();
        }

        private void fpSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }
    }
}
