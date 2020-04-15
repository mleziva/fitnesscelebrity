import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { CreatePage } from './components/workout/Create-Page';
import { FitnessPathPage } from './components/fitnesspath/FitnessPathPage';
import { WorkoutPage } from './components/workout/WorkoutPage';
import { MovementPage } from './components/movement/MovementPage';
import { ProfilePage } from './components/profile/profilepage';
import { SearchPage } from './components/search/SearchPage';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css'
import './style/loadingSpinner.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
          <Route path='/search' component={SearchPage} />
            <Route path='/workout/create' component={CreatePage} />
            <Route path='/fitnessPath/:fitnessPathId' component={FitnessPathPage} />
            <Route path='/workout/:workoutId' component={WorkoutPage} />
            <Route path='/movement/:movementId' component={MovementPage} />
            <Route path='/profile/:profileUserName' component={ProfilePage} />
        <AuthorizeRoute path='/fetch-data' component={FetchData} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
    );
  }
}
