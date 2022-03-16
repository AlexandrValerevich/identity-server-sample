package com.example.demo1;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

public class Login extends HttpServlet {

    public void init() {
    }

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

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
    }

    public void destroy() {
    }
}