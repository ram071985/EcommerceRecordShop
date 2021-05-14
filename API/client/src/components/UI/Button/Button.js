import React from "react";
import "./Button.scss";

const Button = (props) => {
  return (
    <button className={`Button ${props.variant}`} onClick={props.clicked}>
      {props.children}
    </button>
  );
};

export default Button;
