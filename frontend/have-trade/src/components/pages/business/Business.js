import Footer from '../../layouts/Footer';
import Menu from '../../layouts/Menu';
import Search from '../../layouts/Search';
import './business.css'
import a from '../../../assets/a.png'
import fo from '../../../assets/fo.jpg'
import React, { useState } from 'react';
import Carousel from 'react-bootstrap/Carousel';
import { FaFacebook, FaInstagram, FaPhoneAlt, FaWhatsapp } from 'react-icons/fa';
import { MdWatchLater } from 'react-icons/md';
import Leaflet from '../../layouts/Leaflet';

export default function Business() {
    const [index, setIndex] = useState(0);
    const handleSelect = (selectedIndex, e) => {
        setIndex(selectedIndex);
    };

    return (
        <>
            <Menu />
            <Search />
            <div className="cardbusiness">
                <div className="business_name">
                    <h1>Supermercado Iquegami</h1>
                </div>
                <h3>Galeria de Fotos</h3>
                <Carousel className="business_carousel" activeIndex={index} onSelect={handleSelect}>
                    <Carousel.Item>
                        <img className="d-block w-100" src={a} alt="img" />
                    </Carousel.Item>
                    <Carousel.Item>
                        <img className="d-block w-100" src={fo} alt="img" />
                    </Carousel.Item>
                </Carousel>
                <div className="location">
                    <Leaflet />
                </div>
                <div className="cardtext">
                    <div className="info">
                        <p>
                            R. Profa. Nair de Almeida, 988 - Centro <br /> Severínia - SP, 14735-000
                        </p>
                    </div>
                    <ul className="socialmedia">
                        <li>
                            <a href=''><FaWhatsapp /></a>
                        </li>
                        <li>
                            <a href=''> <FaInstagram /></a>
                        </li>
                        <li>
                            <a href=''><FaFacebook /></a>
                        </li>
                        <li>
                            <a href=''><FaPhoneAlt /></a>
                        </li>
                    </ul>
                </div>
                <div className="hours">
                    <h5>Funcionamento:</h5>
                    <li>
                        <a href=''><MdWatchLater /></a>
                    </li>
                </div>
                {/* <div className="cardhours">
                    <h5>Funcionamento:</h5>
                    <h6> SEG: <h7>08H às 18H</h7></h6>
                    <h6> TER: <h7>08H às 18H</h7></h6>
                    <h6> QUA: <h7>08H às 18H</h7></h6>
                    <h6> QUI: <h7>08H às 18H</h7></h6>
                    <h6> SEX: <h7>08H às 18H</h7></h6>
                    <h6> SAB: <h7>09H às 15H</h7></h6>
                    <h6> DOM: <h7>FECHADO</h7></h6>
                </div> */}
            </div>

            {/* <div className="cardbusiness">
                <div className="business_name">
                    <h1>Supermercado Iquegami</h1>
                </div>
                <div className="location">
                    
                </div>
                <Carousel className="business_carousel" activeIndex={index} onSelect={handleSelect}>
                    <Carousel.Item>
                        <img className="d-block w-100" src={a} alt="img" />
                    </Carousel.Item>
                    <Carousel.Item>
                        <img className="d-block w-100" src={p} alt="img" />
                    </Carousel.Item>
                </Carousel>
                <div className="cardtext">
                    <div className="info">
                        <p>
                            R. Profa. Nair de Almeida, 988 - Centro <br /> Severínia - SP, 14735-000
                        </p>
                    </div>
                    <ul className="socialmedia">
                        <li>
                            <a href=''><FaWhatsapp /></a>
                        </li>
                        <li>
                            <a href=''> <FaInstagram /></a>
                        </li>
                        <li>
                            <a href=''><FaFacebook /></a>
                        </li>
                        <li>
                            <a href=''><FaPhoneAlt /></a>
                        </li>
                    </ul>
                </div>
            </div>

            <div className="cardbusiness">
                <div className="business_name">
                    <h1>Supermercado Iquegami</h1>
                </div>
                <div className="location">
                    
                </div>
                <Carousel className="business_carousel" activeIndex={index} onSelect={handleSelect}>
                    <Carousel.Item>
                        <img className="d-block w-100" src={a} alt="img" />
                    </Carousel.Item>
                    <Carousel.Item>
                        <img className="d-block w-100" src={p} alt="img" />
                    </Carousel.Item>
                </Carousel>
                <div className="cardtext">
                    <div className="info">
                        <p>
                            R. Profa. Nair de Almeida, 988 - Centro <br /> Severínia - SP, 14735-000
                        </p>
                    </div>
                    <ul className="socialmedia">
                        <li>
                            <a href=''><FaWhatsapp /></a>
                        </li>
                        <li>
                            <a href=''> <FaInstagram /></a>
                        </li>
                        <li>
                            <a href=''><FaFacebook /></a>
                        </li>
                        <li>
                            <a href=''><FaPhoneAlt /></a>
                        </li>
                    </ul>
                </div>
            </div> */}
            {/* <Footer /> */}
        </>
    );
}