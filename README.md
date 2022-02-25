# BB8 Movement Exercise
A small obstacle game as a game development exercise. 

![BB8 Game](https://user-images.githubusercontent.com/40600576/155817143-7ec27712-d785-407d-9dc4-d82682449bae.png)

## About the game
- You play a the BB8 character from Starwars.
- You have evade obstacles (only walls until now) to reach the Millenium Falcon.
- Unfinished content:
  - Lasers and enemies to evade.

## Game features
- Smartphone controls using gyroscope data sent over UDP with the ZigZim app.
- Stereoskopic 3D render option (this game was developed to be demonstrated in the UBIC 3D theater of the University of Aizu, Japan)

## Technical details
- Unity version:
  - 2018.3.14f1

- Required tools:
  - ZigZim app settings:
    - Sensor data: Accel(erator), Quaternion(calculated)
    - Protocol: UDP
    - IP adress: [IP adress of your network]
    - Port number: [A port number to communicate over, e.g. 42002]
    - Message format: JSON
    - Message rate: 30
    - Compass angle: Faceup
  - Local network to send data over UDP, e.g. mobile hotspot

- Game repository
  - Assets/
    - **BB8Game/**
    - Plugins/
      - [Third-party/Unity assets]/
      - ...
