import React, { Component } from 'react';
import FitnessPathService from '../../services/FitnessPathService'
import SubscribeBtn from './SubscribeBtn';
import Spinner from '../home/Spinner'
import WorkoutList from '../workout/WorkoutList'
import FitnessPathEditForm from './FitnessPathEditForm'
import FitnessPathDetails from './FitnessPathDetails'
import FitnessPathWorkouts from './FitnessPathWorkouts'


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
    let detailsView =  (
      <>
      <FitnessPathDetails fitnessPath={fitnessPath}/>
      <h2>Linked Workouts</h2>
      <WorkoutList workouts={fitnessPath.workouts} />
      </>
    );
    let editingView = (
      <>
      <FitnessPathEditForm values={fitnessPath}/>
      </>
    );
    let content = isEditing ? editingView : detailsView;
    return (
      <div>
          <Spinner loading={this.state.loading}></Spinner>
          <div className="row">
            <div className={`col-sm-2  ${isEditing ? "invisible" : ""}`}>
            <SubscribeBtn fitnessPathId={fitnessPath.id} ></SubscribeBtn>
            </div>
            <div className="col-sm-2 pull-right offset-sm-8">
            <div className="text-right">
              <button className="btn btn-primary" onClick={this.handleEditClick} >{isEditing ? "Cancel" : "Edit"}</button>
              </div>
            </div>
             
          </div>
          
           {content}
          <FitnessPathWorkouts workouts={fitnessPath.workouts}/>
           
      </div>
    );
  }

}
