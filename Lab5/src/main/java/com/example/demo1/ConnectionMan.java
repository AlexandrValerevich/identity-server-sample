package com.example.demo1;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

// Класс хранящий подключение к БД
public class ConnectionMan {
    // Данные для подключение к БД
    static final String JDBC_DRIVER = "org.postgresql.Driver";
    static final String JDBC_DB_URL = "jdbc:postgresql://localhost:5432/authentication";
    static final String JDBC_USER = "postgres";
    static final String JDBC_PASS = "xwbk01xn17";
    // Статическое поле, для хранения объект подключения к БД
    private static Connection connection = null;

    // Метод который возращает подключение к БД 
    public static Connection getConnection() {
        if (connection == null) {
           connection = setNewConnection();
        }
        return connection;
    }
    
    // метод который осуществляет начальную инициализацию объета соединения 
    private static Connection setNewConnection() {
        Connection newConnection = null;
        try {
            Class.forName(JDBC_DRIVER);
            newConnection =  DriverManager.getConnection(JDBC_DB_URL,
                                                         JDBC_USER, 
                                                         JDBC_PASS);
                
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
        return newConnection;
    }
}

