const express = require('express');
const axios = require('axios');

const app = express();
const PORT = 3000;

app.use(express.static('public'));
app.use(express.urlencoded({ extended: true }));
app.use(express.json());

app.get('/', (req, res) => {
  res.sendFile(__dirname + '/public/index.html');
});

app.post('/search', async (req, res) => {
  try {
    const { searchField, searchQuery } = req.body;
    const response = await axios.get(`http://host.docker.internal:5000/api/books/search?${searchField}=${searchQuery}`);
    // const response = await axios.get(`http://localhost:5000/api/books/search?${searchField}=${searchQuery}`);
    res.json(response.data);
  } catch (error) {
    res.status(500).json({ error: 'Internal Server Error' });
  }
});

app.listen(PORT, () => {
  console.log(`Server running on port ${PORT}`);
});
