import React from "react";
import { Route } from "react-router";
import {
  WorkoutPage,
  WorkoutCreatePage,
  WorkoutEditPage,
} from "../../components/workout";

function WorkoutRoutes(props) {
  return (
    <>
      <Route exact path="/workout/:workoutId(\d+)" component={WorkoutPage} />
      <Route exact path="/workout/create" component={WorkoutCreatePage} />
      <Route
        exact
        path="/workout/:workoutId(\d+)/edit"
        component={WorkoutEditPage}
      />
    </>
  );
}
export default WorkoutRoutes;
