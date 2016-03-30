using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Webboard
{
    public partial class Reply1 : System.Web.UI.Page
    {
        string CurrentTID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentTID = Request.QueryString["TID"];
            if (CurrentTID == null)
            {
                Response.RedirectPermanent("Default.aspx");
            }
            else
            {
                if (CurrentTID == "")
                {
                    Response.RedirectPermanent("Default.aspx");
                }
                else
                {
                    dbWebboardDataContext db = new dbWebboardDataContext();
                    var ts = from t in db.Topics
                             where t.TID == CurrentTID
                             select t;

                    if (ts.Count() > 0)
                    {
                        var ViewCount = ts.FirstOrDefault().ViewCount;

                        ts.FirstOrDefault().ViewCount = ViewCount + 1;
                        using (TransactionScope tc = new TransactionScope())
                        {
                            db.SubmitChanges();
                            tc.Complete();
                        }
                        db.Connection.Close();
                    }
                }
            }
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            dbWebboardDataContext db = new dbWebboardDataContext();
            var rs = (from r in db.Replies
                      where r.TID == CurrentTID
                      orderby r.ReplyNO descending
                      select r).Take(1);

            int LastReplyNO;
            if (rs.Count() > 0)
            {
                var CurrentReplyNO = Convert.ToInt32(rs.FirstOrDefault().ReplyNO);
                CurrentReplyNO++;
                LastReplyNO = CurrentReplyNO;
            }
            else
            {
                LastReplyNO = 1;
            }

            Reply rp = new Reply();
            rp.TID = CurrentTID;
            rp.ReplyNO = LastReplyNO;
            rp.Description = txtDescription.Text.Trim();
            rp.ReplyName = txtReplyName.Text.Trim();
            rp.ReplyDate = DateTime.Now;
            rp.IP = Request.ServerVariables["REMOTE_ADDR"];

            var ts = from t in db.Topics
                     where t.TID == CurrentTID
                     select t;
            ts.FirstOrDefault().ReplyCount = LastReplyNO;

            using (TransactionScope tc = new TransactionScope())
            {
                db.Replies.InsertOnSubmit(rp);
                db.SubmitChanges();
                tc.Complete();
            }

            db.Connection.Close();
            Response.RedirectPermanent("Default.aspx");
        }

        protected void cmdClear_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            txtReplyName.Text = "";
        }
    }
}