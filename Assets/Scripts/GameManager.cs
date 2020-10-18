using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
	public Arrow_Script arrow;

	void OnValidate()
	{
		if (arrow == null)
			arrow = FindObjectOfType<Arrow_Script>();
	}

	// Update is called once per frame
	void onEnable()
	{
		arrow.Clicked += OnClicked;
	}
	void onDisable()
	{
		arrow.Clicked -= OnClicked;
	}
	void OnClicked(float t)
	{
		t = 1.0f - 2.0f * t;
		arrow.enabled = false;
		Debug.Log($"{t:F5}");
	}
}
