import React from "react";

function SearchableList(props) {
    let items = props.items ?? [];
    let btnText = props.btnText;
    let btnAction = props.btnAction;
    const actionButton = btnText ? <button className="btn btn-primary pull-right" onClick={btnAction}>{btnText}</button> : null;
    const listItems = items.map((item) =>
    <li className="list-group-item" key={item.id} data-id={item.id} data-name={item.name}>
      {item.name}
      {actionButton}
    </li>
  );
    const search =(e) => {
        // Loop through all list items, and hide those who don't match the search query
        let filter = e.target.value.toUpperCase();
        let i, ul, li;
        ul = e.target.nextSibling; 
        li = ul.getElementsByTagName('li');
        for (i = 0; i < li.length; i++) {
            var txtValue =  li[i].innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                li[i].style.display = "";
            } else {
                li[i].style.display = "none";
            }
        }
    }
    //const workouts = props.workouts ?? [];
    return (
        <div id="searchableList">
            <input className="search" placeholder="Search" onChange={search}  />
            <ul className="list list-group">{listItems}</ul>
        </div>
    );
}
export default SearchableList;