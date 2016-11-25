using PasswordApplication.AbstractClass;
using PasswordApplication.Helper;
using PasswordApplication.Interfaces;
using PasswordApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordApplication.Controller
{
    /// <summary>
    /// Delete category name from the tree view, delete record from UserRecordCategory table and Categories table
    /// </summary>
    class DeleteCategoryController
    {
        // view is a window form object,used to call back view method to update itself.
        Form view;
        //entity can be any table in db, such as UserRecord,Categories,UserRecordCategories, 
        //used to grab info(ie. userRecordID) from view what user want to manupulate.
        AbDatabaseEntity entity;
        // Two deleteUserRecord and deleteUserCategory helper class, used to call the helper class to do db stuff(ie. delete,save,insert).
        IDelete deleteHelper;

        //Constructor
        public DeleteCategoryController(Form _view, AbDatabaseEntity _entity)
        {
            this.view = _view;
            this.entity = _entity;
        }

        public bool DeleteCategory()
        {
            //Check if record in Record table,UserRecordCategory is deleted.
            bool isCategoryDeleted;
            bool isUserCategoryDeleted;
            bool isDeleted = false;

            DialogResult result;
            //Confirm if user wants to delete the record
            result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result.Equals(DialogResult.OK))
            {
                //Call DeleteUserCategory and DeleteCategory hepler classes
                //Remove category name from Categories table
                //Remove the dependancy from userRecordCategory table first                  
                deleteHelper = new DeleteUserCategoryhelper();
                isUserCategoryDeleted = deleteHelper.DeleteEntity(((UserRecordCategory)entity));  // Cast entity to UserRecord 
                deleteHelper = new DeleteCategoryhelper();
                isCategoryDeleted = deleteHelper.DeleteEntity(((UserRecordCategory)entity));  // Cast entity to UserRecord
                if (isUserCategoryDeleted && isCategoryDeleted)
                {
                    MessageBox.Show("The record has been deleted.");
                    // display the result,cast view to MainForm and call MainForm update the Datagrid.
                    ((MainForm)view).DisplayUserRecordDataGrid();
                    isDeleted = true;
                }
                else
                {
                    MessageBox.Show("Something wrong.");
                    isDeleted = false;
                }
            }
            return isDeleted;
        }
    }
}
