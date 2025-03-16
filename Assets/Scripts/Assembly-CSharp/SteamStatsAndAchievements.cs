using Steamworks;
using UnityEngine;

internal class SteamStatsAndAchievements : MonoBehaviour
{
	private enum Achievement
	{
		WISH_GRANTED = 0,
		LIFE_RUINED = 1,
		GONE_FATAL = 2,
		PERFECT = 3,
		META = 4,
		YOU_ARE_WELCOME = 5,
		I_NEEDED_TO_SEE_WHAT_HAPPENS = 6,
		TROLLED = 7,
		SEE_YOU_SPACE_PRINCESS = 8,
		MASTER_CHEF = 9,
		DOUJINSHI_WRITE_THEMSELVES = 10,
		I_THINK_I_KNOW_THIS_ANIME = 11,
		REWRITING_A_CLASSIC = 12,
		NO_ANIMALS_HARMED = 13,
		ANIME_WAS_A_MISTAKE = 14,
		I_WISH_TO_BE_HER_RIGHT_NOW = 15
	}

	private class Achievement_t
	{
		public Achievement m_eAchievementID;

		public string m_strName;

		public string m_strDescription;

		public bool m_bAchieved;

		public Achievement_t(Achievement achievementID, string name, string desc)
		{
			m_eAchievementID = achievementID;
			m_strName = name;
			m_strDescription = desc;
			m_bAchieved = false;
		}
	}

	public bool wish_granted;

	public bool life_ruined;

	public bool gone_fatal;

	public bool perfect;

	public bool meta;

	public bool you_are_welcome;

	public bool i_needed_to_see_what_happens;

	public bool trolled;

	public bool see_you_space_princess;

	public bool master_chef;

	public bool doujinshi_write_themselves;

	public bool i_think_i_know_this_anime;

	public bool rewriting_a_classic;

	public bool no_animals_harmed;

	public bool anime_was_a_mistake;

	public bool i_wish_to_be_her_right_now;

	private Achievement_t[] m_Achievements = new Achievement_t[16]
	{
		new Achievement_t(Achievement.WISH_GRANTED, string.Empty, string.Empty),
		new Achievement_t(Achievement.LIFE_RUINED, string.Empty, string.Empty),
		new Achievement_t(Achievement.GONE_FATAL, string.Empty, string.Empty),
		new Achievement_t(Achievement.PERFECT, string.Empty, string.Empty),
		new Achievement_t(Achievement.META, string.Empty, string.Empty),
		new Achievement_t(Achievement.YOU_ARE_WELCOME, string.Empty, string.Empty),
		new Achievement_t(Achievement.I_NEEDED_TO_SEE_WHAT_HAPPENS, string.Empty, string.Empty),
		new Achievement_t(Achievement.TROLLED, string.Empty, string.Empty),
		new Achievement_t(Achievement.SEE_YOU_SPACE_PRINCESS, string.Empty, string.Empty),
		new Achievement_t(Achievement.MASTER_CHEF, string.Empty, string.Empty),
		new Achievement_t(Achievement.DOUJINSHI_WRITE_THEMSELVES, string.Empty, string.Empty),
		new Achievement_t(Achievement.I_THINK_I_KNOW_THIS_ANIME, string.Empty, string.Empty),
		new Achievement_t(Achievement.REWRITING_A_CLASSIC, string.Empty, string.Empty),
		new Achievement_t(Achievement.NO_ANIMALS_HARMED, string.Empty, string.Empty),
		new Achievement_t(Achievement.ANIME_WAS_A_MISTAKE, string.Empty, string.Empty),
		new Achievement_t(Achievement.I_WISH_TO_BE_HER_RIGHT_NOW, string.Empty, string.Empty)
	};

	private CGameID m_GameID;

	private bool m_bRequestedStats;

	private bool m_bStoreStats;

	protected Callback<UserStatsReceived_t> m_UserStatsReceived;

	protected Callback<UserAchievementStored_t> m_UserAchievementStored;

	private void OnEnable()
	{
		if (SteamManager.Initialized)
		{
			m_GameID = new CGameID(SteamUtils.GetAppID());
			m_UserStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
			m_UserAchievementStored = Callback<UserAchievementStored_t>.Create(OnAchievementStored);
			m_bRequestedStats = false;
		}
	}

	private void Update()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		if (!m_bRequestedStats)
		{
			if (!SteamManager.Initialized)
			{
				m_bRequestedStats = true;
				return;
			}
			bool bRequestedStats = SteamUserStats.RequestCurrentStats();
			m_bRequestedStats = bRequestedStats;
		}
		Achievement_t[] achievements = m_Achievements;
		foreach (Achievement_t achievement_t in achievements)
		{
			if (achievement_t.m_bAchieved)
			{
				continue;
			}
			switch (achievement_t.m_eAchievementID)
			{
			case Achievement.WISH_GRANTED:
				if (wish_granted)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.LIFE_RUINED:
				if (life_ruined)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.GONE_FATAL:
				if (gone_fatal)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.PERFECT:
				if (perfect)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.META:
				if (meta)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.YOU_ARE_WELCOME:
				if (you_are_welcome)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.I_NEEDED_TO_SEE_WHAT_HAPPENS:
				if (i_needed_to_see_what_happens)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.TROLLED:
				if (trolled)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.SEE_YOU_SPACE_PRINCESS:
				if (see_you_space_princess)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.MASTER_CHEF:
				if (master_chef)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.DOUJINSHI_WRITE_THEMSELVES:
				if (doujinshi_write_themselves)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.I_THINK_I_KNOW_THIS_ANIME:
				if (i_think_i_know_this_anime)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.REWRITING_A_CLASSIC:
				if (rewriting_a_classic)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.NO_ANIMALS_HARMED:
				if (no_animals_harmed)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.ANIME_WAS_A_MISTAKE:
				if (anime_was_a_mistake)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			case Achievement.I_WISH_TO_BE_HER_RIGHT_NOW:
				if (i_wish_to_be_her_right_now)
				{
					UnlockAchievement(achievement_t);
				}
				break;
			}
		}
		if (m_bStoreStats)
		{
			bool flag = SteamUserStats.StoreStats();
			m_bStoreStats = !flag;
		}
	}

	private void UnlockAchievement(Achievement_t achievement)
	{
		achievement.m_bAchieved = true;
		SteamUserStats.SetAchievement(achievement.m_eAchievementID.ToString());
		m_bStoreStats = true;
	}

	private void OnUserStatsReceived(UserStatsReceived_t pCallback)
	{
		if (!SteamManager.Initialized || (ulong)m_GameID != pCallback.m_nGameID)
		{
			return;
		}
		if (pCallback.m_eResult == EResult.k_EResultOK)
		{
			Debug.Log("Received stats and achievements from Steam\n");
			Achievement_t[] achievements = m_Achievements;
			foreach (Achievement_t achievement_t in achievements)
			{
				if (SteamUserStats.GetAchievement(achievement_t.m_eAchievementID.ToString(), out achievement_t.m_bAchieved))
				{
					achievement_t.m_strName = SteamUserStats.GetAchievementDisplayAttribute(achievement_t.m_eAchievementID.ToString(), "name");
					achievement_t.m_strDescription = SteamUserStats.GetAchievementDisplayAttribute(achievement_t.m_eAchievementID.ToString(), "desc");
				}
				else
				{
					Debug.LogWarning(string.Concat("SteamUserStats.GetAchievement failed for Achievement ", achievement_t.m_eAchievementID, "\nIs it registered in the Steam Partner site?"));
				}
			}
		}
		else
		{
			Debug.Log("RequestStats - failed, " + pCallback.m_eResult);
		}
	}

	private void OnAchievementStored(UserAchievementStored_t pCallback)
	{
		if ((ulong)m_GameID == pCallback.m_nGameID)
		{
			if (pCallback.m_nMaxProgress == 0)
			{
				Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' unlocked!");
				return;
			}
			Debug.Log("Achievement '" + pCallback.m_rgchAchievementName + "' progress callback, (" + pCallback.m_nCurProgress + "," + pCallback.m_nMaxProgress + ")");
		}
	}
}
