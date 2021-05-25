import axios from "../../config/api/index";

const fetchProducts = async (count) => {
  try {
    const res = await axios.get(`/products/${count}`);
    if (res.status !== 200) {
      const data = res.data;
      throw new Error("Fetch Products API call failed");
    }

    return res.data;
  } catch (error) {
    console.log(error);
  }
};

export { fetchProducts };
