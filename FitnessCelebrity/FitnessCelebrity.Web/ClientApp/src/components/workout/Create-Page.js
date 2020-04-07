import React, { Component } from 'react';
import authService from '../api-authorization/AuthorizeService'

export class CreatePage extends Component {
    static displayName = CreatePage.name;

    constructor(props) {
        super(props);
        this.state = { displayExistingPaths: false, displayNewPathForm: false, existingPaths: [] };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.displayExistingPaths = this.displayExistingPaths.bind(this);
        this.displayNewPathForm = this.displayNewPathForm.bind(this);
    }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    handleSubmit(event) {
        alert('A name was submitted: ' + this.state.value);
        event.preventDefault();
    }

    render() {
        const displayExistingPaths = this.state.displayExistingPaths;
        const displayNewPathForm = this.state.displayNewPathForm;
        const Dropdown = ({ options }) =>
            <select>
                {options.map((e, i) => <option key={i}>{e}</option>)}
            </select>
            ;
        let pathsDisplay;
        if (displayExistingPaths) {
            pathsDisplay = <p><Dropdown options={this.state.existingPaths} /></p>
        }
        if (displayNewPathForm) {
            pathsDisplay = <p>New Paths!</p>
        }
      

        return (
            <div>
                <h1>Create a new workout</h1>

                <p>Fitness Path</p>
                <button className='btn' onClick={this.displayExistingPaths}>Add this workout to an existing fitness path</button>
                <button className='btn' onClick={this.displayNewPathForm}>Create new fitness path</button>
                {pathsDisplay}
                <form onSubmit={this.handleSubmit}>
                    <div class="form-group">
                        <label for="inputName">Workout name</label>
                        <input id="inputName" className="form-control" type="text" value={this.state.value} onChange={this.handleChange} placeholder="Enter workout name" />
                        <small id="nameHelp" className="form-text text-muted">Give your workout a name.</small>
                    </div>
                    <div class="form-group">
                        <label for="inputDescription">Workout description</label>
                        <textarea id="inputDescription" className="form-control" rows="4" placeholder="Enter workout name"></textarea>
                    </div>
                    <div class="form-group">
                        <label for="inputBody">Workout content</label>
                        <textarea id="inputBody" className="form-control" rows="4"></textarea>
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

                    <input type="submit" className="btn btn-primary" value="Submit" />
                </form>
            </div>

        );
    }
    displayExistingPaths() {
        let showPaths = this.state.displayExistingPaths
        if (!showPaths) {
            //load data from API
            this.setState({ existingPaths: ["Grass", "Poison", "Fire", "Flying", "Dragon"]});
        }
        this.setState({
            displayExistingPaths: !showPaths,
            displayNewPathForm: false
        });
    }
    displayNewPathForm() {
        this.setState({
            displayExistingPaths: false,
            displayNewPathForm: !this.state.displayNewPathForm
        });
    }
    async getExistingPaths() {
        const token = await authService.getAccessToken();
        const response = await fetch('weatherforecast', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
}
