import React from 'react';
import Button from '@material-ui/core/Button'

const Counter = props => (
    <div>
      <h1>Counter</h1>
  
      <p>This is a simple example of a React component.</p>
  
      <p>Current count: <strong>{props.count}</strong></p>
  
      <Button color="primary" variant="contained" onClick={props.increment}>Increment</Button>
    </div>
  );

export default Counter;