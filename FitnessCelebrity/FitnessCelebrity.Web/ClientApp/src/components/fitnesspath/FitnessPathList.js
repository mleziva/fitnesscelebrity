import React from "react";
import FitnessPathCard from "./FitnessPathCard";
import { Link } from "react-router-dom";

function FitnessPathList(props) {
  const fitnessPaths = props.fitnessPaths;
  const viewAll = props.viewAll;
  if (!fitnessPaths) {
    return null;
  }
  function renderViewAll() {
    if (!viewAll) {
      return null;
    }
    return (
      <div className="col">
        <Link to={viewAll.link}>View all</Link>
      </div>
    );
  }

  return (
    <div className="row">
      {fitnessPaths.map((fitnessPath) => (
        <div className="col" key={fitnessPath.id}>
          <FitnessPathCard fitnessPath={fitnessPath}></FitnessPathCard>
        </div>
      ))}
      {renderViewAll()}
    </div>
  );
}

export default FitnessPathList;
