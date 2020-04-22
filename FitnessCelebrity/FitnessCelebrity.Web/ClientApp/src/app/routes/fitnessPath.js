import React from "react";
import { Route } from "react-router";
import {
  FitnessPathPage,
  FitnessPathEditPage,
  FitnessPathCreatePage,
  FitnessPathEditWorkoutsPage,
} from "../../components/fitnesspath";

function FitnessPathRoutes(props) {
  return (
    <>
      <Route
        exact
        path="/fitnessPath/:fitnessPathId(\d+)"
        component={FitnessPathPage}
      />
      <Route
        exact
        path="/fitnessPath/create"
        component={FitnessPathCreatePage}
      />
      <Route
        exact
        path="/fitnessPath/:fitnessPathId/edit"
        component={FitnessPathEditPage}
      />
      <Route
        exact
        path="/fitnessPath/:fitnessPathId/edit/workouts"
        component={FitnessPathEditWorkoutsPage}
      />
    </>
  );
}
export default FitnessPathRoutes;
