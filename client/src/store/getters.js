export const mainGetters = {
  GetPageTitle: state => state.PageTitle
};

export const authGetters = {
  isLoggedIn: state => {
    const token = state.User.Token;
    if (!token) {
      return false;
    }

    const data = JSON.parse(atob(token.split(".")[1]));
    const exp = new Date(data.exp * 1000); // JS deals with dates in milliseconds since epoch
    const now = new Date();
    return now < exp;
  },
  GetAuthStatus: state => state.User.Status,
  GetToken: state => state.User.Token,
  GetUser: state => state.User.User
};

export const voteGetters = {
  GetVoteLoadStatus: state => () => {
    return state.Vote.Sites.Loading || state.Vote.Timers.Loading;
  },
  GetVoteSites: state => state.Vote.Sites.Data,
  GetVoteTimers: state => state.Vote.Timers.Data,
  GetVoteStatus: state => state.Vote.Status
};

export const newsGetters = {
  GetNewsStatus: state => state.News.Loading,
  GetNewsData: state => state.News.Data,
  GetNewsComments: state => newsId => {
    const comments = state.News.Comments.find(x => x.newsId == newsId);
    return comments.comments;
  },
  GetNewsCommentsStatus: state => newsId => {
    const comments = state.News.Comments.find(x => x.newsId == newsId);
    return comments.isLoading;
  }
};
