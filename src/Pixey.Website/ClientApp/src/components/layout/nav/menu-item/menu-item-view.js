import clsx from 'clsx';
import React from 'react';
import PropTypes from 'prop-types';

import { makeStyles } from '@material-ui/core/styles';

import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Fade from '@material-ui/core/Fade';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { NavLink } from 'react-router-dom';

const useStyles = makeStyles(theme => ({
    collapsedMenuItem: {
        alignItems: 'center',
        justifyContent: 'center',
    },
    menuItemIcon: {
    },
    collapsedMenuItemIcon: {
        minWidth: '0',
    },
}));

const MenuItem = function (props) {
    const classes = useStyles();
    const LinkRef = React.forwardRef((props, ref) => <div ref={ref}><NavLink {...props} /></div>);

    return (
        <ListItem button component={LinkRef} to={props.linkTo} className={clsx(!props.isDrawerOpen && classes.collapsedMenuItem)}>
            <ListItemIcon className={clsx(classes.menuItemIcon, !props.isDrawerOpen && classes.collapsedMenuItemIcon)}>
                <FontAwesomeIcon icon={props.icon} size="2x" />
            </ListItemIcon>

            <Fade in={props.isDrawerOpen}>
                <ListItemText primary={props.text} />
            </Fade>
        </ListItem>
    );
}

MenuItem.propTypes = {
    isDrawerOpen: PropTypes.bool.isRequired,
    icon: PropTypes.object.isRequired,
    text: PropTypes.string.isRequired,
    linkTo: PropTypes.string.isRequired
};

export default MenuItem;