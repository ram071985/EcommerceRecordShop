import React, { useState, useEffect } from "react";
import DynamicBanner from "../../components/DynamicBanner/DynamicBanner";
import LoadingSpinner from "../../components/UI/LoadingSpinner/LoadingSpinner";
import { fetchRandomProducts } from "../../services/api/products";
import { useDispatch } from "react-redux";
import { getRandomProducts } from "../../store/dynamicBannerSlice";

const DynamicBannerContainer = () => {
  const dispatch = useDispatch();
  const [isLoading, setIsLoading] = useState(true);
  const [albumSlides, setAlbumSlides] = useState([]);
  const [artistsSlides, setArtistsSlides] = useState([]);

  useEffect(() => {
    //Testing
    dispatch(getRandomProducts({ count: 5 }));
    fetchRandomProducts(5)
      .then((res) => {
        const newAlbumSlides = [];
        const newArtistSlides = [];
        res.map((product) => {
          const {
            artistId,
            imageUrl,
            artistData,
            name,
            recordLabel,
            artistName,
          } = product.album;

          newAlbumSlides.push({
            id: artistId,
            src: imageUrl,
            alt: `Album ${name}`,
            title: name,
            subtitle: recordLabel,
          });

          newArtistSlides.push({
            id: artistId,
            src: artistData.artistImageUrls[1].url,
            alt: `Artist ${artistName}`,
            title: artistName,
            subtitle: recordLabel,
          });
        });

        setAlbumSlides(newAlbumSlides);
        setArtistsSlides(newArtistSlides);
        setIsLoading(false);
      })
      .catch((e) => {
        console.log(e);
      });
  }, [dispatch]);

  const [activeIndex, setActiveIndex] = useState(0);

  const next = () => {
    const slideIdx =
      activeIndex + 1 > artistsSlides.length - 1 ? 0 : activeIndex + 1;
    setActiveIndex(slideIdx);
  };

  const prev = () => {
    const slideIdx =
      activeIndex - 1 < 0 ? artistsSlides.length - 1 : activeIndex - 1;
    setActiveIndex(slideIdx);
  };
  return (
    <div>
      {!isLoading ? (
        <DynamicBanner
          detailsSlides={artistsSlides}
          productsSlides={albumSlides}
          activeIndex={activeIndex}
          prev={prev}
          next={next}
        />
      ) : (
        <LoadingSpinner style={{ marginTop: "100px" }} />
      )}
    </div>
  );
};

export default DynamicBannerContainer;
