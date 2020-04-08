import React, { Component } from 'react';

export class MovementForm extends Component {
  static displayName = MovementForm.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  render() {
    return (
      <div className="row pathformdiv">
        <div className="col-md-6 offset-md-3">
        <form>
            <div class="form-group">
                <label for="inputName">Fitness Path name</label>
                <input id="inputName" className="form-control" type="text" placeholder="Enter workout name" />
                <small id="nameHelp" className="form-text text-muted">Give your workout a name.</small>
            </div>
            <div class="form-group">
                <label for="inputDescription">Fitness Path description</label>
                <textarea id="inputDescription" className="form-control" rows="4" placeholder="Enter workout name"></textarea>
            </div>

            <div class="form-group">
                <label for="category">Category:</label>
                <select className="form-control" id="category">
                    <option value="instagram">instagram</option>
                    <option value="youtube">youtube</option>
                    <option value="google sheets">google</option>
                    <option value="image">image</option>
                    <option value="text/other">Other</option>
                </select>
            </div>
            </form>
        </div>
    </div>
    );
  }
}
