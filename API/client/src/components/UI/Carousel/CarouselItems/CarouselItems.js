import React from "react";
import CarouselItem from "./CarouselItem/CarouselItem";
import { CCarouselInner } from "@coreui/react";

const CarouselItems = (props) => {
  return (
    <CCarouselInner>
      {props.slides.map((slide) => (
        <CarouselItem
          key={slide.id}
          src={slide.src}
          alt={slide.alt}
          title={slide.title}
          subtitle={slide.subtitle}
          blackbars={props.blackbars}
        />
      ))}
    </CCarouselInner>
  );
};

export default CarouselItems;
