import React, { useState } from "react";
import "./DynamicBanner.scss";
import Carousel from "../UI/Carousel/Carousel";

const DynamicBanner = (props) => {
  const slides = [
    "https://via.placeholder.com/1200x589",
    "https://via.placeholder.com/1200x589",
    "https://via.placeholder.com/1200x589",
  ];

  const [activeIndex, setActiveIndex] = useState(0);

  const next = () => {
    const slideIdx = activeIndex + 1 > slides.length - 1 ? 0 : activeIndex + 1;
    setActiveIndex(slideIdx);
  };

  const prev = () => {
    const slideIdx = activeIndex - 1 < 0 ? slides.length - 1 : activeIndex - 1;
    setActiveIndex(slideIdx);
  };

  return (
    <div className="DynamicBanner">
      <div className="detailsCarousel">
        <Carousel
          slides={slides}
          activeIndex={activeIndex}
          variantControls="dynamicBanner"
          prev={prev}
          next={next}
          hideIndicators
        />
      </div>
      <div className="productsCarousel">
        <Carousel
          slides={slides}
          activeIndex={activeIndex}
          hideControls
          hideIndicators
        />
      </div>
    </div>
  );
};

export default DynamicBanner;
