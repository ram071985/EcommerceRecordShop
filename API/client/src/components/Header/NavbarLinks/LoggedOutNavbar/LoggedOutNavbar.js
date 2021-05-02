import React from "react";
import { CNavbarNav, CNavLink } from "@coreui/react";

const LoggedOutNavbar = () => {
  return (
    <CNavbarNav
      style={{ alignItems: "center", flexDirection: "row" }}
      className="ml-auto"
    >
      <CNavLink
        style={{ padding: "0 15px" }}
        onClick={() => console.log("Sign up")}
      >
        Sign Up
      </CNavLink>
      <CNavLink
        style={{ padding: "0 15px" }}
        onClick={() => console.log("Log In")}
      >
        Log In
      </CNavLink>
    </CNavbarNav>
  );
};

export default LoggedOutNavbar;
