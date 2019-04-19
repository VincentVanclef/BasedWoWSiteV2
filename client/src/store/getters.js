export const productGetters = {
  // All products
  allProducts: (state, getters) => {
    return state.products;
  },
  productById: (state, gettters) => id => {
    if (getters.allProducts.length > 0) {
      return getters.allProducts.filter(p => p._id === id)[0];
    } else {
      return state.product;
    }
  }
};

export const manufacturerGetters = {
  // All manufacturers
  allManufacturers: state => state.manufacturers
};

export const authGetters = {
  isLoggedIn: state => {
     const token = state.User.Token
     if (!token) { return false; } 

     const data = JSON.parse(atob(token.split('.')[1]))
     const exp = new Date(data.exp * 1000) // JS deals with dates in milliseconds since epoch
     const now = new Date()
     return now < exp
    },
  authStatus: state => state.User.Status,
  token: state => state.User.Token,
  user: state => JSON.parse(state.User.User),
}
