const startDiagnostics = 'DIAGNOSTICS_START';
const cancelDiagnostics = 'DIAGNOSTICS_CANCEL';
const initialState = { 
  inProgress: false
};

export const actionCreators = {
  start: () => ({ type: startDiagnostics }),
  cancel: () => ({ type: cancelDiagnostics })
};

export const reducer = (state, action) => {
  state = state || initialState;

  // if (action.type === incrementCountType) {
  //   return { ...state, count: state.count + 1 };
  // }

  // if (action.type === decrementCountType) {
  //   return { ...state, count: state.count - 1 };
  // }

  return state;
};
