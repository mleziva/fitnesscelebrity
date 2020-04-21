import React, { Component } from "react";
import FitnessPathService from "../../services/FitnessPathService";
import FitnessPathForm from "./FitnessPathForm";
import { Redirect } from "react-router-dom";

export class FitnessPathCreatePage extends Component {
  static displayName = FitnessPathCreatePage.name;

  componentDidMount() {}
  onFitnessPathSave = async (values) => {
    var createdPath = await FitnessPathService.create(values);
    //if success redirect to created page using response from post request
    this.props.history.push(`/fitnesspath/${createdPath.id}`);
  };
  render() {
    return (
      <div>
        <div className="row">
          <div className="col">
            <button
              className="btn btn-outline-primary"
              onClick={() => this.props.history.goBack()}
            >
              Cancel
            </button>
          </div>
        </div>
        <FitnessPathForm onSubmit={this.onFitnessPathSave} />
      </div>
    );
  }
}
