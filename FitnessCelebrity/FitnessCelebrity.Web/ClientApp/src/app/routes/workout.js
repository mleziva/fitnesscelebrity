import React from "react";
import { Route } from "react-router";
import { WorkoutPage, CreatePage } from "../../components/workout";

function WorkoutRoutes(props) {
  return (
    <>
      <Route path="/workout/create" component={CreatePage} />
      <Route path="/workout/:workoutId" component={WorkoutPage} />
    </>
  );
}
export default WorkoutRoutes;
