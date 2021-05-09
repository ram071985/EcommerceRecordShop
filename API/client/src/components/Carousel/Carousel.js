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
//TODO: Slides get passed in as props

const Carousel = (props) => {
  const slides = [
    "https://via.placeholder.com/150",
    "https://via.placeholder.com/150",
    "https://via.placeholder.com/150",
    "https://via.placeholder.com/150",
  ];
  const [activeIndex, setActiveIndex] = useState(0);

  return (
    <div>
      <CRow>
        <CCol sm={12}>
          <CCarousel activeIndex={activeIndex}>
            <CCarouselIndicators />
            <CCarouselInner>
              <CCarouselItem>
                <img className="d-block w-100" src={slides[0]} alt="slide 1" />
                <CCarouselCaption>
                  <h3>Slide 1</h3>
                  <p>Slide 1</p>
                </CCarouselCaption>
              </CCarouselItem>
              <CCarouselItem>
                <img className="d-block w-100" src={slides[1]} alt="slide 2" />
                <CCarouselCaption>
                  <h3>Slide 2</h3>
                  <p>Slide 2</p>
                </CCarouselCaption>
              </CCarouselItem>
              <CCarouselItem>
                <img className="d-block w-100" src={slides[2]} alt="slide 3" />
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
