import axios from "axios";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";

export const getRandomProducts = createAsyncThunk(
  "dynamicBanner/getRandomProducts",
  async ({ count }) => {
    try {
      const res = await axios.get(`/products/random/${count}`);
      if (res.status !== 200) {
        throw new Error("Fetch Products API call failed");
      }

      return res.data;
    } catch (error) {
      throw error;
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
          ? state.artistsSlides.length - 1
          : state.activeIndex - 1;
    },
    next(state) {
      state.activeIndex =
        state.activeIndex + 1 > state.artistsSlides.length - 1
          ? 0
          : state.activeIndex + 1;
    },
  },
  extraReducers: {
    [getRandomProducts.pending]: (state) => {
      state.status = "loading";
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

      state.status = "success";
    },
    [getRandomProducts.rejected]: (state, action) => {
      state.status = "failed";
    },
  },
});

export const dynamicBannerActions = dynamicBannerSlice.actions;
export default dynamicBannerSlice.reducer;
