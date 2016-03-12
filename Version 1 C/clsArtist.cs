using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string name;
        private string speciality;
        private string phone;
        
        private decimal _TotalValue;

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;
        
        private static frmArtist artistDialog = new frmArtist();
        
        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            EditDetails();
        }
        
        public void EditDetails()
        {
            artistDialog.SetDetails(name, speciality, phone, _WorksList, _ArtistList);
            if (artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                artistDialog.GetDetails(ref name, ref speciality, ref phone);
                _TotalValue = _WorksList.GetTotalValue();
            }
        }

        public string GetKey()
        {
            return name;
        }

        public decimal GetWorksValue()
        {
            return _TotalValue;
        }
    }
}
