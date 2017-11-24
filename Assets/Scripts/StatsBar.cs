using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour {
	public Text totalLabel;
	public Text modLabel;
	public Image bar;
	public GameObject selectedBG;
	public Sprite[] barSprite;

	protected float _stats = 0f;
	protected float _mod = 0f;

	public float stats {
		get {
			return _stats;
		}
		set {
			_stats = value;
			UpdateStats ();
		}
	}
	public float mod {
		get {
			return _mod;
		}
		set {
			_mod = value;
			UpdateStats ();
		}
	}

	public bool selected {
		get {
			return selectedBG.activeSelf;
		}
		set {
			selectedBG.SetActive (value);
		}
	}

	protected void UpdateStats() {
		totalLabel.text = _stats.ToString ("000") + " / 100"; 
		modLabel.text = (_mod >= 0 ? "+" : "") + _mod.ToString ("0.0000") + "/s";
		bar.fillAmount = _stats / 100f;

		if (_stats >= 90f) {
			bar.sprite = barSprite [0];
		} else if (_stats < 20f) {
			bar.sprite = barSprite [3];
		} else if (_stats < 40f) {
			bar.sprite = barSprite [2];
		} else {
			bar.sprite = barSprite [1];
		}
	}

}
