package com.example.demo1;

import java.util.ArrayList;
import java.util.List;


// Класс описывающий нашего пользователя
public class UserAccount {
   // контанты с полом
   public static final String GENDER_MALE = "M";
   public static final String GENDER_FEMALE = "F";

   // Поля структуры
   private String userName;
   private String gender;
   private String password;

   // Список ролей пользователя
   private List<String> roles;

   // Конструктор по умолчанию
   public UserAccount() {

   }

   //Конструктор инициализации пользователя
   public UserAccount(String userName, String password, String gender, String... roles) {
      this.userName = userName;
      this.password = password;
      this.gender = gender;

      this.roles = new ArrayList<String>();
      if (roles != null) {
         for (String r : roles) {
            this.roles.add(r);
         }
      }
   }

   // Ниже предствленны гетеры и сетеры для всех полей структуры

   public String getUserName() {
      return userName;
   }

   public void setUserName(String userName) {
      this.userName = userName;
   }

   public String getGender() {
      return gender;
   }

   public void setGender(String gender) {
      this.gender = gender;
   }

   public String getPassword() {
      return password;
   }

   public void setPassword(String password) {
      this.password = password;
   }

   public List<String> getRoles() {
      return roles;
   }

   public void setRoles(List<String> roles) {
      this.roles = roles;
   }
}