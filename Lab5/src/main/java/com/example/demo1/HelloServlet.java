package com.example.demo1;

import java.io.*;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.*;


/**
 * The type Hello servlet.
 */
public class HelloServlet extends HttpServlet {
    
    private String message;
    
    
    @Override
    public void init() {
        message = "Hello Servlet!";
    }

    /**
     * Instantiates a new User account.
     *
     * @param request the HttpServletRequest
     * @param response the HttpServletResponse
     */
    @Override
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.setContentType("text/html");

        PrintWriter out = response.getWriter();
        out.println("<html><body>");
        out.println("<h1>" + message + "</h1>");
        out.println("</body></html>");
    }
}