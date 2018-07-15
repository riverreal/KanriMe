using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeekColumn : MonoBehaviour {
	[SerializeField] Common.WeekWorkParameter.Day m_day;
	[SerializeField] GameObject[] m_workElements;
	[SerializeField] TextMeshProUGUI m_weekName;
	[SerializeField] ElementMenu m_elementMenu;
	[SerializeField] GameObject m_messageEditMenu;
	[SerializeField] WeekWorkPanel m_weekWorkPanel;

	void Start()
	{
		SetColTitle();
	}

	public void SetColTitle()
	{
		var selWeek = m_weekWorkPanel.GetSelectedWeek();
		var day = selWeek.AddDays((int)m_day);
		m_weekName.text = m_day.ToString() + "\n" + day.Month + "/" + day.Day;
	}

	public void OnElementClick(int elemNum)
	{
		var elemRectTrans = m_workElements[elemNum].GetComponent<RectTransform>();
		m_elementMenu.gameObject.SetActive(true);
		m_elementMenu.SetElement(elemRectTrans.position, elemNum, (int)m_day);
	}

	public void HideElementMenu()
	{
		m_elementMenu.gameObject.SetActive(false);
	}

	public void UpdateElement(int elemNum, int workType, string content)
	{
		m_workElements[elemNum].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = content;
		m_workElements[elemNum].GetComponent<Image>().color = Common.WeekWorkParameter.WeekWorkColors[workType];
	}
}
