import React, { Component } from "react";
import SpinnerPage from "../home/SpinnerPage";
import { FitnessPathHistoryService, FitnessPathService } from "../../services";
import { SpanRow } from "../home";
import { WorkoutScheduleTableCompleted } from "../workoutschedule";
export class FitnessPathHistoryPage extends Component {
  static displayName = FitnessPathHistoryPage.name;

  constructor(props) {
    super(props);
    this.state = {
      fitnessPathHistory: {},
      fitnessPath: {},
      loading: true,
    };
  }

  //load fitness path and fitness path history
  //compare workouts and add like for viewing finished workouts
  componentDidMount() {
    const {
      match: { params },
    } = this.props;
    this.loadFitnessPathHistory(params.fitnessPathHistoryId);
  }
  async loadFitnessPathHistory(id) {
    let fph = await FitnessPathHistoryService.getById(id);
    let fp = await FitnessPathService.getById(fph.fitnessPathId);
    this.setState({ fitnessPathHistory: fph, fitnessPath: fp, loading: false });
  }

  render() {
    let fitnessPath = this.state.fitnessPath;
    let fitnessPathHistory = this.state.fitnessPathHistory;
    return (
      <>
        <SpinnerPage loading={this.state.loading}></SpinnerPage>
        <SpanRow label="Started Date" value={fitnessPathHistory.startedDate} />
        <WorkoutScheduleTableCompleted
          workoutSchedule={fitnessPath.workoutSchedule}
          workouts={fitnessPath.workouts}
          completedWorkouts={fitnessPathHistory.workoutHistories}
        />
      </>
    );
  }
}
