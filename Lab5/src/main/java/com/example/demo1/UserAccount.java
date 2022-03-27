package com.example.demo1;

import java.util.ArrayList;
import java.util.List;

// Описывает модели пользователя
public class UserAccount {
   // Константы описывающие пол
   public static final String GENDER_MALE = "M";
   public static final String GENDER_FEMALE = "F";
   
   // Поля описывающие нашего пользователя
   private String userName;
   private String gender;
   private String password;
   
   // Лист для хранение ролей
   private List<String> roles;
   
   // Конструктор по умолчанию
   public UserAccount() {

   }
   
   // Конструктор создания пользователя
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
   // Гетеры и сетеры
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