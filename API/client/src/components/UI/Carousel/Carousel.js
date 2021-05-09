import React, { useState } from "react";
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

const Carousel = (props) => {
  const [activeIndex, setActiveIndex] = useState(0);

  return (
    <div>
      <CRow>
        <CCol sm={12}>
          <CCarousel activeIndex={activeIndex}>
            <CCarouselIndicators />
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
            <CCarouselControl direction="prev" />
            <CCarouselControl direction="next" />
          </CCarousel>
        </CCol>
      </CRow>
    </div>
  );
};

export default Carousel;
