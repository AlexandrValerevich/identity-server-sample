package com.example.demo1;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

// Класс аторизации
public class Login extends HttpServlet {

    // Обработка POST запроса для авторизации пользрвателя
    @Override
    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        String userName = request.getParameter("userName");
        String password = request.getParameter("password");

        // Создается экземпляр класса и вызывается метод на проверку коректности вводимых данных
        UserAccount userAccount = DataDAO.findUser(userName, password);

        response.setContentType("text/html");
        PrintWriter out = response.getWriter();

        // Если аккаунт не найден, то пользавателю выводится html страница с ошибкой
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

    // Отправка начальной страницы пользователю
    @Override
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        request.getRequestDispatcher("/index.jsp").forward(request, response);
    }
}