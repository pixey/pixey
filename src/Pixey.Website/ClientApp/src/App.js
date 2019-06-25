import React from 'react';
import { Route } from 'react-router';
import Layout from './components/layout';
import Home from './components/Home';
import Counter from './components/counter';
import FetchData from './components/FetchData';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
  </Layout>
);