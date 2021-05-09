import React, { useState } from "react";
import "./DynamicBanner.scss";
import Carousel from "../UI/Carousel/Carousel";

const DynamicBanner = (props) => {
  const slides = [
    "https://via.placeholder.com/1200x589",
    "https://via.placeholder.com/1200x589",
    "https://via.placeholder.com/1200x589",
    "https://via.placeholder.com/1200x589",
  ];

  const [activeIndex, setActiveIndex] = useState(0);

  return (
    <div className="DynamicBanner">
      <div className="detailsCarousel">
        <Carousel
          slides={slides}
          activeIndex={activeIndex}
          hideDefaultControls
        />
      </div>
      <div className="productsCarousel">
        <Carousel
          slides={slides}
          activeIndex={activeIndex}
          hideDefaultControls
        />
      </div>
    </div>
  );
};

export default DynamicBanner;
