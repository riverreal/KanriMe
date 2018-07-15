using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ElementMenu : MonoBehaviour {
	[SerializeField] WeekColumn[] m_weeks;
	[SerializeField] GameObject m_messageEditMenu;
	[SerializeField] TMP_InputField m_editInputField;
	[SerializeField] TMP_Dropdown m_editDropdown;
	RectTransform rectTransform;
	int m_selectedElement;
	int m_selectedColumn;
	Common.WeekWork m_weekWorkData;
	string m_weekDate;

	void Awake()
	{
		rectTransform = transform as RectTransform;
		m_selectedElement = 0;
		m_selectedColumn = 0;
	}

	void OnDestroy()
	{
		PlayerPrefs.Save();
	}

	public void LoadWeek()
	{
		foreach(WeekColumn weekCol in m_weeks)
		{
			weekCol.SetColTitle();
		}

		if(m_weekDate == "")
		{
			return;
		}

		if(PlayerPrefs.HasKey(m_weekDate))
		{
			m_weekWorkData = JsonUtility.FromJson<Common.WeekWork>(PlayerPrefs.GetString(m_weekDate));
		}
		else
		{
			m_weekWorkData = new Common.WeekWork();
			PlayerPrefs.SetString(m_weekDate, JsonUtility.ToJson(m_weekWorkData));
		}

		for(int dayNum = 0; dayNum < m_weekWorkData.weekWork.Count; dayNum++)
		{
			if(dayNum > m_weeks.Length - 1)
			{
				return;
			}
				
			for(int hourNum = 0; hourNum < m_weekWorkData.weekWork[dayNum].dayWork.Count; hourNum++)
			{
				m_weeks[dayNum].UpdateElement(hourNum,
					m_weekWorkData.weekWork[dayNum].dayWork[hourNum].workType,
					m_weekWorkData.weekWork[dayNum].dayWork[hourNum].workContent);
			}
		}
	}

	public void SetWeek(string weekDate)
	{
		m_weekDate = weekDate;
	}

	public void SetElement(Vector3 position, int elemNum, int colNum)
	{
		rectTransform.position = position;
		m_selectedElement = elemNum;
		m_selectedColumn = colNum;
	}

	public void OpenMessageEditMenu()
	{
		m_messageEditMenu.SetActive(true);
		m_editInputField.text = m_weekWorkData.weekWork[m_selectedColumn].dayWork[m_selectedElement].workContent;
		m_editDropdown.value = m_weekWorkData.weekWork[m_selectedColumn].dayWork[m_selectedElement].workType;
	}

	public void OnMsgEditOkClick()
	{
		m_messageEditMenu.SetActive(false);
		gameObject.SetActive(false);
		if(m_editInputField.text == "")
		{
			if(m_editDropdown.value != (int)Common.WeekWorkParameter.WorkType.Break)
			{
				return;
			}
			else
			{
				m_editInputField.text = "Break";
			}
		}

		m_weekWorkData.weekWork[m_selectedColumn].dayWork[m_selectedElement].workContent = m_editInputField.text;
		m_weekWorkData.weekWork[m_selectedColumn].dayWork[m_selectedElement].workType = m_editDropdown.value;
		if(m_editDropdown.value == (int)Common.WeekWorkParameter.WorkType.None)
		{
			m_weekWorkData.weekWork[m_selectedColumn].dayWork[m_selectedElement].workType = (int)Common.WeekWorkParameter.WorkType.Normal;
		}
		m_weeks[m_selectedColumn].UpdateElement(m_selectedElement,
			m_weekWorkData.weekWork[m_selectedColumn].dayWork[m_selectedElement].workType,
			m_editInputField.text);

		PlayerPrefs.SetString(m_weekDate, JsonUtility.ToJson(m_weekWorkData));
	}

	public void OnMsgEditDeleteClick()
	{
		m_messageEditMenu.SetActive(false);
		gameObject.SetActive(false);
		m_weekWorkData.weekWork[m_selectedColumn].dayWork[m_selectedElement].workContent = "";
		m_weekWorkData.weekWork[m_selectedColumn].dayWork[m_selectedElement].workType = (int)Common.WeekWorkParameter.WorkType.None;
		m_weeks[m_selectedColumn].UpdateElement(m_selectedElement, (int)Common.WeekWorkParameter.WorkType.None, "");

		PlayerPrefs.SetString(m_weekDate, JsonUtility.ToJson(m_weekWorkData));
	}
}
