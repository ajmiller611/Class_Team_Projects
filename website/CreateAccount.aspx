﻿<!DOCTYPE html>
<html>

<head>
	<title>Create an Account</title>
	<meta charset="utf-8" />
	<link rel="stylesheet" href="css/style.css" type="text/css" />
</head>

<body>
	<h1>Hotel</h1>
		<header  class = "menuBar">				
		<nav>
			<ul>
			<li><a href="index.html">Home</a></li>
			<li><a href="reservation.html">Reservation</a></li>
			<li><a href="contact_us.html">Contact Us</a></li>
			</ul>
		</nav>
	</header>
	
	<h1>Create an Account</h1>
	<h2>Sign up for an account here!</h2>
	<form ... onsubmit="return checkForm(this);">
	<label>Username: <input type="text" name="username"></label><br>
	<label>Password: <input type="password" name="pwd1"></label><br>
	<label>Confirm Password: <input type="password" name="pwd2"></label><br>
	<script type="text/javascript">

  function checkForm(form)
  {
    if(form.username.value == "") {
      alert("Error: Username cannot be blank!");
      form.username.focus();
      return false;
    }
    re = /^\w+$/;
    if(!re.test(form.username.value)) {
      alert("Error: Username must contain only letters, numbers and underscores!");
      form.username.focus();
      return false;
    }

    if(form.pwd1.value != "" && form.pwd1.value == form.pwd2.value) {
      if(form.pwd1.value.length < 6) {
        alert("Error: Password must contain at least six characters!");
        form.pwd1.focus();
        return false;
      }
      if(form.pwd1.value == form.username.value) {
        alert("Error: Password must be different from Username!");
        form.pwd1.focus();
        return false;
      }
      re = /[0-9]/;
      if(!re.test(form.pwd1.value)) {
        alert("Error: password must contain at least one number (0-9)!");
        form.pwd1.focus();
        return false;
      }
      re = /[a-z]/;
      if(!re.test(form.pwd1.value)) {
        alert("Error: password must contain at least one lowercase letter (a-z)!");
        form.pwd1.focus();
        return false;
      }
      re = /[A-Z]/;
      if(!re.test(form.pwd1.value)) {
        alert("Error: password must contain at least one uppercase letter (A-Z)!");
        form.pwd1.focus();
        return false;
      }
    } else {
      alert("Error: Please check that you've entered and confirmed your password!");
      form.pwd1.focus();
      return false;
    }

    alert("You entered a valid password: " + form.pwd1.value);
    return true;
  }

</script>
    <label>First Name: <input type="text" name="firstname"></label><br>
	<label>Last Name: <input type="text" name="lastname"></label><br>
	<label>Email:<input type="text" name= "Email"></label><br>
	<label>Street Address:<input type="text" name="street"></label><br>
    <label>City:<input type="text" name="city"></label><br>
    <label>State:<input type="text" name="state"></label><br>
    <label>Zip:<input type="text" name="zip"></label><br>
	<label>Emergency Contact Name: <input type="text" name="emergencyname"></label><br>
	<label>Emergency Contact Number: <input type="text" name="emergencynumber"></label><br>
	<input type="submit" value="Submit">
	<input type="reset" value="Clear">
	</form>
</body>
</html>