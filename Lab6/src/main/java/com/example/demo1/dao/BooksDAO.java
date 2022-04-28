package com.example.demo1.dao;

import com.example.demo1.models.Book;

import java.util.List;

/**
 * The interface Books dao.
 */
public interface BooksDAO {
    /**
     * Select book by id book.
     *
     * @param idBook the id book
     * @return the book
     */
    Book selectBookById(Long idBook);

    /**
     * Select all books list.
     *
     * @return the list
     */
    List<Book> selectAllBooks();

    /**
     * Update book.
     *
     * @param book the book
     */
    void updateBook(Book book);

    /**
     * Add book.
     *
     * @param book the book
     */
    void addBook(Book book);

    /**
     * Delete book.
     *
     * @param book the book
     */
    void deleteBook(Book book);
}