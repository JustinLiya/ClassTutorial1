using System;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }
               
        private clsWorksList _WorksList;
        private byte sortOrder; // 0 = Name, 1 = Date
        private clsArtist _Artist;

        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (sortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            UpdateDisplay();
            ShowDialog();
        }
                
        private void btnDelete_Click(object sender, EventArgs e)
        {           
            if (lstWorks.SelectedIndex >= 0 && lstWorks.SelectedIndex < _WorksList.Count)
            {
                if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _WorksList.RemoveAt(lstWorks.SelectedIndex);
                }
            }
            UpdateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _WorksList.AddWork();
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                DialogResult = DialogResult.OK;
            }
            else
                throw new Exception("Artist with that name already exists!");
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
              
              if(_Artist.IsDuplicate(txtName.Text))
                {
                                      
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
               
                if (lcIndex >= 0 && lcIndex < _WorksList.Count)
                {
                    clsWork lcWork = (clsWork)_WorksList[lcIndex];
                    lcWork.EditDetails();
                }
                else
                {
                    MessageBox.Show("Sorry no work selected #" + Convert.ToString(lcIndex));
                }
                UpdateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            sortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            _WorksList = _Artist.WorksList;         
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
        }
    }
}