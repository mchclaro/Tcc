import Menu from "./Menu";
import "./home.css";
import { FaSearch } from "react-icons/fa";
import p from '../../assets/p.png'
import s from '../../assets/s.png'
import t from '../../assets/t.png'
import { Carousel } from 'react-responsive-carousel';
import "react-responsive-carousel/lib/styles/carousel.min.css";
import Events from "./Events";

function Home() {
    return (
        <>
            <Menu />
            <div className="search">
                <form className="search__FormUI-sc-1wvs0c1-1 cQGSFH" action="/">
                    <input className="search__InputUI-sc-1wvs0c1-2 dRQgOV" type="text" name="conteudo" placeholder="Digita sua busca..." />
                    <button className="search__SearchButtonUI-sc-1wvs0c1-4 laEttB">
                        <FaSearch />
                    </button>
                </form>
            </div>
            <div className="carousel-wrapper">
                <Carousel autoPlay>
                    <div>
                        <img src={t} />
                    </div>
                    <div>
                        <img src={s} />
                    </div>
                    <div>
                        <img src={p} />
                    </div>
                    <div>
                        <img src={p} />
                    </div>
                </Carousel>
            </div>

            <Events />
        </>
    );
}
export default Home