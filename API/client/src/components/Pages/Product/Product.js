import React, { useState, useEffect } from "react";
import { Table, Button } from "react-bootstrap";
import axios from "axios";
import { CIcon } from "@coreui/icons-react";
import { icons } from "../../../assets/icons/index";
import { freeSet } from "@coreui/icons";
import "./Product.scss";
import {
  CPopover,
  CLink,
  CDropdown,
  CDropdownMenu,
  CDropdownToggle,
} from "@coreui/react";

const ProductLayout = () => {
  const [artistName, setArtistName] = useState("Kiefer");
  const [albumName, setAlbumName] = useState(" Happysad");
  const [albumResults, setAlbumResults] = useState([]);
  const fields = ["Name", "Duration"];

  useEffect(() => {
    getData();
  }, []);

  const getData = async () => {
    const id = "7t0S1JQpSHsZftfzVQWW2a";
    const response = await axios.get(`spotify/${id}`);
    setAlbumResults(response.data);
  };

  const renderTracks = () => {
    getData();
    albumResults.tracks.map((track, index) => track.name);
  };

  const convertSecondsToMinutes = (seconds) => {
    let minutes = Math.floor(seconds / 60);
    let second = seconds - 60 * minutes;
    if (second.toString().length < 2) {
      second = second + "0";
    }
    return minutes + ":" + second;
  };
  console.log(albumResults);
  return (
    <div className="main-container d-flex">
      <div className="left-container container-fluid">
        <img id="album-img" className="img-fluid" src={albumResults.imageUrl} />
      </div>
      <div className="right-container justify-content-left">
        <div className="pname-container container-fluid d-flex flex-wrap">
          <h1 className="product-details mb-0" id="artist-name">
            {albumResults.artistName}
          </h1>
          <div className="favorite-container">
            <span className="icon ml-5">
              <CPopover placement="bottom" content="Add To Wishlist">
                <CLink className="wishlist-link">
                  <CIcon className="ml-1" content={freeSet.cilBookmark} />
                </CLink>
              </CPopover>
            </span>
          </div>
          <img
            id="artistImage"
            className="img-fluid"
            src={albumResults.artistImageUrl}
          />
        </div>
        <h1 className="product-details d-inline" id="album-name">
          {albumResults.name}
        </h1>
        <p className="text-left mt-1 record-lable-text">{albumResults.recordLabel}</p>
        <h3 className="text-left" id="price">
          $20
        </h3>
        <CDropdown direction="dropstart">
          <CDropdownToggle color="secondary">View tracks</CDropdownToggle>
          <CDropdownMenu className="tracks-dropdown">
            <Table>
              <thead>
                <tr>
                  <th>Name</th>
                  <th colspan="2">Duration</th>
                </tr>
              </thead>
              <tbody>
                {albumResults.tracks &&
                  albumResults.tracks.map((item, index) => (
                    <tr key={index}>
                      <td>{item.name}</td>
                      <td>{convertSecondsToMinutes(item.duration)}</td>
                    </tr>
                  ))}
              </tbody>
            </Table>
          </CDropdownMenu>
        </CDropdown>
        <Button id="cart-button" size="large" variant="warning">
          ADD TO CART
        </Button>
      </div>
    </div>
  );
};

export default ProductLayout;
