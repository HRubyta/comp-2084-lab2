using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

//add a reference in use of EF for the database
using comp2084_lesson9.Models;

namespace comp2084_lesson9
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //call the GetStudents function to populate the grid
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            //use entity framework to connect and get list of Departments
            using (DefaultConnection db = new DefaultConnection())
            {
                var stud = from d in db.Students
                           select d;

                //bind the stud query result to grid
                grdStudents.DataSource = stud.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //identify the studentID to be deleted from the row the user selected
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

            //connect to database
            using (DefaultConnection db = new DefaultConnection())
            {
                Student stud = (from d in db.Students 
                                where d.StudentID == StudentID
                                select d).FirstOrDefault();

                //delete
                db.Students.Remove(stud);
                db.SaveChanges();

                //refresh grid
                GetStudents();
            }
        }

        protected void grdStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set new page index and repopulate the grid
            grdStudents.PageIndex = e.NewPageIndex;
            GetStudents();
        }

        protected void grdStudents_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve table from the session object
            DataTable dt = Session["Student"] as DataTable;
            
            if (dt != null)
            {
                //sort student data
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                grdStudents.DataSource = Session["Student"];
                grdStudents.DataBind();
            }
        }
        
        private string GetSortDirection(string column)
        {
            //by default,set sort direction to ascending 
            string sortDirection = "ASC";
            
            //retrieve the last column that was sorted
            string sortExpression = ViewState["SortExpression"] as string;
            
            if (sortExpression != null)
            {
                //check if the same column is being sorted
                //otherwise default value can be return
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            
            }
            
            //Save new values in ViewState
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;
        
            return sortDirection;
        }
    }
}
