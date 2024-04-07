document.getElementById('searchForm').addEventListener('submit', async (e) => {
  e.preventDefault();
  const formData = new FormData(e.target);
  const searchField = formData.get('searchField');
  const searchQuery = formData.get('searchQuery');

  try {
    const response = await axios.post('/search', { searchField, searchQuery });
    const books = response.data;
    displayBooks(books);
  } catch (error) {
    console.error(error);
  }
});

function displayBooks(books) {
  const table = document.getElementById('resultsTable');
  table.innerHTML = ''; // Clear existing table contents

  // Create table headers
  const headers = ['Book Title', 'Author', 'Type', 'ISBN', 'Category', 'Available Copies'];
  const headerRow = table.insertRow();
  headers.forEach(header => {
    const th = document.createElement('th');
    th.textContent = header;
    headerRow.appendChild(th);
  });

  // Populate table rows with book data
  books.books.forEach(book => {

    const wantedFields = { title: book.title, author: book.author, type: book.type, isbn: book.isbn, category: book.category, available_copies: book.totalCopies - book.copiesInUse }
    const row = table.insertRow();
    Object.values(wantedFields).forEach(value => {
      const cell = row.insertCell();
      cell.textContent = value;
    });
  });
}
