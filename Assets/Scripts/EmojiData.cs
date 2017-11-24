using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsData {
	Hunger,
	Hygiene,
	Happiness,
	Stamina,
	Health
}


public class EmojiData : MonoBehaviour {
	public float[] initStats;
	public float[] stats;
	public float[] mod;

	public float[][] eatMod;
	public float[] cookingMod;
	Dictionary<float,int> healthSecs;
	Dictionary<float,float> healthInit;

	void Awake() {
		healthSecs = new Dictionary<float,int> ();
		healthSecs.Add(-3f,-1);
		healthSecs.Add(-2f,-1);
		healthSecs.Add(-1f,-1);
		healthSecs.Add(-0.5f,-1);
		healthSecs.Add(0f,-1);
		healthSecs.Add(1f,-1);
		healthSecs.Add(2f,-1);
		healthSecs.Add(3f,-1);
		healthInit = new Dictionary<float,float> ();
		healthInit.Add(-3f,0f);
		healthInit.Add(-2f,0f);
		healthInit.Add(-1f,0f);
		healthInit.Add(-0.5f,0f);
		healthInit.Add(0f,0f);
		healthInit.Add(1f,0f);
		healthInit.Add(2f,0f);
		healthInit.Add(3f,0f);
		eatMod = new float[10][];
		for (int i = 0; i < eatMod.Length; i++) {
			eatMod [i] = new float[5];
		}
		cookingMod = new float[5];
	}

	public void TickStats(int secs) {
		for (int i = 0; i < 4; i++) {
			stats [i] = initStats[i] + (mod[i] * secs);
			if (stats [i] > 100f)
				stats [i] = 100f;
			if (stats [i] < 0f)
				stats [i] = 0f;
		}
		float healthMultiplier = HealthMultiplier();	
		float healthMod = mod [4] * healthMultiplier;
		if (healthSecs [healthMultiplier] < 0f) {
			healthSecs [healthMultiplier] = secs;
			healthInit [healthMultiplier] = stats [4];
		}
		int diff = secs - healthSecs [healthMultiplier];
		stats [4] = healthInit [healthMultiplier] + (healthMod * diff);
		if (stats [4] > 100f)
			stats [4] = 100f;
		if (stats [4] < 0f)
			stats [4] = 0f;

	}
	public void SetInit() {
		for (int i = 0; i < 5; i++) {
			stats[i] = initStats [i];
		}
		healthSecs [-3f] = -1;
		healthSecs [-2f] = -1;
		healthSecs [-1f] = -1;
		healthSecs [0f] = -1;
		healthSecs [0.5f] = -1;
		healthSecs [1f] = -1;
		healthSecs [2f] = -1;
		healthSecs [3f] = -1;
		healthInit [-3f] = initStats[4];
		healthInit [-2f] = initStats[4];
		healthInit [-1f] = initStats[4];
		healthInit [0f] = initStats[4];
		healthInit [0.5f] = initStats[4];
		healthInit [1f] = initStats[4];
		healthInit [2f] = initStats[4];
		healthInit [3f] = initStats[4];
	}

	public int GetGreen() {
		int result = 0;
		for (int i = 0; i < 4; i++) {
			if (stats [i] >= 90)
				result++;			
		}
		return result;
	}
	public int GetRed() {
		int result = 0;
		for (int i = 0; i < 4; i++) {
			if (stats [i] < 20)
				result++;			
		}
		return result;
	}
	float HealthMultiplier() {
		int _green = GetGreen ();
		int _red = GetRed ();

		float multiplier = _green>1 ? _green-1 : (_green==1 ? 0.5f : 0f);
		multiplier -= _red > 1 ? (_red - 1) : 0;
		return -multiplier;
	}

}
