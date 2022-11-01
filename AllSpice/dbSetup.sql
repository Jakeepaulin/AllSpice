-- Active: 1666715468584@@SG-legend-pirate-8653-6837-mysql-master.servers.mongodirector.com@3306@garbagestuff
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS recipes (
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR (255) NOT NULL,
  instructions VARCHAR (255) NOT NULL,
  img VARCHAR (255) NOT NULL,
  category VARCHAR (255) NOT NULL,
  creatorId VARCHAR (255) NOT NULL,
  Foreign Key (creatorId) REFERENCES accounts(id)
)default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS ingredients (
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR (255) NOT NULL,
  quantity VARCHAR (255) NOT NULL,
  recipeId int NOT NULL,
  Foreign Key (recipeId) REFERENCES recipes(id)
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS favorites (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  accountId VARCHAR (255) NOT NULL,
  recipeId int NOT NULL,
  Foreign Key (accountId) REFERENCES accounts(id),
  Foreign Key (recipeId) REFERENCES recipes(id)
)default charset utf8 COMMENT '';

DROP Table favorites;