<template>
  <product-form
    @save-product="addProduct()"
    v-bind:model="model"
    v-bind:manufacturers="manufacturers"
    v-bind:isEditing="false"
  ></product-form>
</template>

<script>
import ProductFrom from "@/components/ProductForm";
export default {
  props: {
    test: ""
  },
  data() {
    return {
      model: {},
      manufacturers: [
        {
          _id: "sam",
          name: "Samsung"
        },
        {
          _id: "apple",
          name: "Apple"
        }
      ]
    };
  },
  //    created () {
  //      this.$store.dispatch('allManufacturers')
  //    },
  //    computed: {
  //      manufacturers () {
  //        return this.$store.getters.allManufacturers
  //      }
  //    },
  //    methods: {
  //      addProduct (model) {
  //        console.log('model', model)
  //        this.$store.dispatch('addProduct', model)
  //      }
  //    },
  components: {
    "product-form": ProductFrom
  },
  methods: {
    addProduct() {
      console.log("test");
    }
  },
  created() {}
};
</script>