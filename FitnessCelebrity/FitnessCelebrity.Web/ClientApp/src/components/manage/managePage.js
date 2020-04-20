import React, { Component } from "react";
import { Link } from "react-router-dom";
import FitnessPathListGroup from "../fitnesspath/FitnessPathListGroup";

export class ManagePage extends Component {
  static displayName = ManagePage.name;

  render() {
    return (
      <div>
        <h1>Manage Fitness</h1>
        <div className="row">
          <div className="col-sm-6">
            <h2>Fitness Paths</h2>
          </div>
          <div className="col-sm-6">
            <Link
              to="/fitnessPath/create"
              className="btn btn-outline-primary float-right"
            >
              Create New Fitness Path
            </Link>
          </div>
        </div>
        <div className="row">
          <div className="col">
            <FitnessPathListGroup />
          </div>
        </div>
        <div className="row">
          <div className="col">Workouts</div>
        </div>
        <div className="row">
          <div className="col">Workout List</div>
        </div>
        <div className="row">
          <div className="col">
            <Link to="/workout/create" className="btn btn-primary">
              Create workout
            </Link>
          </div>
        </div>
        <div className="row">
          <div className="col">Movements</div>
        </div>
        <div className="row">
          <div className="col">Movements List</div>
        </div>
      </div>
    );
  }
}
