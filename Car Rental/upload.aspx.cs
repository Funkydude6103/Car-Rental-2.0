using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace Car_Rental
{
    public partial class upload : System.Web.UI.Page
    {
        protected int user_id;
        protected int car_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["user_id"]))
                {
                    user_id = int.Parse(Request.QueryString["user_id"]);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["car_id"]))
                {
                    car_id = int.Parse(Request.QueryString["car_id"]);
                }
            }
        }

        protected void Sub_Click(object sender, EventArgs e)
        {
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string phone = Request.Form["phone"];
            DateTime pickupTime = DateTime.Parse(Request.Form["pickup-datetime"]);
            DateTime returnTime = DateTime.Parse(Request.Form["return-datetime"]);

            // check if rental period is within car availability period
            bool isAvailable = false;
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT start_date, end_date, is_available FROM Car WHERE car_id=@car_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@car_id", car_id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        DateTime startDate = (DateTime)reader["start_date"];
                        DateTime endDate = (DateTime)reader["end_date"];
                        isAvailable = (bool)reader["is_available"];
                        if (pickupTime >= startDate && returnTime <= endDate && isAvailable)
                        {
                            // save rental request
                            string insertQuery = "INSERT INTO RentalRequest (car_id, renter_id, start_datetime, end_datetime, status) VALUES (@car_id, @renter_id, @start_datetime, @end_datetime, @status)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@car_id", car_id);
                                insertCommand.Parameters.AddWithValue("@renter_id", user_id);
                                insertCommand.Parameters.AddWithValue("@start_datetime", pickupTime);
                                insertCommand.Parameters.AddWithValue("@end_datetime", returnTime);
                                insertCommand.Parameters.AddWithValue("@status", "Pending");
                                insertCommand.ExecuteNonQuery();
                            }

                          

                            // display success message and redirect
                            Response.Write("<script>alert('Request sent!')</script>");
                            Response.Redirect("cars.aspx?id=" + user_id);
                        }
                        else
                        {
                            // display error message
                            Response.Write("<script>alert('Car is not available for selected period.')</script>");
                            Response.Redirect("cars.aspx?id=" + user_id);
                        }
                    }
                    reader.Close();
                }
            }
        }
    }
}
