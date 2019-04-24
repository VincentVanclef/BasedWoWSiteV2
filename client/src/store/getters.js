export const productGetters = {
  // All products
  allProducts: (state, getters) => {
    return state.products;
  },
  productById: (state, getters) => id => {
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
  GetAuthStatus: state => state.User.Status,
  GetToken: state => state.User.Token,
  GetUser: state =>  state.User.User 
}

export const voteGetters = {
  GetVoteLoadStatus: state => () => { return state.Vote.Sites.Loading || state.Vote.Timers.Loading },
  GetVoteSites: state => state.Vote.Sites.Data,
  GetVoteTimers: state => state.Vote.Timers.Data,
  GetVoteStatus: state => state.Vote.Status
}

export const newsGetters = {
  GetNewsStatus: state => state.News.Loading,
  GetNewsData: state => state.News.Data
}