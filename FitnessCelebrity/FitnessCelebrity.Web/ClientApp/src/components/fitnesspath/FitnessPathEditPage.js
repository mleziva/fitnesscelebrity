import React, { Component } from 'react';
import FitnessPathService from '../../services/FitnessPathService'
import Spinner from '../home/Spinner';
import FitnessPathEditForm from '../fitnesspath/FitnessPathEditForm';


export class FitnessPathEditPage extends Component {
  static displayName = FitnessPathEditPage.name;

  constructor(props) {
    super(props);
    this.state = { fitnessPath: {}, loading: true};
  }

  componentDidMount() {
    const { match: { params } } = this.props;
    this.loadFitnessPath(params.fitnessPathId);
  }
  async loadFitnessPath(id) {
    let data = await FitnessPathService.getById(id);
    this.setState({ fitnessPath: data, loading: false });
  }

  handleSaveClick =() => {
    this.setState({ isEditing: !this.state.isEditing });
  }

  render() {
    let fitnessPath = this.state.fitnessPath;
    return (
      <div>
          <div className="row">
            <button className="btn btn-primary" onClick={() => this.props.history.goBack()} >Cancel</button>
          </div>
          <Spinner loading={this.state.loading}></Spinner>
          <FitnessPathEditForm values={fitnessPath} onSubmit={this.handleSaveClick}/>
      </div>
    );
  }

}
