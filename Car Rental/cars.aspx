<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cars.aspx.cs" Inherits="Car_Rental.cars" %>

<!DOCTYPE html>
<html>
  <head>
    <title>Car Rental Website</title>
      	<style>
    .car1 {
        border: 1px solid #ccc;
        box-shadow: 2px 2px 6px #ccc;
        margin: 10px;
        padding: 10px;
        width: 800px;
        margin-left:320px;
       
    }

    .carHeader {
        margin-bottom: 10px;
        text-align: center;
    }

    .carHeader label {
        display: block;
        font-size: 16px;
        font-weight: bold;
        margin-bottom: 5px;
    }

    .carFooter {
        border-top: 1px solid #ccc;
        margin-top: 10px;
        padding-top: 10px;
        text-align: center;
    }

    .carFooter label {
        display: block;
        font-size: 14px;
    }

    .carFooter label strong {
        font-weight: bold;
    }

    .carFooter button {
        background-color: #008CBA;
        border: none;
        color: white;
        padding: 10px 20px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
        margin: 4px 2px;
        cursor: pointer;
        border-radius: 5px;
    }
   .btn-review,.btn-details {
  background-color: #4CAF50; /* Green */
  border: none;
  color: white;
  padding: 10px 20px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  border-radius: 4px;
}

btn-review,.btn-details:hover {
  background-color: #3e8e41;
}

.btn-review:active,.btn-details:active {
  background-color: #3e8e41;
  transform: translateY(2px);
}
.car1 img {
  max-width: 200px;
  max-height: 200px;
}
</style>
    <link rel="stylesheet" type="text/css" href="style2.css">
  </head>
  <body>
    <header>
      <div>
        <h1>Get the Best Match</h1>
      </div>
    </header>
    <div class="navbar">
      <ul class="options">
        
                 <li><a href="/home.aspx?id=<%=id%>">Home</a></li>
				<li><a href="./cars.aspx?id=<%=id%>">See Cars</a></li>
				<li><a href="./uploadYourCar.aspx?id=<%=id%>">Upload Car</a></li>
				<li><a href="UploadedCars.aspx?id=<%=id%>">Uploaded Cars</a></li>
				<li><a href="RequestsSent.aspx?id=<%=id%>">Requests Sent</a></li>
				<li><a href="HIstory.aspx?id=<%=id%>">History</a></li>
				<li><a href="User Profile.aspx?id=<%=id%>">User Profile</a></li>
				<li><a href="Contact Us.aspx?id=<%=id%>">Contact Us</a></li>
		
      
      </ul>
    </div>
    <div class="search-container">
      <form>
        <input type="text" placeholder="Search cars...">
        <div class="filters">
          <label for="date-filter">Date:</label>
          <input type="date" id="date-filter" name="date">
          <label for="location-filter">Location:</label>
          <select id="location-filter" name="location">
            <option value="">Any location</option>
            <option value="New York">New York</option>
            <option value="Los Angeles">Los Angeles</option>
            <option value="Chicago">Chicago</option>
          </select>
          <label for="price-filter">Price:</label>
          <select id="price-filter" name="price">
            <option value="">Any price</option>
            <option value="10000">$10,000 or less</option>
            <option value="20000">$10,000 - $20,000</option>
            <option value="30000">$20,000 - $30,000</option>
            <option value="40000">$30,000 or more</option>
          </select>
          <label for="car-filter">Car Name:</label>
          <input type="text" id="car-filter" name="car-name">
        </div>
        <button type="submit">Search</button>
      </form>
    </div>
      <div class="intro">
        <h2>Cars</h2>
        <div class="entry">
        
          <p class="tagline">Welcome to our rent a car website, where you can find a wide selection of cars to suit your needs. We offer a range of vehicles from compact cars to SUVs, luxury cars to minivans, and everything in between. Our cars are well-maintained, reliable, and up-to-date with the latest safety features. We understand that every customer has unique needs and preferences, which is why we have a variety of car models available for rent. Whether you need a car for a short trip or a long-term rental, we have you covered. Explore our website to find the perfect car for your next adventure</p>

        </div>
      
      </div>

   
    <main>
      <form runat="server">
		<asp:Panel ID="carsPanel" runat="server" CssClass="carsPanel"></asp:Panel>
	</form>
    </main>
    
  </body>
</html>
