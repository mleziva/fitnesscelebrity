import React, { useState, useEffect } from "react";
import { FitnessPathHistoryService } from "../../services";
import HistoryDetails from "./HistoryDetails";
import CreateBtn from "./CreateBtn";

export default function HistoryPanel(props) {
  const [fitnessPathHistory, setFitnessPathHistory] = useState({});
  useEffect(() => {
    load();
  }, []);

  const load = async () => {
    let results = await FitnessPathHistoryService.getMyCurrentlyActive();
    setFitnessPathHistory(results[0]);
  };

  let content;

  if (fitnessPathHistory) {
    content = <HistoryDetails fitnessPathHistory={fitnessPathHistory} />;
  } else {
    content = <CreateBtn fitnessPathId={props.fitnessPathId} />;
  }

  return <>{content}</>;
}
