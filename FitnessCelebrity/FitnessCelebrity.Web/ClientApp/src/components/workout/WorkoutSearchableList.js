import React, { useState, useEffect } from "react";
import SearchableList from "../home/SearchableList";
import WorkoutService from "../../services/WorkoutService";

function WorkoutSearchableList(props) {
  const [workouts, setAvailableWorkouts] = useState([]);
  useEffect(() => {
    loadWorkouts();
  }, []);
  const loadWorkouts = async () => {
    var workouts = await WorkoutService.getMyCreatedWorkouts();
    setAvailableWorkouts(workouts);
  };

  return (
    <SearchableList
      items={workouts}
      btnText="add"
      btnAction={props.btnAction}
    />
  );
}
export default WorkoutSearchableList;
