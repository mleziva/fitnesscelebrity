import React from "react";
import { Formik, Form} from "formik";
import * as Yup from "yup";
import TextInput from "../home/TextInput"
import SelectInput from "../home/SelectInput"


function FitnessPathEditForm(props) {
    const onSubmit = props.onSubmit;
    const values = props.values;
    const SignupForm = () => {
        return (
          <>
            <Formik
              initialValues= {values}
              validationSchema={Yup.object({
                name: Yup.string()
                  .max(15, "Must be 15 characters or less")
                  .required("Required"),
                description: Yup.string()
                  .max(20, "Must be 20 characters or less")
                  .required("Required")
              })}
              onSubmit={(values, { setSubmitting }) => {
                setTimeout(() => {
                  alert(JSON.stringify(values, null, 2));
                  setSubmitting(false);
                }, 400);
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
                  <TextInput
                  label="Tags"
                  name="tags"
                  type="text"
                  placeholder="cardio fun"
                />     
                 <SelectInput multiple
                  label="Workouts"
                  name="workouts"
                  type="select"
                />
                <button type="submit">Save</button>
              </Form>
            </Formik>
          </>
        );
      };
      return(
          <SignupForm/>
      )
}
export default FitnessPathEditForm;