export default {
  data() {
    return {};
  },
  created() {},
  methods: {
    GetErrorMessage(error) {
      if (error.response) {
        return error.response.data.message;
      }

      return error;
    }
  }
};
