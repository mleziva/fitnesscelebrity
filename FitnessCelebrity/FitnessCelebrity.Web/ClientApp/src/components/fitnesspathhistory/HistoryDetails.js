import React from "react";
import SpanRow from "../home/SpanRow";

export default function HistoryDetails(props) {
  const fph = props.fitnessPathHistory;
  return (
    <>
      <SpanRow
        value={fph.startedDate}
        label={"Started Date"}
        name="startedDate"
      />
    </>
  );
}
