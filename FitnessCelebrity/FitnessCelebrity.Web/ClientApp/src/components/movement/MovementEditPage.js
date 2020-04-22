import React, { Component } from "react";
import MovementService from "../../services/MovementService";
import MovementForm from "./MovementForm";
import CancelButton from "../shared/buttons/cancelbutton";
import SpinnerPage from "../home/SpinnerPage";

export class MovementEditPage extends Component {
  static displayName = MovementEditPage.name;

  constructor(props) {
    super(props);
    this.state = { movement: {}, loading: true };
  }

  componentDidMount() {
    const {
      match: { params },
    } = this.props;
    this.loadMovement(params.movementId);
  }
  async loadMovement(id) {
    let data = await MovementService.getById(id);
    this.setState({ movement: data, loading: false });
  }
  onSave = async (values) => {
    await MovementService.update(values);
    this.props.history.push(`/movement/${this.state.movement.id}`);
  };
  render() {
    let movement = this.state.movement;
    return (
      <div>
        <div className="row">
          <div className="col">
            <CancelButton />
          </div>
        </div>
        <SpinnerPage loading={this.state.loading}></SpinnerPage>
        <MovementForm values={movement} onSubmit={this.onSave} />
      </div>
    );
  }
}
