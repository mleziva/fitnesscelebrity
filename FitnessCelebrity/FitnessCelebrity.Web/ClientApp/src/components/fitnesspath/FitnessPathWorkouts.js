import React, { useState, useEffect }  from "react";
import SearchableList from '../home/SearchableList';
import WorkoutService from '../../services/WorkoutService';

function FitnessPathWorkouts(props) {
    const [isEditing, setIsEditing] = useState(false);
    const [availableWorkouts, setAvailableWorkouts] = useState([]);
    const [linkedWorkouts, setLinkedWorkouts] = useState([]);

    useEffect(() => {
        // Should not ever set state during rendering, so do this in useEffect instead.
        setLinkedWorkouts(props.workouts);
      }, [props.workouts]);

    const handleEditClick =() => {
        setIsEditing(!isEditing);
        //todo only load workouts if not loaded?
        loadWorkouts();
      }
    const handleAddWorkoutClick =(e) =>{
        var id = parseInt(e.target.parentNode.dataset.id);
        var name = e.target.parentNode.dataset.name;
        //remove from available
        var availableWorkouts1 = availableWorkouts.filter(obj => obj.id !== id);
        setAvailableWorkouts(availableWorkouts1);
        //add to linked
        var linkedWorkouts1 = linkedWorkouts;
        linkedWorkouts1.push({"id": id, "name": name});
        setLinkedWorkouts(linkedWorkouts1);
      }
    const handleRemoveWorkoutClick =(e) =>{
        var id = parseInt(e.target.parentNode.dataset.id);
        var name = e.target.parentNode.dataset.name;
        //remove from linked
        var linkedWorkouts1 = linkedWorkouts.filter(obj => obj.id !== id);
        setLinkedWorkouts(linkedWorkouts1);
        //add to available
        var availableWorkouts1 = availableWorkouts;
        availableWorkouts1.push({"id": id, "name": name});
        setAvailableWorkouts(availableWorkouts1);
      }
    const loadWorkouts = async() => {
        var availableWorkouts = await WorkoutService.getMyCreatedWorkouts();
        //remove all the aleady added workouts from available
        availableWorkouts = availableWorkouts.filter((aw) =>{
            for( var i=0, len=linkedWorkouts.length; i<len; i++ ){
                if( linkedWorkouts[i].id === aw.id ) {
                    return false;
                }
            }
            return true;
        });
        setAvailableWorkouts(availableWorkouts);

    }
    return (
    <div >
        <div className="text-right">
              <button className="btn btn-primary" onClick={handleEditClick} >{isEditing ? "Cancel" : "Edit"}</button>
              </div>
              <div className="row">
                  <div className="col-sm-6">
                    Available workouts
                    <SearchableList items={availableWorkouts} btnText="add" btnAction={handleAddWorkoutClick}/>
                  </div>
                  <div className="col-sm-6">
                      Workouts in this fitness path
                      <SearchableList items={linkedWorkouts} btnText="remove" btnAction={handleRemoveWorkoutClick}/>
                  </div>
              </div>
        
      </div>
    );
    }

export default FitnessPathWorkouts;