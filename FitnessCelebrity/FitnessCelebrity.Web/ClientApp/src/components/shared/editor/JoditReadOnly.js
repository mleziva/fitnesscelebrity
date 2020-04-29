import React, { useState, useRef } from "react";
import JoditEditor from "jodit-react";

function JoditReadOnly(props) {
  const editor = useRef(null);

  const config = {
    readonly: true, // all options from https://xdsoft.net/jodit/doc/
    toolbar: false,
  };

  return (
    <div className="jodit-readonly">
      <JoditEditor
        ref={editor}
        value={props.content}
        config={config}
        tabIndex={1} // tabIndex of textarea
      />
    </div>
  );
}

export default JoditReadOnly;
