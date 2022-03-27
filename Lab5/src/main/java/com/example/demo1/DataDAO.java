package com.example.demo1;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

// Предназначен для взаимодействия с БД, в данном классе представлена ввиде хэш мапе
public class DataDAO {

    // Аунтефикация пользователя
    public static UserAccount findUser(String userName, String password) throws SQLException {
        UserAccount u = findByName(userName);
        if (u != null && checkPassword(u, password)) {
            return u;
        }
        return null;
    }

    // Получаем пользователя по его имени из БД
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

    // Получение пользователей из БД
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

    // Проверка пароля
    private static boolean checkPassword(UserAccount user, String password) {
        return user.getPassword().equals(password);
    }
}
