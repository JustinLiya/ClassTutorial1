using System;
using System.Collections.Generic;

namespace Version_1_C
{
    [Serializable()] 
    public class clsWorksList : List<clsWork>
    {
        public byte _SortOrder;

        public byte SortOrder
        {
            get
            {
                return _SortOrder;
            }

            set
            {
                _SortOrder = value;
            }
        }

        public void AddWork()
        {
            clsWork lcWork = clsWork.NewWork();
            if (lcWork != null)
            {
                Add(lcWork);
            }
        }
        
        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsWork lcWork in this)
            {
                lcTotal += lcWork.Value;
            }
            return lcTotal;
        }

         public void SortByName()
         {
             Sort(clsNameComparer.Instance);
         }
    
        public void SortByDate()
        {
            Sort(clsDateComparer.Instance);
        }
    }
}
