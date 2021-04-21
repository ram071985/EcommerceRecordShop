import React from "react";
import { useHistory } from "react-router-dom";
import {
  CNavbarNav,
  CNavLink,
  CButton,
  CDropdown,
  CDropdownToggle,
  CDropdownMenu,
  CDropdownItem,
} from "@coreui/react";

const NavbarLinksRightHalf = (props) => {
  const history = useHistory();

  // const handleSearch = () => {
  //   console.log("Show Search bar");
  // };
  const handleCartLink = () => {
    console.log("Load Cart");
  };

  const handleLogOut = () => {
    console.log("Loggin out");
  };
  return (
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
};

export default NavbarLinksRightHalf;
