import { CNavbar, CToggler, CNavbarBrand } from "@coreui/react";
import React, { useState } from "react";
import { useHistory } from "react-router";
import "./Header.scss";

import Navbar from "./Navbar/Navbar";
import DrawerModal from "./DrawerModal/DrawerModal";
import DrawerMenu from "./DrawerMenu/DrawerMenu";

// TODO: Remove shop from navbar when the drawer is open. Copy the logic similar to Collapsible Navbar.

const Header = (props) => {
  const [isOpen, setIsOpen] = useState(false);

  const drawerLinks = [
    {
      id: "shop",
      name: "Shop",
      path: "/shop",
      clicked: () => setIsOpen(false),
    },
  ];

  return (
    <div>
      <CNavbar expandable="sm" color="info">
        <CToggler inNavbar onClick={() => setIsOpen(true)} />
        <Navbar drawerIsOpen={isOpen} links={drawerLinks} />
      </CNavbar>
      <DrawerModal isOpen={isOpen} close={() => setIsOpen(false)}>
        <DrawerMenu links={drawerLinks} />
      </DrawerModal>
    </div>
  );
};

export default Header;
