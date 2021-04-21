import React from "react";
import LoggedInNavbar from "./LoggedInNavbar/LoggedInNavbar";
import LoggedOutNavbar from "./LoggedOutNavbar/LoggedOutNavbar";

const NavbarLinksRightHalf = (props) => {
  return (
    <>
      {props.loggedIn ? (
        <LoggedInNavbar showSearchbar={props.showSearchbar} />
      ) : (
        <LoggedOutNavbar />
      )}
    </>
  );
};

export default NavbarLinksRightHalf;
