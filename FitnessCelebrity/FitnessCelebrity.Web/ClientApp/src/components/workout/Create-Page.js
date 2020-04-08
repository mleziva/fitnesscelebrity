import React, { Component } from 'react';
import authService from '../api-authorization/AuthorizeService'
import FitnessPathForm from './FitnessPathForm'
import WorkoutJson from './models/workout'

export class CreatePage extends Component {
    static displayName = CreatePage.name;

    constructor(props) {
        super(props);
        this.state = {workoutJson: WorkoutJson, displayExistingPaths: false, displayNewPathForm: false, existingPaths: [] };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.displayExistingPaths = this.displayExistingPaths.bind(this);
        this.displayNewPathForm = this.displayNewPathForm.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const name = target.name;
        const value = target.value;
        this.setState({
            workoutJson: {
                   ...this.state.workoutJson, // deconstruct state.abc into a new object-- effectively making a copy
                   [name]: value
                  }
       });
    }

    async handleSubmit(event) {
        //validate whatever
        event.preventDefault();
        console.log(JSON.stringify(this.state.workoutJson))
        await this.postWorkout();
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
            pathsDisplay = <p><FitnessPathForm/></p>
        }
      

        return (
            <div>
                <h1>Create a new workout</h1>

                <p>Fitness Path</p>
                <button className='btn' onClick={this.displayExistingPaths}>Add this workout to an existing fitness path</button>
                <button className='btn' onClick={this.displayNewPathForm}>Create new fitness path</button>
                {pathsDisplay}
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="inputName">Workout name</label>
                        <input id="inputName" className="form-control" type="text" name="name" value={this.state.workoutJson.name} onChange={this.handleInputChange} placeholder="Enter workout name" />
                        <small id="nameHelp" className="form-text text-muted">Give your workout a name.</small>
                    </div>
                    <div className="form-group">
                        <label htmlFor="inputDescription">Workout description</label>
                        <textarea id="inputDescription" className="form-control" name="description" value={this.state.workoutJson.description} onChange={this.handleInputChange} rows="4" placeholder="Enter workout name"></textarea>
                    </div>
                    <div className="form-group">
                        <label htmlFor="inputBody">Workout content</label>
                        <textarea id="inputBody" className="form-control" name="body" value={this.state.workoutJson.body} onChange={this.handleInputChange} rows="4"></textarea>
                    </div>
                    <div className="form-group">
                        <label htmlFor="category">Category:</label>
                        <select className="form-control" id="category" name="category" value={this.state.workoutJson.category} onChange={this.handleInputChange}>
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
    async postWorkout() {
        const token = await authService.getAccessToken();
        const response = await fetch('/api/workout', {
            method: 'POST',
			body: JSON.stringify(this.state.workoutJson),
            headers: { 
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        });
        const data = await response.json();
        alert('response: ' + JSON.stringify(data));
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
