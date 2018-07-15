using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WeekWorkPanel : MonoBehaviour {
	[SerializeField] ElementMenu m_elementMenu;
	[SerializeField] GameObject[] m_weekDays;
	[SerializeField] GameObject[] m_weekEnds;
	DateTime m_weekDate;
	bool m_weekviewEnds;

	void Awake()
	{
		m_weekviewEnds = false;
		m_weekDate = GetThisWeekDate(DateTime.Now);
	}

	void Start()
	{
		m_elementMenu.SetWeek(m_weekDate.ToShortDateString());
		m_elementMenu.LoadWeek();
	}

	public DateTime GetSelectedWeek()
	{
		return m_weekDate;
	}

	public void SwitchWeekview()
	{
		m_weekviewEnds = !m_weekviewEnds;

		for(int i = 0; i < m_weekEnds.Length; i++)
		{
			m_weekEnds[i].SetActive(m_weekviewEnds);
		}

		for(int i = 0; i < m_weekDays.Length; i++)
		{
			m_weekDays[i].SetActive(!m_weekviewEnds);
		}
	}

	public void ChangeWeek(int diff)
	{
		m_weekDate = m_weekDate.AddDays(diff * 7);
		m_elementMenu.SetWeek(m_weekDate.ToShortDateString());
		m_elementMenu.LoadWeek();

	}

	DateTime GetThisWeekDate(DateTime today)
	{
		int week = (int)today.DayOfWeek;
		if(week == 0)
		{
			week = (int)DayOfWeek.Saturday + 1;
		}
		week--;
		var weekDay = today.AddDays(-week);
		return weekDay;
	}
}
