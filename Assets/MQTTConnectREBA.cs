using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System;
using System.Globalization;

public class MQTTConnectREBA : MonoBehaviour
{
    /*
    [Header("MQTT Configuration")]
    public string BrokerAddress = "broker.hivemq.com";
    public int BrokerPort = 1883;
	public string username = "";
	public string password = "";
    public string Topic_Angle = "mqtt-reba";
    */

    

    private MqttClient client;
    private float nextActionTime = 0.0f;
    public float period = 1f;



    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
        // create client instance 
        client = new MqttClient("broker.hivemq.com", 1883, false, null);

        // register to message received 
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

        string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId, "", "");

        // subscribe to the topic "/home/temperature" with QoS 2 
        client.Subscribe(new string[] { "mqtt-reba" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

    }
    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {

        Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
    }

    // Update is called once per frame
    void Update()
    {



    }
}
