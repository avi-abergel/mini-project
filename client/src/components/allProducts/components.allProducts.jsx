import React from "react";
import { useState } from "react";
import { getAllProducts } from "../services/services";

export const AllProducts = (props) => {
  const [products, setProducts] = usestate([]);
  const getProductsFromServer = async () => {
    let ret = await getAllProducts();
    setProducts(ret);
  };
  return (
    <div>
      <h1>All Products</h1>
      <table className="table table-striped">
        <th>#</th>
        <th>Product Name</th>
        <th>Unit Price</th>
        <tbody>{}</tbody>
      </table>
    </div>
  );
};
