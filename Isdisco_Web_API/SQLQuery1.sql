CREATE TABLE users (
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Fullname varchar(120) NOT NULL,
	Firstname varchar(60) NOT NULL,
	Email varchar(90) NOT NULL UNIQUE,
	AppToken varchar(255),
	FacebookToken varchar(255),
	VIP bit DEFAULT 0
	);


INSERT INTO users (Fullname, Firstname, Email, AppToken)
VALUES ('Rasmus Gregersen', 'Rasmus', 'raller799@live.dk', 'F9659290C65335689BB1F300EDDFDEC036BB3D32E78DB726879049AD487B333D');




SELECT * FROM users;




--DROP TABLE users;