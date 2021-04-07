-- USE nathansburgs;

-- DROP TABLE cars;

-- NOTE: Create table, cars
-- CREATE TABLE cars
-- (
--    id INT AUTO_INCREMENT,
--    make VARCHAR(63) NOT NULL,
--    model VARCHAR(63) NOT NULL,
--    color VARCHAR(63),
--    price DECIMAL(6, 2) NOT NULL,
--    mileage INT NOT NULL,
--    year INT,
--    PRIMARY KEY (id)
-- );

-- NOTE: Create a car
-- INSERT INTO cars
-- (make, model, color, price, mileage, year)
-- VALUES
-- ("Honda", "Civic", "Gray", 5000.00, 106500, 2005);

-- NOTE: Select all cars
-- SELECT * FROM cars;



-- NOTE: Houses
-- CREATE TABLE houses
-- (
--    id INT AUTO_INCREMENT,
--    bedrooms INT NOT NULL,
--    bathrooms INT NOT NULL,
--    price DECIMAL(8, 2) NOT NULL,
--    address VARCHAR(255),
--    description VARCHAR(255),
--    PRIMARY KEY (id)
-- )

-- INSERT INTO houses
-- (bedrooms, bathrooms, price, address, description)
-- VALUES
-- (2, 3, 250000.50, "1234 null island", "");

-- SELECT * FROM houses;



-- NOTE: Jobs
-- CREATE TABLE jobs
-- (
--    id INT AUTO_INCREMENT,
--    title VARCHAR(255) NOT NULL,
--    company VARCHAR(255) NOT NULL,
--    description VARCHAR(255),
--    rate INT,
--    PRIMARY KEY (id)
-- );

-- INSERT INTO jobs
-- (title, company, description, rate)
-- VALUES
-- ("D-Class Personelle", "Secure Contain Protect foundation", "", 000);

-- SELECT * FROM jobs;






















-- NOTE: Tims code

-- NOTE this is creating the table to put burgers in

/* -- CREATE TABLE burgers
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL UNIQUE,
--   description VARCHAR(255),
--   price DECIMAL(6 , 2) NOT NULL,
--   PRIMARY KEY (id)
-- ); */

-- NOTE this is creating actual burger

-- INSERT INTO burgers
-- (name, description, price)
-- VALUES
-- ("Howdy Jonesy", "Brisket", 40)

-- Get All of a collection
-- SELECT * FROM burgers;

-- Get a specific from a collection

-- SELECT * FROM burgers WHERE description="Brisket" OR id=1;

-- DELETE FROM burgers WHERE id=1;

-- DELETE burgers;
-- TRUNCATE burgers;