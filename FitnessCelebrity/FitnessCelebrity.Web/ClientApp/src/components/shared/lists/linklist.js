import React from "react";
import { Link } from "react-router-dom";

function LinkList(props) {
  const items = props.items ?? [];
  const path = props.path;
  return (
    <div className=" row">
      <div className="col">
        <div className="list-group">
          {items.map((item) => (
            <Link
              key={item.id}
              to={"/" + path + "/" + item.id}
              className="list-group-item list-group-item-action"
            >
              {item.name} <small>{item.description}</small>
            </Link>
          ))}
        </div>
      </div>
    </div>
  );
}
export default LinkList;
