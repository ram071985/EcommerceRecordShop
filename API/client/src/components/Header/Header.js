import { CNavbar, CToggler } from "@coreui/react";
import React, { useState } from "react";
import "./Header.scss";

import NavbarLinks from "./NavbarLinks/NavbarLinks";
import DrawerModal from "./DrawerModal/DrawerModal";
import DrawerMenu from "./DrawerMenu/DrawerMenu";
import Searchbar from "./Searchbar/Searchbar";

// TODO: Remove shop from navbar when the drawer is open. Copy the logic similar to Collapsible Navbar.

const Header = (props) => {
  const [isOpen, setIsOpen] = useState(false);
  const [showSearchbar, setShowSearchbar] = useState(false);

  const drawerLinks = [
    {
      id: "shop",
      name: "Shop",
      path: "/shop",
      clicked: () => setIsOpen(false),
    },
  ];

  const toggleSearchbar = () => {
    const newValue = !showSearchbar;
    setShowSearchbar(newValue);
  };

  return (
    <div>
      <CNavbar expandable="sm" color="info">
        <CToggler inNavbar onClick={() => setIsOpen(true)} />
        <NavbarLinks
          drawerIsOpen={isOpen}
          links={drawerLinks}
          showSearchbar={toggleSearchbar}
        />
      </CNavbar>

      <Searchbar active={showSearchbar} />

      <DrawerModal isOpen={isOpen} close={() => setIsOpen(false)}>
        <DrawerMenu links={drawerLinks} />
      </DrawerModal>
    </div>
  );
};

export default Header;
