import React from 'react';

import Paper from '@material-ui/core/Paper';
import Stepper from '@material-ui/core/Stepper'
import Step from '@material-ui/core/Step'
import StepLabel from '@material-ui/core/StepLabel'
import StepContent from '@material-ui/core/StepContent'
import List from '@material-ui/core/List'
import ListItem from '@material-ui/core/ListItem'
import ListItemIcon from '@material-ui/core/ListItemIcon'
import ListItemText from '@material-ui/core/ListItemText'
import CircularProgress from '@material-ui/core/CircularProgress';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';


import { faCheck } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles(theme => ({
  root: {
    padding: theme.spacing(3, 2),
  },
}));

const Diagnostics = props => {
  const classes = useStyles();

  return (
    <div>

      <Typography variant="h3" component="h1" gutterBottom>Diagnostics</Typography>

      {/* Note: The start button should be where the stepper is - big button in the middle  */}

      <Paper className={classes.root}>
        <Stepper orientation="vertical">
          <Step key="dhcp" completed active={true}>
            <StepLabel>DHCP</StepLabel>
            <StepContent>
              <List dense="true">
                <ListItem>
                  <ListItemIcon>
                    <FontAwesomeIcon icon={faCheck} size="lg" />
                  </ListItemIcon>
                  <ListItemText primary="Single-line item 1" />
                </ListItem>
                <ListItem>
                  <ListItemIcon>
                    <FontAwesomeIcon icon={faCheck} size="lg" />
                  </ListItemIcon>
                  <ListItemText primary="Single-line item 2" />
                </ListItem>
              </List>
            </StepContent>
          </Step>
          <Step key="tftp" active={true}>
            <StepLabel>TFTP</StepLabel>
            <StepContent>
              <List dense="true">
                <ListItem>
                  <ListItemIcon>
                    <FontAwesomeIcon icon={faCheck} size="lg" />
                  </ListItemIcon>
                  <ListItemText primary="Single-line item 1" />
                </ListItem>
                <ListItem>
                  <ListItemIcon>
                    <CircularProgress size={20} />
                  </ListItemIcon>
                  <ListItemText primary="Single-line item 2" />
                </ListItem>
              </List>
            </StepContent>
          </Step>
        </Stepper>
        <Grid container direction="row" justify="flex-end" alignItems="center">
          <Button variant="contained" color="primary">Cancel</Button>
        </Grid>
      </Paper>
    </div>
  );
}

export default Diagnostics;