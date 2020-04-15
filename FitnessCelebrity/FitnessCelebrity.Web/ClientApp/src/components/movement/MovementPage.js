import React, { Component } from 'react';
import FitnessPathService from '../../services/FitnessPathService'

export class MovementPage extends Component {
  static displayName = MovementPage.name;

  constructor(props) {
    super(props);
    this.state = { movement: {}, loading: true, isSubscribed: false };
  }

  componentDidMount() {
    const { match: { params } } = this.props;
    this.populateFitnessPath(params.movementId);
  }
  async populateFitnessPath(id) {
    let data = await FitnessPathService.getById(id);
    this.setState({ fitnessPath: data, loading: false });
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
  
}