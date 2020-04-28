import React, { Component } from "react";
import WorkoutService from "../../services/WorkoutService";
import WorkoutForm from "./WorkoutForm";
import CancelButton from "../shared/buttons/cancelbutton";
import SpinnerPage from "../home/SpinnerPage";
import Jodit from "../shared/editor/Jodit";
export class WorkoutEditPage extends Component {
  static displayName = WorkoutEditPage.name;

  constructor(props) {
    super(props);
    this.state = { workout: {}, loading: true };
  }

  componentDidMount() {
    const {
      match: { params },
    } = this.props;
    this.loadData(params.workoutId);
  }
  async loadData(id) {
    let data = await WorkoutService.getById(id);
    this.setState({ workout: data, loading: false });
  }
  onSave = async (values) => {
    await WorkoutService.update(values);
    this.props.history.push(`/workout/${this.state.workout.id}`);
  };
  render() {
    let workout = this.state.workout;
    return (
      <div>
        <div className="row">
          <div className="col">
            <CancelButton />
          </div>
        </div>
        <SpinnerPage loading={this.state.loading}></SpinnerPage>
        <WorkoutForm values={workout} onSubmit={this.onSave} />
        <Jodit />
      </div>
    );
  }
}
