/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Project name: .BookShelfWeb
 * File name: Search.aspx.cs
 * Status: Finished - search by ISBN to be added in future
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
using System.Text;

namespace BookShelfWeb
{
    /// <summary>
    /// Behind code for Search.aspx
    /// Custom control is assessed
    /// </summary>
    public partial class Search : System.Web.UI.Page
    {
        #region member variables

        public StringBuilder stringBuilder = null;

        #endregion member variables

        #region methods

        /// <summary>
        /// Page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                stringBuilder = new StringBuilder(ResultTextBox.Text);
            }
        }

        /// <summary>
        /// Clear inputs server side approach
        /// </summary>
        /// <param name="ctrls"></param>
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
        /// Search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            //CustomSearchControls passed:
            //SearchDropDownList
            //SearchTextBox

            TextBox CustomTextBox = (TextBox)CustomSearchControl1.FindControl("SearchTextBox");
            DropDownList SearchDropDownList = (DropDownList)CustomSearchControl1.FindControl("SearchDropDownList");

            ResultTextBox.Text += "Results:\n";

            if (SearchDropDownList.SelectedValue == "Full Name")
            {
                try
                {
                    //BookShelfUserManagerBLL to search for user by its full name
                    BookShelfUserManagerBLL bookShelfUserManagerBLL = new BookShelfUserManagerBLL();
                    BookShelfUser user = bookShelfUserManagerBLL.GetUserbyName(CustomTextBox.Text);

                    //printing to result textbox 
                    ResultTextBox.Text += "User Information: \n";

                    ResultTextBox.Text += "User ID: " + user.UserID + "\n";
                    ResultTextBox.Text += "Full Name: " + user.FullName + "\n";
                    ResultTextBox.Text += "Password: " + user.Password + "\n";
                    ResultTextBox.Text += "Email: " + user.Email + "\n";
                    ResultTextBox.Text += "Address: " + user.Address + "\n";
                    ResultTextBox.Text += "City:" + user.City + "\n";
                    ResultTextBox.Text += "\n";
                    stringBuilder.Append(ResultTextBox.Text);
                }
                catch (Exception ex)
                {
                    ClearInputs(Page.Controls);
                    stringBuilder.Append(ResultTextBox.Text);
                    ResultTextBox.Text += stringBuilder + "No record is existent within the given keyword!\n";
                }
            }
            else if (SearchDropDownList.SelectedValue == "Book Name")
            {
                string status = string.Empty;

                try
                {
                    //BookShelfBookManagerBLL to search for book by book name
                    BookShelfBookManagerBLL bookShelfBookManagerBLL = new BookShelfBookManagerBLL();
                    BookShelfBook book = bookShelfBookManagerBLL.GetBookbyName(CustomTextBox.Text);

                    //printing to result textbox 
                    ResultTextBox.Text += "Book Information: \n";

                    ResultTextBox.Text += "Book ID: " + book.BookID + "\n";
                    ResultTextBox.Text += "Book ISBN: " + book.Isbn + "\n";
                    ResultTextBox.Text += "Book Name: " + book.BookName + "\n";
                    ResultTextBox.Text += "Author Name: " + book.AuthorName + "\n";

                    if (book.BookStatus == 0)
                        status = "Book is never loaned before!\n";
                    else if (book.BookStatus == 1)
                        status = "Book is loaned by " + book.UserID + "\n";
                    else if (book.BookStatus == 2)
                        status = "Book is returned by " + book.UserID + "\n";

                    ResultTextBox.Text += status;
                    ResultTextBox.Text += "\n";

                    stringBuilder.Append(ResultTextBox.Text);
                }
                catch (Exception ex)
                {
                    ClearInputs(Page.Controls);
                    stringBuilder.Append(ResultTextBox.Text);
                    ResultTextBox.Text += stringBuilder + "No record is existent within the given keyword!\n";
                }
            }
            //ISBN search to be implemented   
        }
        #endregion methods
    }
}