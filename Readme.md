## wasm-frontend-backend
This is a POC project aimed at demonstrating how WASM can allow code sharing between a Frontend browser-consumed application and a backend microservice.

<img src="https://i.imgur.com/NktzMGj.png" />


### Backend
The backend microservice is a Console App packed with Wasi.Sdk and running inside Wagi, exposing the service on the port 3000.

Run it with:
`make run-backend`

### Frontend
The frontend app is a Vanilla JS application running in the browser, using a WASM module which exposes a couple of methods consuming a shared AwesomeService.

Run it with:
`make run-frontend`

---

#### WAGI version
In order to run, the project needs WAGI. 

You can the version that suits your OS here and put the executable file in the WFB.Backend folder (or add it to your system PATH):
https://github.com/deislabs/wagi/releases
