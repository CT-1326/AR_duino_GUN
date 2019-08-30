﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidWrapper : MonoBehaviour {

	private AndroidJavaObject androidJavaObject = null;
	public Text message;

	private AndroidJavaObject GetAndroidJavaObject() {
		if(androidJavaObject == null) {
			androidJavaObject = new AndroidJavaObject("com.plugin.bluetooth.BluetoothControl");
		}
		return androidJavaObject;
	}

	// Use this for initialization
	void Start () {
		// Retrieve current Android Activity from the Unity Player
        AndroidJavaClass jclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = jclass.GetStatic<AndroidJavaObject>("currentActivity");
		
		this.androidJavaObject = GetAndroidJavaObject();
		this.androidJavaObject.Call("setActivity", activity);

		this.message.text = this.androidJavaObject.Call<string>("init");

		if(this.message.text == "initialized") {
			if(this.androidJavaObject.Call<bool>("getDeviceBluetoothState")) {
				this.message.text = "Bluetooth not turned on";
			}
			else {
				this.message.text = "Bluetooth already turned on";
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}