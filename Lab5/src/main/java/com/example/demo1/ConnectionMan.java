package com.example.demo1;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;


/**
 * The type Connection man.
 */
public class ConnectionMan {

    /**
     * The Jdbc driver.
     */
    static final String JDBC_DRIVER = "org.postgresql.Driver";
    /**
     * The Jdbc db url.
     */
    static final String JDBC_DB_URL = "jdbc:postgresql://localhost:5432/authentication";
    /**
     * The Jdbc user.
     */
    static final String JDBC_USER = "postgres";
    /**
     * The Jdbc pass.
     */
    static final String JDBC_PASS = "xwbk01xn17";
    
    private static Connection connection = null;


    /**
     * Gets connection.
     *
     * @return the connection
     */
    public static Connection getConnection() {
        if (connection == null) {
           connection = setNewConnection();
        }
        return connection;
    }
    
     
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

