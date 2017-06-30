using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Interfaces;
using WebApplication1.Modules;
using BookShelfWeb.DAL;
using BookShelfWeb.BookShelfModel;
using System.Data;
using System.Data.SqlClient;
using BookShelfWeb.Definitions;
using System.ComponentModel;
using BookShelf.BusinessLogic;
namespace BookShelfWeb
{
    /// <summary>
    /// Behind code Default.aspx
    /// </summary>
    public partial class _Default : System.Web.UI.Page
    {
        #region member variables
        //
        public bool flagListBook = false;
        public bool flagLoanBook = false;
        public bool flagReturnBook = false;

        #endregion member variables

        #region methods

        /// <summary>
        ///  Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// data source to list of users' business logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ListUserButton_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ObjectDataSource odsUserList = new ObjectDataSource("BookShelf.BusinessLogic.BookShelfUserManagerBLL", "GetUsers");

                ListGridView.DataSource = odsUserList;
                ListGridView.DataBind();
            }
        }

        /// <summary>
        /// data source to list of books' business logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ListBookButton_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                flagListBook = true;
                ObjectDataSource odsBookList = new ObjectDataSource("BookShelf.BusinessLogic.BookShelfBookManagerBLL", "GetBooks");
                ListGridView.DataSource = odsBookList;
                ListGridView.DataBind();

            }
        }

        /// <summary>
        /// data source to list of loaned books' business logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoanBookButton_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                flagLoanBook = true;
                ObjectDataSource odsLoanedBookList = new ObjectDataSource("BookShelf.BusinessLogic.BookShelfBookManagerBLL", "GetLoanedBooks");
                ListGridView.DataSource = odsLoanedBookList;
                ListGridView.DataBind();
            }
        }

        /// <summary>
        /// data source to list of rerturned books' business logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ReturnBookButton_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                flagReturnBook = true;
                ObjectDataSource odsReturnedBookList = new ObjectDataSource("BookShelf.BusinessLogic.BookShelfBookManagerBLL", "GetReturnedBooks");
                ListGridView.DataSource = odsReturnedBookList;
                ListGridView.DataBind();
            }
        }

        /// <summary>
        /// Hide the some of the  columns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UserGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (flagListBook || flagLoanBook || flagReturnBook)
            {
                e.Row.Cells[5].CssClass = "hiddencol";
            }
        }

        /// <summary>
        /// Panel visibility button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ClickButton_Click(object sender, EventArgs e)
        {
            BookShelfPanel.Visible = true;
            StartPanel.Visible = false;
        }

        #endregion methods
    }
}
