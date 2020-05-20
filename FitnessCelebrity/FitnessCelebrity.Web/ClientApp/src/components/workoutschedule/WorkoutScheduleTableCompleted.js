import React, { useEffect, useState } from "react";
import WorkoutScheduleTableSelector from "./WorkoutScheduleTableSelector";

function WorkoutScheduleTableCompleted(props) {
  const workouts = props.workouts ?? [];
  const workoutSchedule = props.workoutSchedule;
  const completedWorkouts = props.completedWorkouts ?? [];
  const [combinedWorkouts, setCombinedWorkouts] = useState([]);

  useEffect(() => {
    combineWorkouts();
  }, [workouts, completedWorkouts]);

  const combineWorkouts = () => {
    if (workouts.length === 0) {
      return;
    }
    if (completedWorkouts.length === 0) {
      setCombinedWorkouts(workouts);
      return;
    }
    var temp = workouts.map((workout) => {
      var completedWorkout = completedWorkouts.find(
        (c) => c.workoutId === workout.workoutId
      );
      if (completedWorkout) {
        workout.startedDate = completedWorkout.startedDate;
        workout.completedDate = completedWorkout.completedDate;
        workout.myNotes = completedWorkout.myNotes;
      }
      return workout;
    });
    setCombinedWorkouts(temp);
  };
  return (
    <>
      <WorkoutScheduleTableSelector
        workoutSchedule={workoutSchedule}
        workouts={combinedWorkouts}
        showCompleted={true}
      />
    </>
  );
}
export default WorkoutScheduleTableCompleted;
