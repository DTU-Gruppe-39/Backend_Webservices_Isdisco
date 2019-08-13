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



CREATE TABLE blacklist (
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TrackId varchar(90) NOT NULL UNIQUE,
	SongName varchar(90) NOT NULL,
	ArtistName varchar(90) NOT NULL,
	Image_small_url varchar(255) NOT NULL,
	Image_medium_url varchar(255) NOT NULL,
	Image_large_url varchar(255) NOT NULL,
	WebplayerLink varchar(255) NOT NULL
	)


CREATE TABLE feedback (
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserId int NOT NULL FOREIGN KEY REFERENCES users(ID),
	Tag varchar(30) NOT NULL,
	TheMessage varchar(2000) NOT NULL,
	)