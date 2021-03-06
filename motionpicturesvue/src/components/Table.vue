<template>
  <div class="container-fluid">
      <table class="table table-dark">
      <thead>
          <tr>
              <th class="table-dark">Name</th>
              <th class="table-dark">Description</th>
              <th class="table-dark">Release Year</th>
              <th class="table-dark">Actions</th>
          </tr>
      </thead>
      <tbody>
          <tr v-for="motionPicture in motionPictures" :key="motionPicture.id">
              <td>{{motionPicture.name}}</td>
              <td>{{motionPicture.description}}</td>
              <td>{{motionPicture.releaseYear}}</td>
              <td><button class="btn btn-warning btn-sm">Edit</button>
              <button class="btn btn-success btn-sm">Copy</button>
              <button class="btn btn-danger btn-sm">Delete</button></td>
          </tr>
      </tbody>
      </table>
  </div>
</template>

<script>
export default {
    name: 'PictureTable',
    computed: {
        motionPictures() {
            return this.$store.state.motionPictures;
        }
    }
}
</script>

<style>

</style>