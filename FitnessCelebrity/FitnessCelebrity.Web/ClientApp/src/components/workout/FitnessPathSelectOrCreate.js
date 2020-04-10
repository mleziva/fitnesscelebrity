import React, { Component } from 'react';
import FitnessPathForm from './FitnessPathForm'
import FitnessPathService from './services/FitnessPathService'

export class FitnessPathSelectOrCreate extends Component {
    static displayName = FitnessPathSelectOrCreate.name;

    constructor(props) {
        super(props);
        this.state = {displayExistingPaths: false, displayNewPathForm: false, existingPaths: [] };
        this.displayExistingPaths = this.displayExistingPaths.bind(this);
        this.displayNewPathForm = this.displayNewPathForm.bind(this);
    }

    async displayExistingPaths() {
        let showPaths = this.state.displayExistingPaths
        if (!showPaths) {
            var paths = await FitnessPathService.listUserFitnessPaths();
            this.setState({ existingPaths: paths.map(c => c.name)});
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
                <p>Fitness Path</p>
                <button className='btn' onClick={this.displayExistingPaths}>Add this workout to an existing fitness path</button>
                <button className='btn' onClick={this.displayNewPathForm}>Create new fitness path</button>
                {pathsDisplay}
            </div>
        );
    }

}
