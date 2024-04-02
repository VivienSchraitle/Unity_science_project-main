using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;

using System;
using System.Globalization;

public class mqttTest : MonoBehaviour {

	//public string brokerIpAddress = "m21.cloudmqtt.com";
	public string brokerIpAddress = "127.0.0.1";
	
	public int brokerPort = 1885;
//	public int brokerPort = 19637;
	public string username = "";
	public  string password = "";
	
	//public string username = "nzzqveez";
	//public  string password = "1iXH9SM1qr1t";
	public string topic_MPU9250 = "/Sensor/MPU9250";
	public string topic_MPU6886 = "/Sensor/MPU6886";


	public Vector3 AHRS_MPU9250;
	public Vector3 AHRS_MPU6886;

	public float[] AHRS_Array_MPU9250; 	
	
	float pitch_IMU1, roll_IMU1, yaw_IMU1;
	float extra = 0.2f;
	public float[] AHRS_Array_MPU6886; 	
	float pitch_IMU2, roll_IMU2, yaw_IMU2;	




	private MqttClient client;
	// Use this for initialization
	void Start () {
		// create client instance 
		//client = new MqttClient(IPAddress.Parse("143.185.118.233"),8080 , false , null ); 
	client = new MqttClient(brokerIpAddress, brokerPort , false , null ); 
		//client = new MqttClient( brokerIpAddress,  brokerPort, bool secure, X509Certificate caCert)
		
		// register to message received 
		
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
		
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId, username, password); 
		
		client.Subscribe(new string[] { topic_MPU9250, topic_MPU6886}, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE}); 

		// subscribe to the topic of IMU MPU9250 with QoS 2 
		//client.Subscribe(new string[] { topic_MPU9250}, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE}); 
		// subscribe to the topic of IMU MPU6886  with QoS 2 
		//client.Subscribe(new string[] { topic_MPU6886}, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE}); 
		
	}
	void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
						//Debug.Log(e.Message);
	
		string  AHRS = System.Text.Encoding.UTF8.GetString(e.Message);
		
		switch (e.Topic)
        {
			case "/Sensor/MPU9250":
			//Debug.Log(e.Topic + " : " + AHRS);
			Debug.Log(e.Message);
			string[] str1 = AHRS.Split(';');

			AHRS_Array_MPU9250 = new float[str1.Length];	

			for(int i = 0; i < str1.Length; i++)
		
				{ //Debug.Log("i: " + i + " Parsing: >"+str[i]+"< ("+str[i].Length+")");
					AHRS_Array_MPU9250[i] = float.Parse(str1[i], System.Globalization.CultureInfo.InvariantCulture);
				// Debug.Log(str[i]);
				}		

				pitch_IMU1 = AHRS_Array_MPU9250[0];
				roll_IMU1  = AHRS_Array_MPU9250[2];
				yaw_IMU1   = AHRS_Array_MPU9250[1];

		//	Debug.Log("pitch1:"+ " "+ pitch_IMU1 + " "+ "roll1:"+ " "+ roll_IMU1 + " "+ "yaw1:"+ " "+ yaw_IMU1);	
			break;

			case "/Sensor/MPU6886":
			string  AHRS2 = System.Text.Encoding.UTF8.GetString(e.Message);
			Debug.Log(e.Message);
			//Debug.Log(e.Topic + " : " + AHRS2);
			string[] str2 = AHRS2.Split(';');
		
		   AHRS_Array_MPU6886 = new float[str2.Length];	
		

			for(int i = 0; i < str2.Length; i++)
	
            { //Debug.Log("i: " + i + " Parsing: >"+str[i]+"< ("+str[i].Length+")");
				AHRS_Array_MPU6886[i] = float.Parse(str2[i], System.Globalization.CultureInfo.InvariantCulture);
               // Debug.Log(str[i]);
			}		

		 	 pitch_IMU2 = AHRS_Array_MPU6886[0];
			 roll_IMU2 = AHRS_Array_MPU6886[2];
			 yaw_IMU2   = AHRS_Array_MPU6886[1];
			
		//	Debug.Log("pitch2:"+ " "+ pitch_IMU2 + " "+ "roll2:"+ " "+ roll_IMU2 + " "+ "yaw2:"+ " "+ yaw_IMU2);	
		

			break;

		}
		
		
	}
		/*	 pitch2 = AHRS_Array[3];
			 roll2  = AHRS_Array[4];
			 yaw2   = AHRS_Array[5];

			Debug.Log("pitch2:"+ " "+ pitch2+ " "+ "roll2:"+ " "+ roll2+ " "+ "yaw2:"+ " "+ yaw2);	

*/
			
			//	Debug.Log(Quatarray[1]);	
			//	Debug.Log(Quatarray[2]);		
			//	Debug.Log(Quatarray[3]);

			//	Debug.Log(Quatarray[0]);	
			//	Debug.Log(Quatarray[1]);	
			//	Debug.Log(Quatarray[2]);		
			//	Debug.Log(Quatarray[3]);

			
			
			

			
/*

		var  Quat = System.Text.Encoding.UTF8.GetString(e.Message);
		
		Quatarray = Array.ConvertAll(Quat.Split(','), float.Parse);
		
		QuatIMU1 =new Quaternion (Quatarray[1],Quatarray[2],Quatarray[3],Quatarray[0]);
		QuatIMU2 =new Quaternion (Quatarray[5],Quatarray[6],Quatarray[7],Quatarray[4]);
		
		//Debug.Log(QuatIMU1);

		Debug.Log(Quatarray[0]);
		Debug.Log(Quatarray[1]);
		Debug.Log(Quatarray[2]); 
		Debug.Log(Quatarray[3]);
		Debug.Log(Quatarray[4]);
		Debug.Log(Quatarray[5]); 
		Debug.Log(Quatarray[6]); 
		Debug.Log(Quatarray[7]); */




	 

	void OnGUI(){
		if ( GUI.Button (new Rect (20,40,80,20), "Message")) {
			Debug.Log("sending...");
			client.Publish("Unity/send", System.Text.Encoding.UTF8.GetBytes("Sending from Unity3D!!!"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
		}
	}
	// Update is called once per frame
	void Update () {

//			IMU1.transform.rotation = new Quaternion(Quatarray[1],Quatarray[2],Quatarray[3],Quatarray[0]);
			//	IMU2.rotate = new Quaternion(Quatarray[5],Quatarray[6],Quatarray[7],Quatarray[4]);
			//IMU2.transform.rotation = new Quaternion(0.87497f, -0.14171f, -0.45028f, -0.107673f);
 			AHRS_MPU9250 =new Vector3 (pitch_IMU1,roll_IMU1,yaw_IMU1);
		//	QuatIMU1 =new Quaternion (q1w,-q1x,q1y,q1z);
			AHRS_MPU6886 =new Vector3 (pitch_IMU2,roll_IMU2,yaw_IMU2);
		//	AHRS2 =new Vector3 (pitch2,roll2,yaw2);
			//QuatIMU2 = new Quaternion(-0.14171f, -0.45028f, -0.107673f,0.87497f);
 


	}
}
