import React from "react";
import { WorkoutScheduleEnum as w } from "../../../app/const/EnumConfig";

function WorkoutScheduleEnum(props) {
  if (props.value === undefined) return null;
  return w[props.value].name;
}

export default WorkoutScheduleEnum;
