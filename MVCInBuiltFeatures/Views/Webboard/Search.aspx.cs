using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webboard
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var _q = Request.QueryString["q"];
            if (_q != null)
            {
                if (_q.Trim() != "")
                {
                    dbWebboardDataContext db = new dbWebboardDataContext();
                    var ts = from t in db.Topics
                             where t.Topic1.Contains(_q)
                             orderby t.TID descending
                             select new
                             {
                                 TID = t.TID,
                                 Topic1 = t.Topic1,
                                 UserName = t.UserName,
                                 RecordDate = t.RecordDate,
                                 ViewCount = t.ViewCount,
                                 ReplyCount = t.ReplyCount,
                                 IP = t.IP
                             };
                    if (ts.Count() > 0)
                    {
                        gvTopic.DataSource = ts.ToList();
                        gvTopic.DataBind();
                    }
                }
                else
                {
                    Response.RedirectPermanent("Default.aspx");
                }
            }
            else
            {
                Response.RedirectPermanent("Default.aspx");
            }
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