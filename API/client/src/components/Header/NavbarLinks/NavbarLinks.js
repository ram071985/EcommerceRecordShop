import React from "react";
import NavbarLinksRightHalf from "./NavbarRightHalf/NavbarLinksRightHalf";
import NavbarLinksLeftHalf from "./NavbarLeftHalf/NavbarLinksLeftHalf";

const Navbar = (props) => {
  return (
    <>
      <NavbarLinksLeftHalf links={props.links} />
      <NavbarLinksRightHalf />
    </>
  );
};

export default Navbar;
