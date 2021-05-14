import React from "react";
import "./Carousel.scss";
import {
  CRow,
  CCol,
  CCarousel,
  CCarouselIndicators,
  CCarouselCaption,
  CCarouselItem,
  CCarouselInner,
  CCarouselControl,
} from "@coreui/react";
import { CIcon } from "@coreui/icons-react";
import Button from "../Button/Button";

const Carousel = (props) => {
  const getControls = () => {
    if (props.hideControls) return null;

    switch (props.variantControls) {
      case "dynamicBanner":
        return (
          <div className="dynamicBannerControls">
            <Button clicked={props.prev} variant="carousel">
              <CIcon name="cilArrowThickLeft" />
            </Button>
            <Button clicked={props.next} variant="carousel">
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
          <CCarousel activeIndex={props.activeIndex}>
            {props.hideIndicators ? null : <CCarouselIndicators />}
            <CCarouselInner>
              <CCarouselItem>
                <img
                  className="d-block w-100"
                  src={props.slides[0]}
                  alt="slide 1"
                />
                <CCarouselCaption>
                  <h3>Slide 1</h3>
                  <p>Slide 1</p>
                </CCarouselCaption>
              </CCarouselItem>
              <CCarouselItem>
                <img
                  className="d-block w-100"
                  src={props.slides[1]}
                  alt="slide 2"
                />
                <CCarouselCaption>
                  <h3>Slide 2</h3>
                  <p>Slide 2</p>
                </CCarouselCaption>
              </CCarouselItem>
              <CCarouselItem>
                <img
                  className="d-block w-100"
                  src={props.slides[2]}
                  alt="slide 3"
                />
                <CCarouselCaption>
                  <h3>Slide 3</h3>
                  <p>Slide 3</p>
                </CCarouselCaption>
              </CCarouselItem>
            </CCarouselInner>
            {getControls()}
          </CCarousel>
        </CCol>
      </CRow>
    </div>
  );
};

export default Carousel;
