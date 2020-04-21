import React from "react";
import { Link } from "react-router-dom";

function FitnessPathEditLink(props) {
  const fitnessPath = props.fitnessPath;
  return <Link to={`/fitnessPath/${fitnessPath.id}/edit`}>Edit</Link>;
}

export default FitnessPathEditLink;
