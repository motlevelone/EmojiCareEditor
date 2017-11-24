using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataAction : MonoBehaviour {
	public EmojiController manager;
	public Text notif;
	public Text emailTo;
	int slot = 0;

	public void ChangeSlot(int _slot) {
		slot = _slot;
	}

	public void Saved() {
		for (int i=0;i<5;i++) {
			PlayerPrefs.SetFloat ("Save"+slot+"Stats"+i,manager.data.initStats[i]);
			PlayerPrefs.SetFloat ("Save"+slot+"Mod"+i,manager.data.mod[i]);
			for (int j = 0; j < 10; j++) {
				PlayerPrefs.SetFloat ("Save"+slot+"Food"+j+"Mod"+i,manager.data.eatMod[j][i]);
			}
			PlayerPrefs.SetFloat ("Save"+slot+"CookMod"+i,manager.data.cookingMod [i]);
		}
		StopAllCoroutines ();
		notif.text = "DATA SAVED";
		StartCoroutine (AnimateNotif ());
	}
	public void Load() {
		for (int i=0;i<5;i++) {
			manager.data.initStats[i] = PlayerPrefs.GetFloat ("Save"+slot+"Stats"+i,70f);
			manager.data.SetInit ();
			manager.data.mod[i] = PlayerPrefs.GetFloat ("Save"+slot+"Mod"+i,0.002f);
			for (int j = 0; j < 10; j++) {
				manager.data.eatMod[j][i] = PlayerPrefs.GetFloat ("Save"+slot+"Food"+j+"Mod"+i,0f);
			}
			manager.data.cookingMod[i] = PlayerPrefs.GetFloat ("Save"+slot+"CookMod"+i,0f);
		}
		manager.UpdateStatsUI ();
		StopAllCoroutines ();
		notif.text = "DATA LOADED";
		StartCoroutine (AnimateNotif ());
	}

	IEnumerator AnimateNotif() {
		float curA = 1f;
		notif.color = new Color (1f,0f,0f,curA);
		notif.gameObject.SetActive (true);
		while (curA > 0f) {
			curA -= (Time.deltaTime / 1f);
			notif.color = new Color (1f,0f,0f,curA);
			yield return null;
		}
		notif.gameObject.SetActive (false);
	}


	public void SendMail() {
		string email = emailTo.text;
		string subject = MyEscapeURL("EMOJICARE Data");
		string bodyTemp = "STATS MODIFIER:\n\n";
		for (int i = 0; i < manager.data.mod.Length; i++) {
			bodyTemp += ((StatsData)i).ToString () + " Mod: " + (manager.data.mod [i]>=0 ? "+" : "" ) + manager.data.mod [i] + "\n";
		}
		bodyTemp += "\n\n\nFOOD MODIFIER:\n\n";
		for (int i = 0; i < manager.data.eatMod.Length; i++) {
			bodyTemp += ((FoodItem) i ).ToString() +  "Effect:\n";
			for (int j = 0; j < 5; j++) {
				bodyTemp += ((StatsData)i).ToString () + ": " + (manager.data.eatMod [i][j]>=0 ? "+" : "" ) + manager.data.eatMod [i][j] + "\n";
			}
			bodyTemp += "\n";
		}
		bodyTemp += "\nCOOKING MODIFIER:\n\n";
		for (int i = 0; i < manager.data.mod.Length; i++) {
			bodyTemp += ((StatsData)i).ToString () + ": " + (manager.data.cookingMod [i]>=0 ? "+" : "" ) + manager.data.cookingMod [i] + "\n";
		}
		bodyTemp += "________";
		string body = MyEscapeURL(bodyTemp);
		//Open the Default Mail App
		Application.OpenURL ("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}
	string MyEscapeURL (string url) 
	{
		return WWW.EscapeURL(url).Replace("+","%20");
	}

}
