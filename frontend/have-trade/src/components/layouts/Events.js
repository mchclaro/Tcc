import noticia1 from '../../assets/processoNoticias.jpg'
import noticia2 from '../../assets/processoNoticiasFinal.jpg'
import noticia3 from '../../assets/rainhaRodeio.jpg'
import noticia4 from '../../assets/queimadaCrime.jpg'
import "./events.css";

function Events() {
    return (
        <>
            <div className="cards_list">
                <div className="card">
                    <div className="card_image">
                    <a href="https://www.severinia.sp.gov.br/noticia/atualizacao-no-processo-seletivo-04-2022-confira-/54280">  <img src={noticia1} alt="images" /> </a>
                    </div>
                    <div className="card_title">
                        <p>Atualização no Processo Seletivo 04 / 2022, confira!</p>
                    </div>
                </div>

                <div className="card">
                    <div className="card_image">
                    <a href="https://www.severinia.sp.gov.br/noticia/processo-seletivo-03-2022-edital-de-classificacao-final/54276"> <img src={noticia2} alt="images" /> </a>
                    </div>
                    <div className="card_title">
                        <p>Processo Seletivo 04/2022 - Edital de Classificação Final</p>
                    </div>
                </div>

                <div className="card">
                    <div className="card_image">
                    <a href="https://www.severinia.sp.gov.br/noticia/rainha-do-rodeio-de-severinia/54272"><img src={noticia3} alt="images" />  </a>
                    </div>
                    <div className="card_title">
                        <p>Rainha do Rodeio de Severínia</p>
                    </div>
                </div>

                <div className="card">
                    <div className="card_image">
                       <a hred="https://www.severinia.sp.gov.br/noticia/atencao-queimada-e-crime-/54264" > <img src={noticia4} alt="images" /> </a>
                    </div>
                    <div className="card_title">
                        <p>ATENÇÃO: Queimada é crime!</p>
                    </div>
                </div>
            </div>
        </>
    );
}
export default Events