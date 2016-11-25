using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordApplication.Interfaces
{
    /// <summary>
    /// Make a connction to database.
    /// </summary>
    interface IDatabaseConnection
    {
         SqlConnection Connect();
    }
}
