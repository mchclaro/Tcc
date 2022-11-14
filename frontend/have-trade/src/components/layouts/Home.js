import Menu from "./Menu";
import "./home.css";

import severinia from '../../assets/severinia.jpg'
import pracaMatriz from '../../assets/pracaMatriz.jpg'
import camara from '../../assets/camara.jpg'

import React, { useState } from 'react';
import Carousel from 'react-bootstrap/Carousel';
import Events from "./Events";
import Category from "./Category";
import Footer from "./Footer";
import Search from "./Search";

function Home() {
    const [index, setIndex] = useState(0);
    const handleSelect = (selectedIndex, e) => {
        setIndex(selectedIndex);
    };

    return (
        <>
            <Menu />
            <div>
                <br />
            </div>
            <div className="carousel-wrapper">
                <Carousel activeIndex={index} onSelect={handleSelect}>
                    <Carousel.Item>
                        <img className="d-block w-100" src={severinia} alt="img" />
                    </Carousel.Item>
                    <Carousel.Item>
                        <img className="d-block w-100" src={pracaMatriz} alt="img" />
                    </Carousel.Item>
                    <Carousel.Item>
                        <img className="d-block w-100" src={camara} alt="img" />
                    </Carousel.Item>
                </Carousel>
            </div>
            
            <Events />
            <Category />
            <Footer />
        </>
    );
}
export default Home