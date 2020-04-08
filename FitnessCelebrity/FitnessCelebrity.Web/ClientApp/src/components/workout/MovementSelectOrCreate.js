import React, { Component } from 'react';
import {MovementForm} from './MovementForm';

export class MovementSelectOrCreate extends Component {
  static displayName = MovementSelectOrCreate.name;

  constructor(props) {
    super(props);
    this.state = { existingMovements: [] };
    this.displayExistingMovements = this.displayExistingMovements.bind(this);
        this.displayNewMovementForm = this.displayNewMovementForm.bind(this);
  }

  displayExistingMovements() {
        let show = this.state.displayExistingMovements
        if (!show) {
            //load data from API
            this.setState({ existingMovements: ["Grass", "Poison", "Fire", "Flying", "Dragon"]});
        }
        this.setState({
            displayExistingMovements: !show,
            displayNewMovementForm: false
        });
    }
    displayNewMovementForm() {
        this.setState({
            displayExistingMovements: false,
            displayNewMovementForm: !this.state.displayNewMovementForm
        });
    }
  render() {
    const displayExistingMovements = this.state.displayExistingMovements;
    const displayNewMovementForm = this.state.displayNewMovementForm;
    const Dropdown = ({ options }) =>
        <select>
            {options.map((e, i) => <option key={i}>{e}</option>)}
        </select>
        ;
    let display;
    if (displayExistingMovements) {
        display = <p><Dropdown options={this.state.existingMovements} /></p>
    }
    if (displayNewMovementForm) {
        display = <p><MovementForm/></p>
    }
    return (
      <div>
        <h1>Movements</h1>
        <button className='btn' onClick={this.displayExistingMovements}>Add existing movements to this workout</button>
            <button className='btn' onClick={this.displayNewMovementForm}>Create new movements for this workout</button>
            {display}
      </div>
    );
  }
}
