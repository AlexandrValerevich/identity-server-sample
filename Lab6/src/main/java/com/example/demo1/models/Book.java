package com.example.demo1.models;

import java.util.Objects;

/**
 * The type Book.
 */
public class Book {
    private Long id;
    private String name;
    private String author;
    private Integer countPages;

    /**
     * Instantiates a new Book.
     */
    public Book() {
    }

    /**
     * Instantiates a new Book.
     *
     * @param id         the id
     * @param name       the name
     * @param author     the author
     * @param countPages the count pages
     */
    public Book(Long id, String name, String author, Integer countPages) {
        this.id = id;
        this.name = name;
        this.author = author;
        this.countPages = countPages;
    }

    /**
     * Gets id.
     *
     * @return the id
     */
    public Long getId() {
        return id;
    }

    /**
     * Sets id.
     *
     * @param id the id
     */
    public void setId(Long id) {
        this.id = id;
    }

    /**
     * Gets name.
     *
     * @return the name
     */
    public String getName() {
        return name;
    }

    /**
     * Sets name.
     *
     * @param name the name
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * Gets author.
     *
     * @return the author
     */
    public String getAuthor() {
        return author;
    }

    /**
     * Sets author.
     *
     * @param author the author
     */
    public void setAuthor(String author) {
        this.author = author;
    }

    /**
     * Gets count pages.
     *
     * @return the count pages
     */
    public Integer getCountPages() {
        return countPages;
    }

    /**
     * Sets count pages.
     *
     * @param countPages the count pages
     */
    public void setCountPages(Integer countPages) {
        this.countPages = countPages;
    }

    @Override
    public String toString() {
        return "Book{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", author='" + author + '\'' +
                ", countPages=" + countPages +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Book book = (Book) o;
        return Objects.equals(id, book.id) &&
                Objects.equals(name, book.name) &&
                Objects.equals(author, book.author) &&
                Objects.equals(countPages, book.countPages);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, name, author, countPages);
    }
}
