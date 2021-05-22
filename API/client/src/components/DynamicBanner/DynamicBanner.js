import React from "react";
import "./DynamicBanner.scss";
import Carousel from "../UI/Carousel/Carousel";
import useWindowDimensions from "../../hooks/useWindowDimensions/useWindowDimensions";

const DynamicBanner = (props) => {
  const { width } = useWindowDimensions();
  return (
    <div className="DynamicBanner">
      <div className="detailsCarousel">
        <Carousel
          slides={props.detailsSlides}
          activeIndex={props.activeIndex}
          autoSlide={1}
          animate={true}
          variantControls="dynamicBanner"
          prev={props.prev}
          next={props.next}
          hideIndicators
        />
      </div>
      <div className="productsCarousel">
        <Carousel
          slides={props.productsSlides}
          autoSlide={1}
          animate={true}
          activeIndex={props.activeIndex}
          hideControls={width <= 576 ? false : true}
          hideIndicators={width <= 576 ? false : true}
        />
      </div>
    </div>
  );
};

export default DynamicBanner;
