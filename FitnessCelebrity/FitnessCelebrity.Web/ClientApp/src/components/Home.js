import React, { Component } from 'react';
import {SearchPage} from './search/SearchPage';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        Your current active workouts: 

        Your progress summary:

        What other people have been doing:

        <SearchPage></SearchPage>
      </div>
    );
  }
}
