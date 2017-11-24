using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookAction : BaseAction {
	protected override void ModChanged(float[] newMod) {
		manager.data.cookingMod = newMod;
	}

	protected override void ItemChanged() {
		statsModifier.InitData (manager.data.cookingMod);
	}

	protected new void OnEnable() {
		statsModifier.InitData (manager.data.cookingMod);
	}


	//MAIN ACTION
	public void Cook() {
		for (int i = 0; i < 5; i++) {
			manager.data.stats [i] += manager.data.cookingMod [i];
		}
		manager.UpdateStatsUI ();
	}
}
