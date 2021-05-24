import React from "react";
import { CCarouselItem, CCarouselCaption } from "@coreui/react";
import "./CarouselItem.scss";

const CarouselItem = (props) => {
  let imageClass = ["d-block"];
  if (props.blackbars) {
    imageClass.push("blackbars");
  } else {
    imageClass.push("w-100");
  }
  return (
    <CCarouselItem className="CarouselItem">
      <div
        className="backgroundImg"
        style={{ backgroundImage: `url(${props.src})` }}
      ></div>
      <img className={imageClass.join(" ")} src={props.src} alt={props.alt} />

      <CCarouselCaption className="captions">
        <div className="dropShadow">
          <h3>{props.title}</h3>
          <p>{props.subtitle}</p>
        </div>
      </CCarouselCaption>
    </CCarouselItem>
  );
};

export default CarouselItem;
