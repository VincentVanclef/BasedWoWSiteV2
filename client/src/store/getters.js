export const mainGetters = {
  GetPageTitle: state => state.PageTitle,
  GetUnstuckLocations: state => state.UnstuckLocations
};

export const voteGetters = {
  GetVoteLoadStatus: state => () => {
    return state.Vote.Sites.Loading || state.Vote.Timers.Loading;
  },
  GetVoteSites: state => state.Vote.Sites.Data,
  GetVoteTimers: state => state.Vote.Timers.Data,
  GetVoteStatus: state => state.Vote.Status
};

export const changelogGetters = {
  GetChangelogCategories: state => state.Changelog.Categories.Data,
  GetChangelogCategoriesStatus: state => state.Changelog.Categories.Loading,
  GetChangelogChanges: state => state.Changelog.Changes.Data,
  GetChangelogChangesStatus: state => state.Changelog.Changes.Loading
};

export const pvpStatsGetters = {
  GetTopArenaTeams: state => state.PvPStats.TopArenaTeams,
  GetTopTeamMembers: state => state.PvPStats.TopTeamMembers,
  GetTopHKPlayers: state => state.PvPStats.TopHKPlayers
};
