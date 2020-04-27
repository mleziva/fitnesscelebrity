import React, { Component } from "react";
import FitnessPathService from "../../services/FitnessPathService";
import WorkoutSearchableList from "../workout/WorkoutSearchableList";
import SpinnerPage from "../home/SpinnerPage";
import WorkoutScheduleTableSelector from "../workoutschedule/WorkoutScheduleTableSelector";

import { Link } from "react-router-dom";

export class FitnessPathEditWorkoutsPage extends Component {
  static displayName = FitnessPathEditWorkoutsPage.name;

  constructor(props) {
    super(props);
    this.state = {
      fitnessPath: {},
      workouts: [],
      loading: true,
    };
  }

  componentDidMount() {
    const {
      match: { params },
    } = this.props;
    this.loadFitnessPath(params.fitnessPathId);
  }
  async loadFitnessPath(id) {
    let fitnessPath = await FitnessPathService.getById(id);
    this.setState({ fitnessPath: fitnessPath, loading: false });
    this.setState({ workouts: fitnessPath.workouts });
  }

  handleAddWorkout = (e) => {
    //append workout to list
    var id = parseInt(e.target.parentNode.dataset.id);
    var name = e.target.parentNode.dataset.name;
    var link = <Link to={"/workout/" + id}>{name}</Link>;
    var workouts = this.state.workouts;
    workouts.push({
      id: id,
      name: link,
    });
    this.setState({ workouts: workouts });
  };
  render() {
    let fitnessPath = this.state.fitnessPath;
    let workouts = this.state.workouts;
    return (
      <div>
        <div className="row">
          <div className="col">
            <button
              className="btn btn-outline-primary"
              onClick={() => this.props.history.goBack()}
            >
              Cancel
            </button>
          </div>
        </div>
        <SpinnerPage loading={this.state.loading}></SpinnerPage>
        <div className="row">
          <div className="col-sm-3">
            Available workouts
            <WorkoutSearchableList btnAction={this.handleAddWorkout} />
          </div>
          <div className="col-sm-9">
            <WorkoutScheduleTableSelector
              workoutSchedule={fitnessPath.workoutSchedule}
              workouts={workouts}
              edit={true}
            />
          </div>
        </div>
      </div>
    );
  }
}
