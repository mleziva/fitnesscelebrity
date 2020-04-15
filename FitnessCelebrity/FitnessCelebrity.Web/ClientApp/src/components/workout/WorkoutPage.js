import React, { Component } from 'react';
import Spinner from '../../components/home/Spinner'
import WorkoutService from '../../services/WorkoutService'

export class WorkoutPage extends Component {
  static displayName = WorkoutPage.name;

  constructor(props) {
    super(props);
    this.state = { workout: {}, loading: true, isSubscribed: false };
  }

  componentDidMount() {
    const { match: { params } } = this.props;
    this.loadWorkout(params.workoutId);
  }
  async loadWorkout(id) {
    let data = await WorkoutService.getById(id);
    this.setState({ workout: data, loading: false });
  }

  render() {
    let workout = this.state.workout;
    let loading = this.state.loading

    return (
      <div>
          <Spinner loading={this.state.loading}></Spinner>
        <form>
        <div className="form-group row">
            <label htmlFor="staticEmail" className="col-sm-2 col-form-label">Name</label>
            <div className="col-sm-10">
            <input type="text" readOnly className="form-control-plaintext" id="staticEmail" value={workout.name}/>
            </div>
        </div>
        <div className="form-group row">
            <label htmlFor="inputPassword" className="col-sm-2 col-form-label">Description</label>
            <div className="col-sm-10">
            <input type="text" readOnly className="form-control-plaintext" id="staticEmail" value={workout.description}/>
            </div>
        </div>
        </form>
      </div>
    );
  }

}