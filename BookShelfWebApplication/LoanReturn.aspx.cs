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
    /// Behind code for LoanReturn.aspx
    /// </summary>
    public partial class LoanReturn : System.Web.UI.Page
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

        protected void Page_PreRender(object sender, EventArgs e)
        {
            LoanButton.Attributes.Add("onmouseup", "ShowModalDialog();");
            ReturnButton.Attributes.Add("onmouseup", "ShowModalDialog();");
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
        /// Loan button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoanButton_Click(object sender, EventArgs e)
        {
            try
            {
                //member variables
                string uitb = this.UserIDTextBox.Text;
                string bitb = this.BookNameTextBox.Text;

                //BookShelfUserManagerBLL to get book entity by book name
                BookShelfUserManagerBLL bookShelfUserManagerBLL = new BookShelfUserManagerBLL();
                BookShelfUser user = bookShelfUserManagerBLL.GetUserbyID(Int32.Parse(uitb));

                BookShelfBookManagerBLL bookShelfBookBLL = new BookShelfBookManagerBLL();
                BookShelfBook book = bookShelfBookBLL.GetBookbyName(bitb);

                book.UserID = Int32.Parse(uitb);
                bookShelfUserManagerBLL.UpdateBookMembership(Int32.Parse(uitb), book, "Loan");

                if (IsPostBack)
                {
                    HiddenLabel.Text = "";
                    ClearInputs(Page.Controls);
                    HiddenLabel.Visible = true;
                    HiddenLabel.Text += "Loan is done successfully!";
                }
            }
            catch (Exception ex)
            {
                HiddenLabel.Text = "";
                ClearInputs(Page.Controls);
                HiddenLabel.Visible = true;
                HiddenLabel.Text += "Loan is failed!";
            }
        }

        protected void ReturnButton_Click(object sender, EventArgs e)
        {
            try
            {
                //member variables
                string uitb = this.UserIDTextBox.Text;
                string bitb = this.BookNameTextBox.Text;

                //BookShelfUserManagerBLL to get book entity by book name
                BookShelfUserManagerBLL bookShelfUserManagerBLL = new BookShelfUserManagerBLL();
                BookShelfUser user = bookShelfUserManagerBLL.GetUserbyID(Int32.Parse(uitb));

                BookShelfBookManagerBLL bookShelfBookManagerBLL = new BookShelfBookManagerBLL();
                BookShelfBook book = bookShelfBookManagerBLL.GetBookbyName(bitb);
                book.UserID = Int32.Parse(uitb);
                bookShelfUserManagerBLL.UpdateBookMembership(Int32.Parse(uitb), book, "Return");

                if (IsPostBack)
                {
                    HiddenLabel.Text = "";
                    ClearInputs(Page.Controls);
                    HiddenLabel.Visible = true;
                    HiddenLabel.Text += "Return is done successfully!";
                }
            }
            catch (Exception ex)
            {
                HiddenLabel.Text = "";
                ClearInputs(Page.Controls);
                HiddenLabel.Visible = true;
                HiddenLabel.Text += "Return is failed!";
            }
        }
        #endregion methods
    }
}