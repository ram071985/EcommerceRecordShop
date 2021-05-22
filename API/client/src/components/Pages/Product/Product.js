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
  CButton,
  CDropdownDivider,
  CDropdownHeader,
  CDropdownItem,
  CDropdownMenu,
  CDropdownToggle,
  CDataTable,
} from "@coreui/react";

const ProductLayout = () => {
  const [artistName, setArtistName] = useState("Kiefer");
  const [albumName, setAlbumName] = useState(" Happysad");
  const [albumResults, setAlbumResults] = useState([]);
  const [image, setImage] = useState(
    "https://i.scdn.co/image/ab67616d0000b2738396e7dd8de7725b5894a36d"
  );
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
console.log(icons)
  return (
    <div className="main-container d-flex">
      <div className="left-container container-fluid">
        <img id="album-img" className="img-fluid" src={image} />
      </div>
      <div className="right-container justify-content-left">
        <div className="pname-container container-fluid d-flex flex-wrap">
          <h1 className="product-details mb-0" id="artist-name">
            Kiefer
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
        </div>
        <h1 className="product-details d-inline" id="album-name">
          Happysad
        </h1>
        <h3 className="text-left" id="price">$20</h3>
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
