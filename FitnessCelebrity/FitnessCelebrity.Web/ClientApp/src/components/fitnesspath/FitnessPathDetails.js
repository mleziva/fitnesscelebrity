import React, { Component } from 'react';
import FitnessPathService from '../../services/FitnessPathService'

export class FitnessPathDetails extends Component {
  static displayName = FitnessPathDetails.name;

  constructor(props) {
    super(props);
    this.state = { fitnessPath: {}, loading: true };
  }

  componentDidMount() {
    const { match: { params } } = this.props;
    this.populateFitnessPath(params.fitnessPathId);
  }

  renderFitnessPath(fitnessPath) {
    return (
        <div>
            <h4><span className="badge badge-secondary">Name </span>{fitnessPath.name}</h4>
        </div>

    );
  }

  render() {
    let fitnessPath = this.state.fitnessPath;
    let contents = this.state.loading
    ? <p><em>Loading...</em></p>
    : this.renderFitnessPath(fitnessPath);

    return (
      <div>
        <h1 >Fitness Path: {fitnessPath.name}</h1>
        <h2> Created by: author</h2>
        {contents}
      </div>
    );
  }
  async populateFitnessPath(id) {
    let data = await FitnessPathService.getById(id);
    this.setState({ fitnessPath: data, loading: false });
  }
}
