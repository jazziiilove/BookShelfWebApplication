/* 
 * Company: 
 * Motto: Talk more to loved ones!
 * Assignment: A book shelf application
 * Deadline: 2012-01-02
 * Programmer: Baran Topal 
 * Solution name: .BookShelfWeb
 * Folder name: Interfaces
 * Project name: .BookShelfWeb
 * File name: Listing.asmx
 * Status: TODO
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using WebApplication1.Modules;

namespace WebApplication1.Interfaces
{
    /// <summary>
    /// Summary description for Listing
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Listing : System.Web.Services.WebService
    {
        #region TODO

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public JQGrid GetListing()
        {
            JQGrid jqGrid = new JQGrid();

            jqGrid.page = 1;
            jqGrid.total = 10;
            jqGrid.records = 10;
            jqGrid.rows = new List<JQGrid.Row>();

            for (int i = 0; i < 10; ++i)
            {
                JQGrid.Row row = new JQGrid.Row();

                row.id = i;
                row.cell.Add((i + 1).ToString());//number
                row.cell.Add("LYA" + i.ToString());//owner
                row.cell.Add(DateTime.Now.ToString());//create time
                row.cell.Add(DateTime.Now.ToString());//start time
                row.cell.Add(DateTime.Now.ToString());//end time
                row.cell.Add("not started");//status
                row.cell.Add("0%");//progress

                jqGrid.rows.Add(row);
            }

            return jqGrid;
        }

        #endregion TODO
    }
}
