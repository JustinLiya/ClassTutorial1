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
        private byte sortOrder;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Speciality
        {
            get
            {
                return speciality;
            }

            set
            {
                speciality = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public decimal TotalValue
        {
            get
            {
                return _TotalValue;
            }

            set
            {
                _TotalValue = value;
            }
        }

        public clsWorksList WorksList
        {
            get
            {
                return _WorksList;
            }

            set
            {
                _WorksList = value;
            }
        }

        public clsArtistList ArtistList
        {
            get
            {
                return _ArtistList;
            }

            set
            {
                _ArtistList = value;
            }
        }

        public byte SortOrder
        {
            get
            {
                return sortOrder;
            }

            set
            {
                sortOrder = value;
            }
        }

        public clsArtist(clsArtistList prArtistList)
        {
            WorksList = new clsWorksList();
            ArtistList = prArtistList;
            EditDetails();
        }

        public void EditDetails()
        {
            artistDialog.SetDetails(this);
            if (artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TotalValue = WorksList.GetTotalValue();
            }
        }        
    }
}