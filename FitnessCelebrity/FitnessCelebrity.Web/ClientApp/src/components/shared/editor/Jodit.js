import React, { useState, useRef } from "react";
import JoditEditor from "jodit-react";

function Jodit(props) {
  const editor = useRef(null);

  const config = {
    readonly: false, // all options from https://xdsoft.net/jodit/doc/
  };

  return (
    <JoditEditor
      ref={editor}
      value={props.content}
      config={config}
      tabIndex={1} // tabIndex of textarea
      onBlur={(newContent) => props.onContentChange(newContent)} // preferred to use only this option to update the content for performance reasons
      onChange={(newContent) => {}}
    />
  );
}

export default Jodit;
