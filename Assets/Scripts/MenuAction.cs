using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAction : MonoBehaviour {
	public delegate void MenuActionEvent();
	public event MenuActionEvent OnChanged;

	public GameObject[] layer; 
	public Image[] buttons; 
	public Color selectedColor;
	public Color unselectedColor = Color.white;
	public int selected;

	void Start() {
		ChangeLayer (0);
	}

	public void ChangeLayer(int idx) {
		for (int i = 0; i < buttons.Length; i++) {
			layer [i].SetActive (false);
			buttons [i].color = unselectedColor;
		}
		layer [idx].SetActive (true);
		buttons [idx].color = selectedColor;
		selected = idx;
		if (OnChanged != null)
			OnChanged ();
	}

}
