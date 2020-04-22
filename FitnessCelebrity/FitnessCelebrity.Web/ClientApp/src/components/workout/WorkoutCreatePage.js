import React, { Component } from "react";
import WorkoutService from "../../services/WorkoutService";
import WorkoutForm from "./WorkoutForm";
import CancelButton from "../shared/buttons/cancelbutton";

export class WorkoutCreatePage extends Component {
  static displayName = WorkoutCreatePage.name;

  componentDidMount() {}
  onSave = async (values) => {
    var createdWorkout = await WorkoutService.create(values);
    //if success redirect to created page using response from post request
    this.props.history.push(`/workout/${createdWorkout.id}`);
  };
  render() {
    return (
      <div>
        <div className="row">
          <div className="col">
            <CancelButton />
          </div>
        </div>
        <WorkoutForm onSubmit={this.onSave} />
      </div>
    );
  }
}
