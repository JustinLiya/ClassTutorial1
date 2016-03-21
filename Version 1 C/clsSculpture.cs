using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsSculpture : clsWork
    {
        private float _Weight;
        private string _Material;

        private static frmSculpture _sculptureDialog;

        public float Weight
        {
            get
            {
                return _Weight;
            }

            set
            {
                _Weight = value;
            }
        }

        public string Material
        {
            get
            {
                return _Material;
            }

            set
            {
                _Material = value;
            }
        }

        public override void EditDetails()
        {
            
            if (_sculptureDialog == null)
            {
                _sculptureDialog = new frmSculpture();
            }
            _sculptureDialog.SetDetails(this);
        
        }
    }
}
