import {
  CNavbar,
  CNavbarNav,
  CNavLink,
  CToggler,
  CCollapse,
  CButton,
  CDropdown,
  CDropdownToggle,
  CDropdownMenu,
  CDropdownItem,
  CNavbarBrand,
} from "@coreui/react";
import React, { useState } from "react";
import { useHistory } from "react-router";
import "./Header.scss";

const Header = (props) => {
  const [isOpen, setIsOpen] = useState(false);
  let history = useHistory();

  const handleSearch = () => {
    console.log("Show Search bar");
  };

  const handleCartLink = () => {
    console.log("Load Cart");
  };

  const handleLogOut = () => {
    console.log("Loggin out");
  };

  return (
    <div>
      <CNavbar expandable="sm" color="info">
        <CToggler inNavbar onClick={() => setIsOpen(!isOpen)} />
        <CNavbarBrand
          style={{ cursor: "pointer" }}
          onClick={() => history.push("/home")}
        >
          NavbarBrand
        </CNavbarBrand>
        <CCollapse show={isOpen} navbar>
          <CNavbarNav>
            <CNavLink onClick={() => history.push("/shop")}>Shop</CNavLink>
          </CNavbarNav>
          <CNavbarNav style={{ alignItems: "center" }} className="ml-auto">
            <CButton
              onClick={handleSearch}
              style={{ width: "50px", height: "37px" }}
            >
              <ion-icon name="search"></ion-icon>{" "}
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
                <CDropdownItem
                  onClick={() => history.push("/transaction-history")}
                >
                  Transaction History
                </CDropdownItem>
                <CDropdownItem onClick={handleLogOut}>Logout</CDropdownItem>
              </CDropdownMenu>
            </CDropdown>
          </CNavbarNav>
        </CCollapse>
      </CNavbar>
    </div>
  );
};

export default Header;
