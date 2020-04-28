import React, { Component } from "react";
import FitnessPathService from "../../services/FitnessPathService";
import WorkoutSearchableList from "../workout/WorkoutSearchableList";
import SpinnerPage from "../home/SpinnerPage";
import WorkoutScheduleTableSelector from "../workoutschedule/WorkoutScheduleTableSelector";
import CancelButton from "../shared/buttons/cancelbutton";
import { Link } from "react-router-dom";
import WorkoutScheduleService from "../../services/WorkoutScheduleService";

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
    var workouts = this.state.workouts;
    workouts.push({
      workoutId: id,
      workoutName: name,
      fitnessPathId: this.state.fitnessPath.id,
      dayOfWeek: "",
      week: null,
      date: null,
      workoutOrder: null,
      notes: "",
    });
    this.setState({ workouts: workouts });
  };
  onRemoveClick = (listId) => {
    var linkedWorkouts1 = this.state.workouts.filter(
      (obj) => obj.listId !== listId
    );
    this.setState({ workouts: linkedWorkouts1 });
  };
  saveWorkoutSchedule = () => {
    var fitnessPath = this.state.fitnessPath;
    WorkoutScheduleService.update(fitnessPath);
  };
  render() {
    let fitnessPath = this.state.fitnessPath;
    let workouts = this.state.workouts;
    return (
      <div>
        <div className="row">
          <div className="col">
            <CancelButton text="Back" />
          </div>
        </div>
        <SpinnerPage loading={this.state.loading}></SpinnerPage>
        <div className="row">
          <div className="col-sm-9">
            <h3>Update workout schedule</h3>
            <WorkoutScheduleTableSelector
              workoutSchedule={fitnessPath.workoutSchedule}
              workouts={workouts}
              edit={true}
              onRemoveClick={this.onRemoveClick}
            />
            <div className="row">
              <div className="col">
                <CancelButton className="float-right" />
                <button
                  type="button"
                  className="btn btn-success float-right"
                  onClick={this.saveWorkoutSchedule}
                >
                  Save
                </button>
              </div>
            </div>
          </div>
          <div className="col-sm-3">
            <h3>Add new workouts</h3>
            <WorkoutSearchableList btnAction={this.handleAddWorkout} />
          </div>
        </div>
      </div>
    );
  }
}
