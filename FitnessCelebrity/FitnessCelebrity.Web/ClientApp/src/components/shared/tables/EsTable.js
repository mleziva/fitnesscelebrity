import React, { useState, useEffect } from "react";
import Spinner from "../../home/Spinner";
import EditLink from "../links/editLink";
import DetailsLink from "../links/detailsLink";

function EsTable(props) {
  const loadItems = props.loadItems;
  const detailsPath = props.detailsPath;
  const [loading, setLoading] = useState(true);
  const [items, setItems] = useState([]);

  useEffect(() => {
    loadItemsList();
  }, []);

  const loadItemsList = async () => {
    let results = await loadItems();
    setLoading(false);
    setItems(results);
  };
  const renderTable = () => {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Description</th>
            <th>Created Date</th>
            <th>Edit</th>
          </tr>
        </thead>
        <tbody>
          {items.map((item) => (
            <tr key={item.id}>
              <td>
                <DetailsLink item={item} path={detailsPath} />
              </td>
              <td>{item.description}</td>
              <td>
                {new Intl.DateTimeFormat("en-GB", {
                  year: "numeric",
                  month: "long",
                  day: "2-digit",
                }).format(Date.parse(item.createdDate))}
              </td>
              <td>
                <EditLink item={item} path={detailsPath} />
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  };
  return <>{loading ? <Spinner /> : renderTable()}</>;
}

export default EsTable;
