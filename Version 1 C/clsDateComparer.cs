using System;
using System.Collections.Generic;

namespace Version_1_C
{
    public sealed class clsDateComparer : IComparer<clsWork>
    {
        public static readonly clsDateComparer instance = new clsDateComparer();

        private clsDateComparer()
        {

        }

        static clsDateComparer()
        {

        }

        public static clsDateComparer Instance
        {
            get
            {
                return instance;
            }
        }

        public int Compare(clsWork x, clsWork y)
        {
            DateTime lcDateX = x.Date;
            DateTime lcDateY = y.Date;
            return lcDateX.CompareTo(lcDateY);
        }
    }
}
