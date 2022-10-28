import e from '../../assets/e.jpg'
import p from '../../assets/p.png'
import "./events.css";

function Events() {
    return (
        <>
            <div className="cards_list">
                <div className="card">
                    <div className="card_image">
                        <img src={e} alt="images" />
                    </div>
                    <div className="card_title">
                        <p>Card Title</p>
                    </div>
                </div>

                <div className="card">
                    <div className="card_image">
                        <img src={p} alt="images" />
                    </div>
                    <div className="card_title">
                        <p>Card Title</p>
                    </div>
                </div>

                <div className="card">
                    <div className="card_image">
                        <img src={e} alt="images" />
                    </div>
                    <div className="card_title">
                        <p>Card Title</p>
                    </div>
                </div>

                <div className="card">
                    <div className="card_image">
                        <img src={e} alt="images" />
                    </div>
                    <div className="card_title">
                        <p>Card Title</p>
                    </div>
                </div>

            </div>


        </>
    );
}
export default Events