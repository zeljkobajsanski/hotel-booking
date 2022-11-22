const express = require('express');
const { v4: uuidv4 } = require('uuid');
const _ = require('lodash')
const app = express();

const rooms = [
    {Id: uuidv4(), Name: "Basel Marriott HotelOpens in new window", Description: "All spacious rooms and suites feature air-conditioning, an LCD satellite TV, and tea and coffee making facilities. A scrumptious breakfast is served daily at the property.", Image: "assets/images/room-1.png", Price: 207},
    {Id: uuidv4(), Name: "AVLiving City LOFT BaselOpens in new window", Description: "AVLiving City Loft Basel is located in the centre of Basel, 200 metres from Kunstmuseum Basel and 400 metres from the Architectural Museum. Free WiFi is offered.", Image: "assets/images/room-2.png", Price: 164},
    {Id: uuidv4(), Name: "Hotel Basel - Da wohnen, wo Basel lebt!", Description: "Only a few steps away from the town hall and many sights and museums, this hotel offers a quiet location in the centre of the picturesque old town of Basel.", Image: "assets/images/room-3.png", Price: 148},
    {Id: uuidv4(), Name: "Hotel D - Design HotelOpens in new window", Description: "This eco-friendly 4-star boutique and design hotel is located in the heart of Basel. The stylish rooms all feature modern amenities such as iPod docking stations. Free Wi-Fi is available.", Image: "assets/images/room-4.png", Price: 53},
    {Id: uuidv4(), Name: "Hotel Euler BaselOpens in new window", Description: "Situated in a historic building in central Basel, Euler Hotel is opposite the SBB Train Station. Guests receive a Mobility Ticket, granting free access to all means of public transport.", Image: "assets/images/room-5.png", Price: 93},
    {Id: uuidv4(), Name: "HSorell Hotel Merian", Description: "The Sorell Hotel Merian is situated right on the river Rhine, in the heart of Basel, offering you charming rooms with a Nespresso coffee machine.", Image: "assets/images/room-6.png", Price: 103},
    {Id: uuidv4(), Name: "GOOD NIGHT Apartments", Description: "Situated 3.6 km from Basel Cathedral, GOOD NIGHT Apartments offers a garden, a terrace and accommodation with a balcony and free WiFi.", Image: "assets/images/room-7.png", Price: 167},
    {Id: uuidv4(), Name: "Pullman Basel Europe", Description: "The Pullman Basel Europe, the first Pullman hotel in Switzerland, is located only 500 metres from the heart of the city and 200 meters from the Messe Basel Congress and Exhibition Centre.", Image: "assets/images/room-8.png", Price: 140},
];

app.get('/api/rooms', (req, res) => {
   return res.send(_.take(rooms, 3));
});

app.post('/api/rooms', (req, res) => {
    const getRandomNumber = () => _.random(rooms.length - 1);
    const found = _.range(0, getRandomNumber()).map(i => rooms[getRandomNumber()]);
    return res.send(found);
})

app.get('/api/rooms/:id', (req, res) => {
    const room = rooms.find(x => x.Id == req.params.id);
    return res.send(room);
})

app.get('/api/check-availability', (req, res) => res.send(true));

app.listen(5102, () => console.log('Room service is running...'));
