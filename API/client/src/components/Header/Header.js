import { CButton, CButtonGroup } from "@coreui/react";
import React from "react";

const Header = (props) => {
  return (
    <>
      <CButtonGroup>
        <CButton color="success">Button</CButton>
        <CButton color="info">Button</CButton>
        <CButton color="primary">Button</CButton>
      </CButtonGroup>
    </>
  );
};

export default Header;
