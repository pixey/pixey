const closeDrawerType = 'DRAWER_CLOSE';
const openDrawerType = 'DRAWER_OPEN';
const initialState = { isOpen: true };

export const actionCreators = {
  closeNav: () => ({ type: closeDrawerType }),
  openNav: () => ({ type: openDrawerType })
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === closeDrawerType) {
    return { ...state, isOpen: false };
  }

  if (action.type === openDrawerType) {
    return { ...state, isOpen: true };
  }

  return state;
};
