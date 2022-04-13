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
 * The type Add book controller.
 */
public class AddBookController extends HttpServlet {
    private static final String URL_INDEX = "book.jsp";

    private long count;
    /**
     * The Books.
     */
    BooksDAO books = new BooksDAOImpl();

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {
        String name = req.getParameter("name");
        String author = req.getParameter("author");
        String countPager = req.getParameter("pages");
        books.addBook(new Book(++count, name, author,
                Integer.valueOf(countPager)));
        resp.sendRedirect(URL_INDEX);
    }

    /**
     * Gets count.
     *
     * @return the count
     */
    public long getCount() {
        return count;
    }
}
