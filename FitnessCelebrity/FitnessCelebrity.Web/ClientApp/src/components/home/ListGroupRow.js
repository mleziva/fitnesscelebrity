import React from "react";

function ListGroupRow(props) {
    const items = props.list ?? [];
    return (
        <div className=" row">
            <div className="col">
                <ul className="list-group">
                {items.map(item =>
                    <li key={item.id} class="list-group-item">{item.name}</li>
                )}
                </ul>
            </div>
        </div>
    );
}
export default ListGroupRow;