using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : StatsBar {

	public Text greenLabel;
	public Text redLabel;
	protected int _red = 0;
	protected int _green = 0;

	public int red {
		get {
			return _red;
		}
		set {
			_red = value;
			UpdateStats ();
		}
	}
	public int green {
		get {
			return _green;
		}
		set {
			_green = value;
			UpdateStats ();
		}
	}

	new protected void UpdateStats() {
		base.UpdateStats ();

		float multiplier = _green>1 ? _green-1 : (_green==1 ? 0.5f : 0f);
		multiplier -= _red > 1 ? (_red - 1) : 0;

		float modMultiplied = _mod * -multiplier;
		modLabel.text = (modMultiplied >= 0 ? "+" : "") + modMultiplied.ToString ("0.0000") + "/s ";
		modLabel.text += "(Base: " + (_mod >= 0 ? "+" : "") + _mod.ToString ("0.0000") + "/s)";
		greenLabel.text = _green.ToString("N0") + " Green";
		redLabel.text = _red.ToString("N0") + " Red";
	}

}
