import React, { Component } from 'react';
import ProfileService from '../../services/ProfileService';
import ProfileDetails from './profiledetails';
import FitnessPathList from '../fitnesspath/FitnessPathList'
import FitnessPathService from '../../services/FitnessPathService'

export class ProfilePage extends Component {
  static displayName = ProfilePage.name;

  constructor(props) {
    super(props);
    this.state = { profileData: {}, fitnessPaths: [], subscribedPaths: [], loading: true };
  }

  componentDidMount() {
    const { match: { params } } = this.props;
    this.populateProfile(params.profileUserName);
    this.loadData();
  }
  async populateProfile(profileUserName) {
    let data = await ProfileService.getProfile(profileUserName);
    this.setState({ profileData: data, loading: false });
  }
  async loadData() {
    let fitnessPaths = await FitnessPathService.get({size:5});
    let subscribedPaths =  await FitnessPathService.getSubscribedPaths("677f3748-0249-45ce-8979-9b7eda98c668", {size:5});
    this.setState({ fitnessPaths: fitnessPaths, subscribedPaths: subscribedPaths });
  }

  render() {
    let imgLink = "https://scontent-ort2-1.cdninstagram.com/v/t51.2885-19/11810005_690703291059585_220494516_a.jpg?_nc_ht=scontent-ort2-1.cdninstagram.com&_nc_ohc=v64FZhAKRwIAX8ve6i-&oh=4ffcaa5fb8e180ddd75d54eeb0aebdaf&oe=5EBE1947"
    let profileData = this.state.profileData;
    let contents = this.state.loading
    ? <p><em>Loading...</em></p>
    : <ProfileDetails profileData={profileData}></ProfileDetails>;

    return (
      <div>
        <h1 >Profile</h1>
        <div className="row">
          <div className="col-sm-4">
            <img src={imgLink} alt="profile pic"></img>
          </div>
          <div className="col">
            {contents}
          </div>
        </div>
        <div className="row">
          <div className="col">
            Top 5 Created fitness paths
            <FitnessPathList fitnessPaths={this.state.fitnessPaths} viewAll={{link: "link"}}></FitnessPathList>
          </div>
        </div>
        <div className="row">
          <div className="col">Top 5 Created  workouts</div>
        </div>
        <div className="row">
          <div className="col">Top 5 created movments</div>
        </div>
        <div className="row">
          <div className="col">
            Top 5 followed fitness
            <FitnessPathList fitnessPaths={this.state.subscribedPaths}></FitnessPathList>
            </div>
            View all
            <div className="col">view alls</div>
        </div>
        <div className="row">
          <div className="col">Top 5 followed workouts</div>
        </div>
      </div>
    );
  }

}
