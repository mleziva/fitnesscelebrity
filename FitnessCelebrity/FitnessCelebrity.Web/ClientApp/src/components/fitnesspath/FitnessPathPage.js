import React, { Component } from "react";
import FitnessPathService from "../../services/FitnessPathService";
import SubscribeBtn from "./SubscribeBtn";
import SpinnerPage from "../home/SpinnerPage";
import { CreateBtn } from "../fitnesspathhistory";
import FitnessPathDetails from "./FitnessPathDetails";
import { Link } from "react-router-dom";
import WorkoutScheduleTableSelector from "../workoutschedule/WorkoutScheduleTableSelector";
import HistoryPanel from "../fitnesspathhistory/HistoryPanel";

export class FitnessPathPage extends Component {
  static displayName = FitnessPathPage.name;

  constructor(props) {
    super(props);
    this.state = {
      fitnessPath: {},
      loading: true,
      isSubscribed: false,
      isEditing: false,
    };
  }

  componentDidMount() {
    const {
      match: { params },
    } = this.props;
    this.loadFitnessPath(params.fitnessPathId);
  }
  async loadFitnessPath(id) {
    let data = await FitnessPathService.getById(id);
    this.setState({ fitnessPath: data, loading: false });
  }

  render() {
    let fitnessPath = this.state.fitnessPath;

    return (
      <div>
        <SpinnerPage loading={this.state.loading}></SpinnerPage>
        <div className="row">
          <div className="col-sm-4">
            <SubscribeBtn fitnessPathId={fitnessPath.id}></SubscribeBtn>
          </div>
          <div className="col-sm-2 offset-sm-6">
            <div className="text-right">
              <Link
                className="btn btn-primary"
                to={this.props.location.pathname + "/edit"}
              >
                Edit
              </Link>
            </div>
          </div>
        </div>
        <HistoryPanel fitnessPathId={fitnessPath.id} />
        <FitnessPathDetails fitnessPath={fitnessPath} />
        <div className="row">
          <div className="col-sm-4">
            <h2>Workouts</h2>
          </div>
          <div className="col-sm-2 offset-sm-6">
            <Link
              className="btn btn-primary"
              to={this.props.location.pathname + "/workouts/edit"}
            >
              Edit
            </Link>
          </div>
        </div>
        <WorkoutScheduleTableSelector
          workoutSchedule={fitnessPath.workoutSchedule}
          workouts={fitnessPath.workouts}
        />
      </div>
    );
  }
}
