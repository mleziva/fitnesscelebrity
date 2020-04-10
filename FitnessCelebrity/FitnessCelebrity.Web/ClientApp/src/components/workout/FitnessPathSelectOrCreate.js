import React, { Component } from 'react';
import FitnessPathForm from './FitnessPathForm'
import FitnessPathService from '../../services/FitnessPathService'

export class FitnessPathSelectOrCreate extends Component {
    static displayName = FitnessPathSelectOrCreate.name;

    constructor(props) {
        super(props);
        this.state = {displayExistingPaths: false, displayNewPathForm: false, existingPaths: [], selectedId : ""};
        this.displayExistingPaths = this.displayExistingPaths.bind(this);
        this.displayNewPathForm = this.displayNewPathForm.bind(this);
    }

    async displayExistingPaths() {
        let showPaths = this.state.displayExistingPaths
        if (!showPaths) {
            var paths = await FitnessPathService.listUserFitnessPaths();
            this.setState({ existingPaths: paths.map(c => ({name: c.name, id: c.id}))});
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

    fitnessPathSelect = (e) => {
        let selectlist = e.target;
        this.setState({selectedId : selectlist.value})
        this.props.onFitnessPathSelect(selectlist.value);
      }


    render() {
        const displayExistingPaths = this.state.displayExistingPaths;
        const displayNewPathForm = this.state.displayNewPathForm;
        const Dropdown = ({ options }) =>
            <select className="form-control" id="fitnessPathId" name="fitnessPathId" value={this.state.selectedId} onChange={this.fitnessPathSelect}>
                {options.map((e,i) => <option key={i} value={e.id}>{e.name}</option>)}
            </select>
            ;
        let pathsDisplay;
        if (displayExistingPaths) {
            pathsDisplay = <Dropdown options={this.state.existingPaths} />
        }
        if (displayNewPathForm) {
            pathsDisplay = <FitnessPathForm fitnessPathObj={this.props.fitnessPathObj} fitnessPathFormChange={this.props.fitnessPathFormChange}/>
        }
      
        return (
            <div>
                <p>Fitness Path</p>
                <div className="btn-group btn-group-toggle" data-toggle="buttons">
                    <label className="btn btn-secondary">
                        <input type="radio" name="options" id="option1" onClick={this.displayExistingPaths}/>Add this workout to an existing fitness path
                    </label>
                    <label className="btn btn-secondary">
                        <input type="radio" name="options" id="option2" onClick={this.displayNewPathForm}/>Create new fitness path
                    </label>
                </div>
                <div className="form-group">
                    <label htmlFor="category">Fitness Path:</label>
                    {pathsDisplay}
                </div>
            </div>
        );
    }

}
