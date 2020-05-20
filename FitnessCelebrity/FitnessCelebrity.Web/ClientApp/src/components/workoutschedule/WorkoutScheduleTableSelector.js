//todo load table based on workout schedule type in fitness path
import React from "react";
import { Link } from "react-router-dom";
import WorkoutScheduleTable from "./WorkoutScheduleTable";
import { Type } from "react-bootstrap-table2-editor";
import _ from "lodash";

/*
 <WorkoutScheduleTableSelector
workoutSchedule={fitnessPath.workoutSchedule}
workouts={fitnessPath.workouts}
/> 
*/
function WorkoutScheduleTableSelector(props) {
  let workouts = props.workouts ?? [];
  const workoutSchedule = props.workoutSchedule;
  const edit = props.edit ?? false;
  const showCompleted = props.showCompleted ?? false;
  const onRemoveClick = props.onRemoveClick;
  let defaultSorted = [];
  const ordered = 0;
  const date = 1;
  const weekday = 2;
  //defaultSorted is not working so use lodash
  if (workoutSchedule === ordered) {
    workouts = _.sortBy(workouts, ["workoutOrder", "name"]);
  }
  if (workoutSchedule === date) {
    workouts = _.sortBy(workouts, ["date", "name"]);
  }
  if (workoutSchedule === weekday) {
    workouts = _.sortBy(workouts, ["week", "dayOfWeek"]);
  }
  //add incremementing id
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
      dataField: "name",
      text: "Name",
      editable: false,
      formatter: (cellContent, row) => {
        return <Link to={"/workout/" + row.workoutId}>{row.workoutName}</Link>;
      },
      sort: true,
    },
  ];

  if (workoutSchedule === ordered) {
    columns.push({
      dataField: "workoutOrder",
      text: "Workout Order",
      type: "number",
      sort: true,
    });

    defaultSorted = [
      {
        dataField: "workoutOrder",
        order: "asc",
      },
    ];
  }

  if (workoutSchedule === date) {
    columns.push({
      dataField: "date",
      text: "Date",
      formatter: (cell) => {
        let dateObj = cell;
        if (!dateObj) return;
        if (typeof cell !== "object") {
          dateObj = new Date(cell);
        }
        return `${("0" + (dateObj.getUTCMonth() + 1)).slice(-2)}/${(
          "0" + dateObj.getUTCDate()
        ).slice(-2)}/${dateObj.getUTCFullYear()}`;
      },
      editor: {
        type: Type.DATE,
      },
      sort: true,
    });
    defaultSorted = [
      {
        dataField: "date",
        order: "asc",
      },
    ];
  }

  if (workoutSchedule === weekday) {
    columns.push(
      {
        dataField: "week",
        text: "Week #",
        type: "number",
        sort: true,
      },
      {
        dataField: "dayOfWeek",
        text: "Day of week",
        sort: true,
        editor: {
          type: Type.SELECT,
          options: [
            {
              value: "Sunday",
              label: "Sunday",
            },
            {
              value: "Monday",
              label: "Monday",
            },
            {
              value: "Tuesday",
              label: "Tuesday",
            },
            {
              value: "Wednesday",
              label: "Wednesday",
            },
            {
              value: "Thursday",
              label: "Thursday",
            },
            {
              value: "Friday",
              label: "Friday",
            },
            {
              value: "Saturday",
              label: "Saturday",
            },
          ],
        },
      }
    );
    defaultSorted = [
      {
        dataField: "week",
        order: "asc",
      },
      {
        dataField: "dayOfWeek",
        order: "asc",
      },
    ];
  }
  columns.push({
    dataField: "notes",
    text: "Notes",
  });
  if (showCompleted) {
    columns.push(
      {
        dataField: "startedDate",
        text: "Started Date",
      },
      {
        dataField: "completedDate",
        text: "Completed Date",
      },
      {
        dataField: "myNotes",
        text: "My Notes",
      }
    );
  }
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
    <WorkoutScheduleTable
      workouts={workouts}
      columns={columns}
      edit={edit}
      defaultSorted={defaultSorted}
    />
  );
}
export default WorkoutScheduleTableSelector;
