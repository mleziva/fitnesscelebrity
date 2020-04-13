import React from "react";
import { Link } from 'react-router-dom';
function FitnessPathItem(props) {
    const fitnessPath = props.fitnessPath;
    return (
    <div className="card">
        <div className="card-body">
            <h5 className="card-title">{fitnessPath.name}</h5>
            <h6 className="card-subtitle mb-2 text-muted">{fitnessPath.author}</h6>
            <p className="card-text">{fitnessPath.description}</p>
            <Link to={'/fitnessPath/'+fitnessPath.id} className="card-link">View</Link>
        </div>
      </div>
    );
    }

export default FitnessPathItem;
