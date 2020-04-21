import React from "react";
import { Link } from "react-router-dom";

function FitnessPathLink(props) {
  const fitnessPath = props.fitnessPath;
  return <Link to={`/fitnessPath/${fitnessPath.id}`}>{fitnessPath.name}</Link>;
}

export default FitnessPathLink;
