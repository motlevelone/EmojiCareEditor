using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseAction : MonoBehaviour {
	public EmojiController manager;
	public StatsModifier statsModifier;
	public MenuAction itemSelect;

	void Start() {
		statsModifier.OnIncrease += ModChanged;
		statsModifier.OnDecrease += ModChanged;
		itemSelect.OnChanged += ItemChanged;
	}

	protected virtual void ModChanged(float[] newMod) {
	}

	protected virtual void ItemChanged() {
	}
		
	protected void OnEnable() {
	}

	void OnDestroy() {
		statsModifier.OnIncrease -= ModChanged;
		statsModifier.OnDecrease -= ModChanged;
		itemSelect.OnChanged -= ItemChanged;
	}
}
