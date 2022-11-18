import { FaSearch } from 'react-icons/fa';
import './search.css'

export default function Search() {
    return (
        <>
            <div className="search">
                <form className="search__FormUI-sc-1wvs0c1-1 cQGSFH" action="/">
                    <input className="search__InputUI-sc-1wvs0c1-2 dRQgOV" type="text" name="conteudo" placeholder="Digite sua busca..." />
                    <button className="search__SearchButtonUI-sc-1wvs0c1-4 laEttB">
                        <FaSearch />
                    </button>
                </form>
            </div>
        </>
    );
}