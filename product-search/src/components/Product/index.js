import React, { useState, useEffect } from "react";
import "./styles.scss";

export default function Product({ style, product }) {
  const createDiscountedCurrency = (price, discountRate) => {
    var currency = price - price * (discountRate / 100);
    return currency.toLocaleString("tr");
  };

  return (
    <div style={style}>
      <div className="product-container">
        <div className="product-image-container">
          <img src={product.imageUrl} alt={product.name}></img>
        </div>
        <div className="product-property-container">
          <p className="property-name">{product.name}</p>
          <p className="property">
            <span>Marka: </span>
            {product.brand}
          </p>
          <p className="property">
            <span>Renk: </span>
            {product.color}
          </p>
        </div>
        <div className="product-price-container">
          <p className="discounted-price">
            {createDiscountedCurrency(product.price, product.discountRate)} TL
          </p>
          <div>
            <p className="price">{product.price} TL</p>
            <p className="discount-rate">{product.discountRate}%</p>
          </div>
        </div>
      </div>
    </div>
  );
}
