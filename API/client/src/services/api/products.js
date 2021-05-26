import axios from "../../config/api/index";

const fetchRandomProducts = async (count) => {
  try {
    const res = await axios.get(`/products/random/${count}`);
    if (res.status !== 200) {
      const data = res.data;
      throw new Error("Fetch Products API call failed");
    }

    return res.data;
  } catch (error) {
    throw error;
  }
};

export { fetchRandomProducts };
