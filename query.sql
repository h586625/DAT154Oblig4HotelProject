DROP TABLE IF EXISTS [dbo].[Reservation];
DROP TABLE IF EXISTS [dbo].[Todo];
DROP TABLE IF EXISTS [dbo].[Room];
DROP TABLE IF EXISTS [dbo].[User];

CREATE TABLE [dbo].[Room] (
	roomnr int NOT NULL PRIMARY KEY,
	beds int NOT NULL,
	size int NOT NULL,
	price int NOT NULL,
	available bit NOT NULL,
	in_order bit NOT NULL,
);

CREATE TABLE [dbo].[User] (
	id int NOT NULL PRIMARY KEY,
	email varchar(128) NOT NULL UNIQUE,
	password varchar(256) NOT NULL,
);

CREATE TABLE [dbo].[Reservation] (
	id int NOT NULL PRIMARY KEY,
	roomnr int FOREIGN KEY REFERENCES Room(roomnr),
	userid int FOREIGN KEY REFERENCES "User"(id),
	
);

CREATE TABLE [dbo].[Todo] (
	id int NOT NULL PRIMARY KEY,
	roomnr int FOREIGN KEY REFERENCES Room(roomnr),
	cleaned bit NOT NULL,
	maintained bit NOT NULL,
	serviced bit NOT NULL,
	notes text,
);

INSERT INTO [dbo].[Room] (roomnr, beds, size, price, available, in_order) VALUES
(100, 2, 12, 950, 1, 1),
(207, 2, 12, 950, 1, 0);

INSERT INTO [dbo].[Todo] (id, roomnr, cleaned, maintained, serviced, notes) VALUES
(1, 100, 1, 1, 1, null),
(2, 207, 0, 0, 1, 'It is a warzone.');

SELECT * FROM [dbo].[Todo];