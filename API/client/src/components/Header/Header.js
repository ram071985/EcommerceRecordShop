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

const Header = (props) => {
  const [isOpen, setIsOpen] = useState(false);
  return (
    <div>
      <CNavbar expandable="sm" color="info">
        <CToggler inNavbar onClick={() => setIsOpen(!isOpen)} />
        <CNavbarBrand>NavbarBrand</CNavbarBrand>
        <CCollapse show={isOpen} navbar>
          <CNavbarNav>
            <CNavLink>Home</CNavLink>
            <CNavLink>Link</CNavLink>
          </CNavbarNav>
          <CNavbarNav className="ml-auto">
            <CForm inline>
              <CInput className="mr-sm-2" placeholder="Search" size="sm" />
              <CButton color="light" className="my-2 my-sm-0" type="submit">
                Search
              </CButton>
            </CForm>
            <CDropdown inNav>
              <CDropdownToggle color="primary">Lang</CDropdownToggle>
              <CDropdownMenu>
                <CDropdownItem>EN</CDropdownItem>
                <CDropdownItem>ES</CDropdownItem>
                <CDropdownItem>RU</CDropdownItem>
                <CDropdownItem>FA</CDropdownItem>
              </CDropdownMenu>
            </CDropdown>
            <CDropdown inNav>
              <CDropdownToggle color="primary">User</CDropdownToggle>
              <CDropdownMenu>
                <CDropdownItem>Account</CDropdownItem>
                <CDropdownItem>Settings</CDropdownItem>
              </CDropdownMenu>
            </CDropdown>
          </CNavbarNav>
        </CCollapse>
      </CNavbar>
    </div>
  );
};

export default Header;
