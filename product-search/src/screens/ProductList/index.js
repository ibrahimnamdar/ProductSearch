import React, { useState, useEffect, useCallback } from "react";
import { useLocation, useSearchParams } from "react-router-dom";
import "./styles.scss";
import OrderSelectBox from "../../components/OrderSelectBox";
import Filter from "../../components/Filter";
import OrderBox from "../../components/OrderBox";
import Product from "../../components/Product";
import { useDispatch, useSelector } from "react-redux";
import { SET_ORDER, SET_PRODUCTS } from "../../constants";
import _ from "underscore";

function ProductList() {
  const result = { productName: "iPhone iOS cep telefonu" };
  const [searchParams, setSearchParams] = useSearchParams();
  const [colorStatus, setColorStatus] = useState({
    active: true,
    current: "",
  });
  const [colorFilters, setColorFilters] = useState([]);
  const [brandFilters, setBrandFilters] = useState([]);

  const [brandStatus, setBrandStatus] = useState({
    active: true,
    current: "",
  });
  const [orderStatus, setOrderStatus] = useState("");
  const orderType = useSelector((state) => state.orderType);
  const searchQuery = useSelector((state) => state.productReducer.searchQuery);

  const [request, setRequest] = useState({
    searchQuery: "",
    page: 1,
    pageSize: 12,
    orderingType: orderStatus,
    brand: brandStatus.current,
    color: colorStatus.current,
  });

  const dispatch = useDispatch();
  const baseUrl = "http://localhost:5000/api";
  const settings = {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ ...request, orderType, searchQuery }),
  };

  const products = useSelector(
    (state) => state.productReducer.products,
    _.isEqual
  );

  useEffect(() => {
    if (searchQuery.length >= 2 || searchQuery === "") {
      fetch(`${baseUrl}/product/filterproducts`, settings)
        .then((res) => {
          return res.json();
        })
        .then((data) => {
          console.log(data.colorFilters);
          console.log(data.brandFilters);
          setColorFilters(data.colorFilters);
          setBrandFilters(data.brandFilters);
          dispatch({
            type: SET_PRODUCTS,
            products: data.products,
          });
        });
    }
  }, [request, orderType, searchQuery]);

  const orderStyles = {
    position: "relative",
    top: "-67px",
    right: "78px",
    minWidth: "120px",
    float: "right",
  };

  const productStyles = {
    float: "left",
    paddingLeft: "11px",
  };

  const handleOrdering = (e) => {
    var value = e.target.getAttribute("data-value");
    if (e.target.value) {
      dispatch({
        type: SET_ORDER,
        orderType: e.target.value,
      });
    }

    setOrderStatus({ active: true, current: value ?? e.target.value });
    setRequest({ ...request, orderingType: value ?? e.target.value });
  };

  const handleColorFiltering = (e) => {
    var value = e.target.getAttribute("data-value");

    if (colorStatus.active && colorStatus.current !== value) {
      setColorStatus({ active: true, current: value });
      setRequest({ ...request, color: value });
    } else if (colorStatus.active && colorStatus.current == value) {
      setColorStatus({ active: false, current: "" });
      setRequest({ ...request, color: "" });
    } else {
      setColorStatus({ active: !colorStatus.active, current: value });
      setRequest({ ...request, color: value });
    }
  };

  const handleBrandFiltering = (e) => {
    var value = e.target.getAttribute("data-value");

    if (brandStatus.active && brandStatus.current !== value) {
      setBrandStatus({ active: true, current: value });
      setRequest({ ...request, brand: value });
    } else if (brandStatus.active && brandStatus.current == value) {
      setBrandStatus({ active: false, current: "" });
      setRequest({ ...request, brand: "" });
    } else {
      setBrandStatus({ active: !brandStatus.active, current: value });
      setRequest({ ...request, brand: value });
    }
  };

  return (
    <div className="container">
      <div className="sub-header">
        <h3 className="product-name">{result.productName}</h3>
        <p className="search-text">
          Aranan kelime:
          <span className="search-result-text">{searchQuery}</span>
        </p>
        <OrderSelectBox style={orderStyles} onChange={handleOrdering} />
      </div>
      <div className="sidebar">
        <Filter
          title="Renk"
          filterItems={colorFilters}
          onClick={handleColorFiltering}
          status={colorStatus}
        />
        <OrderBox style={{ position: "relative" }} onClick={handleOrdering} />
        <Filter
          title="Marka"
          filterItems={brandFilters}
          onClick={handleBrandFiltering}
          status={brandStatus}
        />
      </div>
      <div className="product-list-container">
        {products && products.length > 0
          ? products?.map((product, idx) => {
              return (
                <Product key={idx} style={productStyles} product={product} />
              );
            })
          : ""}
      </div>
    </div>
  );
}

export default ProductList;
