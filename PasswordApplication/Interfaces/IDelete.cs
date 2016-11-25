using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordApplication.AbstractClass;

namespace PasswordApplication.Interfaces
{
    /// <summary>
    /// Delete User Record,Category,User Account from Database
    /// Return bool value if the deletion is success.
    /// Any class implement IDelete can delete any kind of databaseEntity
    /// Ex. class DeleteUserRecordhelper : IDelete
    ///     {
    ///         DeleteEntity(UserRecord);
    ///     }
    ///     class DeleteCategoryHelper : IDelete
    ///     {
    ///         DeleteEntity(Category);
    ///     }
    /// </summary>
    interface IDelete
    {
            //DatabaseEntity can be UserRecord,Category,UserAccount
            bool DeleteEntity(AbDatabaseEntity Entity);
    }
}
