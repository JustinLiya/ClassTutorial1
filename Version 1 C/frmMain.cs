using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Matthias Otto, NMIT, 2010-2016
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        private clsArtistList _ArtistList = new clsArtistList();
        
        private void updateDisplay()
        {
            string[] lcDisplayList = new string[_ArtistList.Count];

            lstArtists.DataSource = null;
            _ArtistList.Keys.CopyTo(lcDisplayList, 0);
            lstArtists.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(_ArtistList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ArtistList.NewArtist();
                throw new Exception("Artist added!");
            }
            catch(Exception ex)
            {            
                MessageBox.Show(ex.Message);
            }

            updateDisplay();
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                try {
                    _ArtistList.EditArtist(lcKey);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                updateDisplay();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            try {
                _ArtistList.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                lstArtists.ClearSelected();
                _ArtistList.Remove(lcKey);
                updateDisplay();
            }
        }
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                _ArtistList = clsArtistList.Retrieve();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            updateDisplay();
        }
    }
}