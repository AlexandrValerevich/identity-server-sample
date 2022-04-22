package com.example.demo1;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;

/**
 * The type Login.
 */
public class Login extends HttpServlet {

    /**
     * Instantiates a new User account.
     *
     * @param request the HttpServletRequest
     * @param response the HttpServletResponse
     */

        @Override
    public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        String userName = request.getParameter("userName");
        String password = request.getParameter("password");

        UserAccount userAccount = null;
        try {
            userAccount = DataDAO.findUser(userName, password);
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }

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

    /**
     * Instantiates a new User account.
     *
     * @param request the HttpServletRequest
     * @param response the HttpServletResponse
     */

    @Override
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
        request.getRequestDispatcher("/index.jsp").forward(request, response);
    }
}