import React, { useState, useEffect } from "react";
import FitnessPathService from "../../services/FitnessPathService";
import { Link } from "react-router-dom";
import Spinner from "../home/Spinner";
import { FitnessPathLink, FitnessPathEditLink } from "../fitnesspath";

function FitnessPathTable(props) {
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
  const renderTable = () => {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Description</th>
            <th>Created Date</th>
            <th>Edit</th>
          </tr>
        </thead>
        <tbody>
          {fitnessPaths.map((fitnessPath) => (
            <tr key={fitnessPath.id}>
              <td>
                <FitnessPathLink fitnessPath={fitnessPath} />
              </td>
              <td>{fitnessPath.description}</td>
              <td>
                {new Intl.DateTimeFormat("en-GB", {
                  year: "numeric",
                  month: "long",
                  day: "2-digit",
                }).format(Date.parse(fitnessPath.createdDate))}
              </td>
              <td>
                <FitnessPathEditLink fitnessPath={fitnessPath} />
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  };
  return <>{loading ? <Spinner /> : renderTable()}</>;
}

export default FitnessPathTable;
