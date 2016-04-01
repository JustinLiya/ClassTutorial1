using System;
using System.Collections.Generic;

namespace Version_1_C
{
    public sealed class clsNameComparer : IComparer<clsWork>
    {
        private static readonly clsNameComparer instance = new clsNameComparer();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static clsNameComparer()
        {
        }

        private clsNameComparer()
        {
        }

        public static clsNameComparer Instance
        {
            get
            {
                return instance;
            }
        }

        public int Compare(clsWork x, clsWork y)
        {
            string lcNameX = x.Name;
            string lcNameY = y.Name;
            return lcNameX.CompareTo(lcNameY);
        }
    }
}
