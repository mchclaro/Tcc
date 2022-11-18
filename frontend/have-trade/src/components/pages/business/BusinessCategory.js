import Footer from '../../layouts/Footer';
import Menu from '../../layouts/Menu';
import Search from '../../layouts/Search';
import './business.css'
import axios from "axios";
import { useEffect, useState } from "react";
import Carousel from 'react-bootstrap/Carousel';
import { FaFacebook, FaInstagram, FaPhoneAlt, FaWhatsapp } from 'react-icons/fa';
import { MdWatchLater } from 'react-icons/md';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet'
import imagem from '../../../assets/imagem.jpg';

export default function Business(props) {
    const [index, setIndex] = useState(0);
    const handleSelect = (selectedIndex, e) => {
        setIndex(selectedIndex);
    };

    const baseUrl = "https://localhost:5001/api/Business/";
    const [data, setData] = useState([]);
    const category = 1;

    const getBusiness = async () => {
        await axios.get(`${baseUrl}read/all/${category}`).then(response => {
            setData(response.data.data);
        }).catch(error => {
            console.log(error);
        })
    };

    useEffect(() => {
        getBusiness();
        console.log(data)
    }, [])

    return (
        <>
            <Menu />
            <Search />
            {data.map(b =>
                <div className="cardbusiness" key={b.id}>
                    <div className="business_name">
                        <h1>{b.businessName}</h1>
                    </div>
                    <h3>Galeria de Fotos</h3>
                    <Carousel className="business_carousel" activeIndex={index} onSelect={handleSelect}>
                        <Carousel.Item>
                            <img className="d-block w-100" src={b.mainImage} alt="img" />
                        </Carousel.Item>
                        <Carousel.Item>
                            <img className="d-block w-100" src={imagem} alt="img" />
                        </Carousel.Item>
                        <Carousel.Item>
                            <img className="d-block w-100" src={b.mainImage} alt="img" />
                        </Carousel.Item>
                    </Carousel>
                    <div className="location">
                        <MapContainer className="map" center={[b.address.latitude, b.address.longitude]} zoom={13} scrollWheelZoom={false}>
                            <TileLayer
                                attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                            />
                            <Marker position={[b.address.latitude, b.address.longitude]}>
                                <Popup>
                                    {b.businessName} <br />
                                </Popup>
                            </Marker>
                        </MapContainer>
                    </div>
                    <div className="cardtext">
                        <div className="info">
                            <p>
                                {b.address.street}, {b.address.streetNumber} - {b.address.district} <br />
                                {b.address.city} - {b.address.state}, {b.address.zipCode}
                            </p>
                        </div>
                        <ul className="socialmedia">
                            <li>
                                <a href={b.socialMedias.whatsapp}><FaWhatsapp /></a>
                            </li>
                            <li>
                                <a href={b.socialMedias.instagram}> <FaInstagram /></a>
                            </li>
                            <li>
                                <a href={b.socialMedias.facebook}><FaFacebook /></a>
                            </li>
                            <li>
                                <a href={b.socialMedias.phone}><FaPhoneAlt /></a>
                            </li>
                        </ul>
                    </div>
                    <div className="hours">
                        <h5>Funcionamento:</h5>
                        <li>
                            <a href=''><MdWatchLater /></a>
                        </li>
                    </div>
                </div>
            )}
            <Footer />
        </>
    );
}