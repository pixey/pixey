import React from 'react';
import { connect } from 'react-redux';
import clsx from 'clsx';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import { withRouter } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import IconButton from '@material-ui/core/IconButton';
import List from '@material-ui/core/List';
import Drawer from '@material-ui/core/Drawer';
import Divider from '@material-ui/core/Divider';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ListSubheader from '@material-ui/core/ListSubheader';
import { bindActionCreators } from 'redux';
import { actionCreators } from '../store/Layout'

import DashboardIcon from '@material-ui/icons/Dashboard';
import LayersIcon from '@material-ui/icons/Layers';
import AssignmentIcon from '@material-ui/icons/Assignment';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCompactDisc, faChartBar, faBookOpen, faDownload } from '@fortawesome/free-solid-svg-icons'

const drawerWidth = 240;

const useStyles = makeStyles(theme => ({
    root: {
      display: 'flex',
    },
    toolbar: {
      paddingRight: 24, // keep right padding when drawer closed
    },
    toolbarIcon: {
      display: 'flex',
      alignItems: 'center',
      justifyContent: 'flex-end',
      padding: '0 8px',
      ...theme.mixins.toolbar,
    },
    appBar: {
      zIndex: theme.zIndex.drawer + 1,
      transition: theme.transitions.create(['width', 'margin'], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
      }),
    },
    appBarShift: {
      marginLeft: drawerWidth,
      width: `calc(100% - ${drawerWidth}px)`,
      transition: theme.transitions.create(['width', 'margin'], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.enteringScreen,
      }),
    },
    menuButton: {
      marginRight: 36,
    },
    menuButtonHidden: {
      display: 'none',
    },
    title: {
      flexGrow: 1,
    },
    drawerPaper: {
      position: 'relative',
      whiteSpace: 'nowrap',
      width: drawerWidth,
      transition: theme.transitions.create('width', {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.enteringScreen,
      }),
    },
    drawerPaperClose: {
      overflowX: 'hidden',
      transition: theme.transitions.create('width', {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
      }),
      width: theme.spacing(7),
      [theme.breakpoints.up('sm')]: {
        width: theme.spacing(9),
      },
    },
    appBarSpacer: theme.mixins.toolbar,
    content: {
      flexGrow: 1,
      height: '100vh',
      overflow: 'auto',
    },
    container: {
      paddingTop: theme.spacing(4),
      paddingBottom: theme.spacing(4),
    },
    paper: {
      padding: theme.spacing(2),
      display: 'flex',
      overflow: 'auto',
      flexDirection: 'column',
    },
    fixedHeight: {
      height: 240,
    },
  }));

function Nav(props) {
    const classes = useStyles();
    
    return (

        <Drawer
            variant="permanent"
            classes={{
                paper: clsx(classes.drawerPaper, !props.isOpen && classes.drawerPaperClose),
            }}
            open={props.isOpen}
        >
            <div className={classes.toolbarIcon}>
                <IconButton onClick={props.closeNav}>
                    <ChevronLeftIcon />
                </IconButton>
            </div>
            <Divider />
            <List>
                <div>
                    <ListItem button>
                        <ListItemIcon>
                            <DashboardIcon />
                        </ListItemIcon>
                        <ListItemText primary="Dashboard" />
                    </ListItem>
                    <ListItem button>
                        <ListItemIcon>
                          <FontAwesomeIcon icon={faCompactDisc} size="2x" />
                        </ListItemIcon>
                        <ListItemText primary="Images" />
                    </ListItem>
                    <ListItem button>
                        <ListItemIcon>
                          <FontAwesomeIcon icon={faDownload} size="2x" />
                        </ListItemIcon>
                        <ListItemText primary="Downloads" />
                    </ListItem>
                    <ListItem button>
                        <ListItemIcon>
                          <FontAwesomeIcon icon={faChartBar} size="2x" />
                        </ListItemIcon>
                        <ListItemText primary="Usage statistics" />
                    </ListItem>
                    <ListItem button>
                        <ListItemIcon>
                          <FontAwesomeIcon icon={faBookOpen} size="2x" />
                        </ListItemIcon>
                        <ListItemText primary="Logs" />
                    </ListItem>
                    <ListItem button>
                        <ListItemIcon>
                            <LayersIcon />
                        </ListItemIcon>
                        <ListItemText primary="Integrations" />
                    </ListItem>
                </div>
            </List>
            <Divider />
            <List>
                <div>
                    <ListSubheader inset>Saved reports</ListSubheader>
                    <ListItem button>
                        <ListItemIcon>
                            <AssignmentIcon />
                        </ListItemIcon>
                        <ListItemText primary="Current month" />
                    </ListItem>
                    <ListItem button>
                        <ListItemIcon>
                            <AssignmentIcon />
                        </ListItemIcon>
                        <ListItemText primary="Last quarter" />
                    </ListItem>
                    <ListItem button onClick={() => props.history.push('/counter')}>
                        <ListItemIcon>
                            <AssignmentIcon />
                        </ListItemIcon>
                        <ListItemText primary="Counter" />
                    </ListItem>
                </div>
            </List>
        </Drawer>
    );
}

export default withRouter(connect(
  state => state.layout,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Nav));