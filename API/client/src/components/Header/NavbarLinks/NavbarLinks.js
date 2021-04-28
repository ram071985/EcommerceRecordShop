import React from "react";
import { CNavbarBrand } from "@coreui/react";
import LoggedInNavbar from "./LoggedInNavbar/LoggedInNavbar";
import LoggedOutNavbar from "./LoggedOutNavbar/LoggedOutNavbar";
import { useHistory } from "react-router-dom";
import "./NavbarLinks.scss";

const NavbarLinks = (props) => {
  const history = useHistory();

  return (
    <>
      <CNavbarBrand onClick={() => history.push("/home")}>
        NavbarBrand
      </CNavbarBrand>

      {props.loggedIn ? (
        <LoggedInNavbar
          links={props.links}
          showSearchbar={props.showSearchbar}
        />
      ) : (
        <LoggedOutNavbar />
      )}
    </>
  );
};

export default NavbarLinks;
