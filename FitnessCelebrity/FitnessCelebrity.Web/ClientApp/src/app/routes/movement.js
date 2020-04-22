import React from "react";
import { Route } from "react-router";
import {
  MovementPage,
  MovementCreatePage,
  MovementEditPage,
} from "../../components/movement";

function MovementRoutes(props) {
  return (
    <>
      <Route exact path="/movement/:movementId(\d+)" component={MovementPage} />
      <Route exact path="/movement/create" component={MovementCreatePage} />
      <Route
        exact
        path="/movement/:movementId(\d+)/edit"
        component={MovementEditPage}
      />
    </>
  );
}
export default MovementRoutes;
