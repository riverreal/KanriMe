using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TopBarMenuWindow : MonoBehaviour {
	[SerializeField] Button[] m_buttons;
	[SerializeField] RectTransform m_fileButton;

	Vector2 m_initialPosition;
	RectTransform m_rectTransform;

	void Awake()
	{
		m_rectTransform = GetComponent<RectTransform>();
		m_initialPosition = m_rectTransform.anchoredPosition;
	}

	void DisableAllButtons()
	{
		for(int i = 0; i < m_buttons.Length; i++)
		{
			m_buttons[i].gameObject.SetActive(false);
		}
	}

	public void OpenMenuWindow(int placementNum, List<string> elements)
	{
		DisableAllButtons();

		for(int i = 0; i < elements.Count; i++)
		{
			m_buttons[i].gameObject.SetActive(true);
			m_buttons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = elements[i];
		}
		
		m_rectTransform.anchoredPosition = m_initialPosition + new Vector2(m_fileButton.rect.width * placementNum, 0);
	}
}
