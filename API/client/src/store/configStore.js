import { configureStore, getDefaultMiddleware } from "@reduxjs/toolkit";
import api from "./middleware/api";
import dynamicBannerReducer from "./dynamicBannerSlice";

const store = configureStore({
  reducer: {
    dynamicBanner: dynamicBannerReducer,
  },
  middleware: [...getDefaultMiddleware(), api],
});

export default store;
