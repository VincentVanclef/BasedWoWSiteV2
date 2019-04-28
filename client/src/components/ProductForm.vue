<template lang="html">
  <div class="container">
    <form @submit.prevent="saveProduct">
      <div class="row">
        <div class="col-lg-4">
          <div class="form-group">
            <label>Name</label>
            <input
              type="text"
              placeholder="Name"
              v-model="model.name"
              v-validate="'required|alpha|min:3'"
              name="name"
              :class="{'form-control': true, 'error': errors.has('name') }"
            >
            <span
              class="small text-danger"
              v-for="error in errors.collect('name')"
              :key="error.id"
            >{{ error }}</span>
          </div>
          <div class="form-group">
            <label>Price</label>
            <input
              type="number"
              class="form-control"
              placeholder="Price"
              v-model="model.price"
              v-validate="'required|min:2|decimal:2'"
              name="price"
              :class="{'form-control': true, 'error': errors.has('price') }"
            >
            <span
              class="small text-danger"
              v-for="error in errors.collect('price')"
              :key="error.id"
            >{{ error }}</span>
          </div>
          <div class="form-group">
            <label>Manufacturer</label>
            <select
              type="text"
              class="form-control"
              v-model="model.manufacturer"
              v-validate="'required'"
              name="manufacturer"
              :class="{'form-control': true, 'error': errors.has('manufacturer') }"
            >
              <template v-for="manufacturer in manufacturers">
                <option
                  :key="manufacturer._id"
                  :value="manufacturer._id"
                  :selected="manufacturer._id == (model.manufacturer && model.manufacturer._id)"
                >{{manufacturer.name}}</option>
              </template>
            </select>
            <span
              class="small text-danger"
              v-show="errors.has('manufacturer')"
            >Manufacturer is required</span>
          </div>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
          <div class="form-group">
            <label>Image</label>
            <input
              type="text"
              lass="form-control"
              placeholder="Image"
              v-model="model.image"
              v-validate="'required|url'"
              name="image"
              :class="{'form-control': true, 'error': errors.has('image') }"
            >
            <span
              class="small text-danger"
              v-for="error in errors.collect('image')"
              :key="error.id"
            >{{ error }}</span>
          </div>
          <div class="form-group">
            <label>Description</label>
            <textarea
              type="number"
              class="form-control"
              placeholder="Description"
              rows="5"
              style="height: 125px;"
              v-model="model.description"
              v-validate="'required|min:20'"
              name="description"
              :class="{'form-control': true, 'error': errors.has('description') }"
            ></textarea>
            <span
              class="small text-danger"
              v-for="error in errors.collect('description')"
              :key="error.id"
            >{{ error }}</span>
          </div>
        </div>
      </div>
      <div class="form-group">
        <button class="button">
          <i class="fa fa-pencil"></i>
          <span v-if="isEditing">Update Product</span>
          <span v-else>Add Product</span>
        </button>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  props: ["model", "manufacturers", "isEditing"],
  methods: {
    async saveProduct() {
      this.$http.post();
    }
  }
};
</script>

<style>
</style>
