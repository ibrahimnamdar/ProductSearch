import React, { useState, useEffect } from "react";
import "./styles.scss";

export default function Filter({ style, title, filterItems, onClick, status }) {
  return (
    <div style={style} onClick={onClick}>
      <p className="filter-header">{title}</p>
      <div className="filter-body">
        {filterItems
          ? filterItems?.map((item, i) => (
              <p
                className={
                  status && status.active && status.current == item.name
                    ? "filter-item active"
                    : "filter-item"
                }
                key={i}
                data-value={item.name}
              >
                {item.name} ({item.count})
              </p>
            ))
          : {}}
      </div>
    </div>
  );
}
