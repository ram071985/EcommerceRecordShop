import React, { useState, useEffect } from "react";
import { Container, Row, Col, Link } from "react-bootstrap";
import axios from "axios";
import { CIcon } from "@coreui/icons-react";
import { freeSet } from "@coreui/icons";
import { CPopover, CLink } from "@coreui/react";

const ProductLayout = () => {
  const [artistName, setArtistName] = useState("Kiefer");
  const [albumName, setAlbumName] = useState(" Happysad");
  const [image, setImage] = useState(
    "https://i.scdn.co/image/ab67616d0000b2738396e7dd8de7725b5894a36d"
  );
  //   useEffect(() => {
  //     getData();
  //   });

  const getData = () => {
    const id = "7t0S1JQpSHsZftfzVQWW2a";
    axios
      .get(`spotify/${id}`)
      .then((response) => {
        setArtistName(response.data.artistName);
        setImage(response.data.imageUrl);
        console.log(response);
      })
      .catch((err) => {
        console.log(err);
      });
  };
  return (
    <div className="main-container d-flex">
      <div classname="left-container container-fluid">
        <img id="album-img" className="img-fluid" src={image} />
      </div>
      <div className="right-container">
        {" "}
        <div className="pname-container container-fluid d-flex flex-wrap">
          <h1 className="product-details mb-0" id="artist-name">
            Kiefer
          </h1>
          <div className="favorite-container">
          <span className="icon ml-5">
            <CPopover placement="bottom" className="favorites-popover" content="Add To Wishlist">
              <CLink >
                <CIcon className="ml-1" content={freeSet.cilBookmark} />
              </CLink>
            </CPopover>
          </span>
          </div>
        </div>
        <h1 className="product-details d-inline mr-5" id="album-name">
          Happysad
        </h1>
        <div className="price-container">
          <h3 id="price">$20</h3>
        </div>
      </div>
    </div>
  );
};

export default ProductLayout;
