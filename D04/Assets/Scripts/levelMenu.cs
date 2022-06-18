﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelMenu : MonoBehaviour {

	public Text currentLevelName;
	public Text currentLevelScore;
	public int currentLevel = 0;
	public int maxLevels = 4;
	public playerProfile profile;
	public TMP_Text playerDeath;
	public TMP_Text playerRings;

	public Image[] levels;

	// Use this for initialization
	void Start () {
		playerRings.text = profile.getPlayerRings().ToString();
		playerDeath.text = profile.getPlayerDeath().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + currentLevel);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) ) {
			currentLevel++;
			if (currentLevel >= maxLevels)
				currentLevel = 0;
			changeLevelSelection (currentLevel);
		} else if (Input.GetKeyDown(KeyCode.LeftArrow) ) {
			currentLevel--;
			if (currentLevel < 0)
				currentLevel = 0;
			changeLevelSelection (currentLevel);
		}

		switch (currentLevel) {
		case 0:
			currentLevelScore.text = "best score : " + profile.getAngelScore () + " pts";
			currentLevelName.text = "Angel Island";
			break;
		case 1:
			currentLevelScore.text = "best score : " + profile.getOilScore () + " pts";
			currentLevelName.text = "Oil Ocean";
			break;
		case 2:
			currentLevelScore.text = "best score : " + profile.getFlyingScore () + " pts";
			currentLevelName.text = "FlyingBattery";
			break;
		case 3:
			currentLevelScore.text = "best score : " + profile.getChemicalScore() + " pts";
			currentLevelName.text = "Chemical Plant";
			break;
		}
	}

	void changeLevelSelection(int level) {
		for (int i = 0; i < levels.Length; i++) {
			Color c = levels[i].GetComponent<Image>().color;
			if (i != level)
			{
				c.r = 0;
			}
			else
				c.r = 1;
			levels [i].color = c;
		}

	}
}
