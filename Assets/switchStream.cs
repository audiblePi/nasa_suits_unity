using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public struct Switch
{
	public string id;
	public bool batt_amp_high;
	public bool batt_vdc_low;
	public bool suit_pressure_low;
	public bool sop_on;
	public bool sspe; //suit pressure emergency
	public bool suit_pressure_high;
	public bool o2_use_high;
	public bool sop_pressure_low;
	public bool fan_error;
	public bool vent_error;
	public bool co2_high;
	public bool vehicle_power;
	public bool h2o_off;
	public bool o2_off;
}

public class switchStream : MonoBehaviour {
	public Switch currentSwitch;

	public SpriteRenderer BattAmpHigh;
	public SpriteRenderer BattVDCLow;
	public SpriteRenderer SuitPressLow;
	public SpriteRenderer SOPOn;
	public SpriteRenderer SpacesuitPressEm;
	public SpriteRenderer SuitPressHigh;
	public SpriteRenderer O2UseHigh;
	public SpriteRenderer SOPPressLow;
	public SpriteRenderer FanFailure;
	public SpriteRenderer NoVentFlow;
	public SpriteRenderer CO2High;
	public SpriteRenderer VehPower;
	public SpriteRenderer H2OOff;
	public SpriteRenderer O2Off;

	public bool live;
	public string serverUrl;
	public string serverLocal;
	public string switchEndpoint;

	private string url;

	void Start() {
		url = live ? serverUrl + switchEndpoint : serverLocal + switchEndpoint;
		//Debug.Log( url );

//		BattAmpHigh = GetComponent<SpriteRenderer>();
//		BattVDCLow = GetComponent<SpriteRenderer>();
//		SuitPressLow = GetComponent<SpriteRenderer>();
//		SOPOn = GetComponent<SpriteRenderer>();
//		SpacesuitPressEm = GetComponent<SpriteRenderer>();
//		SuitPressHigh = GetComponent<SpriteRenderer>();
//		O2UseHigh = GetComponent<SpriteRenderer>();
//		SOPPressLow = GetComponent<SpriteRenderer>();
//		FanFailure = GetComponent<SpriteRenderer>();
//		NoVentFlow = GetComponent<SpriteRenderer>();
//		CO2High = GetComponent<SpriteRenderer>();
//		VehPower = GetComponent<SpriteRenderer>();
//		H2OOff = GetComponent<SpriteRenderer>();
//		O2Off = GetComponent<SpriteRenderer>();

		InvokeRepeating("Request", 1.0f, 1.0f);
	}

	void Update () {
	}

	void FixedUpdate () {
	}

	void Request(){
		StartCoroutine(GetText());
	}

	IEnumerator GetText() {
		UnityWebRequest www = UnityWebRequest.Get(url);

		yield return www.Send();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			currentSwitch = JsonUtility.FromJson<Switch>(www.downloadHandler.text);
//					BattAmpHigh = GetComponent<SpriteRenderer>();
//					BattVDCLow = GetComponent<SpriteRenderer>();
//					SuitPressLow = GetComponent<SpriteRenderer>();
//					SOPOn = GetComponent<SpriteRenderer>();
//					SpacesuitPressEm = GetComponent<SpriteRenderer>();
//					SuitPressHigh = GetComponent<SpriteRenderer>();
//					O2UseHigh = GetComponent<SpriteRenderer>();
//					SOPPressLow = GetComponent<SpriteRenderer>();
//					FanFailure = GetComponent<SpriteRenderer>();
//					NoVentFlow = GetComponent<SpriteRenderer>();
//					CO2High = GetComponent<SpriteRenderer>();
//					VehPower = GetComponent<SpriteRenderer>();
//					H2OOff = GetComponent<SpriteRenderer>();
//					O2Off = GetComponent<SpriteRenderer>();

			BattAmpHigh.color = currentSwitch.batt_amp_high ? Color.red : Color.white;
			BattVDCLow.color = currentSwitch.batt_vdc_low ? Color.red : Color.white;
			SuitPressLow.color = currentSwitch.suit_pressure_low ? Color.red : Color.white;
			SOPOn.color = currentSwitch.sop_on ? Color.red : Color.white;
			SpacesuitPressEm.color = currentSwitch.sspe ? Color.red : Color.white;
			SuitPressHigh.color = currentSwitch.suit_pressure_high ? Color.red : Color.white;
			O2UseHigh.color = currentSwitch.o2_use_high ? Color.red : Color.white;
			SOPPressLow.color = currentSwitch.sop_pressure_low ? Color.red : Color.white;
			FanFailure.color = currentSwitch.fan_error ? Color.red : Color.white;
			NoVentFlow.color = currentSwitch.vent_error ? Color.red : Color.white;
			CO2High.color = currentSwitch.co2_high ? Color.red : Color.white;
			VehPower.color = currentSwitch.vehicle_power ? Color.red : Color.white;
			H2OOff.color = currentSwitch.h2o_off ? Color.red : Color.white;
			O2Off.color = currentSwitch.o2_off ? Color.red : Color.white;

		}
	}
}