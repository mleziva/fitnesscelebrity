import React from "react";
import { useHistory } from "react-router-dom";

function CancelButton(props) {
  const history = useHistory();
  return (
    <button
      className="btn btn-outline-primary"
      onClick={() => history.goBack()}
    >
      Cancel
    </button>
  );
}

export default CancelButton;
