using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsModifier : MonoBehaviour {
	public delegate void StatsModifierEvent(float[] newMods);
	public event StatsModifierEvent OnIncrease;
	public event StatsModifierEvent OnDecrease;

	public float[] mods;
	public float modInc;
	public MenuAction modGroup;
	public Text[] modLabel;

	void Awake() {
		mods = new float[5];
	}

	public void InitData(float[] _mods) {
		mods = _mods;
		modGroup.ChangeLayer (0);
		UpdateUI ();
	}

	public void IncreaseMod() {
		int idx = modGroup.selected;
		mods [idx] += modInc;
		UpdateUI ();
		if (OnIncrease != null)
			OnIncrease (mods);
	}
	public void DecreaseMod() {
		int idx = modGroup.selected;
		mods [idx] -= modInc;
		UpdateUI ();
		if (OnDecrease != null)
			OnDecrease (mods);
	}

	public void UpdateUI() {
		for (int i = 0; i < mods.Length; i++) {
			modLabel[i].text = (mods[i]>=0 ? "+" : "") + mods[i].ToString();
		}
	}
}
