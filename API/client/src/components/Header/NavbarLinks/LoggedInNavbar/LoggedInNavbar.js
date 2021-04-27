import React from "react";
import {
  CNavbarNav,
  CNavLink,
  CButton,
  CDropdown,
  CDropdownToggle,
  CDropdownMenu,
  CDropdownItem,
} from "@coreui/react";
import { useHistory } from "react-router-dom";
import useWindowDimensions from "../../../../hooks/useWindowDimensions/useWindowDimensions";

const LoggedInNavbar = (props) => {
  const history = useHistory();
  const { width } = useWindowDimensions();

  const handleCartLink = () => {
    console.log("Load Cart");
  };

  const handleLogOut = () => {
    console.log("Loggin out");
  };

  const navbarLeft = (
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

  const navbarRight = (
    <CNavbarNav
      style={{ alignItems: "center", flexDirection: "row" }}
      className="ml-auto"
    >
      <CButton
        onClick={props.showSearchbar}
        style={{ width: "50px", height: "37px" }}
      >
        <ion-icon name="search"></ion-icon>
      </CButton>
      <CNavLink
        style={{ width: "50px", height: "37px" }}
        onClick={handleCartLink}
      >
        <ion-icon name="cart"></ion-icon>
      </CNavLink>
      <CNavLink
        style={{ width: "50px", height: "37px" }}
        onClick={() => history.push("/shop")}
      >
        <ion-icon name="heart"></ion-icon>
      </CNavLink>
      <CDropdown inNav>
        <CDropdownToggle caret={false} color="primary">
          <div className="profile-pic-no-img">AR</div>
        </CDropdownToggle>
        <CDropdownMenu placement="bottom">
          <CDropdownItem onClick={() => history.push("/transaction-history")}>
            Transaction History
          </CDropdownItem>
          <CDropdownItem onClick={handleLogOut}>Logout</CDropdownItem>
        </CDropdownMenu>
      </CDropdown>
    </CNavbarNav>
  );
  return (
    <>
      {navbarLeft}
      {navbarRight}
    </>
  );
};

export default LoggedInNavbar;
