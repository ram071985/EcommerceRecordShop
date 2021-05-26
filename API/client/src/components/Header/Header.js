import { CNavbar, CToggler } from "@coreui/react";
import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import "./Header.scss";

import NavbarLinks from "./NavbarLinks/NavbarLinks";
import DrawerModal from "./DrawerModal/DrawerModal";
import DrawerMenu from "./DrawerMenu/DrawerMenu";
import Searchbar from "./Searchbar/Searchbar";

// TODO: Remove shop from navbar when the drawer is open. Copy the logic similar to Collapsible Navbar.

const Header = (props) => {
  let location = useLocation();
  const [showDrawer, setShowDrawer] = useState(false);
  const [showSearchbar, setShowSearchbar] = useState(false);

  const [loggedIn] = useState(true);
  const [headerIsSolid, setHeaderIsSolid] = useState(true);

  useEffect(() => {
    if (location.pathname === "/home" || location.pathname === "/") {
      setHeaderIsSolid(false);
    } else {
      setHeaderIsSolid(true);
    }
  }, [location.pathname]);

  const drawerLinks = [
    {
      id: "shop",
      name: "Shop",
      path: "/shop",
      clicked: () => setShowDrawer(false),
    },
    {
      id: "product",
      name: "Product",
      path: "/product"
    }
  ];

  const toggleSearchbar = () => {
    const newValue = !showSearchbar;
    setShowSearchbar(newValue);
  };

  const toggleDrawer = () => {
    const newValue = !showDrawer;
    setShowDrawer(newValue);
  };

  const isNavbarSolid = () => showSearchbar || showDrawer || headerIsSolid;

  return (
    <header style={{ position: `${headerIsSolid ? "relative" : "absolute"}` }}>
      <div className="headerContent">
        <CNavbar
          className={`customNavbar ${isNavbarSolid() ? "solid" : ""}`}
          sticky
          light
          expandable="sm"
        >
          {loggedIn ? <CToggler inNavbar onClick={toggleDrawer} /> : null}
          <NavbarLinks
            loggedIn={loggedIn}
            drawerIsOpen={showDrawer}
            links={drawerLinks}
            showSearchbar={toggleSearchbar}
          />
        </CNavbar>

        {loggedIn ? (
          <Searchbar
            active={showSearchbar}
            close={() => setShowSearchbar(false)}
          />
        ) : null}

        <DrawerModal isOpen={showDrawer} close={() => setShowDrawer(false)}>
          <DrawerMenu links={drawerLinks} />
        </DrawerModal>
      </div>
    </header>
  );
};

export default Header;
