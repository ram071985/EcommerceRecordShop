import axios from "axios";
import * as actions from "../actions/api";

const api =
  ({ dispatch }) =>
  (next) =>
  async (action) => {
    if (action.type !== actions.apiCallBegan.type) return next(action);
    const { url, method, headers, data, onStart, onSuccess, onError } =
      action.payload;

    if (onStart) dispatch({ type: onStart });
    next(action);

    try {
      const response = await axios.request({
        baseURL: "http://localhost:5001",
        url,
        method,
        headers,
        data,
      });
      dispatch(actions.apiCallSuccess(response.data));

      if (onSuccess) {
        console.log("Success");
        dispatch({ type: onSuccess, payload: response.data });
      }
    } catch (error) {
      dispatch(actions.apiCallFailed(error.message));
      if (onError) dispatch({ type: onError, payload: error.message });
    }
  };

export default api;
