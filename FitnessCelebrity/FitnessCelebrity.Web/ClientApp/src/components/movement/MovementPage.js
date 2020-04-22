import React, { Component } from "react";
import SpinnerPage from "../../components/home/SpinnerPage";
import SpanRow from "../../components/home/SpanRow";
import MovementService from "../../services/MovementService";
import WorkoutList from "../workout/WorkoutList";
import { Link } from "react-router-dom";

export class MovementPage extends Component {
  static displayName = MovementPage.name;

  constructor(props) {
    super(props);
    this.state = { movement: {}, loading: true, isSubscribed: false };
  }

  componentDidMount() {
    const {
      match: { params },
    } = this.props;
    this.loadMovement(params.movementId);
  }
  async loadMovement(id) {
    let data = await MovementService.getById(id);
    this.setState({ movement: data, loading: false });
  }

  render() {
    let movement = this.state.movement;
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
            <form>
              <SpanRow value={movement.name} label={"Name"} />
              <SpanRow value={movement.description} label={"Description"} />
              <SpanRow value={movement.body} label={"Body"} />
              <SpanRow value={movement.tags} label={"Tags"} />
            </form>
          </div>
        </div>
        <div className="row">
          <div className="col-sm-6">
            <h2>Linked Workouts</h2>
          </div>
          <div className="col-sm-6">
            <Link
              className="btn btn-primary float-right"
              to={this.props.location.pathname + "/edit/workouts"}
            >
              Edit
            </Link>
          </div>
        </div>
        <WorkoutList workouts={movement.workouts} />
      </>
    );
  }
}
