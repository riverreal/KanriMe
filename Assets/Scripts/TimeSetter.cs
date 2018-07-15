using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeSetter : MonoBehaviour {
	void Awake()
	{
		int count = Common.WeekWorkParameter.StartTime;
		foreach(Transform child in transform)
		{
			var time = child.GetChild(0).GetComponent<TextMeshProUGUI>();
			time.text = count.ToString() + ":00";
			count++;
		}
	}
}
