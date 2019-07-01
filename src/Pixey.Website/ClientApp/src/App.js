import React from 'react';
import { Route } from 'react-router';
import Layout from './components/layout';

// Old components
import Home from './components/Home';
import Counter from './components/counter';
import FetchData from './components/FetchData';

import Diagnostics from './components/diagnostics';

// Settings
import PxeBinaries from './components/settings/pxe-binaries'

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/diagnostics' component={Diagnostics} />
    <Route path='/settings/pxe-binaries' component={PxeBinaries} />
    <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
  </Layout>
);
