import React from "react";

function FormGroupRow(props) {
    const id = props.label +"id";
    const value = props.value ?? "";
    const isEditing = props.isEditing;
    const name = props.name;

    return (
        
        <div className="form-group row">
            <label htmlFor={id} className="col-sm-2 col-form-label">{props.label}</label>
            <div className="col-sm-10">
                <input type="text" readOnly={!isEditing} name={name} className={isEditing ? "form-control": "form-control-plaintext"} id={id} value={value} onChange={props.handleChange}/>
            </div>
        </div>
    );
}
export default FormGroupRow;