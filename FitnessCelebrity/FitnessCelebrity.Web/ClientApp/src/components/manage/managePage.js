import React, { Component } from "react";
import { Link } from "react-router-dom";
import EsTable from "../shared/tables/EsTable";
import FitnessPathService from "../../services/FitnessPathService";
import MovementService from "../../services/MovementService";
import WorkoutService from "../../services/WorkoutService";

export class ManagePage extends Component {
  static displayName = ManagePage.name;

  render() {
    return (
      <div>
        <h1>Manage Fitness</h1>
        <div className="row border-bottom">
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
            <EsTable
              loadItems={() => FitnessPathService.get()}
              detailsPath={"fitnessPath"}
            />
          </div>
        </div>
        <div className="row border-bottom">
          <div className="col-sm-6">
            <h2>Workouts</h2>
          </div>
          <div className="col-sm-6">
            <Link
              to="/workout/create"
              className="btn btn-outline-primary float-right"
            >
              Create New Workout
            </Link>
          </div>
        </div>
        <div className="row">
          <div className="col">
            <EsTable
              loadItems={() => WorkoutService.getMyCreatedWorkouts()}
              detailsPath={"workout"}
            />
          </div>
        </div>
        <div className="row border-bottom">
          <div className="col-sm-6">
            <h2>Movements</h2>
          </div>
          <div className="col-sm-6">
            <Link
              to="/workout/create"
              className="btn btn-outline-primary float-right"
            >
              Create New Movement
            </Link>
          </div>
        </div>
        <div className="row">
          <div className="col">
            <EsTable
              loadItems={() => MovementService.get()}
              detailsPath={"movement"}
            />
          </div>
        </div>
      </div>
    );
  }
}
