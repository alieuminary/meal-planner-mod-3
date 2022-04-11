USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO

BEGIN TRANSACTION;

CREATE TABLE accounts
(
	account_id int identity(1,1),
	user_id int not null,
	first_name varchar(100),
	last_name varchar(100),
	address varchar(200),
	zipcode int,
	state char(2),
	phone_number int,
	email varchar(100),
	CONSTRAINT PK_accounts PRIMARY KEY (account_id),
	CONSTRAINT FK_accounts_users FOREIGN KEY (user_id) REFERENCES users(user_id)
);
CREATE TABLE cuisine
(
	cuisine_id int identity(1,1),
	name varchar(50) not null,
	CONSTRAINT PK_cuisine PRIMARY KEY (cuisine_id),
);
CREATE TABLE recipes
(
	recipe_id int identity(1,1),
	recipe_name varchar(100) not null,
	description varchar(500),
	prep_time time,
	cook_time time,
	date_created date,
	user_id int not null,
	cuisine_id int not null,
	CONSTRAINT PK_recipes PRIMARY KEY (recipe_id),
	CONSTRAINT FK_recipes_users FOREIGN KEY (user_id) REFERENCES users(user_id),
	CONSTRAINT FK_recipes_cuisine FOREIGN KEY (cuisine_id) REFERENCES cuisine(cuisine_id),
);
CREATE TABLE food_type
(
	type_id int identity(1,1),
	name varchar(50) not null,
	isFresh bit not null,
	CONSTRAINT PK_food_type PRIMARY KEY (type_id),
);
CREATE TABLE ingredient
(
	ingred_id int identity(1,1),
	name varchar(100) not null,
	cost money not null,
	type_id int not null,
	CONSTRAINT PK_ingredient PRIMARY KEY (ingred_id),
	CONSTRAINT FK_ingredient_food_type FOREIGN KEY (type_id) REFERENCES food_type (type_id),
);
CREATE TABLE recipes_ingredients
(
	recipe_id int not null,
	ingred_id int not null,
	CONSTRAINT PK_recipes_ingredients PRIMARY KEY (recipe_id, ingred_id),
	CONSTRAINT FK_recipes_ingredients_recipes FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id),
	CONSTRAINT FK_recipes_ingredients_ingredient FOREIGN KEY (ingred_id) REFERENCES ingredient(ingred_id),
);
CREATE TABLE directions
(
	steps_id int not null,
	description varchar(500),
	step_number int,
	recipe_id int not null,
	CONSTRAINT PK_directions PRIMARY KEY(steps_id),
	CONSTRAINT FK_directions_recipes FOREIGN KEY (recipe_id) REFERENCES recipes(recipe_id)
);
CREATE TABLE planner
(
	planner_id int not null,
	name varchar(50),
	recipe_id int,
	user_id int,
	day varchar(20),
	week int,
	isSharable bit not null,
	CONSTRAINT PK_planner PRIMARY KEY(planner_id),
	CONSTRAINT FK_planner_recipes FOREIGN KEY(recipe_id) REFERENCES recipes(recipe_id),
	CONSTRAINT FK_planner_users FOREIGN KEY(user_id) REFERENCES users(user_id),
	CONSTRAINT CHK_day CHECK (day IN ('sunday', 'monday', 'tuesday', 'wednesday', 'thursday', 'friday', 'saturday')),
);