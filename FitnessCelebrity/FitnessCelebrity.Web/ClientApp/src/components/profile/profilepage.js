import React, { Component } from 'react';
import ProfileService from '../../services/ProfileService';
import ProfileDetails from './profiledetails';

export class ProfilePage extends Component {
  static displayName = ProfilePage.name;

  constructor(props) {
    super(props);
    this.state = { profileData: {}, loading: true };
  }

  componentDidMount() {
    const { match: { params } } = this.props;
    this.populateProfile(params.profileUserName);
  }

  render() {
    let profileData = this.state.profileData;
    let contents = this.state.loading
    ? <p><em>Loading...</em></p>
    : <ProfileDetails profileData={profileData}></ProfileDetails>;

    return (
      <div>
        <h1 >Profile</h1>
        {contents}
      </div>
    );
  }
  async populateProfile(profileUserName) {
    let data = await ProfileService.getProfile(profileUserName);
    this.setState({ profileData: data, loading: false });
  }
}
