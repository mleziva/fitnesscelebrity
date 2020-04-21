import React from "react";

function SpinnerPage(props) {
  if (props.loading) {
    return (
      <div className="lds-ring centered">
        <div></div>
        <div></div>
        <div></div>
        <div></div>
      </div>
    );
  }
  return null;
}
export default SpinnerPage;
