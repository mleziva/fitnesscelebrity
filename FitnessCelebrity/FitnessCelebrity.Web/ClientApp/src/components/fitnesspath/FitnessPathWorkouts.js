import React, { useState, useEffect } from "react";
import _ from "lodash";
import SearchableList from "../home/SearchableList";
import WorkoutService from "../../services/WorkoutService";
import FitnessPathService from "../../services/FitnessPathService";

function FitnessPathWorkouts(props) {
  const [availableWorkouts, setAvailableWorkouts] = useState([]);
  const [linkedWorkouts, setLinkedWorkouts] = useState([]);

  useEffect(() => {
    // Should not ever set state during rendering, so do this in useEffect instead.
    //empty dependency array treats this like onComponentDidMount
    //create copy of workouts
    var workouts = _.cloneDeep(props.fitnessPath.workouts);
    setLinkedWorkouts(workouts);
    loadWorkouts(workouts);
  }, []);

  const handleAddWorkoutClick = (e) => {
    var id = parseInt(e.target.parentNode.dataset.id);
    var name = e.target.parentNode.dataset.name;
    //remove from available
    var availableWorkouts1 = availableWorkouts.filter((obj) => obj.id !== id);
    setAvailableWorkouts(availableWorkouts1);
    //add to linked
    var linkedWorkouts1 = linkedWorkouts;
    linkedWorkouts1.push({ id: id, name: name });
    setLinkedWorkouts(linkedWorkouts1);
  };
  const handleRemoveWorkoutClick = (e) => {
    var id = parseInt(e.target.parentNode.dataset.id);
    var name = e.target.parentNode.dataset.name;
    //remove from linked
    var linkedWorkouts1 = linkedWorkouts.filter((obj) => obj.id !== id);
    setLinkedWorkouts(linkedWorkouts1);
    //add to available
    var availableWorkouts1 = availableWorkouts;
    availableWorkouts1.push({ id: id, name: name });
    setAvailableWorkouts(availableWorkouts1);
  };
  const loadWorkouts = async (linkedWorkouts) => {
    var availableWorkouts = await WorkoutService.getMyCreatedWorkouts();
    //remove all the aleady added workouts from available
    availableWorkouts = availableWorkouts.filter((aw) => {
      for (var i = 0, len = linkedWorkouts.length; i < len; i++) {
        if (linkedWorkouts[i].id === aw.id) {
          return false;
        }
      }
      return true;
    });
    setAvailableWorkouts(availableWorkouts);
  };
  const handleSave = async () => {
    //copy workouts back to main model
    props.fitnessPath.workouts = _.cloneDeep(linkedWorkouts);
    await FitnessPathService.updateLinkedWorkouts(props.fitnessPath);
  };
  return (
    <div>
      <div className="row">
        <div className="col-sm-6">
          Available workouts
          <SearchableList
            items={availableWorkouts}
            btnText="add"
            btnAction={handleAddWorkoutClick}
          />
        </div>
        <div className="col-sm-6 overflow-auto">
          Workouts in this fitness path
          <SearchableList
            items={linkedWorkouts}
            btnText="remove"
            btnAction={handleRemoveWorkoutClick}
          />
        </div>
      </div>
      <div className="row">
        <button className="btn btn-primary" onClick={handleSave}>
          Save
        </button>
      </div>
    </div>
  );
}

export default FitnessPathWorkouts;
