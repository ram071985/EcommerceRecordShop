import React from "react";
import "./DynamicBanner.scss";
import Carousel from "../UI/Carousel/Carousel";

const DynamicBanner = (props) => {
  const slides = [
    "https://via.placeholder.com/1200x589",
    "https://via.placeholder.com/1200x589",
    "https://via.placeholder.com/1200x589",
    "https://via.placeholder.com/1200x589",
  ];
  return (
    <div className="DynamicBanner">
      <Carousel slides={slides} />
    </div>
  );
};

export default DynamicBanner;
