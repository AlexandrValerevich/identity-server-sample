package com.example.demo1.dao;

import com.example.demo1.ConnectionManager;
import com.example.demo1.models.Book;
import org.apache.log4j.LogManager;
import org.apache.log4j.Logger;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

/**
 * The type Books dao.
 */
public class BooksDAOImpl implements BooksDAO {
    private static final String SELECT_ALL = "SELECT id, name, author, countPages FROM \"book\" ORDER BY name ASC";
    private static final String SELECT_BOOK = "SELECT id, name, author, countPages FROM \"book\" WHERE id=? ORDER BY name ASC";
    private static final String UPDATE_BOOK = "UPDATE \"book\" SET name=?, author=?, countPages=? WHERE id=?";
    private static final String INSERT_BOOK = "INSERT INTO \"book\" (name, author, countPages) VALUES (?,?,?)";
    private static final  String DELETE_BOOK = "DELETE FROM \"book\" WHERE id=?";
    /**
     * The Logger.
     */
    protected final Logger logger = LogManager.getLogger(BooksDAOImpl.class);

    @Override
    public Book selectBookById(Long idBook) {
        try {
            PreparedStatement ps = ConnectionManager.getConnection().prepareStatement(SELECT_BOOK);
            ps.setLong(1, idBook);
            ResultSet rs = ps.executeQuery();
            rs.next();
            System.out.println(fillBook(rs).getId());
            System.out.println(fillBook(rs).getAuthor());
            return fillBook(rs);
        } catch (SQLException throwables) {
            throwables.printStackTrace();
            logger.error("Error SQL select book");
        }
        return null;
    }

    @Override
    public List<Book> selectAllBooks() {
        List<Book> list = new ArrayList<>();
        try {
            PreparedStatement ps = ConnectionManager.getConnection().prepareStatement(SELECT_ALL);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                list.add(fillBook(rs));
            }
        } catch (SQLException throwables) {
            logger.error("Error SQL select book");
        }
        return list;
    }


    @Override
    //TODO
    public void updateBook(Book book) {
        try {
            PreparedStatement ps = ConnectionManager.getConnection().prepareStatement(UPDATE_BOOK);
                ps.setString(1, book.getName());
                ps.setString(2, book.getAuthor());
                ps.setInt(3, book.getCountPages());
                ps.setLong(4, book.getId());
            System.out.println(book.getId());
            System.out.println(book.getName());
                ps.executeUpdate();
        } catch (SQLException e) {
            logger.error("Error SQL update book");
        }
    }

    @Override
    public void addBook(Book book) {
        try {
            PreparedStatement ps = ConnectionManager.getConnection().prepareStatement(INSERT_BOOK);
                ps.setString(1, book.getName());
                ps.setString(2, book.getAuthor());
                ps.setInt(3, book.getCountPages());
                ps.executeUpdate();
            } catch(SQLException e){
                logger.error("Error SQL add book");
            }
        }

    @Override
    public void deleteBook(Book book) {
        try {
            PreparedStatement ps = ConnectionManager.getConnection().prepareStatement(DELETE_BOOK);
            ps.setLong(1, book.getId());
        } catch (SQLException throwables) {
           logger.error("Error SQL delete book");
        }
    }

    /**
     * Fill book book.
     *
     * @param rs the rs
     * @return the book
     * @throws SQLException the sql exception
     */
    public Book fillBook(ResultSet rs) throws SQLException {
        long id = rs.getLong("id");
        String name = rs.getString("name");
        String author = rs.getString("author");
        Integer countPages = rs.getInt("countPages");
        return new Book(id, name, author, countPages);
    }
}
