using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webboard
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() != "")
            {
                Response.RedirectPermanent("Search.aspx?q=" + txtSearch.Text.Trim());
            }
        }


    }
}