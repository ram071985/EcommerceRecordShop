import React from "react";
import { CFormGroup, CInput, CButton } from "@coreui/react";
import "./Searchbar.scss";

const Searchbar = (props) => {
  const style = { display: props.active ? "block" : "none" };

  return (
    <div>
      <CFormGroup className={"searchBar"} style={style}>
        <CButton className={"searchBtn"}>
          <ion-icon name="search"></ion-icon>
        </CButton>
        <CInput id="search" className={"searchInput"} placeholder="Search..." />
        <div className="shadowBox" onClick={() => props.close()}></div>
      </CFormGroup>
    </div>
  );
};

export default Searchbar;
