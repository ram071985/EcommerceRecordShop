import React from "react";
import { CCarouselItem, CCarouselCaption } from "@coreui/react";

const CarouselItem = (props) => {
  return (
    <CCarouselItem>
      <img className="d-block w-100" src={props.src} alt={props.alt} />

      <CCarouselCaption>
        <h3>{props.title}</h3>
        <p>{props.subtitle}</p>
      </CCarouselCaption>
    </CCarouselItem>
  );
};

export default CarouselItem;
