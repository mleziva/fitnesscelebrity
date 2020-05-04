import React from "react";
import { FitnessPathHistoryService } from "../../services";

export default function CreateBtn(props) {
  //onclick redirect or how to display the new details?
  return (
    <>
      <button
        className="btn btn-primary"
        onClick={() =>
          FitnessPathHistoryService.activateFitnessPath(props.fitnessPathId)
        }
      >
        Make Active
      </button>
    </>
  );
}
