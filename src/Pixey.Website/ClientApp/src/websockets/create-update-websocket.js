const signalr = require('@aspnet/signalr');

const createSocket = function() {
    let connection = new signalr.HubConnectionBuilder()
        .withUrl('/api/v1/update-hub')
        .build();

    return connection;
}

export default createSocket;