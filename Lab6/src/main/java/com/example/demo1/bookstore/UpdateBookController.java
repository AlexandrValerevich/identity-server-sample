package com.example.demo1.bookstore;

import com.example.demo1.dao.BooksDAO;
import com.example.demo1.dao.BooksDAOImpl;
import com.example.demo1.models.Book;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * The type Update book controller.
 */
public class UpdateBookController extends HttpServlet {
    private static final String URL_INDEX = "book.jsp";
    private static final String URL_UPDATE = "/update.jsp";
    private static final String ID = "id";
    private static final String NAME = "name";
    private static final String AUTHOR = "author";
    private static final String PAGES = "pages";
    private BooksDAO books = new BooksDAOImpl();
    private AddBookController addBookController = new AddBookController();

    @Override
    protected void doPost(final HttpServletRequest req, final HttpServletResponse
            resp) throws ServletException, IOException {
        String name = req.getParameter(NAME);
        String author = req.getParameter(AUTHOR);
        String countPager = req.getParameter(PAGES);
        books.updateBook(new Book(addBookController.getCount(), name, author, Integer.valueOf(countPager)));
        System.out.println(addBookController.getCount());
        resp.sendRedirect(URL_INDEX);
    }

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.getRequestDispatcher(URL_UPDATE).forward(req,resp);
    }
}