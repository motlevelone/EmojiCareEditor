using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUI : MonoBehaviour {

	public StatsBar[] statsBar;
	int selectedIdx = 0;

	void Start() {
		ClickSelection (0);
	}

	public void ClickSelection(int idx) {
		for (int i = 0; i < statsBar.Length; i++) {
			statsBar [i].selected = false;
		}
		statsBar [idx].selected = true;
		selectedIdx = idx;
	}

	public int GetSelected() {
		return selectedIdx;
	}

}
