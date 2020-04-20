import React, { useState, useEffect } from "react";
import FitnessPathService from "../../services/FitnessPathService";
import { Link } from "react-router-dom";
import Spinner from "../home/Spinner";

function FitnessPathListGroup(props) {
  const [loading, setLoading] = useState(true);
  let fitnessPaths = [];

  useEffect(() => {
    loadFitnessPaths();
  }, []);

  const loadFitnessPaths = async () => {
    fitnessPaths = await FitnessPathService.get();
    setLoading(false);
  };

  return (
    <>
      <ul className="list-group">
        {fitnessPaths.map((fitnessPath) => (
          <li className="list-group-item" key={fitnessPath.id}>
            {fitnessPath.name}
          </li>
        ))}
      </ul>
    </>
  );
}

export default FitnessPathListGroup;
