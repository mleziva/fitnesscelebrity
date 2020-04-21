import React from "react";
import { Link } from "react-router-dom";

function DetailsLink(props) {
  const item = props.item;
  const path = props.path;
  return <Link to={`/${path}/${item.id}`}>{item.name}</Link>;
}

export default DetailsLink;
