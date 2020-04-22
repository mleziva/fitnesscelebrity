import React from "react";
import { Route } from "react-router";
import { MovementPage } from "../../components/movement";

function MovementRoutes(props) {
  return (
    <>
      <Route path="/movement/:movementId" component={MovementPage} />
    </>
  );
}
export default MovementRoutes;
