import React from "react";
import FitnessPathItem from "./FitnessPathItem";

function FitnessPathList(props) {
    const fitnessPathResults = props.fitnessPathResults;
    if (!fitnessPathResults) {
        return null;
      }
    return (
        <div className="row">
            {fitnessPathResults.map(fitnessPath =>
            <div className="col"  key={fitnessPath.id}>
                <FitnessPathItem fitnessPath={fitnessPath}></FitnessPathItem>
                </div>
            )}
          </div>
    );
    }

export default FitnessPathList;
