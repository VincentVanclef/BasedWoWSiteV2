export const mainGetters = {
  GetPageTitle: state => state.PageTitle,
  GetUnstuckLocations: state => state.UnstuckLocations
};

export const changelogGetters = {
  GetChangelogCategories: state => state.Changelog.Categories.Data,
  GetChangelogCategoriesStatus: state => state.Changelog.Categories.Loading,
  GetChangelogChanges: state => state.Changelog.Changes.Data,
  GetChangelogChangesStatus: state => state.Changelog.Changes.Loading
};
