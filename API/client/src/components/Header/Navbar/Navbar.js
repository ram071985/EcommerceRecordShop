import React from "react";
import NavbarRightHalf from "./NavbarRightHalf/NavbarRightHalf";
import NavbarLeftHalf from "./NavbarLeftHalf/NavbarLeftHalf";

const Navbar = (props) => {
  return (
    <>
      <NavbarLeftHalf links={props.links} />
      <NavbarRightHalf />
    </>
  );
};

export default Navbar;
