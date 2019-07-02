import React from 'react';
import PropTypes from 'prop-types';

import List from '@material-ui/core/List';
import ListSubheader from '@material-ui/core/ListSubHeader';
import Collapse from '@material-ui/core/Collapse';

const MenuSection = props => (
    <List
        component="nav"
        subheader={
            props.title ?
            <Collapse in={props.isDrawerOpen}>
                <ListSubheader component="div">
                    Diagnostics
                </ListSubheader>
            </Collapse>
            : null
        }>
        <div>
            {props.menuItems}
        </div>
    </List>
);

MenuSection.propTypes = {
    title: PropTypes.string,
    isDrawerOpen: PropTypes.bool.isRequired,
    menuItems: PropTypes.element.isRequired
};

export default MenuSection;