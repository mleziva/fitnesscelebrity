import React, { useState, useEffect } from "react";
import FitnessPathService from "../../services/FitnessPathService";
import { Link } from "react-router-dom";
import Spinner from "../home/Spinner";

function FitnessPathListGroup(props) {
  const [loading, setLoading] = useState(true);
  const [fitnessPaths, setFitnessPaths] = useState([]);

  useEffect(() => {
    loadFitnessPaths();
  }, []);

  const loadFitnessPaths = async () => {
    let results = await FitnessPathService.get();
    setLoading(false);
    setFitnessPaths(results);
  };
  const renderListGroup = () => {
    return (
      <ul className="list-group">
        {fitnessPaths.map((fitnessPath) => (
          <li className="list-group-item" key={fitnessPath.id}>
            {fitnessPath.name}
          </li>
        ))}
      </ul>
    );
  };
  return <>{loading ? <Spinner /> : renderListGroup()}</>;
}

export default FitnessPathListGroup;
