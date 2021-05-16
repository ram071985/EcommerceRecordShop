import React, { useState } from "react";
import "./DynamicBanner.scss";
import Carousel from "../UI/Carousel/Carousel";
import useWindowDimensions from "../../hooks/useWindowDimensions/useWindowDimensions";

const DynamicBanner = (props) => {
  const slides = [
    {
      id: 1,
      src: "https://via.placeholder.com/1200x589",
      alt: "slide1",
      title: "Slide 1",
      subtitle: "slide 1 sub",
    },
    {
      id: 2,
      src: "https://via.placeholder.com/1200x589",
      alt: "slide2",
      title: "Slide 2",
      subtitle: "slide 2 sub",
    },
    {
      id: 3,
      src: "https://via.placeholder.com/1200x589",
      alt: "slide3",
      title: "Slide 3",
      subtitle: "slide 3 sub",
    },
    {
      id: 4,
      src: "https://via.placeholder.com/1200x589",
      alt: "slide4",
      title: "Slide 4",
      subtitle: "slide 4 sub",
    },
  ];

  const { width } = useWindowDimensions();

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
          autoSlide={1}
          animate={true}
          variantControls="dynamicBanner"
          prev={prev}
          next={next}
          hideIndicators
        />
      </div>
      <div className="productsCarousel">
        <Carousel
          slides={slides}
          autoSlide={1}
          animate={true}
          activeIndex={activeIndex}
          hideControls={width <= 576 ? false : true}
          hideIndicators={width <= 576 ? false : true}
        />
      </div>
    </div>
  );
};

export default DynamicBanner;
