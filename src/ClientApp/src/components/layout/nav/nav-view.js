import { makeStyles } from '@material-ui/core/styles';
import { DrawerWidth } from '../../../consts'

import clsx from 'clsx';

import React from 'react';
import IconButton from '@material-ui/core/IconButton';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft'; // TODO: Replace with FA
import Drawer from '@material-ui/core/Drawer';
import Divider from '@material-ui/core/Divider';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCompactDisc, faChartBar, faBookOpen, faDownload, faDatabase } from '@fortawesome/free-solid-svg-icons'

const useStyles = makeStyles(theme => ({
    toolbarIcon: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'flex-end',
        padding: '0 8px',
        ...theme.mixins.toolbar,
    },
    title: {
        flexGrow: 1,
    },
    drawerPaper: {
        position: 'relative',
        whiteSpace: 'nowrap',
        width: DrawerWidth,
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
    paper: {
        padding: theme.spacing(2),
        display: 'flex',
        overflow: 'auto',
        flexDirection: 'column',
    }
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
                <IconButton onClick={props.closeNavDrawer}>
                    <ChevronLeftIcon />
                </IconButton>
            </div>
            <Divider />
            <List>
                <div>
                    <ListItem button>
                        <ListItemIcon>
                        <FontAwesomeIcon icon={faDatabase} size="2x" />
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
                </div>
            </List>
        </Drawer>
    );
}

export default Nav;