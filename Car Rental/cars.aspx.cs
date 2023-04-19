using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Car_Rental
{
    public partial class cars : System.Web.UI.Page
    {

        protected int id;
       
          
            protected void Page_Load(object sender, EventArgs e)
           {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    id = int.Parse(Request.QueryString["id"]);
                }
            }
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT c.car_id,c.make, c.model, c.year, c.location, c.price, c.is_available, MAX(ci.image_url) AS image_url FROM Car c INNER JOIN car_image ci ON c.car_id = ci.car_id GROUP BY c.car_id, c.make, c.model, c.year, c.location, c.price, c.is_available";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    string make = reader["make"].ToString();
                    string model = reader["model"].ToString();
                    int year = Convert.ToInt32(reader["year"]);
                    string location = reader["location"].ToString();
                    decimal price = Convert.ToDecimal(reader["price"]);
                    bool isAvailable = Convert.ToBoolean(reader["is_available"]);
                    byte[] imageBytes = (byte[])reader["image_url"];
                    string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    string imageUrl = string.Format("data:image/jpeg;base64,{0}", base64String);

                    Panel carPanel = new Panel();
                    carPanel.CssClass = "car1";

                    Panel carHeaderPanel = new Panel();
                    carHeaderPanel.CssClass = "carHeader";

                    Label makeModelLabel = new Label();
                    makeModelLabel.Text = string.Format("{0} {1}", make, model);
                    carHeaderPanel.Controls.Add(makeModelLabel);

                    Label availabilityLabel = new Label();
                    availabilityLabel.Text = isAvailable ? "Available" : "Not Available";
                    carHeaderPanel.Controls.Add(availabilityLabel);

                    carPanel.Controls.Add(carHeaderPanel);

                    Image carImage = new Image();
                    carImage.ImageUrl = imageUrl;
                    carPanel.Controls.Add(carImage);

                    Panel carFooterPanel = new Panel();
                    carFooterPanel.CssClass = "carFooter";

                    Label priceLabel = new Label();
                    priceLabel.Text = string.Format("<strong>Price per Hour:</strong> {0:C}", price);
                    carFooterPanel.Controls.Add(priceLabel);

                    carPanel.Controls.Add(carFooterPanel);

                    Button reviewButton = new Button();
                    reviewButton.Text = "Review";
                    reviewButton.ID = "ReviewButton"+counter;
                    reviewButton.CssClass = "btn-review"; // add CSS class
                    reviewButton.Click += new EventHandler(ReviewButton_Click);
                    carPanel.Controls.Add(reviewButton);

                    Button detailsButton = new Button();
                    detailsButton.Text = "See Details";
                    detailsButton.ID = "sdf"+counter;
                    detailsButton.CssClass = "btn-details"; // add CSS class
                    detailsButton.Click += new EventHandler(DetailsButton_Click);
                    carPanel.Controls.Add(detailsButton);
                    counter++;
                    carsPanel.Controls.Add(carPanel);
                }
                reader.Close();
            }
        }

        protected void ReviewButton_Click(object sender, EventArgs e)
        {
            Button reviewButton = (Button)sender;
            string buttonID = reviewButton.ID;
            int carIndex = int.Parse(buttonID.Replace("ReviewButton", ""));
            string carID = GetCarID(carIndex);
            Response.Redirect("Review.aspx?carid=" + carID);
        }

        protected void DetailsButton_Click(object sender, EventArgs e)
        {
            Button detailsButton = (Button)sender;
            string buttonID = detailsButton.ID;
            int carIndex = int.Parse(buttonID.Replace("sdf", ""));
            string carID = GetCarID(carIndex);
            Response.Redirect("Car Details.aspx?carid=" + carID);
        }
        private string GetCarID(int index)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT c.car_id FROM Car c INNER JOIN car_image ci ON c.car_id = ci.car_id GROUP BY c.car_id, c.make, c.model, c.year, c.location, c.price, c.is_available ORDER BY c.car_id";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    if (counter == index)
                    {
                        string carID = reader["car_id"].ToString();
                        reader.Close();
                        return carID;
                    }
                    counter++;
                }
                reader.Close();
                return null;
            }
        }
    }
}