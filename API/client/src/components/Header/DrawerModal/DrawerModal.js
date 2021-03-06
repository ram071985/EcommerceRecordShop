import React, { useEffect } from "react";
import "./DrawerModal.scss";

import useWindowDimensions from "../../../hooks/useWindowDimensions/useWindowDimensions";

const DrawerModal = (props) => {
  const { width } = useWindowDimensions();

  let modalStyle = { display: props.isOpen ? "flex" : "none" };

  useEffect(() => {
    return () => {
      if (props.isOpen && width >= 576) {
        props.close();
      }
    };
  });

  return (
    <div className="DrawerModal" style={modalStyle}>
      <div className="modalMenu">
        <button onClick={props.close}>
          <ion-icon name="close-outline"></ion-icon>
        </button>
        <div className="content">{props.children}</div>
      </div>
      <div className="shadowBox" onClick={props.close}></div>
    </div>
  );
};

export default DrawerModal;
