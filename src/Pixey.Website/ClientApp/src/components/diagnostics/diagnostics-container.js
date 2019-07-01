import View from './diagnostics-view';
import { actionCreators } from './diagnostics-store';

import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

const mapStateToProps = state => {
    return {
        count: state.counter.count,
        hello: "Hello"
    }
};

export default connect(
    mapStateToProps,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(View);
