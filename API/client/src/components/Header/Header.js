import { CNavbar, CToggler } from "@coreui/react";
import React, { useEffect } from "react";
import { useLocation } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { headerActions } from "../../store/headerSlice";
import "./Header.scss";

import NavbarLinks from "./NavbarLinks/NavbarLinks";
import DrawerModal from "./DrawerModal/DrawerModal";
import DrawerMenu from "./DrawerMenu/DrawerMenu";
import Searchbar from "./Searchbar/Searchbar";

const Header = () => {
  let location = useLocation();
  const dispatch = useDispatch();
  const { openDrawer, showSearchbar, loggedIn, headerIsSolid } = useSelector(
    (state) => state.header
  );

  useEffect(() => {
    dispatch(headerActions.updateHeaderTransparency(location.pathname));
  }, [location.pathname, openDrawer, showSearchbar, dispatch]);

  const drawerLinks = [
    {
      id: "shop",
      name: "Shop",
      path: "/shop",
      clicked: () => dispatch(headerActions.closeDrawer()),
    },
  ];
  const closeSearchbarHandler = () => dispatch(headerActions.closeSearchbar());

  const toggleDrawerHandler = () => dispatch(headerActions.toggleDrawer());
  const closeDrawerHandler = () => dispatch(headerActions.closeDrawer());

  return (
    <header style={{ position: `${headerIsSolid ? "relative" : "absolute"}` }}>
      <div className="headerContent">
        <CNavbar
          className={`customNavbar ${headerIsSolid ? "solid" : ""}`}
          sticky
          light
          expandable="sm"
        >
          {loggedIn ? (
            <CToggler inNavbar onClick={toggleDrawerHandler} />
          ) : null}
          <NavbarLinks
            loggedIn={loggedIn}
            drawerIsOpen={openDrawer}
            links={drawerLinks}
          />
        </CNavbar>

        {loggedIn ? (
          <Searchbar active={showSearchbar} close={closeSearchbarHandler} />
        ) : null}

        <DrawerModal isOpen={openDrawer} close={closeDrawerHandler}>
          <DrawerMenu links={drawerLinks} />
        </DrawerModal>
      </div>
    </header>
  );
};

export default Header;
