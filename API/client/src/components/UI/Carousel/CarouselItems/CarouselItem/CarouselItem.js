import React from "react";
import { CCarouselItem, CCarouselCaption } from "@coreui/react";
import "./CarouselItem.scss";

const CarouselItem = (props) => {
  let imageClass = ["d-block"];
  //TODO: Create context for this.
  if (props.blackbars) {
    imageClass.push("blackbars");
  } else {
    imageClass.push("w-100");
  }
  return (
    <CCarouselItem className="CarouselItem">
      {/* w-100 */}
      <img className={imageClass.join(" ")} src={props.src} alt={props.alt} />

      <CCarouselCaption>
        <div className="dropShadow">
          <h3>{props.title}</h3>
          <p>{props.subtitle}</p>
        </div>
      </CCarouselCaption>
    </CCarouselItem>
  );
};

export default CarouselItem;
