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
            //grdStudents.SortDirection = e.SortDirection;
            GetStudents();

        }

    }
}
