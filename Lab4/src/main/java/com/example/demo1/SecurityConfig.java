package com.example.demo1;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;



// Класс предназначен для создания ролей которые присутствуют в системе
public class SecurityConfig {
	
	// Константы в которых хранятся имена ролей 
	public static final String ROLE_MANAGER = "MANAGER";
	public static final String ROLE_EMPLOYEE = "EMPLOYEE";

	// Хранилище ролей и доступные им команды
	private static final Map<String, List<String>> mapConfig = new HashMap<String, List<String>>();
	 
	// Блок инициализации
	{
		List<String> urlPatterns1 = new ArrayList<String>();

		urlPatterns1.add("/userInfo");
		urlPatterns1.add("/employeeTask");

		mapConfig.put(ROLE_EMPLOYEE, urlPatterns1);

		List<String> urlPatterns2 = new ArrayList<String>();

		urlPatterns2.add("/userInfo");
		urlPatterns2.add("/managerTask");

		mapConfig.put(ROLE_MANAGER, urlPatterns2);
	}

	// возращает все возможные роли 
	public static Set<String> getAllAppRoles() {
		return mapConfig.keySet();
	}
	// возращает возможные действия пользователя
	public static List<String> getUrlPatternsForRole(String role) {
		return mapConfig.get(role);
	}

}