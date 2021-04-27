import React from "react";
import { CNavbarBrand } from "@coreui/react";
import LoggedInNavbar from "./LoggedInNavbar/LoggedInNavbar";
import LoggedOutNavbar from "./LoggedOutNavbar/LoggedOutNavbar";
import { useHistory } from "react-router-dom";

const Navbar = (props) => {
  const history = useHistory();

  return (
    <>
      <CNavbarBrand
        style={{ cursor: "pointer" }}
        onClick={() => history.push("/home")}
      >
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

export default Navbar;
