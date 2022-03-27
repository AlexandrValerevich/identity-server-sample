package com.example.demo1;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

//Класс режимов доступа
public class SecurityConfig {
	//константа ролей
	public static final String ROLE_MANAGER = "MANAGER";
	public static final String ROLE_EMPLOYEE = "EMPLOYEE";

	//мапа для конфигурации определенных ролей
	private static final Map<String, List<String>> mapConfig = new HashMap<String, List<String>>();

	/** 
	 * Блок инициализации, в котором объявлен лист, в нем содержится url ссылки,
	 * которые доступны  для определенных ролей 
	 */
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

	// Сетеры
	public static Set<String> getAllAppRoles() {
		return mapConfig.keySet();
	}

	public static List<String> getUrlPatternsForRole(String role) {
		return mapConfig.get(role);
	}

}