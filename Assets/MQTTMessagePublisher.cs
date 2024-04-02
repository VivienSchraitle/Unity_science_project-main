using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using System;

public class MQTTMessagePublisher : MonoBehaviour
{
    private MqttClient client;
    private string message = "5";

    // Start is called before the first frame update
    void Start()
    {
        // Create client instance
        client = new MqttClient("broker.hivemq.com", 1883, false, null);

        // Connect to the broker
        string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId);

        // Check if connected
        if (client.IsConnected)
        {
            Debug.Log("Connected to MQTT broker");

            // Publish message to the topic "mqtt-reba-unity"
            client.Publish("mqtt-reba-unity", System.Text.Encoding.UTF8.GetBytes(message), 
                           uPLibrary.Networking.M2Mqtt.Messages.MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Debug.Log("Message published to mqtt-reba-unity: " + message);

            // Disconnect from the broker
            client.Disconnect();
        }
        else
        {
            Debug.LogError("Failed to connect to MQTT broker");
        }
    }
}
