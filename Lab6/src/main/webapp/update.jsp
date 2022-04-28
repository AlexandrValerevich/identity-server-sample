<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
 <title>Update book</title>
</head>
<body>
<section>
 <jsp:useBean id="book" scope="request"
class="com.example.demo1.models.Book"/>
 <form method="post" action="updateBook"/>
 <input type="hidden" name="id" value="<%= book.getId() %>"/>
 <p>name: <input type="text" name="name" value="<%= book.getName() %>"
placeholder="<%= book.getName() %>"/></p>
 <p>author: <input type="text" name="author" value="<%= book.getAuthor()
%>" placeholder="<%= book.getAuthor() %>"/></p>
 <p>pages: <input type="number" name="pages" value="<%=
book.getCountPages() %>" placeholder="<%= book.getCountPages() %>"/></p>
 <button type="submit">Save</button>
 </form>
</section>
</body>
</html>
