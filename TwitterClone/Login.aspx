<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TwitterClone.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>welcome to my twitter clone</title>
<style>
body {font-family: Arial, Helvetica, sans-serif;}
/*form {border: 3px solid #f1f1f1;}*/

input[type=text], input[type=password] {
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    box-sizing: border-box;
    width:250px;
}

button {
    background-color: #4CAF50;
    color: white;
    padding: 7px 10px;
    margin: 8px 0;
    border: none;
    cursor: pointer;
}

button:hover {
    opacity: 0.8;
}


.container {
    padding: 16px;
}

span.psw {
    float: right;
    padding-top: 16px;
}

/* Change styles for span and cancel button on extra small screens */
@media screen and (max-width: 300px) {
    span.psw {
       display: block;
       float: none;
    }
}
</style>
</head>
<body style="margin-left:250px;">

<form action="/Tweets/Index" method="post">
     <h2>Welcome to my twitter clone</h2>
  <div class="container" style="margin-top:20px; width:360px;">
     <fieldset  style="width:360px;background-color:transparent;">
     <legend>Login</legend>
    <label for="uname"><b>Username: </b></label>&nbsp;
    <input type="text" placeholder="Enter Username" name="uname" />
      <br />
    <label for="psw"><b>Password: </b></label>&nbsp;
    <input type="password" placeholder="Enter Password" name="psw" /> 
       <br />       
    <button type="submit" style="margin-left:290px;">Login</button>
          <br /><br />   
   <label>New user ?</label>  <a href="/Person/Index">SignUp</a>
         </fieldset>
  </div>
</form>
</body>
</html>

