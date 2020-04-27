import React from "react";
import { Link } from "react-router-dom";
import BootstrapTable from "react-bootstrap-table-next";
import cellEditFactory from "react-bootstrap-table2-editor";

function WorkoutScheduleTable(props) {
  const products = props.workouts ?? [];

  const columns = [
    {
      dataField: "id",
      text: "Workout ID",
    },
    {
      dataField: "name",
      text: "Name",
    },
    {
      dataField: "dayOfWeek",
      text: "Day of week",
    },
    {
      dataField: "week",
      text: "Week #",
    },
    {
      dataField: "notes",
      text: "Noyes",
    },
  ];

  return (
    <BootstrapTable
      keyField="id"
      data={products}
      columns={columns}
      cellEdit={cellEditFactory({
        mode: "click",
        blurToSave: true,
      })}
    />
  );
}
export default WorkoutScheduleTable;
