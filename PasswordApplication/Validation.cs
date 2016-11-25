using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace PasswordApplication
{
    /// <summary>
    /// Class Validation ensures validtion is correct.
    /// </summary>
    public class Validation
    {
        Regex regex = null;

        //intialize the variables
        private string sUserName;
        private string sPassword;
        private string sVerifyPassword;
        private string sCategory;
        private string sNote;

        //create the accessors
        public string SUserName
        {
            get { return sUserName; }
            set { this.sUserName = value; }
        }
        public string SPassword
        {
            get { return sPassword; }
            set { this.sPassword = value; }
        }
        public string SVerifyPassword
        {
            get { return sVerifyPassword; }
            set { this.sVerifyPassword = value; }
        }
        public string SCategory
        {
            get { return sCategory; }
            set { this.sCategory = value; }
        }
        public string SNote
        {
            get { return sNote; }
            set { this.sNote = value; }
        }

        //method to validate
        public bool ValidateUserName()
        {
            //string pattern allows user to enter alphabets and numbers only
            if (RegValidation(sUserName.Trim(), "^[a-z|A-Z|]+[a-z|A-Z|0-9]*") != true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //bool to validate correct pw input
        public bool ValidatePassword()
        {
            //string pattern only restrict user from entering special characters such as ‘,\\*&amp;$&lt;&gt;
            if (RegValidation(sPassword.Trim(), "^([1-zA-Z0-1@.\\s]{1,255})$") != true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //bool to verify same pw
        public bool VerifyPassword()
        {
            if (sVerifyPassword == sPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerifyCategory()
        {
            //if user does not select a category, it will return false.
            if (sCategory == "--Select One--")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool VerifyNote()
        {
            //check if user input does not have any special characters
            if (RegValidation(sNote, "^([1-zA-Z0-1@.\\s]{1,255})$") != true && sNote != "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //method to check for regex validation
        public bool RegValidation(string sInput, string sPattern)
        {
            regex = new Regex(sPattern);
            if (regex.Match(sInput).Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
