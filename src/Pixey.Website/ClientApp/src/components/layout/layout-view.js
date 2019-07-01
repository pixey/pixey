import React from 'react';
import Nav from './nav';

import { makeStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import CssBaseline from '@material-ui/core/CssBaseline';
import Container from '@material-ui/core/Container';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faGithub } from '@fortawesome/free-brands-svg-icons'
import { faBook, faSmile, faBars } from '@fortawesome/free-solid-svg-icons';

const useStyles = makeStyles(theme => ({
  root: {
    display: 'flex',
  },
  appBar: {
    zIndex: theme.zIndex.drawer + 1,
  },
  appBarSpacer: theme.mixins.toolbar,
  toggleDrawerButton: {
    marginLeft: '-15px'
  },
  title: {
    marginLeft: '20px'
  },
  content: {
    flexGrow: 1,
    height: '100vh',
    overflow: 'auto',
  },
  container: {
    paddingTop: theme.spacing(4),
    paddingBottom: theme.spacing(4),
  }
}));

function Layout(props) {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <CssBaseline />
      <AppBar position="fixed" className={classes.appBar}>
        <Toolbar>
          <Grid
            justify="space-between"
            alignItems="center"
            container>
            <Grid item>
              <Grid container justify="flex-start" alignItems="center">
                <IconButton
                  edge="start"
                  color="inherit"
                  aria-label="Open drawer"
                  className={classes.toggleDrawerButton}
                  onClick={props.toggleNavDrawer}>
                  <FontAwesomeIcon icon={faBars} size="sm" />
                </IconButton>

                <Typography component="h1" variant="h5" noWrap className={classes.title}>
                  Pixey
                </Typography>
              </Grid>
            </Grid>
            <Grid item>
              <div>
                <IconButton color="inherit" title="Documentation">
                  <FontAwesomeIcon icon={faBook} />
                </IconButton>
                <IconButton color="inherit" title="Send us feedback">
                  <FontAwesomeIcon icon={faSmile} />
                </IconButton>
                <IconButton color="inherit" title="Pixey GitHub repository">
                  <FontAwesomeIcon icon={faGithub} />
                </IconButton>
              </div>
            </Grid>
          </Grid>
        </Toolbar>
      </AppBar>

      <Nav />

      <main className={classes.content}>
        <div className={classes.appBarSpacer} />
        <Container maxWidth="lg" className={classes.container}>
          {props.children}
        </Container>
      </main>
    </div>
  );
}

export default Layout;