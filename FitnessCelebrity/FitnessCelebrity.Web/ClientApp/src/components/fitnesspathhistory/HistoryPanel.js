import React, { useState, useEffect } from "react";
import { FitnessPathHistoryService } from "../../services";
import HistoryDetails from "./HistoryDetails";
import CreateBtn from "./CreateBtn";

export default function HistoryPanel(props) {
  const [fitnessPathHistory, setFitnessPathHistory] = useState({});
  useEffect(() => {
    if (props.fitnessPathId) load(props.fitnessPathId);
  }, [props.fitnessPathId]);

  const load = async (fpId) => {
    let results = await FitnessPathHistoryService.getMyCurrentlyActive(fpId);
    setFitnessPathHistory(results[0]);
  };
  const onActivated = (activeHistory) => {
    setFitnessPathHistory(activeHistory);
  };

  let content;
  if (fitnessPathHistory) {
    content = <HistoryDetails fitnessPathHistory={fitnessPathHistory} />;
  } else {
    content = (
      <CreateBtn
        fitnessPathId={props.fitnessPathId}
        onActivated={onActivated}
      />
    );
  }

  return (
    <>
      <div className="card">
        <div className="card-body">{content}</div>
      </div>
    </>
  );
}
