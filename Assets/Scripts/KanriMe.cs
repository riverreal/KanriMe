using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanriMe : MonoBehaviour
{
	public static KanriMe m_instance;
	public static KanriMe Instance
	{
		get{
			if(m_instance == null)
			{
				m_instance = GameObject.FindObjectOfType<KanriMe>();

				if(m_instance == null)
				{
					GameObject container = new GameObject("KanriMe");
					m_instance = container.AddComponent<KanriMe>();
				}
			}

			return m_instance;
		}
	}

	void Awake()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 15;
	}
}
