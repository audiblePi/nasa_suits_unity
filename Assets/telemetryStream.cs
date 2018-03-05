using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public struct Telemetry
{
	public string id;
	public string p_suit; //internal suit pressure
	public string t_batt; //time life battery
	public string t_o2; // time life oxygen
	public string t_h2o; // time life water
	public string p_sub; // external environment pressure
	public string t_sub; // external environment temperature
	public string v_fan; // speed of cooling fan
	public string t_eva; // eva time
	public string p_o2; // oxygen presure
	public string rate_o2; // oxygen rate
	public string cap_battery; // battery capacity
	public string p_h2o_g; // h2o gas pressure
	public string p_h2o_l; // h2o liquid pressure
	public string p_sop; // sop pressure
	public string rate_sop; // sop rate
}

public class telemetryStream : MonoBehaviour {
	public Telemetry currentTelemetry;

	public Text timeLifeOxygen;
	public Text timeLifeBattery;
	public Text timeLifeWater;
	public Text internalSuitPressure;
	public Text subPressure;
	public Text evaTime;
	public Text subTemp;
	public Text fanSpeed;
	public Text oxyPress;
	public Text oxyRate;
	public Text battCap;
	public Text h20GasPressure;
	public Text h20LiqPress;
	public Text sopPress;
	public Text sopRate;

	void Start() {
		StartCoroutine(GetText());
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine(GetText());
	}

	IEnumerator GetText() {
		UnityWebRequest www = UnityWebRequest.Get("http://localhost:3000/api/telemetry/recent");
		yield return www.Send();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			// Show results as text
			//Debug.Log(www.downloadHandler.text);

			currentTelemetry = JsonUtility.FromJson<Telemetry>(www.downloadHandler.text);

			timeLifeOxygen.text = currentTelemetry.t_o2;
			timeLifeBattery.text = currentTelemetry.t_batt;
			timeLifeWater.text = currentTelemetry.t_h2o;
			internalSuitPressure.text = currentTelemetry.p_suit;
			subPressure.text = currentTelemetry.p_sub;
			evaTime.text = currentTelemetry.t_eva;

			subTemp.text = currentTelemetry.t_sub;
			fanSpeed.text = currentTelemetry.v_fan;
			oxyPress.text = currentTelemetry.p_o2;
			oxyRate.text = currentTelemetry.rate_o2;
			battCap.text = currentTelemetry.cap_battery;
			h20GasPressure.text = currentTelemetry.p_h2o_g;
			h20LiqPress.text = currentTelemetry.p_h2o_l;
			sopPress.text = currentTelemetry.p_sop;
			sopRate.text = currentTelemetry.rate_sop;

			//Debug.Log( Math.Truncate(100 * currentTelemetry.rate_o2) / 100);

		}
	}
}