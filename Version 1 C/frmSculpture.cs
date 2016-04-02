using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public sealed partial class frmSculpture : Version_1_C.frmWork
    {
        private static readonly frmSculpture instance = new frmSculpture();
        private frmSculpture()
        {
            InitializeComponent();
        }

        static frmSculpture()
        {

        }

        public static frmSculpture Instance
        {
            get
            {
                return instance;
            }
        }
                
        protected override void updateForm()
        {
            base.updateForm();
            clsSculpture lcWork = (clsSculpture)_Work;
            txtWeight.Text = lcWork.Weight.ToString();
            txtMaterial.Text = lcWork.Material;
        }

        protected override void pushData()
        {
            base.pushData();
            clsSculpture lcWork = (clsSculpture)_Work;
            lcWork.Weight = Single.Parse(txtWeight.Text);
            lcWork.Material = txtMaterial.Text;
        }

    }
}

