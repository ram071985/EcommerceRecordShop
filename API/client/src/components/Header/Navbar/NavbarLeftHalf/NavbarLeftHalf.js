import React from "react";
import { CNavbarNav, CNavLink, CNavbarBrand } from "@coreui/react";
import { useHistory } from "react-router-dom";
import useWindowDimensions from "../../../../hooks/useWindowDimensions/useWindowDimensions";

const NavbarLeftHalf = (props) => {
  const { width } = useWindowDimensions();
  const history = useHistory();

  return (
    <>
      <CNavbarBrand
        style={{ cursor: "pointer" }}
        onClick={() => history.push("/home")}
      >
        NavbarBrand
      </CNavbarBrand>
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
    </>
  );
};

export default NavbarLeftHalf;