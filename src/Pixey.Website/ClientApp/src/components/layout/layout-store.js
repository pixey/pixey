const closeDrawerType = 'LAYOUT_NAV_DRAWER_CLOSE';
const openDrawerType = 'LAYOUT_NAV_DRAWER_OPEN';
const initialState = { isOpen: true };

export const actionCreators = {
  closeNavDrawer: () => ({ type: closeDrawerType }),
  openNavDrawer: () => ({ type: openDrawerType })
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
