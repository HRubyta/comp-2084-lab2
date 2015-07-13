using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace comp2084_lesson4
{
    public partial class lesson4 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //show the current date and time in the footer
            lblTimestamp.Text = System.DateTime.Now.ToString();
        }
    }
}