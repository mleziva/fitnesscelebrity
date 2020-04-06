import React, { Component } from 'react';

export class CreatePage extends Component {
    static displayName = CreatePage.name;

  constructor(props) {
    super(props);
    this.state = { value: '' };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    handleSubmit(event) {
        alert('A name was submitted: ' + this.state.value);
        event.preventDefault();
    }

    render() {
        return (
            <div>
                <h1>Create a new workout</h1>

                <p>Fitness Path: Add this workout to a new or existing fitness path</p>
                <button>Button for fitness path</button>
            <form onSubmit={this.handleSubmit}>
                <label>
                    Name:
          <input type="text" value={this.state.value} onChange={this.handleChange} />
                </label>
                <input type="submit" value="Submit" />
                </form>
            </div>

        );
    }
}
