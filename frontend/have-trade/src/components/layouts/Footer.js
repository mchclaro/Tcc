import styles from './Footer.module.css'
import { FaFacebook } from 'react-icons/fa'
import { SiGmail, SiInstagram } from 'react-icons/si'


export default function Footer() {
    return (
        <div className="container my-5">
            <hr />
            <footer className={styles.footer}>
                <ul className={styles.social_list}>
                    <li>
                        <a href=''> <SiInstagram /></a>
                    </li>
                    <li>
                        <a href=''><FaFacebook /></a>
                    </li>
                    <li>
                        <a href=''><SiGmail /></a>
                    </li>

                </ul>

                <p className={styles.copy_right}>
                    <span>&copy; 2022 AQUI TEM COMÉRCIO</span>
                </p>
            </footer>

        </div>
    );
}