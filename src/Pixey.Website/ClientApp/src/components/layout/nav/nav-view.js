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
import ListSubheader from '@material-ui/core/ListSubheader';


import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCompactDisc, faChartBar, faMicrochip, faWrench, faNetworkWired, faStethoscope, faScroll } from '@fortawesome/free-solid-svg-icons'
import { faFileAlt } from '@fortawesome/free-regular-svg-icons'
import { NavLink } from 'react-router-dom';

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
    },
    link: {
        textDecoration: 'none'
    },
    activeLink: {
        backgroundColor: 'red'
    },
    nested: {
        paddingLeft: theme.spacing(4),
    }
}));

function Nav(props) {
    const classes = useStyles();
    const LinkRef = React.forwardRef((props, ref) => <div ref={ref}><NavLink {...props} /></div>)

    return (
        <Drawer
            variant="permanent"
            classes={{
                paper: clsx(classes.drawerPaper, !props.isOpen && classes.drawerPaperClose),
            }}
            open={props.isOpen}
        >
            <div className={classes.toolbarIcon}>
                <h2>Pixey</h2>
                <IconButton onClick={props.closeNavDrawer}>
                    <ChevronLeftIcon />
                </IconButton>
            </div>
            <Divider />
            <List>
                <div>
                    <ListItem button component={LinkRef} to="/">
                        <ListItemIcon>
                            <FontAwesomeIcon icon={faChartBar} size="2x" />
                        </ListItemIcon>
                        <ListItemText primary="Dashboard" />
                    </ListItem>
                    <ListItem button component={LinkRef} to="/images">
                        <ListItemIcon>
                            <FontAwesomeIcon icon={faCompactDisc} size="2x" />
                        </ListItemIcon>
                        <ListItemText primary="Images" />
                    </ListItem>
                    <ListItem button component={LinkRef} to="/boot-scripts">
                        <ListItemIcon>
                            <FontAwesomeIcon icon={faScroll} size="2x" />
                        </ListItemIcon>
                        <ListItemText primary="Boot scripts" />
                    </ListItem>
                </div>
            </List>
            <Divider />
            <List
                component="nav"
                subheader={
                    props.isOpen ?
                        <ListSubheader component="div" id="nested-list-subheader">
                            Diagnostics
                    </ListSubheader>
                        : <span />}>
                <div>
                    <ListItem button component={LinkRef} to="/diagnostics/logs">
                        <ListItemIcon>
                            <FontAwesomeIcon icon={faFileAlt} size="2x" />
                        </ListItemIcon>
                        <ListItemText primary="Event Logs" />
                    </ListItem>
                    <ListItem button component={LinkRef} to="/diagnostics/troubleshooting">
                        <ListItemIcon>
                            <FontAwesomeIcon icon={faStethoscope} size="2x" />
                        </ListItemIcon>
                        <ListItemText primary="Troubleshooting" />
                    </ListItem>
                </div>
            </List>
            <Divider />
            <List
                component="nav"
                subheader={
                    props.isOpen ?
                        <ListSubheader component="div" id="nested-list-subheader">
                            Settings
                    </ListSubheader>
                        : <span />}>
                <div>
                    <ListItem button component={LinkRef} to="/settings">
                        <ListItemIcon>
                            <FontAwesomeIcon icon={faWrench} size="2x" />
                        </ListItemIcon>
                        <ListItemText>General</ListItemText>
                    </ListItem>
                    <ListItem button component={LinkRef} to="/settings/pxe-binaries">
                        <ListItemIcon>
                            <FontAwesomeIcon icon={faMicrochip} size="2x" />
                        </ListItemIcon>
                        <ListItemText>Bootloader</ListItemText>
                    </ListItem>
                    <ListItem button component={LinkRef} to="/settings/network">
                        <ListItemIcon>
                            <FontAwesomeIcon icon={faNetworkWired} size="2x" />
                        </ListItemIcon>
                        <ListItemText>Network</ListItemText>
                    </ListItem>
                </div>
            </List>
        </Drawer>
    );
}

export default Nav;