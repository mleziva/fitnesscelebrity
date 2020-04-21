import React from "react";
import { Link } from "react-router-dom";

function EditLink(props) {
  const item = props.item;
  const path = props.path;
  return <Link to={`/${path}/${item.id}/edit`}>Edit</Link>;
}

export default EditLink;
