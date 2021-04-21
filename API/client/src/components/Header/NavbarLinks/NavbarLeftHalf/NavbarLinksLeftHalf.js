import React from "react";
import { CNavbarNav, CNavLink, CNavbarBrand } from "@coreui/react";
import { useHistory } from "react-router-dom";
import useWindowDimensions from "../../../../hooks/useWindowDimensions/useWindowDimensions";

const NavbarLinksLeftHalf = (props) => {
  const { width } = useWindowDimensions();
  const history = useHistory();

  const navbarLinksComponent = (
    <CNavbarNav
      style={{
        display: width > 576 ? "flex" : "none",
        flexDirection: "row",
      }}
    >
      {props.links.map((link) => (
        <CNavLink key={link.id} onClick={() => history.push(link.path)}>
          {link.name}
        </CNavLink>
      ))}
    </CNavbarNav>
  );

  return (
    <>
      <CNavbarBrand
        style={{ cursor: "pointer" }}
        onClick={() => history.push("/home")}
      >
        NavbarBrand
      </CNavbarBrand>

      {props.loggedIn ? navbarLinksComponent : null}
    </>
  );
};

export default NavbarLinksLeftHalf;
