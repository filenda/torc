-- Create the book_library_db database
CREATE DATABASE book_library_db;

-- Connect to the book_library_db database
\c book_library_db;

-- Create the books table
CREATE TABLE books (
    book_id SERIAL PRIMARY KEY,
    title VARCHAR(100) NOT NULL,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    total_copies INT NOT NULL DEFAULT 0,
    copies_in_use INT NOT NULL DEFAULT 0,
    type VARCHAR(50),
    isbn VARCHAR(80),
    category VARCHAR(50)
);

-- Create full-text search index for book title
CREATE INDEX idx_book_title ON books USING gin(to_tsvector('english', title));

-- Create full-text search index for publisher
CREATE INDEX idx_publisher ON books USING gin(to_tsvector('english', publisher));

-- Create full-text search index for authors (assuming first_name and last_name are concatenated)
CREATE INDEX idx_authors ON books USING gin(to_tsvector('english', CONCAT(first_name, ' ', last_name)));

-- Create full-text search index for category
CREATE INDEX idx_category ON books USING gin(to_tsvector('english', category));

-- Insert initial data into the books table
INSERT INTO books (title, first_name, last_name, total_copies, copies_in_use, type, isbn, category)
VALUES ('Pride and Prejudice', 'Jane', 'Austen', 100, 80, 'Hardcover', '1234567891', 'Fiction'),
       ('To Kill a Mockingbird', 'Harper', 'Lee', 75, 65, 'Paperback', '1234567892', 'Fiction'),
       ('The Catcher in the Rye', 'J.D.', 'Salinger', 50, 45, 'Hardcover', '1234567893', 'Fiction'),
       ('The Great Gatsby', 'F. Scott', 'Fitzgerald', 50, 22, 'Hardcover', '1234567894', 'Non-Fiction'),
       ('The Alchemist', 'Paulo', 'Coelho', 50, 35, 'Hardcover', '1234567895', 'Biography'),
       ('The Book Thief', 'Markus', 'Zusak', 75, 11, 'Hardcover', '1234567896', 'Mystery'),
       ('The Chronicles of Narnia', 'C.S.', 'Lewis', 100, 14, 'Paperback', '1234567897', 'Sci-Fi'),
       ('The Da Vinci Code', 'Dan', 'Brown', 50, 40, 'Paperback', '1234567898', 'Sci-Fi'),
       ('The Grapes of Wrath', 'John', 'Steinbeck', 50, 35, 'Hardcover', '1234567899', 'Fiction'),
       ('The Hitchhiker''s Guide to the Galaxy', 'Douglas', 'Adams', 50, 35, 'Paperback', '1234567900', 'Non-Fiction'),
       ('Moby-Dick', 'Herman', 'Melville', 30, 8, 'Hardcover', '8901234567', 'Fiction'),
       ('To Kill a Mockingbird', 'Harper', 'Lee', 20, 0, 'Paperback', '9012345678', 'Non-Fiction'),
       ('The Catcher in the Rye', 'J.D.', 'Salinger', 10, 1, 'Hardcover', '0123456789', 'Non-Fiction');
