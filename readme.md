# Book Library Web Application

This project is a web application for managing a book library. It provides functionalities to search, add, update, and delete books in the library.

## How to Run Locally

To run the project locally, follow these steps:

1. Clone the repository to your local machine:
   ```
   git clone git@github.com:filenda/torc.git
   ```

2. Start the application using Docker Compose:
   ```
   docker-compose up --build
   ```

3. Access the application:
   - Web API: http://localhost:5000/swagger/index.html
   - Frontend: http://localhost:3000

## Services

The application consists of the following services:

- PostgreSQL Database: Stores book information.
- ASP.NET Core API: Provides RESTful endpoints for book operations.
- Frontend: User interface for interacting with the book library.

## API Endpoints
- GET /api/books/search?criteria=value: Search books by criteria (title, author, category).
- POST /api/books: Add a new book.
- PUT /api/books/{id}: Update an existing book by ID.
- DELETE /api/books/{id}: Delete a book by ID.
- GET /api/books: Retrieve all books.


## Technologies Used

- ASP.NET Core
- PostgreSQL w/ FTS indexes
- Docker
- MediatR (for command handling)
- NodeJS with express and plain HTML and JS (for frontend)

Feel free to explore and contribute to the project!
