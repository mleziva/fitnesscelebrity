//todo load table based on workout schedule type in fitness path
import React from "react";
import { Link } from "react-router-dom";
import WorkoutScheduleTable from "./WorkoutScheduleTable";

function WorkoutScheduleTableSelector(props) {
  const workouts = props.workouts ?? [];
  const workoutSchedule = props.workoutSchedule;
  const edit = props.edit ?? false;
  const onRemoveClick = props.onRemoveClick;
  //create link from name and add incremementing id
  workouts.forEach(function (workout, index) {
    workout.listId = index;
  });
  const columns = [
    {
      dataField: "listId",
      text: "Id",
      hidden: false,
    },
    {
      dataField: "workoutId",
      text: "Workout Id",
      hidden: true,
    },
    {
      dataField: "link",
      text: "Name",
      editable: false,
      formatter: (cellContent, row) => {
        return <Link to={"/workout/" + row.workoutId}>{row.workoutName}</Link>;
      },
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

  if (edit) {
    columns.push({
      dataField: "none",
      text: "Remove",
      editable: false,
      formatter: (cellContent, row) => {
        return (
          <button
            className="btn btn-danger btn-xs"
            onClick={() => onRemoveClick(row.listId)}
          >
            Remove
          </button>
        );
      },
    });
  }

  return (
    <WorkoutScheduleTable workouts={workouts} columns={columns} edit={edit} />
  );
}
export default WorkoutScheduleTableSelector;
