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

  const [loggedIn, setLoggedIn] = useState(true);

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
    <header>
      <div className="headerContent">
        <CNavbar className="customNavbar" sticky light expandable="sm">
          {loggedIn ? (
            <CToggler inNavbar onClick={() => setIsOpen(true)} />
          ) : null}
          <NavbarLinks
            loggedIn={loggedIn}
            drawerIsOpen={isOpen}
            links={drawerLinks}
            showSearchbar={toggleSearchbar}
          />
        </CNavbar>

        {loggedIn ? <Searchbar active={showSearchbar} /> : null}

        <DrawerModal isOpen={isOpen} close={() => setIsOpen(false)}>
          <DrawerMenu links={drawerLinks} />
        </DrawerModal>
      </div>
    </header>
  );
};

export default Header;
