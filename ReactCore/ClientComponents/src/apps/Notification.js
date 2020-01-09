import React, {useState, useEffect} from 'react';
import PropTypes from 'prop-types';
import {HubConnectionBuilder} from "@microsoft/signalr";


function Notification(props) {
    const hubConn = new HubConnectionBuilder()
        .withUrl("/notificationHub")
        .withAutomaticReconnect()
        .build();
    const [message, setMessage] = useState(null);


    const subscribe = (name) => {
        hubConn.invoke("Subscribe", name).catch(function(err) {
            setMessage(hubConn.state + " " + err.toString());
            return console.error('Subscribe', err.toString());
        });
    };
    /*
    invoke: GetWeather
    events: WeatherError(err), WeatherReceive(data)

    */
    // signalR events
    hubConn.on("SubscriberAdded", function (name) {
        setMessage(name);
        console.log('SubscriberAdded', name);
    });


    hubConn.onclose((err) => {
        // console.assert(connection.state === signalR.HubConnectionState.Disconnected);

        setMessage( `Connection closed due to error "${err}". Try refreshing this page to restart the connection.`);
        if(err) {
            console.error('onclose', err.toString());
        }
        // console.log('onclose');
    });
    hubConn.onreconnecting((err) => {
        // console.assert(connection.state === signalR.HubConnectionState.Reconnecting);
        setMessage(`Connection lost due to error "${err}". Reconnecting.`);
        if(err) {
            console.error('onreconnecting', err.toString());
        }
        // console.log('onreconnecting');
    });
    hubConn.onreconnected((connectionId) => {
        // console.assert(connection.state === signalR.HubConnectionState.Connected);
        setMessage(`Connection reestablished. Connected with connectionId "${connectionId}".`);
        console.error('onreconnected', connectionId);
        console.log('onreconnected');
    });
    // signalR connection
    const connectHub = () => {
        console.log('connecting...', hubConn);
        hubConn.start().then(function() {
            console.log('started hub connection...');
            setMessage(hubConn.state);
            subscribe("ReactCore");
        })
        .catch(function (err) {
            setMessage(hubConn.state + " " + err.toString());
            return console.error('connectHub', err.toString());
        });
    };
    useEffect(() => {
        connectHub();
      },[]);
    return (
        <div className="alert alert-primary" role="alert">
            <strong>{props.name}</strong>: {message}
        </div>
    )
}
Notification.propTypes = {
    name: PropTypes.string.isRequired,
  };

export default Notification;

/*
connection.start().then(function(){
    document.getElementById("sendButton").disabled = false;
    document.getElementById("clearButton").disabled = false;
    document.getElementById("subscribeButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
connection.on("TodoAdded", function (todo) {
    appendTodo(todo);
});
    connection.invoke("Subscribe", subId ).catch(function(err) {
        return console.error(err.toString());
    });
*/