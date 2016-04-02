using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public sealed partial class frmPainting : Version_1_C.frmWork
    {
        private static readonly frmPainting instance = new frmPainting();

        static frmPainting()
        {

        }

        private frmPainting()
        {
            InitializeComponent();
        }

        public static frmPainting Instance
        {
            get
            {
                return instance;
            }
        }
       
        protected override void updateForm() {
            base.updateForm();
            clsPainting lcWork = (clsPainting)_Work;
            txtWidth.Text = lcWork.Width.ToString();
            txtHeight.Text = lcWork.Height.ToString();
            txtType.Text = lcWork.Type;
        }

        protected override void pushData() {
            base.pushData();
            clsPainting lcWork = (clsPainting)_Work;
            lcWork.Width = Single.Parse(txtWidth.Text);
            lcWork.Height = Single.Parse(txtHeight.Text);
            lcWork.Type = txtType.Text;
        }
    }
}

