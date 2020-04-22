import React, { Component } from "react";
import MovementService from "../../services/MovementService";
import MovementForm from "./MovementForm";
import CancelButton from "../shared/buttons/cancelbutton";

export class MovementCreatePage extends Component {
  static displayName = MovementCreatePage.name;

  componentDidMount() {}
  onSave = async (values) => {
    var createdMovement = await MovementService.create(values);
    //if success redirect to created page using response from post request
    this.props.history.push(`/movement/${createdMovement.id}`);
  };
  render() {
    return (
      <div>
        <div className="row">
          <div className="col">
            <CancelButton />
          </div>
        </div>
        <MovementForm onSubmit={this.onSave} />
      </div>
    );
  }
}
