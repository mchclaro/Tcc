import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet'
import './leaflet.css'

export default function Leaflet() {
  return (
    <MapContainer className="map" center={[-20.805211, -48.804648]} zoom={13} scrollWheelZoom={false}>
      <TileLayer
        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
      />
      <Marker position={[-20.805211, -48.804648]}>
        <Popup>
          A pretty CSS3 popup. <br /> Easily customizable.
        </Popup>
      </Marker>
    </MapContainer>
  );
}