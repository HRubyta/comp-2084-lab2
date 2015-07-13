using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//add a rference so can use EF(entity framework) for our database
using comp2084_lesson9.Models;


namespace comp2084_lesson9
{
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //call the GetDepartments function to populate grid
            if(!IsPostBack)
            {
                GetDepartments();
            }
            
        }

        protected void GetDepartments()
        {
            //use entity framework to connect and get the list of departments
            using (DefaultConnection db = new DefaultConnection())
            {
                var deps = from d in db.Departments
                           select d;

                //bind the deps query result to our grid
                grdDepartments.DataSource = deps.ToList();
                grdDepartments.DataBind();
            }


        }

        protected void grdDepartments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page index and repopulate the grid
            grdDepartments.PageIndex = e.NewPageIndex;
            GetDepartments();

        }

        protected void grdDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //identify the departmentID to be deleted from the row user selected
            Int32 DepartmentID = Convert.ToInt32(grdDepartments.DataKeys[e.RowIndex].Values["DepartmentID"]);

            //connect
            using (DefaultConnection db = new DefaultConnection())
            {
                Department dep = (from d in db.Departments 
                                     where d.DepartmentID == DepartmentID 
                                      select d).FirstOrDefault();

                //delete
                db.Departments.Remove(dep);
                db.SaveChanges();

                //refresh grid
                GetDepartments();
            }

        }
    }
}