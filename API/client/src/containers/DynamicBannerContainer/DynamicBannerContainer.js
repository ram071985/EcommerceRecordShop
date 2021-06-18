import React, { useEffect } from "react";
import DynamicBanner from "../../components/DynamicBanner/DynamicBanner";
import LoadingSpinner from "../../components/UI/LoadingSpinner/LoadingSpinner";
import { useDispatch, useSelector } from "react-redux";
import { getRandomProducts } from "../../store/dynamicBannerSlice";
import { dynamicBannerActions } from "../../store/dynamicBannerSlice";
import { APIStatus } from "../../store/constants/apiStatus";

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

  const dynamicBannerHandler = () => {
    if (status === APIStatus.LOADING) {
      return <LoadingSpinner style={{ marginTop: "100px" }} />;
    } else if (status === APIStatus.SUCCESS) {
      return (
        <DynamicBanner
          detailsSlides={artistSlides}
          productsSlides={albumSlides}
          activeIndex={activeIndex}
          prev={prevHandler}
          next={nextHandler}
        />
      );
    } else if (status === APIStatus.FAILED) {
      return (
        <div>Oops, we've encountered an error. Could not load banner.</div>
      );
    }
  };

  return <div>{dynamicBannerHandler()}</div>;
};

export default DynamicBannerContainer;
