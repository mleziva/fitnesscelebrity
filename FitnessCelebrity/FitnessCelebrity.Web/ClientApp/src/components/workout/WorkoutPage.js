import React, { Component } from "react";
import SpinnerPage from "../../components/home/SpinnerPage";
import SpanRow from "../../components/home/SpanRow";
import WorkoutService from "../../services/WorkoutService";

export class WorkoutPage extends Component {
  static displayName = WorkoutPage.name;

  constructor(props) {
    super(props);
    this.state = { workout: {}, loading: true, isSubscribed: false };
  }

  componentDidMount() {
    const {
      match: { params },
    } = this.props;
    this.loadWorkout(params.workoutId);
  }
  async loadWorkout(id) {
    let data = await WorkoutService.getById(id);
    this.setState({ workout: data, loading: false });
  }

  render() {
    let workout = this.state.workout;
    return (
      <div>
        <SpinnerPage loading={this.state.loading}></SpinnerPage>
        <form>
          <SpanRow value={workout.name} label={"Name"} />
          <SpanRow value={workout.description} label={"Description"} />
          <SpanRow value={workout.body} label={"Body"} />
          <SpanRow value={workout.tags} label={"Tags"} />
        </form>
      </div>
    );
  }
}
