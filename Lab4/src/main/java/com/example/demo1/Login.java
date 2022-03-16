package com.example.demo1;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;


// Класс предназначен для авторизации пользователя
public class Login extends HttpServlet {
    /* 
        имя: doPost
        параметры:
            - request
                Информация об HTTP запросе о пользователя
            - responce
                HTTP ответ пользователю
        Ищет пользователя в "БД" в случае совпадения высвечиввается приветствие.
        Если пользватель остутствует в базе то выводим ошибку.
    */
    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        String userName = request.getParameter("userName");
        String password = request.getParameter("password");
        UserAccount userAccount = DataDAO.findUser(userName, password);

        response.setContentType("text/html");
        PrintWriter out = response.getWriter();
        if (userAccount == null) {
            String errorMessage = "Invalid userName or Password";
            out.println("<html><body>");
            out.println("<h1>" + errorMessage + "</h1>");
            out.println("</body></html>");
            return;
        }
        out.println("<html><body>");
        out.println("<h1>" + "Ok" + "</h1>");
        out.println("</body></html>");
    }
}