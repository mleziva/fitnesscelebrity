import React from "react";
import { Link } from 'react-router-dom';
function WorkoutList(props) {
    const workouts = props.workouts ?? [];
    return (
        <div className=" row">
            <div className="col">
            <div className="list-group">
                {workouts.map(workout =>
                <Link key={workout.id} to={'/workout/'+workout.id} 
                className="list-group-item list-group-item-action">{workout.name} <small>{workout.description}</small></Link>
                )}
                </div>
            </div>
        </div>
    );
}
export default WorkoutList;