import React, { useState } from 'react';
import { NavLink, Link } from 'react-router-dom';
import { FiAlignRight, FiXCircle, FiChevronDown } from "react-icons/fi";
import logo from '../../assets/logo.jpg'
import './menu.css'


const Menu = () => {

    const [isMenu, setisMenu] = useState(false);
    const [isResponsiveclose, setResponsiveclose] = useState(false);
    const toggleClass = () => {
        setisMenu(isMenu === false ? true : false);
        setResponsiveclose(isResponsiveclose === false ? true : false);
    };

    let boxClass = ["main-menu menu-right menuq1"];
    if (isMenu) {
        boxClass.push('menuq2');
    } else {
        boxClass.push('');
    }

    const [isMenuSubMenu, setMenuSubMenu] = useState(false);

    const toggleSubmenu = () => {
        setMenuSubMenu(isMenuSubMenu === false ? true : false);
    };

    let boxClassSubMenu = ["sub__menus"];
    if (isMenuSubMenu) {
        boxClassSubMenu.push('sub__menus__Active');
    } else {
        boxClassSubMenu.push('');
    }

    return (
        <header className="header__middle">
            <div className="container">
                <div className="header__middle__logo">
                    <Link to="/" className='is-active'>
                        <img src={logo} alt="logo" width="100" height="100" />
                    </Link>
                </div>
                <div className="row">
                    <div className="header__middle__menus">

                        <nav className="main-nav " >
                            {isResponsiveclose === true ? <>
                                <span className="menubar__button" style={{ display: 'none' }} onClick={toggleClass}><FiXCircle /></span>
                            </> : <>
                                <span className="menubar__button" style={{ display: 'none' }} onClick={toggleClass}><FiAlignRight /></span>
                            </>}

                            <ul className={boxClass.join(' ')}>
                                <li className="menu-item" >
                                    <Link to="/" className='is-active' onClick={toggleClass}>Home</Link>
                                </li>
                                <li className="menu-item"><Link to="/business" onClick={toggleClass} className='is-active'>Comércios</Link></li>
                                <li className="menu-item"><Link to="/" onClick={toggleClass} className='is-active'>Produtos</Link></li>
                                <li onClick={toggleSubmenu} className="menu-item sub__menus__arrows" > <Link to="/"> Categorias <FiChevronDown /></Link>
                                    <ul className={boxClassSubMenu.join(' ')} >
                                        <li> <Link to="/" onClick={toggleClass} className='is-active'>Fármacias</Link></li>
                                        <li><Link to="/" onClick={toggleClass} className='is-active'>Mercados</Link></li>
                                        <li><Link to="/" onClick={toggleClass} className='is-active'>Restaurantes</Link></li>
                                    </ul>
                                </li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </header>
    )
}

export default Menu