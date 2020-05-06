import React from "react";
import { Link } from "react-router-dom";

export default function HistoryDetails(props) {
  const fph = props.fitnessPathHistory;
  return (
    <>
      <p>
        You started this fitnesspath on{" "}
        {new Date(fph.startedDate).toLocaleDateString("en-US")}
      </p>
      <p>
        <Link to="">View Progress</Link>
      </p>
    </>
  );
}
