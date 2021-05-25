import React from "react";
import { CSpinner } from "@coreui/react";
import "./LoadingSpinner.scss";
const LoadingSpinner = (props) => {
  return (
    <div>
      <CSpinner
        className={"LoadingSpinner"}
        style={{ width: "4rem", height: "4rem", ...props.style }}
        variant="grow"
      />
    </div>
  );
};

export default LoadingSpinner;
