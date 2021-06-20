import { configureStore, getDefaultMiddleware } from "@reduxjs/toolkit";
// import api from "./middleware/api";
import dynamicBannerReducer from "./dynamicBannerSlice";
import headerReducer from "./headerSlice";

const store = configureStore({
  reducer: {
    header: headerReducer,
    dynamicBanner: dynamicBannerReducer,
  },
  // middleware: [...getDefaultMiddleware()],
});

export default store;
