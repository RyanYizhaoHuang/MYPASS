using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordApplication.Interfaces;
using PasswordApplication.AbstractClass;
using PasswordApplication.Model;
using System.Data.SqlClient;

namespace PasswordApplication
{
    /// <summary>
    /// Delete Record from User Record table, accept Entity(UserRecord,UserAccount,Category)
    /// </summary>
    class EditUserCategoryhelper : IEdit
    {
        public bool EditEntity(AbDatabaseEntity Entity)
        {
            //Initial connection maker to make a connention 
            SQLServerConnMaker SQLconn = new SQLServerConnMaker();

            //Initial UserRecord entity
            UserRecord userRecord = (UserRecord)Entity;
            
            // Delete record from UserRecordCategories table
            SqlCommand editUserCategoryCmd;
            editUserCategoryCmd = new SqlCommand("UPDATE FROM UserRecordCategories WHERE RecordID = @RecordID;", SQLconn.Connect());

            // Add the parameters for the DeleteCommand.
            editUserCategoryCmd.Parameters.AddWithValue("@RecordID", userRecord.RecordID);

            try
            {
                SQLconn.Connect().Open();
                using (editUserCategoryCmd) { editUserCategoryCmd.ExecuteNonQuery(); }
            }
            catch (Exception e)
            {
                //show error in output
                Console.WriteLine(e.ToString());
            }
            finally
            {
                SQLconn.Connect().Close();
            }

            throw new NotImplementedException();
        }
    }
}
