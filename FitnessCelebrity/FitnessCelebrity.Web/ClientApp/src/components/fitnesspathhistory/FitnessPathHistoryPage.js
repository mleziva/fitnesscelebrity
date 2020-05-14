import React, { Component } from "react";
import SpinnerPage from "../home/SpinnerPage";
import { FitnessPathHistoryService } from "../../services";
import { SpanRow } from "../home";
export class FitnessPathHistoryPage extends Component {
  static displayName = FitnessPathHistoryPage.name;

  constructor(props) {
    super(props);
    this.state = {
      fitnessPathHistory: {},
      loading: true,
    };
  }

  componentDidMount() {
    const {
      match: { params },
    } = this.props;
    this.loadFitnessPathHistory(params.fitnessPathHistoryId);
  }
  async loadFitnessPathHistory(id) {
    let data = await FitnessPathHistoryService.getById(id);
    this.setState({ fitnessPathHistory: data, loading: false });
  }

  render() {
    return (
      <>
        <SpinnerPage loading={this.state.loading}></SpinnerPage>
        <SpanRow
          label="Started Date"
          value={this.state.fitnessPathHistory.startedDate}
        />
      </>
    );
  }
}
