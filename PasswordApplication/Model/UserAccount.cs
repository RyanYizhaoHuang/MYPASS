using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordApplication.AbstractClass;

namespace PasswordApplication.Model
{
    /// <summary>
    /// Represent one userAccount record from UserAccount table
    /// </summary>
    class UserAccount:AbDatabaseEntity
    {
        //UserAccountID in UserAccount table
        public int UserAccountID { get; set; }

        //Name in UserAccount table
        public string Name { get; set; }

        //Password in UserAccount table
        public string Password { get; set; }

        //SecurityType in UserAccount table
        private int securityType;
        public int SecurityType
        {
            get { return securityType; }
            set
            {
                if (value != 0 && value != 1)
                    value = 0;
            }
         }

        //SecurityAnswer in UserAccount table
        public string SecurityAns { get; set; }

        //KPI in UserAccount table
        public string KPI { get; set; }
    }
}
