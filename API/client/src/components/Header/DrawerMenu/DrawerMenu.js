import React from "react";
import { Link } from "react-router-dom";
import "./DrawerMenu.scss";

const DrawerMenu = (props) => {
  return (
    <ul className="DrawerMenu">
      {props.links.map((link) => {
        return (
          <li key={link.id}>
            <Link to={link.path} onClick={link.clicked}>
              {link.name}
            </Link>
          </li>
        );
      })}
    </ul>
  );
};

export default DrawerMenu;
