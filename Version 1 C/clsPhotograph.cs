using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        private float theWidth;
        private float theHeight;
        private string theType;

        private static frmPhotograph photographDialog;

        public override void EditDetails()
        {
            if (photographDialog == null)
            {
                photographDialog = new frmPhotograph();
            }
            photographDialog.SetDetails(_Name, theDate, theValue, theWidth, theHeight, theType);
            if (photographDialog.ShowDialog() == DialogResult.OK)
            {
                photographDialog.GetDetails(ref _Name, ref theDate, ref theValue, ref theWidth, ref theHeight, ref theType);
            }
        }
    }
}
