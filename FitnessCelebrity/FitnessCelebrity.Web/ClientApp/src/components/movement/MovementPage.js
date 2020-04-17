import React, { Component } from 'react';
import Spinner from '../../components/home/Spinner'
import SpanRow from '../../components/home/SpanRow'
import MovementService from '../../services/MovementService'

export class MovementPage extends Component {
  static displayName = MovementPage.name;

  constructor(props) {
    super(props);
    this.state = { movement: {}, loading: true, isSubscribed: false };
  }

  componentDidMount() {
    const { match: { params } } = this.props;
    this.loadMovement(params.movementId);
  }
  async loadMovement(id) {
    let data = await MovementService.getById(id);
    this.setState({ movement: data, loading: false });
  }
  
  render() {
    let movement = this.state.movement;
    return (
      <div>
          <Spinner loading={this.state.loading}></Spinner>
        <form>
            <SpanRow value={movement.name} label={"Name"}/>
            <SpanRow value={movement.description} label={"Description"}/>
            <SpanRow value={movement.body} label={"Body"}/>
            <SpanRow value={movement.tags} label={"Tags"}/>
        </form>
      </div>
    );
  }
  
}