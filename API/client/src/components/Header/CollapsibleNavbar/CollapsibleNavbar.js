import React from "react";
import { CCollapse, CNavbarNav, CNavLink } from "@coreui/react";
import { useHistory } from "react-router";

const CollapsibleNavbar = (props) => {
  const history = useHistory();
  return (
    <CCollapse show={props.isOpen} navbar>
      <CNavbarNav>
        <CNavLink onClick={() => history.push("/shop")}>Shop</CNavLink>
      </CNavbarNav>
    </CCollapse>
  );
};

export default CollapsibleNavbar;
