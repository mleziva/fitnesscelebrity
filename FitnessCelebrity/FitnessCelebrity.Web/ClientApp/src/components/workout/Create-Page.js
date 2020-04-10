import React, { Component } from 'react';
import authService from '../api-authorization/AuthorizeService'
import {MovementSelectOrCreate} from './MovementSelectOrCreate'
import {FitnessPathSelectOrCreate} from './FitnessPathSelectOrCreate'
import WorkoutJson from './models/workout'

export class CreatePage extends Component {
    static displayName = CreatePage.name;

    constructor(props) {
        super(props);
        this.state = {workoutJson: WorkoutJson };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
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
    fitnessPathSelect = (fitnessPathid) => {
        let fpobj = {};
        fpobj["fitnessPathid"]=fitnessPathid;
        let fitnessPathWorkouts = [fpobj];
        console.log(JSON.stringify(fitnessPathWorkouts));
        const workoutJson = { ...this.state.workoutJson, ["fitnessPathWorkouts"]: fitnessPathWorkouts }
        this.setState(() => ({ workoutJson }))
    }

    render() {
        return (
            <div>
                <h1>Create a new workout</h1>
                    <FitnessPathSelectOrCreate onFitnessPathSelect={this.fitnessPathSelect}></FitnessPathSelectOrCreate>
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
                        <MovementSelectOrCreate></MovementSelectOrCreate>
                    <input type="submit" className="btn btn-primary" value="Submit" />
                </form>
            </div>

        );
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
        //do some error handling/logging
        const data = await response.json();
    }
}
