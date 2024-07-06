CREATE TABLE Professor (
    pId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Family VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    Phonenumber VARCHAR(20) NOT NULL
);

CREATE TABLE Student (
	sId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Family VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    Phonenumber VARCHAR(20) NOT NULL
);

CREATE TABLE Course (
	cId INT IDENTITY(1,1) PRIMARY KEY,
	Title VARCHAR(255) NOT NULL,
	Semester INT NOT NULL,
	Department VARCHAR(255) NOT NULL,
	pId INT NOT NULL
	FOREIGN KEY (pId) REFERENCES Professor(pId)
);

CREATE TABLE Registration(
	sId INT NOT NULL,
	cId INT NOT NULL,
	Grade DECIMAL(5,2),
	PRIMARY KEY (sId, cId),
	FOREIGN KEY (sId) REFERENCES Student(sId),
	FOREIGN KEY (cId) REFERENCES Course(cId)
);

CREATE TABLE Files(
	fId INT,
	Title VARCHAR(255) NOT NULL,
	Link VARCHAR(255) NOT NULL,
	cId INT,
	PRIMARY KEY (fId, cId),
	FOREIGN KEY (cId) REFERENCES Course(cId)
);

CREATE TABLE Exams(
	eId INT,
	Title VARCHAR(255) NOT NULL,
	Due datetime NOT NULL,
	Questions VARCHAR(255) NOT NULL,
	Answers VARCHAR(255) NOT NULL,
	cId INT
	PRIMARY KEY (eId, cId),
	FOREIGN KEY (cId) REFERENCES Course(cId)
);

CREATE TABLE Registration_Request(
	sId INT NOT NULL,
	cId INT NOT NULL,
	PRIMARY KEY (sId, cId),
	FOREIGN KEY (sId) REFERENCES Student(sId),
	FOREIGN KEY (cId) REFERENCES Course(cId)
);