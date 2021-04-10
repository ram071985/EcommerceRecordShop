import {
  CNavbar,
  CNavbarNav,
  CNavLink,
  CToggler,
  CCollapse,
  CForm,
  CInput,
  CButton,
  CDropdown,
  CDropdownToggle,
  CDropdownMenu,
  CDropdownItem,
  CNavbarBrand,
} from "@coreui/react";
import React, { useState } from "react";
import "./Header.scss";

const Header = (props) => {
  const [isOpen, setIsOpen] = useState(false);

  const handleLogoLink = () => {
    console.log("Load Home Page");
  };

  const handleShopLink = () => {
    console.log("Load Shop Page");
  };

  const handleSearch = () => {
    console.log("Show Search bar");
  };

  const handleCartLink = () => {
    console.log("Load Cart");
  };
  return (
    <div>
      <CNavbar expandable="sm" color="info">
        <CToggler inNavbar onClick={() => setIsOpen(!isOpen)} />
        <CNavbarBrand style={{ cursor: "pointer" }} onClick={handleLogoLink}>
          NavbarBrand
        </CNavbarBrand>
        <CCollapse show={isOpen} navbar>
          <CNavbarNav>
            <CNavLink onClick={handleShopLink}>Shop</CNavLink>
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
              onClick={handleCartLink}
            >
              <ion-icon name="heart"></ion-icon>
            </CNavLink>
            <CDropdown inNav>
              <CDropdownToggle caret={false} color="primary">
                <div className="profile-pic-no-img">AR</div>
              </CDropdownToggle>
              <CDropdownMenu placement="bottom">
                <CDropdownItem onClick={() => console.log("Transaction btn")}>
                  Transaction History
                </CDropdownItem>
                <CDropdownItem onClick={() => console.log("Logout Btn")}>
                  Logout
                </CDropdownItem>
              </CDropdownMenu>
            </CDropdown>
          </CNavbarNav>
        </CCollapse>
      </CNavbar>
    </div>
  );
};

export default Header;
