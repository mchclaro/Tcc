import "./category.css";
import restaurant from '../../assets/restaurant.svg'
import bank from '../../assets/bank.svg'
import icecream from '../../assets/icecream.svg'
import gasstation from '../../assets/gasstation.svg'
import pharmacy from '../../assets/pharmacy.svg'

function Category() {
    return (
        <>
            <div className="cardmain">
                <div className="cardcategory" onClick="this.classList.toggle('expanded')">
                    <div className="icon">
                        <img src={restaurant} alt="img" width="140" height="140" />
                    </div>
                    <div className="text">
                        <div className="text_content">
                            <h1 className="title">Restaurantes</h1>
                        </div>
                    </div>
                    <svg className="chevron" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 35" width="30"><path d="M5 30L50 5l45 25" fill="none" stroke="#000" strokeWidth="5" /></svg>
                </div>
                <div className="cardcategory" onClick="this.classList.toggle('expanded')">
                    <div className="icon">
                        <img src={bank} alt="img" width="140" height="140" />
                    </div>
                    <div className="text">
                        <div className="text_content">
                            <h1 className="title">Bancos</h1>
                        </div>
                    </div>
                    <svg className="chevron" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 35" width="30"><path d="M5 30L50 5l45 25" fill="none" stroke="#000" strokeWidth="5" /></svg>
                </div>

                <div className="cardcategory" onClick="this.classList.toggle('expanded')">
                    <div className="icon">
                        <img src={icecream} alt="img" width="140" height="140" />
                    </div>
                    <div className="text">
                        <div className="text_content">
                            <h1 className="title">Sorveteria</h1>
                        </div>
                    </div>
                    <svg className="chevron" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 35" width="30"><path d="M5 30L50 5l45 25" fill="none" stroke="#000" strokeWidth="5" /></svg>
                </div>

                <div className="cardcategory" onClick="this.classList.toggle('expanded')">
                    <div className="icon">
                        <img src={gasstation} alt="img" width="140" height="140" />
                    </div>
                    <div className="text">
                        <div className="text_content">
                            <h1 className="title">Posto de Combustível</h1>
                        </div>
                    </div>
                    <svg className="chevron" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 35" width="30"><path d="M5 30L50 5l45 25" fill="none" stroke="#000" strokeWidth="5" /></svg>
                </div>

                <div className="cardcategory" onClick="this.classList.toggle('expanded')">
                    <div className="icon">
                        <img src={pharmacy} alt="img" width="140" height="140" />
                    </div>
                    <div className="text">
                        <div className="text_content">
                            <h1 className="title">Farmácia</h1>
                        </div>
                    </div>
                    <svg className="chevron" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 35" width="30"><path d="M5 30L50 5l45 25" fill="none" stroke="#000" strokeWidth="5" /></svg>
                </div>
            </div>
        </>
    );
}
export default Category