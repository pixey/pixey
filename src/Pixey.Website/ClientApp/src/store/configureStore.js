import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';
import logger from 'redux-logger'

import * as Layout from '../components/layout/layout-store';
import * as Counter from '../components/counter/counter-store';

import websocketMiddleware from './middlewares/websocket-middleware';

export default function configureStore (history, initialState) {
  const reducers = {
    layout: Layout.reducer,
    counter: Counter.reducer
  };

  const middleware = [
    thunk,
    routerMiddleware(history),
    logger,
    websocketMiddleware()
  ];

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  const isDevelopment = process.env.NODE_ENV === 'development';
  if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
    enhancers.push(window.devToolsExtension());
  }

  const rootReducer = combineReducers({
    ...reducers,
    routing: routerReducer
  });

  return createStore(
    rootReducer,
    initialState,
    compose(applyMiddleware(...middleware), ...enhancers)
  );
}
