using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TopBar : MonoBehaviour {
	[SerializeField] TopBarMenuWindow m_menuWindow;

	bool m_windowOpenMode;
	TopBarWindowButton m_currentButton;

	void Awake()
	{
		m_windowOpenMode = false;
		m_currentButton = TopBarWindowButton.None;
	}

	public enum TopBarWindowButton
	{
		None,
		File,
		Edit
	}

	List<string>[] m_menuElements =
	{
		new List<string>(new string[] {""}),
		new List<string>(new string[] {"Save", "Load"}),
		new List<string>(new string[] {"Change timescale"}),
	};

	public void HideMenuWindow()
	{
		m_windowOpenMode = false;
		m_menuWindow.gameObject.SetActive(false);
		m_currentButton = TopBarWindowButton.None;
	}

	public void OnTopBarButtonClick(int windowButton)
	{
		m_windowOpenMode = !m_windowOpenMode;

		if(!m_windowOpenMode)
		{
			HideMenuWindow();
			return;
		}

		m_currentButton = (TopBarWindowButton)windowButton;
		//Reposition
		m_menuWindow.gameObject.SetActive(true);
		m_menuWindow.OpenMenuWindow((int)windowButton-1, m_menuElements[(int)windowButton]);
	}

	public void OnTopBarButtonHover(int windowButton)
	{
		if(!m_windowOpenMode)
		{
			return;
		}

		m_currentButton = (TopBarWindowButton)windowButton;
		m_menuWindow.OpenMenuWindow((int)windowButton-1, m_menuElements[(int)windowButton]);
	}

	public void OnMenuElementClicked(int elementIndex)
	{
		Debug.Log(m_menuElements[(int)m_currentButton][elementIndex] + " pressed");
		HideMenuWindow();
	}
}
