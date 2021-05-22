import axios from "../../config/api/index";

const fetchProducts = async (count) => {
  try {
    const res = await axios.get(`/products/${count}`);
    console.log(res);
    if (res.status !== 200) {
      const data = res.data;
      throw new Error("Something went wrong");
    }

    return res.data;
  } catch (error) {
    console.log(error);
  }
};

export { fetchProducts };
