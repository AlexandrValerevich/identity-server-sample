package com.example.demo1;

import java.io.*;
import javax.servlet.http.*;

// Возвращает страницу /helloServelet
public class HelloServlet extends HttpServlet {
    private String message;

    /*
        имя: init
        Инициализурует поля класса
    */
    public void init() {
        message = "Hello Servlet!";
    }

    /* 
        имя: doGet
        параметры:
            - request
                Информация об HTTP запросе о пользователя
            - responce
                HTTP ответ пользователю
        Конструирует HTML страницу
    */
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.setContentType("text/html");

        PrintWriter out = response.getWriter();
        out.println("<html><body>");
        out.println("<h1>" + message + "</h1>");
        out.println("</body></html>");
    }
}