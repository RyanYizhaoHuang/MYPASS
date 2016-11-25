using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordApplication.AbstractClass;

namespace PasswordApplication.Model
{
    /// <summary>
    /// Represent one record from UserRecordCategory table
    /// </summary>
    class UserRecordCategory : AbDatabaseEntity
    {
        //RecordID in table
        public int RecordID { get; set; }

        //CategoryID in table
        public int CategoryID { get; set; }
    }
}
