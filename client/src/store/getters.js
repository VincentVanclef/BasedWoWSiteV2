export const mainGetters = {
  GetPageTitle: state => state.PageTitle,
  GetUnstuckLocations: state => state.UnstuckLocations
};

export const adminGetters = {
  GetAdmins: state => state.Admin.Data,
  GetAdminStatus: state => state.Admin.Loading
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
  GetUser: state => state.User.User,
  GetAccountData: state => state.User.User.AccountData,
  GetBanData: state => state.User.User.BanData,
  GetCharacters: state => state.User.Characters
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

export const changelogGetters = {
  GetChangelogCategories: state => state.Changelog.Categories.Data,
  GetChangelogCategoriesStatus: state => state.Changelog.Categories.Loading,
  GetChangelogChanges: state => state.Changelog.Changes.Data,
  GetChangelogChangesStatus: state => state.Changelog.Changes.Loading
}

export const pvpStatsGetters = {
  GetTopArenaTeams: state => state.PvPStats.TopArenaTeams,
  GetTopTeamMembers: state => state.PvPStats.TopTeamMembers,
  GetTopHKPlayers: state => state.PvPStats.TopHKPlayers
}