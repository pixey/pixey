import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { actionCreators } from './layout-store'

import View from './layout-view';

export default connect(
    state => state.layout,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(View);