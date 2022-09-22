CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

SELECT * FROM accounts


-- Active: 1663174271535@@SG-SQL-FIrst-Try-6712-mysql-master.servers.mongodirector.com@3306@firstTry
-- Orders
CREATE TABLE Orders(
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL, 
    total INT NOT NULL DEFAULT 0,
    screenshot varchar(255) NOT NULL,
    creatorId VARCHAR(255) NOT NULL,

    FOREIGN KEY (creatorId) REFERENCES accounts(id)
) DEFAULT charset utf8;

DROP TABLE `Orders`;

SELECT * FROM `Orders`;

INSERT INTO `Orders`
(name, total, screenshot, creatorId)
VALUES
("Peanut Butter Perfection", 7, "https://static.onecms.io/wp-content/uploads/sites/24/2022/04/15/2686501_Bount_Mint_julep_tea_254_silo-2000.jpg", "6328c5a5f170ebe2ab203b70");


-- Ingredients
CREATE TABLE Ingredients(
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL, 
    price INT NOT NULL DEFAULT 0,
    image varchar(255) NOT NULL,
    creatorId VARCHAR(255) NOT NULL,

    FOREIGN KEY (creatorId) REFERENCES accounts(id)
) DEFAULT charset utf8;

 SELECT
i.*,
a.*
FROM Ingredients i
JOIN accounts a ON a.id = i.creatorId;

INSERT INTO `Ingredients`
(name, price, image, creatorId)
VALUES
("Reese's", 2, "http://throughherlookingglass.com/wp-content/uploads/2016/09/Chocolate-Peanut-Butter-Trifle6.jpg", "6328c5a5f170ebe2ab203b70");


-- Favorties

CREATE TABLE IF NOT EXISTS favorities(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  orderId INT NOT NULL,
  accountId VARCHAR(255),

  FOREIGN KEY (orderId) REFERENCES Orders(id) ON DELETE CASCADE,
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';


SELECT 
  o.*,
  a.*
FROM Orders o 
JOIN accounts a On a.id = o.creatorId
Where o.id = 3;

INSERT INTO favorities
(orderId, accountId)
VALUES
(3, '6328c5a5f170ebe2ab203b70');

SELECT 
a.*,
f.*
FROM favorities f
JOIN accounts a ON a.id = f.accountId
WHERE f.orderId = 3;

 INSERT INTO favorites
(orderId, accountId)
VALUES
(@orderId, @accountId);
