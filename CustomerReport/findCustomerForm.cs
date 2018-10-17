using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erp.CodeViewer
{
    public partial class findCustomerForm : Form
    {
        public string customerCode;
        public string customerName;

        public int OrderLeadTime = 0;

        public findCustomerForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init() //
        {
            fpSpread1.ActiveSheet.AutoFilterMode = FarPoint.Win.Spread.AutoFilterMode.EnhancedContextMenu;

            ShowData();
        }

        private void ShowData() //
        {
            this.customerDS.customer2.Clear();
            DataSet dataSet = Erp.BusinessManager.Customer.GetCodeName();
            this.customerDS.customer2.Merge(dataSet.Tables[0]);
            this.customerDS.customer2.AcceptChanges();

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            ShowDataByTextBox(textBox1.Text);
        }

        private void ShowDataByTextBox(string customerCode)
        {
            this.customerDS.customer2.Clear();
            DataSet dataSet = Erp.BusinessManager.Customer.GetFindByCustomerCode(textBox1.Text);
            if(dataSet.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("조회된 검색결과가 없습니다.", "검색결과", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.customerDS.customer2.Merge(dataSet.Tables[0]);
            this.customerDS.customer2.AcceptChanges();

        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            int row = this.fpSpread1.ActiveSheet.ActiveRowIndex;

            int cnt = this.fpSpread1.ActiveSheet.RowCount;

            if (cnt < 1)
            {
                return;
            }

            this.customerCode = fpSpread1.ActiveSheet.Cells[row, 0].Text;
            this.customerName = fpSpread1.ActiveSheet.Cells[row, 1].Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void CancleBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ShowDataByTextBox(textBox1.Text); 
            }
        }

        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            OkBtn.PerformClick();
        }
    }
}
