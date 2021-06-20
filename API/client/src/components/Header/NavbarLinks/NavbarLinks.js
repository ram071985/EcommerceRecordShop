import React from "react";
import { CNavbarBrand } from "@coreui/react";
import LoggedInNavbar from "./LoggedInNavbar/LoggedInNavbar";
import LoggedOutNavbar from "./LoggedOutNavbar/LoggedOutNavbar";
import { useHistory } from "react-router-dom";
import { useSelector } from "react-redux";
import "./NavbarLinks.scss";

const NavbarLinks = (props) => {
  const history = useHistory();
  const { loggedIn } = useSelector((state) => state.header);

  return (
    <>
      <CNavbarBrand
        style={{ cursor: "pointer" }}
        onClick={() => history.push("/home")}
      >
        NavbarBrand
      </CNavbarBrand>

      {loggedIn ? <LoggedInNavbar links={props.links} /> : <LoggedOutNavbar />}
    </>
  );
};

export default NavbarLinks;
