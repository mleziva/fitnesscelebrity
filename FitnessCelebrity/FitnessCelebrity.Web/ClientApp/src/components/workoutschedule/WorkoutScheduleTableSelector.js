//todo load table based on workout schedule type in fitness path
import React from "react";
import { Link } from "react-router-dom";
import WorkoutScheduleTable from "./WorkoutScheduleTable";

function WorkoutScheduleTableSelector(props) {
  const workouts = props.workouts ?? [];
  const workoutSchedule = props.workoutSchedule;
  const edit = props.edit ?? false;
  //create link from name
  workouts.forEach(function (workout) {
    workout.link = <Link to={"/workout/" + workout.id}>{workout.name}</Link>;
  });
  const columns = [
    {
      dataField: "link",
      text: "Name",
      editable: false,
    },
  ];

  const ordered = 0;
  const date = 1;
  const weekday = 2;
  if (workoutSchedule === ordered) {
    columns.push({
      dataField: "workoutOrder",
      text: "Workout Order",
    });
  }

  if (workoutSchedule === date) {
    columns.push({
      dataField: "date",
      text: "Date",
    });
  }

  if (workoutSchedule === weekday) {
    columns.push(
      {
        dataField: "dayOfWeek",
        text: "Day of week",
      },
      {
        dataField: "week",
        text: "Week #",
      }
    );
  }

  columns.push({
    dataField: "notes",
    text: "Notes",
  });

  return (
    <WorkoutScheduleTable workouts={workouts} columns={columns} edit={edit} />
  );
}
export default WorkoutScheduleTableSelector;
