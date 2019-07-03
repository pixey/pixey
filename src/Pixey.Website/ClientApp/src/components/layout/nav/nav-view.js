import { makeStyles } from '@material-ui/core/styles';
import { DrawerWidth } from '../../../consts'

import clsx from 'clsx';

import React from 'react';
import Drawer from '@material-ui/core/Drawer';
import Divider from '@material-ui/core/Divider';

import { faCompactDisc, faChartBar, faMicrochip, faWrench, faNetworkWired, faStethoscope, faScroll } from '@fortawesome/free-solid-svg-icons'
import { faFileAlt } from '@fortawesome/free-regular-svg-icons'

import MenuSection from './menu-section';
import MenuItem from './menu-item';

const useStyles = makeStyles(theme => ({
    drawer: {
        width: DrawerWidth,
        flexShrink: 0,
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
    subHeader: {
        transition: theme.transitions.create('display', {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.enteringScreen,
        }),
        display: 'block'
    },
    subHeaderHidden: {
        transition: theme.transitions.create('display', {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.leavingScreen,
        }),
        display: 'none'
    },
    toolbar: theme.mixins.toolbar,
    collapsedMenuItem: {
        alignItems: 'center',
        justifyContent: 'center',
    },
    collapsedMenuItemIcon: {
        minWidth: '0'
    }
}));

function Nav(props) {
    const classes = useStyles();

    return (
        <Drawer
            variant="permanent"
            className={classes.drawer}
            open={props.isOpen}
            classes={{
                paper: clsx(classes.drawerPaper, !props.isOpen && classes.drawerPaperClose),
            }}>
            <div className={classes.toolbar} />
            <MenuSection
                isDrawerOpen={props.isOpen}
                menuItems={
                    <div>
                        <MenuItem icon={faChartBar} text="Dashboard" linkTo="/" isDrawerOpen={props.isOpen} />
                        <MenuItem icon={faCompactDisc} text="Images" linkTo="/images" isDrawerOpen={props.isOpen} />
                        <MenuItem icon={faScroll} text="Boot scripts" linkTo="/boot-scripts" isDrawerOpen={props.isOpen} />
                    </div>
                }
            />
            <Divider />
            <MenuSection
                title="Diagnostics"
                isDrawerOpen={props.isOpen}
                menuItems={
                    <div>
                        <MenuItem icon={faFileAlt} text="Event Logs" linkTo="/diagnostics/logs" isDrawerOpen={props.isOpen} />
                        <MenuItem icon={faStethoscope} text="Troubleshooting" linkTo="/diagnostics/troubleshooting" isDrawerOpen={props.isOpen} />
                    </div>
                }
                />

            <Divider />
            <MenuSection
                title="Settings"
                isDrawerOpen={props.isOpen}
                menuItems={
                    <div>
                        <MenuItem icon={faWrench} text="General" linkTo="/settings" isDrawerOpen={props.isOpen} />
                        <MenuItem icon={faMicrochip} text="Bootloaders" linkTo="/settings/pxe-binaries" isDrawerOpen={props.isOpen} />
                        <MenuItem icon={faNetworkWired} text="Network" linkTo="/settings/network" isDrawerOpen={props.isOpen} />
                    </div>
                }
                />
        </Drawer >
    );
}

export default Nav;