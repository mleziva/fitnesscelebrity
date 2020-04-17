import React from "react";
import { Formik, Form} from "formik";
import * as Yup from "yup";
import TextInput from "../home/TextInput"


function FitnessPathEditForm(props) {
    const onSubmit = props.onSubmit;
    const values = props.values;
    const SignupForm = () => {
        return (
          <>
            <Formik
              initialValues= {values}
              validationSchema={Yup.object({
                firstName: Yup.string()
                  .max(15, "Must be 15 characters or less")
                  .required("Required"),
                lastName: Yup.string()
                  .max(20, "Must be 20 characters or less")
                  .required("Required"),
                email: Yup.string()
                  .email("Invalid email addresss`")
                  .required("Required"),
                jobType: Yup.string()
                  // specify the set of valid values for job type
                  // @see http://bit.ly/yup-mixed-oneOf
                  .oneOf(
                    ["designer", "development", "product", "other"],
                    "Invalid Job Type"
                  )
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
                  label="Created By"
                  name="description"
                  type="text"
                  placeholder="High-energy workouts"
                />
                 <TextInput
                  label="Category"
                  name="description"
                  type="text"
                  placeholder="High-energy workouts"
                />
                <TextInput
                  label="Description"
                  name="description"
                  type="text"
                  placeholder="High-energy workouts"
                />
                <TextInput
                  label="Body"
                  name="email"
                  type="text"
                  placeholder="jane@formik.com"
                /> 
                  <TextInput
                  label="Tags"
                  name="email"
                  type="text"
                  placeholder="jane@formik.com"
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