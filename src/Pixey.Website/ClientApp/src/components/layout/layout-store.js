const closeDrawerType = 'LAYOUT_NAV_DRAWER_CLOSE';
const openDrawerType = 'LAYOUT_NAV_DRAWER_OPEN';
const toggleDrawerType = 'LAYOUT_NAV_DRAWER_TOGGLE';
const initialState = { isOpen: true };

export const actionCreators = {
  closeNavDrawer: () => ({ type: closeDrawerType }),
  openNavDrawer: () => ({ type: openDrawerType }),
  toggleNavDrawer: () => ({ type: toggleDrawerType }),
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === closeDrawerType) {
    return { ...state, isOpen: false };
  }

  if (action.type === openDrawerType) {
    return { ...state, isOpen: true };
  }

  if (action.type === toggleDrawerType) {
    return { ...state, isOpen: !state.isOpen };
  }

  return state;
};
