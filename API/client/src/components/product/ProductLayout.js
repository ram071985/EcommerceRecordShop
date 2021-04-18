import React, { useState, useEffect } from "react";
import { Container, Row, Col } from "react-bootstrap";
import axios from "axios";

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
      <div classname="left-container">
        <img id="album-img" className="img-fluid" src={image} />
      </div>
      <div>
        <h1 className="product-details" id="artist-name">Kiefer</h1>
      </div>
    </div>
    // <Container className="main-container">
    //   <div>
    //     <Col className="left-col d-inline">
    //       <img id="album-img" className="img-fluid" src={image} />
    //     </Col>
    //   </div>
    //   <div>
    //     <Col className="d-inline right-col" md={4}>
    //       <div className="album-content">
    //         {" "}
    //         <span className="product-titles" id="artist-name">
    //           {artistName}
    //           <span className="product-titles" id="album-name">
    //             {albumName}
    //           </span>
    //         </span>
    //         <span className="product-titles mt-1" id="price">
    //           $20
    //         </span>
    //       </div>
    //     </Col>
    //   </div>
    // </Container>
  );
};

export default ProductLayout;
