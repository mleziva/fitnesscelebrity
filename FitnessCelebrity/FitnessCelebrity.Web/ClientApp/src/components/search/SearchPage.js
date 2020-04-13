import React, { Component } from 'react';
import FitnessPathService from '../../services/FitnessPathService'
import FitnessPathList from '../fitnesspath/FitnessPathList';

export class SearchPage extends Component {
  static displayName = SearchPage.name;

  constructor(props) {
    super(props);
    this.state = { fitnessPathResults: [], query: '' };
    this.searchFitnessPath = this.searchFitnessPath.bind(this);
  }

  handleChange = (e) => {
    const target = e.target;
    const name = target.name;
    const value = target.value;
    this.setState({[name]: value});
 }

  renderFitnessPathSearchResults(fitnessPathResults) {
    return (
        <FitnessPathList fitnessPathResults={this.state.fitnessPathResults}></FitnessPathList>

    );
  }

  render() {
    let fitnessPathResults = this.state.fitnessPathResults;
    let contents = fitnessPathResults.length ===0
      ? <p><em>No Results</em></p>
      : this.renderFitnessPathSearchResults(fitnessPathResults);

    return (
      <div>
        <h1 >Search Fitness Paths</h1>
        <div className="input-group mb-3">
            <input type="text" className="form-control" name="query" value={this.state.query} onChange={this.handleChange} placeholder="FitnessPath Tags" aria-label="Fitness Path Tags" aria-describedby="basic-addon2"/>
            <div className="input-group-append">
                <button className="btn btn-outline-secondary" type="button" onClick={this.searchFitnessPath}>Search</button>
            </div>
        </div>
        Results:
        {contents}
      </div>
    );
  }
  async searchFitnessPath() {
    let query = this.state.query;
    let data = await FitnessPathService.search(query);
    this.setState({ fitnessPathResults: data, loading: false });
  }
}
