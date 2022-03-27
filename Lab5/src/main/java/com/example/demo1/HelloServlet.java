package com.example.demo1;

import java.io.*;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.*;

// Начальная страница приветствия
public class HelloServlet extends HttpServlet {
    // Объявление полей класса
    private String message;
    
    // Методы инициализации где мы присваиваем переменной message определенную строку
    @Override
    public void init() {
        message = "Hello Servlet!";
    }
    
    // Метод отправки пользователю HTML страницы
    @Override
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.setContentType("text/html");

        PrintWriter out = response.getWriter();
        out.println("<html><body>");
        out.println("<h1>" + message + "</h1>");
        out.println("</body></html>");
    }
}