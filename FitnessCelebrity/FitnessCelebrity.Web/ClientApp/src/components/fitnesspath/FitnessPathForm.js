import React from "react";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import TextInput from "../home/TextInput";
import SelectInput from "../home/SelectInput";
import * as enums from "../../app/const/EnumConfig";
function FitnessPathForm(props) {
  const values = props.values ?? {};
  const SignupForm = () => {
    return (
      <>
        <Formik
          initialValues={values}
          validationSchema={Yup.object({
            name: Yup.string()
              .max(50, "Must be 50 characters or less")
              .required("Required"),
            description: Yup.string()
              .max(50, "Must be 50 characters or less")
              .required("Required"),
          })}
          onSubmit={(values, { setSubmitting }) => {
            props.onSubmit(values);
            setSubmitting(false);
          }}
        >
          <Form>
            <TextInput
              label="Name"
              name="name"
              type="text"
              placeholder="Move that body"
            />
            <TextInput
              label="Category"
              name="category"
              type="text"
              placeholder="Cardio"
            />
            <TextInput
              label="Description"
              name="description"
              type="text"
              placeholder="High-energy workouts"
            />
            <TextInput
              label="Body"
              name="body"
              type="text"
              placeholder="15 pushups"
            />
            <SelectInput
              label="Privacy"
              name="privacy"
              type="text"
              options={enums.PrivacyEnum}
            />
            <SelectInput
              label="workout schedule"
              name="workoutSchedule"
              type="text"
              options={enums.WorkoutScheduleEnum}
            />
            <TextInput
              label="Tags"
              name="tags"
              type="text"
              placeholder="cardio fun"
            />
            <button type="submit" className="btn btn-success">
              Save
            </button>
          </Form>
        </Formik>
      </>
    );
  };
  return <SignupForm />;
}
export default FitnessPathForm;
