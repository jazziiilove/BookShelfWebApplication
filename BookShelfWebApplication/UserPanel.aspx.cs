/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Project name: .BookShelfWeb
 * File name: UserPanel.aspx.cs
 * Status: Finished
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShelf.BusinessLogic;
using BookShelfWeb.BookShelfModel;

namespace BookShelfWeb
{
    /// <summary>
    /// Behind code for UserPanel.aspx
    /// </summary>
    public partial class UserPanel1 : System.Web.UI.Page
    {
        #region methods

        /// <summary>
        /// Page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Page PreRenderer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            InsertButton.Attributes.Add("onmouseup", "ShowModalDialog();");
            UpdateButton.Attributes.Add("onmouseup", "ShowModalDialog();");
            DeleteButton.Attributes.Add("onmouseup", "ShowModalDialog();");
        }

        /// <summary>
        /// Clear inputs server side approach
        /// </summary>
        /// <param name="ctrls">control collection</param>
        void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;

                ClearInputs(ctrl.Controls);
            }
        }

        /// <summary>
        /// Insert button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InsertButton_Click(object sender, EventArgs e)
        {
            //variables to grab user input
            string untb = this.UserNameTextBox.Text;
            string ptb = this.PasswordTextBox.Text;
            string vptb = this.VerifyPasswordTextBox.Text;
            string eatb = this.EmailAddressTextBox.Text;
            string atb = this.AddressTextBox.Text;
            string ctb = this.CityTextBox.Text;

            //BookShelfUserManagerBLL to add BookShelfUser
            BookShelfUserManagerBLL bookShelfUserManagerBLL = new BookShelfUserManagerBLL();
            BookShelfUser user = new BookShelfUser();

            user.FullName = untb;
            user.Password = ptb;
            string verify = vptb;
            user.Email = eatb;
            user.Address = atb;
            user.City = ctb;

            bookShelfUserManagerBLL.AddUser(user);

            //If true, clear the inputs and make hidden label visible
            if (IsPostBack)
            {
                HiddenLabel.Text = "";
                ClearInputs(Page.Controls);
                HiddenLabel.Visible = true;
                HiddenLabel.Text += "User is inserted successfully!";
                UserGridView.DataBind();
            }
        }

        /// <summary>
        /// Update button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            //variables to grab user input
            string uitb = this.UserIDTextBox.Text;
            string untb = this.UserNameTextBox.Text;
            string ptb = this.PasswordTextBox.Text;
            string vptb = this.VerifyPasswordTextBox.Text;
            string eatb = this.EmailAddressTextBox.Text;
            string atb = this.AddressTextBox.Text;
            string ctb = this.CityTextBox.Text;

            //BookShelfUserManagerBLL to update BookShelfUser
            BookShelfUserManagerBLL bookShelfUserManagerBLL = new BookShelfUserManagerBLL();
            BookShelfUser user = new BookShelfUser();

            user.UserID = Int32.Parse(uitb);
            user.FullName = untb;
            user.Password = ptb;
            string verify = vptb;
            user.Email = eatb;
            user.Address = atb;
            user.City = ctb;

            bookShelfUserManagerBLL.UpdateUser(user);

            //If true, clear the inputs and make hidden label visible
            if (IsPostBack)
            {
                HiddenLabel.Text = "";
                ClearInputs(Page.Controls);
                HiddenLabel.Visible = true;
                HiddenLabel.Text += "User is updated successfully!";
                UserGridView.DataBind();
            }
        }

        /// <summary>
        /// Delete button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            //variables to grab user input
            string uitb = this.UserIDTextBox.Text;
            string untb = this.UserNameTextBox.Text;

            //BookShelfUserManagerBLL to delete BookShelfUser
            BookShelfUserManagerBLL bookShelfUserManagerBLL = new BookShelfUserManagerBLL();

            bookShelfUserManagerBLL.DeleteUser(Int32.Parse(uitb));

            //If true, clear the inputs and make hidden label visible
            if (IsPostBack)
            {
                HiddenLabel.Text = "";
                ClearInputs(Page.Controls);
                HiddenLabel.Visible = true;
                HiddenLabel.Text += "User is deleted successfully!";
                UserGridView.DataBind();
            }
        }

        /// <summary>
        /// InsertCheckBox checkbox checkedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InsertCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                //check for the checkbox Checked property 
                if (this.InsertCheckBox.Checked)
                {
                    //Enable user id text box, make update and delete buttons visible, insert button invisible
                    this.UserIDTextBox.Enabled = true;
                    this.UpdateButton.Visible = true;
                    this.DeleteButton.Visible = true;
                    this.InsertButton.Visible = false;
                }
                else
                {
                    this.UserIDTextBox.Enabled = false;
                    this.UpdateButton.Visible = false;
                    this.DeleteButton.Visible = false;
                    this.InsertButton.Visible = true;
                }
            }
        }

        #endregion methods
    }
}