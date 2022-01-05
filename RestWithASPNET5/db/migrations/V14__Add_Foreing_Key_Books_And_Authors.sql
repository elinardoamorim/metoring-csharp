ALTER TABLE books
ADD CONSTRAINT FK_books_authors
FOREIGN KEY (author_id) REFERENCES authors(id);