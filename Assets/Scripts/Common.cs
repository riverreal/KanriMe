using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
	public class Parameters
	{
		public const int ReferenceResX = 1280;
		public const int ReferenceResY = 720;
		public const int ReferenceResHalfX = ReferenceResX / 2;
		public const int ReferenceResHalfY = ReferenceResY / 2;
		public const int ReferenceLeft = -ReferenceResHalfX;
		public const int ReferenceTop = ReferenceResHalfY;
		public const int ReferenceRight = ReferenceResHalfX;
		public const int ReferenceBottom = -ReferenceResHalfY;
	}

	public class WeekWorkParameter
	{
		public enum Day
		{
			Monday,
			Tuesday,
			Wednesday,
			Thurday,
			Friday,
			Saturday,
			Sunday
		};

		public enum WorkType
		{
			None,
			Normal,
			Task,
			Break
		};

		public const int StartTime = 9;
		public const int DefaultWeekWorkAlpha = 132;
		public static Color NoWeekWorkColor = new Color32(255, 255, 255, 0);
		public static Color DefaultWeekWorkColor = new Color32(0, 50, 255, DefaultWeekWorkAlpha);
		public static Color TaskWeekWorkColor = new Color32(0, 255, 100, DefaultWeekWorkAlpha);
		public static Color BreakWeekWorkColor = new Color32(255, 255, 0, DefaultWeekWorkAlpha);
		public static Color[] WeekWorkColors = {NoWeekWorkColor, DefaultWeekWorkColor, TaskWeekWorkColor, BreakWeekWorkColor};
	}

	[System.Serializable]
	public class HourWork
	{
		public HourWork(int hn, int wt, string wc)
		{
			hourNum = hn;
			workType = wt;
			workContent = wc;
		}

		public int hourNum;
		public int workType;
		public string workContent;
	}

	[System.Serializable]
	public class DayWork
	{
		public DayWork()
		{
			dayWork = new List<HourWork>();
			for(int i = WeekWorkParameter.StartTime; i < WeekWorkParameter.StartTime + 11; i++)
			{
				dayWork.Add(new HourWork(i, 0, ""));
			}
		}
		public List<HourWork> dayWork;
	}

	[System.Serializable]
	public class WeekWork
	{
		public WeekWork()
		{
			weekWork = new List<DayWork>();
			ResetData();
		}

		public void ResetData()
		{
			weekWork.Clear();

			for(int i = 0; i < 7; i++)
			{
				weekWork.Add(new DayWork());
			}
		}

		public List<DayWork> weekWork;
	}
}
