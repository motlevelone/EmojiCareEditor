using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmojiController : MonoBehaviour {

	public EmojiData data;
	public StatsUI statsUI;

	public Slider daySlider;
	public Text elapsedLabel;

	public void UpdateStatsUI(bool withInit = true) {
		for (int i = 0; i < 5; i++) {
			statsUI.statsBar [i].stats = data.stats[i];
			statsUI.statsBar [i].mod = data.mod[i];
		}
		((HealthBar)statsUI.statsBar [4]).green = data.GetGreen ();
		((HealthBar)statsUI.statsBar [4]).red = data.GetRed ();
		if (withInit)
			ResetSlider ();
	}

	void Start() {
		SetReset ();
		UpdateElapsedTime (0);
	}

	public void SetReset() {
		data.initStats [0] = 70f;
		data.initStats [1] = 70f;
		data.initStats [2] = 70f;
		data.initStats [3] = 70f;
		data.initStats [4] = 70f;
		data.SetInit ();
		data.mod [0] = -0.002f;
		data.mod [1] = -0.002f;
		data.mod [2] = -0.002f;
		data.mod [3] = -0.002f;
		data.mod [4] = -0.002f;
		UpdateStatsUI ();
	}
	public void SetFull() {
		data.initStats [0] = 100f;
		data.initStats [1] = 100f;
		data.initStats [2] = 100f;
		data.initStats [3] = 100f;
		data.initStats [4] = 100f;
		data.SetInit ();
		UpdateStatsUI ();
	}

	public void IncreaseMod() {
		int idx = statsUI.GetSelected ();
		data.mod [idx] += 0.0001f;
		if (data.mod [idx] > 0f)
			data.mod [idx] = 0f;
		UpdateStatsUI ();
		ChangeStatsByTime (0);
	}
	public void DecreaseMod() {
		int idx = statsUI.GetSelected ();
		data.mod [idx] -= 0.0001f;
		UpdateStatsUI ();
		ChangeStatsByTime (0);
	}

	public void SliderChange() {
		int updatedTime = 0;

		if (daySlider.value > 0.75f) {
			updatedTime = (int)((24 * 60 * 60) * (daySlider.value - 0.75f) * 4) + (24 * 60 * 60);
		} else if (daySlider.value > 0.5f) {
			updatedTime = (int)((24 * 60 * 60) * (daySlider.value - 0.5f) * 2) + (12 * 60 * 60);
		} else {
			updatedTime = (int)((24 * 60 * 60) * daySlider.value);
		}

		ChangeStatsByTime (updatedTime);
	}

	void UpdateElapsedTime(int elapsed) {
		int days = elapsed / (24 * 60 * 60);
		int hours = (elapsed - (days*(24 * 60 * 60))) / (60 * 60);
		int mins = (elapsed - (days*(24 * 60 * 60)) - (hours*(60 * 60))) / 60;
		elapsedLabel.text = "ELAPSED TIME: " + days.ToString ("00")+ "d " + hours.ToString ("00")+ "h " + mins.ToString ("00")+ "m ";
	}

	void ChangeStatsByTime(int secs) {
		data.TickStats (secs);
		UpdateStatsUI (false);
		UpdateElapsedTime (secs);
	}

	public void ResetSlider() {
		daySlider.value = 0;
	}
}
