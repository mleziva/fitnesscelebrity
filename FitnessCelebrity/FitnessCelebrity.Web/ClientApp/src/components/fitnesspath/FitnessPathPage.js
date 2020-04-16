import React, { Component } from 'react';
import FitnessPathService from '../../services/FitnessPathService'
import SubscribeBtn from './SubscribeBtn';
import Spinner from '../../components/home/Spinner'
import FormGroupRow from '../../components/home/FormGroupRow'
import WorkoutList from '../../components/workout/WorkoutList'

export class FitnessPathPage extends Component {
  static displayName = FitnessPathPage.name;

  constructor(props) {
    super(props);
    this.state = { fitnessPath: {}, loading: true, isSubscribed: false, isEditing: false };
  }

  componentDidMount() {
    const { match: { params } } = this.props;
    this.loadFitnessPath(params.fitnessPathId);
  }
  async loadFitnessPath(id) {
    let data = await FitnessPathService.getById(id);
    this.setState({ fitnessPath: data, loading: false });
  }
  handleChange = (e) => {
    const target = e.target;
    this.setState({
      fitnessPath: {
             ...this.state.fitnessPath, // deconstruct state.abc into a new object-- effectively making a copy
             [target.name]: target.value
            }
    });
  }
  handleEditClick =() => {
    this.setState({ isEditing: !this.state.isEditing });
  }

  render() {
    let fitnessPath = this.state.fitnessPath;
    let isEditing = this.state.isEditing;
    return (
      <div>
          <Spinner loading={this.state.loading}></Spinner>
          <SubscribeBtn fitnessPathId={fitnessPath.id} isEditing={isEditing}></SubscribeBtn>
          <button className="btn btn-primary" onClick={this.handleEditClick} >Edit</button>
        <form>
            <FormGroupRow value={fitnessPath.name} label={"Name"} name="name" isEditing={isEditing} handleChange={this.handleChange}/>
            <FormGroupRow value={fitnessPath.category} label={"Category"} isEditing={isEditing}/>
            <FormGroupRow value={fitnessPath.description} label={"Description"} isEditing={isEditing}/>
            <FormGroupRow value={fitnessPath.body} label={"Body"} isEditing={isEditing}/>
            <FormGroupRow value={fitnessPath.tags} label={"Tags"} isEditing={isEditing}/>
        </form>
        <h2>Workouts</h2>
        <WorkoutList workouts={fitnessPath.workouts} />

      </div>
    );
  }

}
