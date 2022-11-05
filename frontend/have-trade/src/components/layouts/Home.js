import Menu from "./Menu";
import "./home.css";
import p from '../../assets/p.png'
import s from '../../assets/s.png'
import t from '../../assets/t.png'
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
            <Search />
            <div className="carousel-wrapper">
                <Carousel activeIndex={index} onSelect={handleSelect}>
                    <Carousel.Item>
                        <img className="d-block w-100" src={t} alt="img" />
                    </Carousel.Item>
                    <Carousel.Item>
                        <img className="d-block w-100" src={s} alt="img" />
                    </Carousel.Item>
                    <Carousel.Item>
                        <img className="d-block w-100" src={p} alt="img" />
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