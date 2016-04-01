using System;
using System.Collections.Generic;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtistList : SortedList<string, clsArtist>
    {
        private const string _FileName = "gallery11.xml";
        public void EditArtist(string prKey)
        {
            clsArtist lcArtist=this[prKey];
            if (lcArtist != null)
                lcArtist.EditDetails();
            else
                throw new Exception("Sorry no artist by this name");
        }
       
        public void NewArtist()
        {
            clsArtist lcArtist = new clsArtist(this);
            if (lcArtist.Name != "")
                Add(lcArtist.Name, lcArtist);
            
        }
        
        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsArtist lcArtist in Values)
            {
                lcTotal += lcArtist.TotalValue;
            }
            return lcTotal;
        }

        public void Save()
        {
            System.IO.FileStream lcFileStream = null;
            try
            {
                 lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
                 System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                     new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                   lcFormatter.Serialize(lcFileStream, this);
                   lcFileStream.Close();
            }
            catch (Exception e)
            {
                if (lcFileStream!=null)
                    lcFileStream.Close();
                throw new Exception(e.Message+", File Save Error");
            }
        }

        public static clsArtistList Retrieve()
        {
            clsArtistList lcArtistList;
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
                lcFileStream.Close();
            }

            catch (Exception e)
            {
                lcArtistList = new clsArtistList();
                throw new Exception(e.Message + ", File Retrieve Error");
            }

            return lcArtistList;
        }
    }
}
