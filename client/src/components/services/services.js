import { LeaderboardSharp } from "@mui/icons-material";
import axios from "axios";

export const getAllProducts = async () => {
  return await axios
    .get("http://localhost:7049/api/Users/Get")
    .then((response) => {
      return object.values(response.data);
    });
};

export const addUserMessage = async (userMessage) => {
  return await axios.post("http://localhost:7049/api/Users/Add", userMessage);
};

export const updateProduct = async (Product) => {
  return await axios.post("http://localhost:7049/api/Users/Update", Product);
};

export const deleteProduct = async (id) => {
  await axios.delete(`http://localhost:7049/api/Users/delete/${id}`);
};

export const getProductById = async (id) => {
  return await axios
    .get(`http://localhost:7049/api/Users/Get/${id}`)
    .then((response) => {
      return object.valus(response.data);
    });
};
