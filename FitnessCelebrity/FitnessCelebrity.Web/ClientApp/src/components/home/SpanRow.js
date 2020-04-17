import React from "react";

function SpanRow(props) {
    return (
        
        <div className="form-group row">
            <label  className="col-sm-2">{props.label}</label>
            <div className="col-sm-10">
                <span>{props.value}</span>
            </div>
        </div>
    );
}
export default SpanRow;