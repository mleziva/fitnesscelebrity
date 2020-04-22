import React, { useState, useEffect } from "react";
import _ from "lodash";
import SearchableList from "../../home/SearchableList";

function ListManager(props) {
  //props: linkedItems, allItems, onSave, linkedItemsTitle, allItemsTitle
  const linkedItemsTitle = props.linkedItemsTitle;
  const allItemsTitle = props.allItemsTitle;
  const [availableItems, setAvailableItems] = useState([]);
  const [linkedItems, setLinkedItems] = useState([]);

  useEffect(() => {
    var items = _.cloneDeep(props.linkedItems);
    setLinkedItems(items);
    var allItems = _.cloneDeep(props.allItems);
    var availableItems = filterAllItems(allItems, items);
    setAvailableItems(availableItems);
  }, []);

  const addItemClick = (e) => {
    var id = parseInt(e.target.parentNode.dataset.id);
    var name = e.target.parentNode.dataset.name;
    removeIdFromAvailable(id);
    addItemToLinked({ id: id, name: name });
  };
  const removeItemClick = (e) => {
    var id = parseInt(e.target.parentNode.dataset.id);
    var name = e.target.parentNode.dataset.name;
    removeIdFromLinked(id);
    addItemToAvailable({ id: id, name: name });
  };
  const filterAllItems = (allItems, linkedItems) => {
    //remove all the aleady added itemss from available
    if (
      linkedItems &&
      linkedItems.length > 0 &&
      allItems &&
      allItems.length > 0
    ) {
      allItems = allItems.filter((aw) => {
        for (var i = 0, len = linkedItems.length; i < len; i++) {
          if (linkedItems[i].id === aw.id) {
            return false;
          }
        }
        return true;
      });
    }
    return allItems;
  };
  const addItemToAvailable = (item) => {
    var availableWorkouts1 = availableItems;
    availableWorkouts1.push(item);
    setAvailableItems(availableWorkouts1);
  };
  const addItemToLinked = (item) => {
    var availableWorkouts1 = linkedItems;
    availableWorkouts1.push(item);
    setLinkedItems(availableWorkouts1);
  };
  const removeIdFromAvailable = (id) => {
    var availableWorkouts1 = availableItems.filter((obj) => obj.id !== id);
    setAvailableItems(availableWorkouts1);
  };
  const removeIdFromLinked = (id) => {
    var linkedWorkouts1 = linkedItems.filter((obj) => obj.id !== id);
    setLinkedItems(linkedWorkouts1);
  };
  const handleSave = () => {
    props.onSave(linkedItems);
  };
  return (
    <>
      <div className="row">
        <div className="col-sm-6">
          {linkedItemsTitle}
          <SearchableList
            items={availableItems}
            btnText="add"
            btnAction={addItemClick}
          />
        </div>
        <div className="col-sm-6 overflow-auto">
          {allItemsTitle}
          <SearchableList
            items={linkedItems}
            btnText="remove"
            btnAction={removeItemClick}
          />
        </div>
      </div>
      <div className="row">
        <button className="btn btn-primary" onClick={handleSave}>
          Save
        </button>
      </div>
    </>
  );
}
export default ListManager;
