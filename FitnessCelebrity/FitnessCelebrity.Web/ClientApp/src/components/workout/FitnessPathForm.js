import React from "react";
import '../../custom.css';

const FitnessPathForm = () => (
    <div className="col-md-8">
    <div className="row pathformdiv">
        <div className="col-md-6 offset-md-3">
        <form>
            <div className="form-group">
                <label htmlFor="inputName">Fitness Path name</label>
                <input id="inputName" className="form-control" type="text" placeholder="Enter workout name" />
                <small id="nameHelp" className="form-text text-muted">Give your workout a name.</small>
            </div>
            <div className="form-group">
                <label htmlFor="inputDescription">Fitness Path description</label>
                <textarea id="inputDescription" className="form-control" rows="4" placeholder="Enter workout name"></textarea>
            </div>

            <div class="form-group">
                <label htmlFor="category">Category:</label>
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
    </div>
);

export default FitnessPathForm;
