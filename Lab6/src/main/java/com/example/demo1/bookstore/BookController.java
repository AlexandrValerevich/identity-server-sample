package com.example.demo1.bookstore;

import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;

import javax.servlet.ServletContext;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * The type Book controller.
 */
public class BookController extends HttpServlet {
    private static final String URL_INDEX = "book.jsp";
    private final Logger logger = LogManager.getLogger(BookController.class);

    @Override
    public void init() {
       ServletContext ctx = getServletContext();
       logger.info(ctx.getServletContextName() + " " + (ctx).getServletRegistrations());
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.sendRedirect(URL_INDEX);
    }
}
