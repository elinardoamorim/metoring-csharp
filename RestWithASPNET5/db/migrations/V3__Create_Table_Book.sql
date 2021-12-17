CREATE TABLE book (
	id BIGINT IDENTITY(1,1) PRIMARY KEY,
	title VARCHAR(255),
	author VARCHAR(255),
	launch_date DateTime,
	price DECIMAL(10, 2)
);