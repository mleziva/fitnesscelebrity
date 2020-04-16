import React from "react";
import { Link } from 'react-router-dom';
function MovementList(props) {
    const movements = props.movements ?? [];
    return (
        <div className=" row">
            <div className="col">
            <div className="list-group">
                {movements.map(movement =>
                <Link key={movement.id} to={'/movement/'+movement.id} 
                className="list-group-item list-group-item-action">{movement.name} <small>{movement.description}</small></Link>
                )}
                </div>
            </div>
        </div>
    );
}
export default MovementList;