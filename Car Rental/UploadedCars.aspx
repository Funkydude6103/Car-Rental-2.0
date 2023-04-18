﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadedCars.aspx.cs" Inherits="Car_Rental.UploadedCars" %>

<!DOCTYPE html>
<html>
<head>
  <meta charset="UTF-8">
  <title>My Car Rentals</title>
  <link rel="stylesheet" href="UploadedCarsstyles.css">
</head>
<body>
  <header>
    <h1>My Car Rentals</h1>
  </header>
    <div class="navbar">
      <ul class="options">
        
          <li><a href="./home.aspx">Home</a></li>
          <li><a href="./cars.aspx">See Cars</a></li>
          <li><a href="./uploadYourCar.aspx">Upload Car</a></li>
          <li><a href="UploadedCars.aspx">Uploaded Cars</a></li>
          <li><a href="RequestsSent.aspx">Requests Sent</a></li>
          <li><a href="HIstory.aspx">History</a></li>
          <li><a href="User Profile.aspx">User Profile</a></li>
          <li><a href="Contact Us.aspx">Contact Us</a></li>
      
      </ul>
    </div>
  

  <main class="container">
    

    <div class="car-card">
      <h2>Toyota Camry</h2>
      <img src="data:image/jpeg;base64,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" alt="Toyota Camry">
      <p><strong>Model:</strong> Camry</p>
      <p><strong>Year:</strong> 2020</p>
      <p><strong>Color:</strong> Silver</p>
      <p><strong>Price per day:</strong> $50</p>
      <button>Edit</button>
      <button>Delete</button>
      <button onclick="window.location.href = 'Car Request Details.aspx';">Requests</button>
      <button onclick="window.location.href = 'Review.aspx';">Check Reviews</button>
    </div>

    <div class="car-card">
      <h2>Honda Civic</h2>
      <img src="data:image/jpeg;base64,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" alt="Honda Civic">
      <p><strong>Model:</strong> Civic</p>
      <p><strong>Year:</strong> 2019</p>
      <p><strong>Color:</strong> Red</p>
      <p><strong>Price per day:</strong> $40</p>
      <button>Edit</button>
      <button>Delete</button>
      <button>Requests</button>
      <button onclick="window.location.href = 'Review.aspx';">Check Reviews</button>
    </div>
  </main>

  <footer>
    <p>&copy; 2023 My Car Rentals</p>
  </footer>
</body>
</html>
