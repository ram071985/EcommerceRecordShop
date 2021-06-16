import React, { useState, useEffect } from "react";
import DynamicBanner from "../../components/DynamicBanner/DynamicBanner";
import LoadingSpinner from "../../components/UI/LoadingSpinner/LoadingSpinner";
// import { fetchRandomProducts } from "../../services/api/products";
import { useDispatch, useSelector } from "react-redux";
import { getRandomProducts } from "../../store/dynamicBannerSlice";
import { dynamicBannerActions } from "../../store/dynamicBannerSlice";

const DynamicBannerContainer = () => {
  const dispatch = useDispatch();
  const { albumSlides, artistSlides, activeIndex, status } = useSelector(
    (state) => state.dynamicBanner
  );

  useEffect(() => {
    dispatch(getRandomProducts({ count: 5 }));
  }, [dispatch]);

  const prevHandler = () => {
    dispatch(dynamicBannerActions.prev());
  };

  const nextHandler = () => {
    dispatch(dynamicBannerActions.next());
  };
  return (
    <div>
      {status === "success" ? (
        <DynamicBanner
          detailsSlides={artistSlides}
          productsSlides={albumSlides}
          activeIndex={activeIndex}
          prev={prevHandler}
          next={nextHandler}
        />
      ) : (
        <LoadingSpinner style={{ marginTop: "100px" }} />
      )}
    </div>
  );
};

export default DynamicBannerContainer;
