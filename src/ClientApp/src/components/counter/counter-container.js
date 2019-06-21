import View from './counter-view';
import { actionCreators } from './counter-store';

import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

const mapStateToProps = state => {
    return {
        count: state.counter.count,
        hello: "Hello"
    }
};

export default connect(
    // state => return {
    //     counter: state.counter;
    //     someTest: "Hello"
    // },
    mapStateToProps,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(View);
