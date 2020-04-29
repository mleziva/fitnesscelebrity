import React from "react";
import { PrivacyEnum as p } from "../../../app/const/EnumConfig";

function PrivacyEnum(props) {
  if (props.value === undefined) return null;
  return p[props.value].name;
}

export default PrivacyEnum;
