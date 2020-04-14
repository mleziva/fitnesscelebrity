import React from "react";
import FitnessPathCard from "./FitnessPathCard";

function FitnessPathList(props) {
    const fitnessPathResults = props.fitnessPathResults;
    if (!fitnessPathResults) {
        return null;
      }
    return (
        <div className="row">
            {fitnessPathResults.map(fitnessPath =>
            <div className="col"  key={fitnessPath.id}>
                <FitnessPathCard fitnessPath={fitnessPath}></FitnessPathCard>
                </div>
            )}
          </div>
    );
    }

export default FitnessPathList;
