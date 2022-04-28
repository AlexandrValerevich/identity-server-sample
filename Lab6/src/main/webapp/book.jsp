<%@ page import="com.example.demo1.ConnectionManager" %>
<%@ page import="com.example.demo1.models.Book" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
 <title>Book store</title>
</head>
<body>

<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container-fluid">
    <a class="navbar-brand" href="login">Login</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Переключатель навигации">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="upload">upload</a>
        </li>
         <li class="nav-item">
                  <a class="nav-link active" aria-current="page" href="uploadAjax.jsp">uploadAjax</a>
                </li>
      </ul>
    </div>
  </div>
</nav>

<section>
 <% ConnectionManager.getConnection(); %>
 <jsp:useBean id="bookDAO" scope="application"
class="com.example.demo1.dao.BooksDAOImpl"/>
 <% for (Book book : bookDAO.selectAllBooks()) {%>
 <p>book: <%= book.getName() %>, author <%= book.getAuthor() %> - pages <%=
book.getCountPages() %> |
 <a href="updateBook?action=update&id=<%= book.getId() %>">update</a>
 </p>
  <button type="submit" onclick = <% bookDAO.deleteBook(book); %> >Delete</button>
 <% } %>
 <a href="newbook.jsp">add new book</a>
</section>
</body>
</html>