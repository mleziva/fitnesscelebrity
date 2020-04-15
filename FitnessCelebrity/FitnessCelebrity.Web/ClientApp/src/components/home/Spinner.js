import React from "react";

function Spinner(props) {
    if (props.loading) {
        return <div className="lds-ring centered"><div></div><div></div><div></div><div></div></div>;
      }
      return null;
}
export default Spinner;