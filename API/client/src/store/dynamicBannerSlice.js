import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { fetchRandomProducts } from "../services/api/products";
import { APIStatus } from "./constants/apiStatus";

export const getRandomProducts = createAsyncThunk(
  "dynamicBanner/getRandomProducts",
  async ({ count }, { rejectWithValue }) => {
    try {
      const response = await fetchRandomProducts(count);
      return response.data;
    } catch (error) {
      return rejectWithValue(error.response.data);
    }
  }
);

const dynamicBannerSlice = createSlice({
  name: "dynamicBanner",
  initialState: {
    albumSlides: [],
    artistSlides: [],
    activeIndex: 0,
    status: null,
  },
  reducers: {
    prev(state) {
      state.activeIndex =
        state.activeIndex - 1 < 0
          ? state.artistSlides.length - 1
          : state.activeIndex - 1;
    },
    next(state) {
      state.activeIndex =
        state.activeIndex + 1 > state.artistSlides.length - 1
          ? 0
          : state.activeIndex + 1;
    },
  },
  extraReducers: {
    [getRandomProducts.pending]: (state) => {
      state.status = APIStatus.LOADING;
    },
    [getRandomProducts.fulfilled]: (state, { payload }) => {
      payload.map((product) => {
        const {
          artistId,
          imageUrl,
          artistData,
          name,
          recordLabel,
          artistName,
        } = product.album;

        state.albumSlides.push({
          id: artistId,
          src: imageUrl,
          alt: `Album ${name}`,
          title: name,
          subtitle: recordLabel,
        });

        state.artistSlides.push({
          id: artistId,
          src: artistData.artistImageUrls[1].url,
          alt: `Artist ${artistName}`,
          title: artistName,
          subtitle: recordLabel,
        });
      });

      state.status = APIStatus.SUCCESS;
    },
    [getRandomProducts.rejected]: (state, action) => {
      state.status = APIStatus.FAILED;
    },
  },
});

export const dynamicBannerActions = dynamicBannerSlice.actions;
export default dynamicBannerSlice.reducer;
