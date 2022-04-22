package com.example.demo1;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;


/**
 * The type Data dao.
 */
public class DataDAO {

    /**
     * Find user user account.
     *
     * @param userName the user name
     * @param password the password
     * @return the user account
     * @throws SQLException the sql exception
     */
    public static UserAccount findUser(String userName, String password) throws SQLException {
        UserAccount u = findByName(userName);
        if (u != null && checkPassword(u, password)) {
            return u;
        }
        return null;
    }


    /**
     * Find by name user account.
     *
     * @param name the name
     * @return the user account
     * @throws SQLException the sql exception
     */
    public static UserAccount findByName(String name) throws SQLException {
        UserAccount user = null;
        ResultSet resObj =  getUsersFromDB(name);

        while (resObj.next()) {
            user = new UserAccount();
            String userName = resObj.getString("name");
            user.setUserName(userName);
            String password = resObj.getString("password");
            user.setPassword(password);
            String gender = resObj.getString("gender");
            user.setGender(gender);
        }
  
        return user;
    }

    
    private static ResultSet getUsersFromDB(String name){

        ResultSet resObj = null;
        
        try {
            Connection connection = ConnectionMan.getConnection();

            String query = "SELECT DISTINCT name, password, gender FROM \"user\" WHERE name=?";
            PreparedStatement prepStatement = connection.prepareStatement(query);
            prepStatement.setString(1, name);

            resObj = prepStatement.executeQuery();
        } catch (SQLException exception) {
            exception.printStackTrace();
        }
        return resObj;
    }


    private static boolean checkPassword(UserAccount user, String password) {
        return user.getPassword().equals(password);
    }
}
