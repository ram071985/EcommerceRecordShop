import React from "react";
import "./Carousel.scss";
import {
  CRow,
  CCol,
  CCarousel,
  CCarouselIndicators,
  CCarouselControl,
} from "@coreui/react";
import { CIcon } from "@coreui/icons-react";
import Button from "../Button/Button";
import CarouselItems from "./CarouselItems/CarouselItems";

const Carousel = (props) => {
  const getControls = () => {
    if (props.hideControls) return null;

    switch (props.variantControls) {
      case "dynamicBanner":
        return (
          <div className="dynamicBannerControls">
            <Button clicked={props.prev} variant="carouselBtn">
              <CIcon name="cilArrowThickLeft" />
            </Button>
            <Button clicked={props.next} variant="carouselBtn">
              <CIcon name="cilArrowThickRight" />
            </Button>
          </div>
        );
      default:
        return (
          <>
            <CCarouselControl direction="prev" />
            <CCarouselControl direction="next" />
          </>
        );
    }
  };

  return (
    <div>
      <CRow>
        <CCol sm={12}>
          <CCarousel activeIndex={props.activeIndex} animate={props.animate}>
            {props.hideIndicators ? null : <CCarouselIndicators />}
            <CarouselItems slides={props.slides} blackbars={props.blackbars} />
            {getControls()}
          </CCarousel>
        </CCol>
      </CRow>
    </div>
  );
};

export default Carousel;
