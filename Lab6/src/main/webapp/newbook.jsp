<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
 <title>Add new book</title>
</head>
<body>
<section>
 <form method="post" action="addBook"/>
 <p>name: <input type="text" name="name" value=""/></p>
 <p>author: <input type="text" name="author" value=""/></p>
 <p>pages: <input type="number" name="pages" value=""/></p>
 <button type="submit">Save</button>
 </form>
</section>
</body>
</html>