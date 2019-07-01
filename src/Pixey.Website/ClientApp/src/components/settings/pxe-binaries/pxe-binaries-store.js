const refreshBinaries = 'PXE_BINARIES_REFRESH';

const initialState = { versions: {} };

export const actionCreators = {
  refresh: () => ({ type: refreshBinaries }),
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === refreshBinaries) {
    return { ...state, binaries: {} };
  }

  return state;
};
