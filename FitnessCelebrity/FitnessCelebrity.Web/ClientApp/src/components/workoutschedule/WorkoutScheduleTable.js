import React from "react";
import BootstrapTable from "react-bootstrap-table-next";
import cellEditFactory from "react-bootstrap-table2-editor";

function WorkoutScheduleTable(props) {
  const workouts = props.workouts ?? [];
  const columns = props.columns ?? [];
  const edit = props.edit ?? false;
  const defaultSorted = props.defaultSorted;

  if (edit) {
    return (
      <BootstrapTable
        keyField="listId"
        data={workouts}
        columns={columns}
        defaultSorted={defaultSorted}
        cellEdit={cellEditFactory({
          mode: "click",
          blurToSave: true,
        })}
      />
    );
  } else {
    return (
      <BootstrapTable
        keyField="listId"
        data={workouts}
        columns={columns}
        defaultSorted={defaultSorted}
      />
    );
  }
}
export default WorkoutScheduleTable;
