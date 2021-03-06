<template>
  <div>
      <form>
          <label for="name">Name</label>
          <input v-model.trim="motionPicture.name" type="text" class="form-control" required id="name">
          <label for="description" class="form-label">Description</label>
          <textarea v-model.trim="motionPicture.description" maxlength="500" class="form-control" id="description"></textarea>
          <label for="release-year" class="form-label">Release Year</label>
          <input v-model.number="motionPicture.releaseYear" maxlength="4" type="text" placeholder="YYYY" class="form-control" required id="release-year">
          <button :show-form="showForm" @click.prevent="showForm != showForm" class="btn btn-danger">Cancel</button>
          <button @click.prevent="addMotionPicture" class="btn btn-success">Save</button>
      </form>
  </div>
</template>

<script>
import MotionPictureService from '../service/MotionPictureService';
export default {
    name: "PictureForm",
    data() {
        return {
            motionPicture: {
                id: Number,
                name: "",
                description: "",
                releaseYear: ""
            }
        }
    },
    methods: {
        clearForm() {
            
        },
        addMotionPicture() {
            MotionPictureService.addMotionPicture(this.motionPicture)
            .then(response => {
                if(response.status == 201)
                {
                    MotionPictureService.getPictureByID(response.data.id)
                    .then(secondResponse => {
                        if(secondResponse.status == 200) {
                            this.$store.commit('LOAD_PICTURES', secondResponse.data);
                        }
                    })
                }
            })
        }
    },
    
}
</script>

<style>

</style>