DROP TABLE IF EXISTS CollectionItems;
DROP TABLE IF EXISTS Collections;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Images;
CREATE TABLE Users(
    
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Login TEXT NOT NULL,
    Email TEXT NOT NULL,
    Password TEXT NOT NULL
);
INSERT INTO Users (Login, Email, Password) VALUES ('MyLogin', 'test@test.com', '12345678');
SELECT * FROM Users;

CREATE TABLE Collections(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    User INTEGER,
    FOREIGN KEY(User) REFERENCES Users(Id)
);

CREATE TABLE Images(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT,
    Comment TEXT,
    Url TEXT,
    Path TEXT
);

CREATE TABLE CollectionItems(
    Collection INTEGER, 
    Item INTEGER,
    FOREIGN KEY(Collection) REFERENCES Collections(Id),
    FOREIGN KEY(Item) REFERENCES Images(Id)
);