import React, { useContext } from "react";
import AccordionContext from "react-bootstrap/AccordionContext";
export default function AccordionCaret(props) {
  const value = useContext(AccordionContext);
  let isOpen = value === props.eventKey;
  const right = (
    <>
      <svg
        class="bi bi-caret-right"
        width="1em"
        height="1em"
        viewBox="0 0 16 16"
        fill="currentColor"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          fill-rule="evenodd"
          d="M6 12.796L11.481 8 6 3.204v9.592zm.659.753l5.48-4.796a1 1 0 000-1.506L6.66 2.451C6.011 1.885 5 2.345 5 3.204v9.592a1 1 0 001.659.753z"
          clip-rule="evenodd"
        />
      </svg>
    </>
  );
  const down = (
    <>
      <svg
        class="bi bi-caret-down"
        width="1em"
        height="1em"
        viewBox="0 0 16 16"
        fill="currentColor"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          fill-rule="evenodd"
          d="M3.204 5L8 10.481 12.796 5H3.204zm-.753.659l4.796 5.48a1 1 0 001.506 0l4.796-5.48c.566-.647.106-1.659-.753-1.659H3.204a1 1 0 00-.753 1.659z"
          clip-rule="evenodd"
        />
      </svg>
    </>
  );
  if (isOpen) return down;
  else return right;
}
