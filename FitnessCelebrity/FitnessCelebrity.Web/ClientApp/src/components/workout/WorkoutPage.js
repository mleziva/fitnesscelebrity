import React, { Component } from "react";
import SpinnerPage from "../../components/home/SpinnerPage";
import SpanRow from "../../components/home/SpanRow";
import WorkoutService from "../../services/WorkoutService";
import { Link } from "react-router-dom";
import LinkList from "../shared/lists/linklist";

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
      <>
        <SpinnerPage loading={this.state.loading}></SpinnerPage>
        <div className="row">
          <div className="col">
            <Link
              className="btn btn-primary float-right"
              to={this.props.location.pathname + "/edit"}
            >
              Edit
            </Link>
          </div>
        </div>
        <div className="row">
          <div className="col">
            <SpanRow value={workout.name} label={"Name"} />
            <SpanRow value={workout.description} label={"Description"} />
            <SpanRow value={workout.body} label={"Body"} />
            <SpanRow value={workout.tags} label={"Tags"} />
          </div>
        </div>
        <div className="row">
          <div className="col-sm-6">
            <h2>Linked FitnessPaths</h2>
          </div>
          <div className="col-sm-6">
            <Link
              className="btn btn-primary float-right"
              to={this.props.location.pathname + "/fitnessPaths/edit"}
            >
              Edit
            </Link>
          </div>
        </div>
        <LinkList items={workout.fitnessPaths} path="fitnesspath" />
        <div className="row">
          <div className="col-sm-6">
            <h2>Linked Movements</h2>
          </div>
          <div className="col-sm-6">
            <Link
              className="btn btn-primary float-right"
              to={this.props.location.pathname + "/edit/movements"}
            >
              Edit
            </Link>
          </div>
        </div>
        <LinkList items={workout.movements} path="movement" />
      </>
    );
  }
}
