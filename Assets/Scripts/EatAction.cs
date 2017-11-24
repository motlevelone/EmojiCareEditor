using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodItem {
	Caesar_Salad,
	Ramen,
	Burger,
	Grilled_Fish,
	Pizza,
	Sundubu,
	Chicken_Fries,
	Baked_Potato,
	Skewer,
	Steak
}

public class EatAction : BaseAction {
	protected override void ModChanged(float[] newMod) {
		manager.data.eatMod [itemSelect.selected] = newMod;
	}

	protected override void ItemChanged() {
		statsModifier.InitData (manager.data.eatMod [itemSelect.selected]);
	}

	protected new void OnEnable() {
		statsModifier.InitData (manager.data.eatMod [itemSelect.selected]);
	}


	//MAIN ACTION
	public void Eat() {
		for (int i = 0; i < 5; i++) {
			manager.data.stats [i] += manager.data.eatMod [itemSelect.selected] [i];
		}
		manager.UpdateStatsUI ();
	}
}
