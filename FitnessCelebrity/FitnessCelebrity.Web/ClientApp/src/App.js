import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/app/Layout";
import { Home } from "./components/home/Home";
import { FetchData } from "./components/FetchData";
import FitnessPathRoutes from "./app/routes/fitnessPath";
import MovementRoutes from "./app/routes/movement";
import WorkoutRoutes from "./app/routes/workout";
import { ManagePage } from "./components/manage/managePage";
import { ProfilePage } from "./components/profile/profilepage";
import { SearchPage } from "./components/search/SearchPage";
import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import ApiAuthorizationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { ApplicationPaths } from "./components/api-authorization/ApiAuthorizationConstants";
import { FitnessPathHistoryPage } from "./components/fitnesspathhistory";

import "./custom.css";
import "./style/loadingSpinner.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/search" component={SearchPage} />
        <FitnessPathRoutes />
        <MovementRoutes />
        <WorkoutRoutes />
        <Route exact path="/manage" component={ManagePage} />
        <Route path="/profile/:profileUserName" component={ProfilePage} />
        <Route
          exact
          path="/fitnessPathHistory/:fitnessPathHistoryId"
          component={FitnessPathHistoryPage}
        />

        <AuthorizeRoute path="/fetch-data" component={FetchData} />
        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
      </Layout>
    );
  }
}
