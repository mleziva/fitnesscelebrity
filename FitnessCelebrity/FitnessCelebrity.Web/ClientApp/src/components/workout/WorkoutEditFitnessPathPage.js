import React, { Component } from "react";
import WorkoutService from "../../services/WorkoutService";
import FitnessPathService from "../../services/FitnessPathService";
import SpinnerPage from "../home/SpinnerPage";
import ListManager from "../shared/content/ListManager";

export class WorkoutEditFitnessPathPage extends Component {
  static displayName = WorkoutEditFitnessPathPage.name;

  constructor(props) {
    super(props);
    this.state = {
      workout: {},
      fitnessPaths: [],
      loading: true,
    };
  }

  componentDidMount() {
    const {
      match: { params },
    } = this.props;
    this.loadData(params.workoutId);
  }
  async loadData(id) {
    let workout = await WorkoutService.getById(id);
    let fitnessPaths = await FitnessPathService.get();
    this.setState({
      workout: workout,
      fitnessPaths: fitnessPaths,
      loading: false,
    });
  }
  onSave = async (linkedItems) => {
    var workout = this.state.workout;
    workout.fitnessPaths = linkedItems;
    await WorkoutService.updateFitnessPaths(workout);
    //update the state if it worked
    this.setState({ workout: workout });
    this.props.history.push(`/workout/${this.state.workout.id}`);
  };

  render() {
    let workout = this.state.workout;
    let fitnessPaths = this.state.fitnessPaths;
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <ListManager
        linkedItems={workout.fitnessPaths}
        allItems={fitnessPaths}
        onSave={this.onSave}
        linkedItemsTitle="Linked fitness paths"
        allItemsTitle="Available fitness paths"
      />
    );

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
        {contents}
      </div>
    );
  }
}
