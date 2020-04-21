import React, { Component } from "react";
import FitnessPathService from "../../services/FitnessPathService";
import SpinnerPage from "../home/SpinnerPage";
import FitnessPathWorkouts from "./FitnessPathWorkouts";

export class FitnessPathEditWorkoutsPage extends Component {
  static displayName = FitnessPathEditWorkoutsPage.name;

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

    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <FitnessPathWorkouts fitnessPath={fitnessPath} />
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
