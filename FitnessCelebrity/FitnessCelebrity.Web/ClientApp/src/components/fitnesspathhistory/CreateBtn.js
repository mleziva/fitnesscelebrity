import React from "react";
import { FitnessPathHistoryService } from "../../services";

export default function CreateBtn(props) {
  //onclick redirect or how to display the new details?
  const handleClick = async () => {
    var activatedHistoryObject = await FitnessPathHistoryService.activateFitnessPath(
      props.fitnessPathId
    );
    props.onActivated(activatedHistoryObject);
  };
  return (
    <>
      <button className="btn btn-primary" onClick={() => handleClick()}>
        Make Active
      </button>
    </>
  );
}
