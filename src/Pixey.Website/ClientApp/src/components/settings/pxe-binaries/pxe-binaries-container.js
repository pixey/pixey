import View from './pxe-binaries-view';
import { actionCreators } from './pxe-binaries-store';

import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

const mapStateToProps = state => {
    return {
        binaries: state.pxeBinaries
    }
};

export default connect(
    mapStateToProps,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(View);
