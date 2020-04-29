import React from "react";
import { useField } from "formik";

function SelectInput(props) {
  const label = props.label;
  const formikProps = { ...props };
  const [field, meta] = useField(formikProps);
  //const options = field.value;
  const options = props.options ?? [];

  return (
    <div className="form-group row">
      <label htmlFor={formikProps.name} className="col-sm-2 col-form-label">
        {label}
      </label>
      <div className="col-sm-10">
        <select
          className="form-control"
          id={formikProps.name}
          {...field}
          {...formikProps}
        >
          {options.map((item) => (
            <option value={item.id}>{item.name}</option>
          ))}
        </select>
        {meta.touched && meta.error ? (
          <div className="error">{meta.error}</div>
        ) : null}
      </div>
    </div>
  );
}
export default SelectInput;
