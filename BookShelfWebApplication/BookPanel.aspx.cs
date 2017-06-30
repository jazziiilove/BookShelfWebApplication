/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Project name: .BookShelfWeb
 * File name: BookPanel.aspx.cs
 * Status: Finished
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
    /// Behind code for BookPanel.aspx
    /// </summary>
    public partial class BookPanel1 : System.Web.UI.Page
    {
        #region methods

        /// <summary>
        /// Page Load
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
            string isbn = this.BookISBNTextBox.Text;
            string bitb = this.BookNameTextBox.Text;
            string batb = this.BookAuthorTextBox.Text;

            //BookShelfBookManagerBLL to add BookShelfBook
            BookShelfBookManagerBLL bookShelfBookManagerBLL = new BookShelfBookManagerBLL();
            BookShelfBook book = new BookShelfBook();

            book.Isbn = isbn;
            book.BookName = bitb;
            book.AuthorName = batb;

            bookShelfBookManagerBLL.AddBook(book);

            //If true, clear the inputs and make hidden label visible
            if (IsPostBack)
            {
                HiddenLabel.Text = "";
                ClearInputs(Page.Controls);
                HiddenLabel.Visible = true;
                HiddenLabel.Text += "Book is inserted successfully!";
                BookGridView.DataBind();
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
            string uitb = this.BookIDTextBox.Text;
            string isbn = this.BookISBNTextBox.Text;
            string bitb = this.BookNameTextBox.Text;
            string batb = this.BookAuthorTextBox.Text;

            //BookShelfBookManagerBLL to update BookShelfBook
            BookShelfBookManagerBLL bookShelfBookManagerBLL = new BookShelfBookManagerBLL();
            BookShelfBook book = new BookShelfBook();

            book.BookID = Int32.Parse(uitb);
            book.Isbn = isbn;
            book.BookName = bitb;
            book.AuthorName = batb;

            bookShelfBookManagerBLL.UpdateBook(book);

            //If true, clear the inputs and make hidden label visible
            if (IsPostBack)
            {
                HiddenLabel.Text = "";
                ClearInputs(Page.Controls);
                HiddenLabel.Visible = true;
                HiddenLabel.Text += "Book is updated successfully!";
                BookGridView.DataBind();
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
            string uitb = this.BookIDTextBox.Text;

            //BookShelfBookManagerBLL to delete BookShelfBook
            BookShelfBookManagerBLL bookShelfBookManagerBLL = new BookShelfBookManagerBLL();

            bookShelfBookManagerBLL.DeleteBook(Int32.Parse(uitb));

            //If true, clear the inputs and make hidden label visible
            if (IsPostBack)
            {
                HiddenLabel.Text = "";
                ClearInputs(Page.Controls);
                HiddenLabel.Visible = true;
                HiddenLabel.Text += "Book is deleted successfully!";
                BookGridView.DataBind();
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
                    this.BookIDTextBox.Enabled = true;
                    this.UpdateButton.Visible = true;
                    this.DeleteButton.Visible = true;
                    this.InsertButton.Visible = false;
                }
                else
                {
                    this.BookIDTextBox.Enabled = false;
                    this.UpdateButton.Visible = false;
                    this.DeleteButton.Visible = false;
                    this.InsertButton.Visible = true;
                }
            }
        }
        #endregion methods
    }
}