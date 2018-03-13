using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace jodeware2.LocalDB
{
    public class Hersteller
    {
        [PrimaryKey, AutoIncrement]
        public int HerID
        {
            get;
            set;
        }

        public String Bezeichnung
        {
            get;
            set;
        }
    }
}
