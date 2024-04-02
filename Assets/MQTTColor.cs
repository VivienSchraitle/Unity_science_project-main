using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System;

public class MQTTColor : MonoBehaviour
{
    private MqttClient client;
    public Controller cont;
    public string RawData;
    public string RawData2;
    public string rula;
    public string reba;

    void Start()
    {
        try
        {
            // Create client instance
            client = new MqttClient("broker.hivemq.com", 1883, false, null);

            // Register to message received event
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            // Generate client ID
            string clientId = Guid.NewGuid().ToString();

            // Connect to the broker
            client.Connect(clientId);

            if (client.IsConnected)
            {
                Debug.Log("Connected to MQTT broker");

                // Subscribe to the desired topics
                SubscribeToTopic("mqtt-color");
                //SubscribeToTopic("mqtt-color-unity");
                //SubscribeToTopic("mqtt-color-unity2");
                SubscribeToTopic("mqtt-reba-unity");
                SubscribeToTopic("mqtt-rula-unity");
            }
            else
            {
                Debug.LogError("Failed to connect to MQTT broker");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error connecting to MQTT broker: " + ex.Message);
        }
    }

    void SubscribeToTopic(string topic)
    {
        try
        {
            client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
           // Debug.Log("Subscribed to topic: " + topic);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error subscribing to topic " + topic + ": " + ex.Message);
        }
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        try
        {
            // Process message based on topic
            if (e.Topic == "mqtt-color")
            {
                RawData = System.Text.Encoding.UTF8.GetString(e.Message).Substring(1, e.Message.Length - 2);

                // Process data for mqtt-color-unity
            }
         /*   else if (e.Topic == "mqtt-color-unity2")
            {
                RawData2 = System.Text.Encoding.UTF8.GetString(e.Message).Substring(1, e.Message.Length - 2);
                Debug.Log("data 2 " + RawData2.ToString());
                Debug.Log("Received data for mqtt-color-unity2");
                // Process data for mqtt-color-unity
            }*/
            else if (e.Topic == "mqtt-reba-unity")
            {
                reba = System.Text.Encoding.UTF8.GetString(e.Message);
                // Process data for mqtt-reba-unity
            }
            else if (e.Topic == "mqtt-rula-unity")
            {
                rula = System.Text.Encoding.UTF8.GetString(e.Message);
                // Process data for mqtt-rula-unity
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error processing MQTT message: " + ex.Message);
        }
    }

    void Update()
    {
       
    }
}
