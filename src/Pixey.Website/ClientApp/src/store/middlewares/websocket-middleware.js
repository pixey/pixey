import createWebsocket from '../../websockets/create-update-websocket';

import { actionCreators as troubleshootingActionCreators } from '../../components/troubleshooting/troubleshooting-store';

const createMiddleware = () => {
    return storeAPI => {
        let websocket = createWebsocket();

        websocket.on("UpdateTroubleshootingStatus", (message) => {
            console.log("Troubleshooter status: " + message);

            let action = troubleshootingActionCreators.updateStatus(message);

            storeAPI.dispatch(action);
        });

        websocket.start();

        return next => action => {
            if(action.type === "DIAGNOSTICS_START") {
                console.log("Sending message to server");

                websocket.send(action.payload);
                return;
            }

            return next(action);
        }
    }
}

export default createMiddleware;