import React, { Component } from 'react';
import Helper from '../../services/Helper'
import FitnessPathService from '../../services/FitnessPathService'
import WorkoutService from '../../services/WorkoutService'
import MovementService from '../../services/MovementService'
import FitnessPathList from '../fitnesspath/FitnessPathList';
import MovementList from '../movement/MovementList';
import WorkoutList from '../workout/WorkoutList';

export class SearchPage extends Component {
  static displayName = SearchPage.name;

  constructor(props) {
    super(props);
    this.state = { fitnessPathResults: [], workoutResults: [], movementResults: [], query: '' };
  }
  componentDidMount() {
    let qobject = Helper.queryToObject(this.props.location.search);
    let qtext = qobject.q;
    if(qtext) {
      this.setState({query: qtext});
      this.search(qtext);
     }
  }

  handleChange = (e) => {
    const target = e.target;
    const name = target.name;
    const value = target.value;
    this.setState({[name]: value});
 }

   handleSearch = async() => {
    let query = this.state.query;
    Helper.setQueryStringWithoutPageReload({"q": query});
    this.search(query);
  }
  search= async(query) => {
    let fresults = await FitnessPathService.search(query);
    let wresults = await WorkoutService.search(query);
    let mresults = await MovementService.search(query);
    this.setState({ fitnessPathResults: fresults, workoutResults: wresults, movementResults: mresults });
  }


  render() {
    let fresults = this.state.fitnessPathResults;
    let wresults = this.state.workoutResults;
    let mresults = this.state.movementResults;
    let flist, wlist, mlist;
    if(fresults.length > 0){
      flist = (
        <div>
        <div className="row">
          <div className="col">
          <h2>Fitness Paths:</h2>
          </div>
          </div>
          <FitnessPathList fitnessPaths={fresults}></FitnessPathList>
          </div>
      )
    }
    if(wresults.length > 0){
      wlist = (
        <div>
        <div className="row">
          <div className="col">
          <h2>Workouts:</h2>
          </div>
          </div>
          <WorkoutList workouts={wresults}/>
          </div>
        )
    }
    if(mresults.length > 0){
      mlist = (
        <div>
        <div className="row">
          <div className="col">
          <h2>Movements:</h2>
          </div>
          </div>
          <MovementList movements={mresults}/>
          </div>
        )
    }
    return (
      <div>
        <h1 >Search Fitness Paths</h1>
        <div className="input-group mb-3">
            <input type="text" className="form-control" name="query" value={this.state.query} onChange={this.handleChange} placeholder="FitnessPath Tags" aria-label="Fitness Path Tags" aria-describedby="basic-addon2"/>
            <div className="input-group-append">
                <button className="btn btn-outline-secondary" type="button" onClick={this.handleSearch}>Search</button>
            </div>
        </div>
        {flist}
        {wlist}
        {mlist}
      </div>
    );
  }

}
