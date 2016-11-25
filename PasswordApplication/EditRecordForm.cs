using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordApplication
{
    public partial class EditRecordForm : Form
    {   //instantiate objs
        DatabaseHelper updateDH = new DatabaseHelper();

        //intialize variables
        private int selectedRecordID;
        private string selectedCategory;
        private string selectedUserName;
        private string selectedPassword;
        private string selectedNote;
        //set the accessors
        public int GrabRecordID
        {
            get { return selectedRecordID; }
            set { selectedRecordID = value; }
        }
        public string EditUserName
        {
            get { return selectedUserName; }
            set { selectedUserName = value; }
        }
        public string EditCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; }
        }
        public string EditPassword
        {
            get { return selectedPassword; }
            set { selectedPassword = value; }
        }
        public string EditNote
        {
            get { return selectedNote; }
            set { selectedNote = value; }
        }
        public EditRecordForm()
        {
            InitializeComponent();
        }

        private void EditRecordForm_Load(object sender, EventArgs e)
        {
            //on form load, display information from view record form in editable textboxes.
            UserNameTextBox.Text = EditUserName;
            PasswordTextBox.Text = EditPassword;
            CategoryOptionComboBox.Text = EditCategory;
            NoteTextBox.Text = EditNote;
        }
        private bool ValidatingEditRecord()
        {
            //instantiating objects
            Validation userName = new Validation();
            Validation password = new Validation();
            Validation verifyPassword = new Validation();
            Validation verifyCategory = new Validation();
            Validation verifyNote = new Validation();
            userName.SUserName = UserNameTextBox.Text;
            password.SPassword = PasswordTextBox.Text;
            verifyPassword.SVerifyPassword = VerifyPasswordTextBox.Text;
            verifyPassword.SPassword = PasswordTextBox.Text;
            verifyCategory.SCategory = CategoryOptionComboBox.Text;
            verifyNote.SNote = NoteTextBox.Text;

            //if wrong validation, show error message
            while (true)
            {
                if (!userName.ValidateUserName())
                {
                    errorProvider.SetError(UserNameTextBox, "Please enter username in alphabers and numbers only");
                    return false;
                }
                else
                {
                    errorProvider.SetError(UserNameTextBox, "");
                }
                if (!password.ValidatePassword())
                {
                    errorProvider.SetError(PasswordTextBox, "The password cannot contain any of the following: ‘,\\*&amp;$&lt;&gt;");
                    return false;
                }
                else
                {
                    errorProvider.SetError(PasswordTextBox, "");
                }
                if (!verifyPassword.VerifyPassword())
                {
                    errorProvider.SetError(VerifyPasswordTextBox, "The passwords do not match.Please enter them again.");
                    return false;
                }
                else
                {
                    errorProvider.SetError(VerifyPasswordTextBox, "");

                }
                if (!verifyCategory.VerifyCategory())
                {
                    errorProvider.SetError(CategoryOptionComboBox, "Please select a category");
                    return false;
                }
                else
                {
                    errorProvider.SetError(CategoryOptionComboBox, "");
                }
                if (!verifyNote.VerifyNote())
                {
                    errorProvider.SetError(NoteTextBox, "Please don't put in any of the following characters ‘,\\*&amp;$&lt;&gt;");
                    return false;
                }
                else
                {
                    errorProvider.SetError(NoteTextBox, "");
                    return true;
                }
            }
        }



        private void ShowPasswordChkBox_CheckedChanged(object sender, EventArgs e)
        {
            //check if user check to show password or not and display/no display.
            if (ShowPasswordChkBox.Checked == true)
            {
                PasswordTextBox.PasswordChar = '\0';
                VerifyPasswordTextBox.PasswordChar = '\0';
            }
            else
            {
                PasswordTextBox.PasswordChar = '*';
                VerifyPasswordTextBox.PasswordChar = '*';

            }
        }

        private void SaveNewRecordButton_Click(object sender, EventArgs e)
        {
            if (ValidatingEditRecord() == true)
            {
                //set info to database helper to update db
                updateDH.PassUserName = UserNameTextBox.Text;
                updateDH.PassPassword = PasswordTextBox.Text;
                updateDH.PassNote = NoteTextBox.Text;
                updateDH.PassRecordID = selectedRecordID;
                //not sure if we pass the string value to db or not
                //updateDH.PassCategory = CategoryOptionComboBox.SelectedText.ToString();
                updateDH.UpdateRecord();
                MessageBox.Show("Record has been updated.");
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();

            }
            else
            {
                MessageBox.Show("Please enter the correct information before sending.");
                return;
            }

            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();

        }
    }
}
