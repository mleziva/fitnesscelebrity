import React from "react";
import BootstrapTable from "react-bootstrap-table-next";
import cellEditFactory from "react-bootstrap-table2-editor";

function WorkoutScheduleTable(props) {
  const workouts = props.workouts ?? [];
  const columns = props.columns ?? [];
  const edit = props.edit ?? false;

  if (edit) {
    return (
      <BootstrapTable
        keyField="id"
        data={workouts}
        columns={columns}
        cellEdit={cellEditFactory({
          mode: "click",
          blurToSave: true,
        })}
      />
    );
  } else {
    return <BootstrapTable keyField="id" data={workouts} columns={columns} />;
  }
}
export default WorkoutScheduleTable;
