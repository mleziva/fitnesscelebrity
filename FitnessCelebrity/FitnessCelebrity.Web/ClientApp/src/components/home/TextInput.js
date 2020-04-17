import React from "react";
import {useField} from "formik";

function TextInput(props) {
    // useField() returns [formik.getFieldProps(), formik.getFieldMeta()]
    // which we can spread on <input> and alse replace ErrorMessage entirely.
    const label = props.label;
    const formikProps = {...props};
    const [field, meta] = useField(formikProps);
    return (
        <div className="form-group row">
            <label htmlFor={formikProps.id || formikProps.name} className="col-sm-2 col-form-label">{label}</label>
            <div className="col-sm-10">
                <input className={"form-control"} {...field} {...formikProps} />
                {meta.touched && meta.error ? (
                <div className="error">{meta.error}</div>
                ) : null}
            </div>
        </div>
    );
}
export default TextInput;