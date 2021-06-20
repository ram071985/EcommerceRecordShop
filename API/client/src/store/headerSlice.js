import { createSlice } from "@reduxjs/toolkit";

const headerSlice = createSlice({
  name: "header",
  initialState: {
    openDrawer: false,
    showSearchbar: false,
    loggedIn: true,
    headerIsSolid: true,
  },
  reducers: {
    toggleSearchbar(state) {
      state.showSearchbar = !state.showSearchbar;
    },
    toggleDrawer(state) {
      state.openDrawer = !state.openDrawer;
    },
    closeSearchbar(state) {
      state.showSearchbar = false;
    },
    closeDrawer(state) {
      state.openDrawer = false;
    },
    updateHeaderTransparency(state, action) {
      const isOnHomePage = action.payload === "/home" || action.payload === "/";
      if (isOnHomePage && !state.showSearchbar && !state.openDrawer) {
        state.headerIsSolid = false;
      } else {
        state.headerIsSolid = true;
      }
    },
    cartBtnHandler(state) {
      // TODO:
      console.log("Cart button pressed, loading cart");
    },
    logoutBtnHandler(state) {
      // TODO:
      console.log("Log out button pressed, Log out user");
    },
  },
});

export const headerActions = headerSlice.actions;
export default headerSlice.reducer;
