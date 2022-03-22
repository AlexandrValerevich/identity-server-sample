package com.example.demo1;

import java.util.HashMap;
import java.util.Map;




// Данный класс предназначен для взаимодействия с базой данных
public class DataDAO {
   
   // Заглушка для базы данных. База данных предоставленная в виде словаря ключ-значение. 
   private static final Map<String, UserAccount> mapUsers = new HashMap<String, UserAccount>();

   
   // Инициализаци полей структуры.
   {
      UserAccount emp = new UserAccount("employee1", "123", UserAccount.GENDER_MALE, //
            SecurityConfig.ROLE_EMPLOYEE);
      UserAccount mng = new UserAccount("manager1", "123", UserAccount.GENDER_MALE, //
            SecurityConfig.ROLE_EMPLOYEE, SecurityConfig.ROLE_MANAGER);
      mapUsers.put(emp.getUserName(), emp);
      mapUsers.put(mng.getUserName(), mng);
   }

   /*
      Метод поиска пользователя по имени и паролю. 
      В случае аунтефикации пользователя возращается структура данных с пользователем.
      Если неудалось аунтефицировать пользователя возращается null.
   */
   public static UserAccount findUser(String userName, String password) {
      UserAccount u = mapUsers.get(userName);
      if (u != null && u.getPassword().equals(password)) {
         return u;
      }
      return null;
   }

}