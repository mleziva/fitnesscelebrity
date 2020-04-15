import React, { Component } from 'react';
import Spinner from '../../components/home/Spinner'
import FormGroupRow from '../../components/home/FormGroupRow'
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
    return (
      <div>
          <Spinner loading={this.state.loading}></Spinner>
        <form>
            <FormGroupRow value={workout.name} label={"Name"}/>
            <FormGroupRow value={workout.description} label={"Description"}/>
            <FormGroupRow value={workout.body} label={"Body"}/>
            <FormGroupRow value={workout.tags} label={"Tags"}/>
        </form>
      </div>
    );
  }

}