const startTroubleshooting = 'TROUBLESHOOTING_START';
const cancelTroubleshooting = 'TROUBLESHOOTING_CANCEL';
const troubleshootingStatusUpdate = 'TROUBLESHOOTING_STATUS_UPDATE';

const initialState = { 
  inProgress: false
};

export const actionCreators = {
  start: () => ({ type: startTroubleshooting }),
  cancel: () => ({ type: troubleshootingStatusUpdate }),
  updateStatus: (status) => ({
    type: troubleshootingStatusUpdate,
    status: status
  })
};

export const reducer = (state, action) => {
  state = state || initialState;

  // if (action.type === incrementCountType) {
  //   return { ...state, count: state.count + 1 };
  // }

  // if (action.type === decrementCountType) {
  //   return { ...state, count: state.count - 1 };
  // }

  if(action.type === troubleshootingStatusUpdate) {
    return { ...state, status: action.status }
  }

  return state;
};
