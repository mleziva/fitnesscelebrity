import React, { Component } from 'react';
import {SearchPage} from './search/SearchPage';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <SearchPage></SearchPage>
      </div>
    );
  }
}
