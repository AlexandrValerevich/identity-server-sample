<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>JSP - Hello World</title>
</head>
<body>
<h1><%= "Hello World!" %>
</h1>
<br/>
<a href="helloServlet">Hello Servlet</a>
<form action="login" method="post"> Input for username:<br>
    <input name="userName" type="text"><br>
    Input for password:<br>
    <input name="password" type="password"><br>
    <input type="submit" value="Авторизироваться">
</form>
</body>
</html>