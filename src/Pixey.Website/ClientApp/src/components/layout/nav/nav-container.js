import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';
import { bindActionCreators } from 'redux';
import { actionCreators } from '../layout-store';

import View from './nav-view';

export default withRouter(connect(
    state => state.layout,
    dispatch => bindActionCreators(actionCreators, dispatch)
  )(View));