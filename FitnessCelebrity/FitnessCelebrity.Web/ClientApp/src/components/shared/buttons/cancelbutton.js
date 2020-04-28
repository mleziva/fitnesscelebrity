import React from "react";
import { useHistory } from "react-router-dom";

function CancelButton(props) {
  const history = useHistory();
  const text = props.text ?? "Cancel";
  return (
    <button
      className="btn btn-outline-primary"
      onClick={() => history.goBack()}
    >
      {text}
    </button>
  );
}

export default CancelButton;
