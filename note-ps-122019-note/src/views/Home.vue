<template>
  <div class="container">
    <div class="row">
      <div class="col-sm-10">
        <h1>Заметки</h1>
        <hr><br><br>
        <button type="button" class="btn btn-success btn-sm">Добавить заметку</button>
        <br><br>
        <table class="table table-hover">
          <thead>
              <tr>
              <th scope="col">Заголовок</th>
              <th scope="col">Содержимое</th>
              <th scope="col">Дата создания</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(book, index) in books" :key="index">
              <td>{{book.Title}}</td>
              <td>{{book.Body}}</td>
              <td>{{book.CreateDate}}</td>
              <td>
                <button type="button" class="btn btn-warning btn-sm">Изменить</button>
                <button type="button" class="btn btn-danger btn-sm">Удалить</button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>
<script>

import axios from 'axios';

export default {
  data() {
    return {
      books: [],
    };
  },
  methods: {
    getBooks() {
      const path = 'http://localhost:5000/books';
      axios.get(path)
        .then((res) => {
          this.books = res.data.books;
        })
        .catch((error) => {
          // eslint-отключение следующей строки
          console.error(error);
        });
    },
  },
  created() {
    this.getBooks();
  },
};
</script>