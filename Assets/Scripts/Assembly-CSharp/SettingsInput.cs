using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingsInput : MonoBehaviour
{
	private GameObject globalScripter;

	private GeneralController generalController;

	private GlobalInput globalInput;

	public GameObject mainmenuScripter;

	public GameObject narratorScripter;

	private MainmenuInput mainmenuInput;

	public GameObject menu;

	private IngameMenuController ingameMenuController;

	private PlayClip playClip;

	public AudioClip thump;

	public AudioClip increase;

	public AudioClip decrease;

	public AudioClip apply;

	public AudioClip changeSelection;

	public GameObject mainmenu;

	public GameObject logo;

	public GameObject settings;

	public GameObject settingsMobile;

	public bool inSettings;

	public GameObject settings_label_text;

	public GameObject language;

	public GameObject language_label_holder;

	public GameObject language_button1;

	public GameObject language_para_holder;

	public GameObject language_button2;

	public GameObject language_label_text;

	public GameObject language_para_text;

	public GameObject resolution;

	public GameObject resolution_label_holder;

	public GameObject resolution_button1;

	public GameObject resolution_para_holder;

	public GameObject resolution_button2;

	public GameObject resolution_label_text;

	public GameObject resolution_para_text;

	public GameObject fullscreen;

	public GameObject fullscreen_label_holder;

	public GameObject fullscreen_para1;

	public GameObject fullscreen_para2;

	public GameObject fullscreen_label_text;

	public GameObject fullscreen_para1_text;

	public GameObject fullscreen_para2_text;

	public GameObject sound;

	public GameObject sound_label_holder;

	public GameObject sound_button1;

	public GameObject sound_para_holder;

	public GameObject sound_button2;

	public GameObject sound_label_text;

	public GameObject sound_para_text;

	public GameObject music;

	public GameObject music_label_holder;

	public GameObject music_button1;

	public GameObject music_para_holder;

	public GameObject music_button2;

	public GameObject music_label_text;

	public GameObject music_para_text;

	public GameObject categories_label_text;

	public GameObject misc;

	public GameObject misc_label_holder;

	public GameObject misc_para1;

	public GameObject misc_para2;

	public GameObject misc_label_text;

	public GameObject misc_para1_text;

	public GameObject misc_para2_text;

	public GameObject cinema;

	public GameObject cinema_label_holder;

	public GameObject cinema_para1;

	public GameObject cinema_para2;

	public GameObject cinema_label_text;

	public GameObject cinema_para1_text;

	public GameObject cinema_para2_text;

	public GameObject vidya;

	public GameObject vidya_label_holder;

	public GameObject vidya_para1;

	public GameObject vidya_para2;

	public GameObject vidya_label_text;

	public GameObject vidya_para1_text;

	public GameObject vidya_para2_text;

	public GameObject animation;

	public GameObject animation_label_holder;

	public GameObject animation_para1;

	public GameObject animation_para2;

	public GameObject animation_label_text;

	public GameObject animation_para1_text;

	public GameObject animation_para2_text;

	public GameObject confirmation;

	public GameObject cancel_label_holder;

	public GameObject apply_label_holder;

	public GameObject cancel_label_text;

	public GameObject apply_label_text;

	public GameObject applyPanel;

	public Sprite yesno_holder;

	public Sprite yesno_holder_selected;

	public Sprite para_holder;

	public Sprite para_holder_selected;

	public GameObject settings_label_textM;

	public GameObject languageM;

	public GameObject language_label_holderM;

	public GameObject language_button1M;

	public GameObject language_para_holderM;

	public GameObject language_button2M;

	public GameObject language_label_textM;

	public GameObject language_para_textM;

	public GameObject soundM;

	public GameObject sound_label_holderM;

	public GameObject sound_button1M;

	public GameObject sound_para_holderM;

	public GameObject sound_button2M;

	public GameObject sound_label_textM;

	public GameObject sound_para_textM;

	public GameObject musicM;

	public GameObject music_label_holderM;

	public GameObject music_button1M;

	public GameObject music_para_holderM;

	public GameObject music_button2M;

	public GameObject music_label_textM;

	public GameObject music_para_textM;

	public GameObject categories_label_textM;

	public GameObject miscM;

	public GameObject misc_label_holderM;

	public GameObject misc_para1M;

	public GameObject misc_para2M;

	public GameObject misc_label_textM;

	public GameObject misc_para1_textM;

	public GameObject misc_para2_textM;

	public GameObject cinemaM;

	public GameObject cinema_label_holderM;

	public GameObject cinema_para1M;

	public GameObject cinema_para2M;

	public GameObject cinema_label_textM;

	public GameObject cinema_para1_textM;

	public GameObject cinema_para2_textM;

	public GameObject vidyaM;

	public GameObject vidya_label_holderM;

	public GameObject vidya_para1M;

	public GameObject vidya_para2M;

	public GameObject vidya_label_textM;

	public GameObject vidya_para1_textM;

	public GameObject vidya_para2_textM;

	public GameObject animationM;

	public GameObject animation_label_holderM;

	public GameObject animation_para1M;

	public GameObject animation_para2M;

	public GameObject animation_label_textM;

	public GameObject animation_para1_textM;

	public GameObject animation_para2_textM;

	public GameObject confirmationM;

	public GameObject cancel_label_holderM;

	public GameObject apply_label_holderM;

	public GameObject cancel_label_textM;

	public GameObject apply_label_textM;

	public GameObject applyPanelM;

	public GameObject policy_button;

	public GameObject policy_holder;

	public GameObject policy_label;

	private Color selectedColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	private Color selectedUnpickedColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	private Color unselectedColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 150);

	private Color unselectedUnpickedColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 100);

	private bool up;

	private bool down;

	private bool left;

	private bool right;

	private bool enter;

	private bool back;

	private bool esc;

	private string selection = string.Empty;

	private string para_lang;

	private Resolution para_resolution;

	private Resolution[] resolutions;

	private int resolution_index;

	private bool para_fullscreen;

	private int para_soundVol;

	private int para_musicVol;

	private int original_soundVol;

	private int original_musicVol;

	private bool para_misc;

	private bool para_vidya;

	private bool para_cinema;

	private bool para_animation;

	private Vector3 cursorPosition;

	private float timer;

	private bool applyHiding;

	private void Start()
	{
		globalScripter = GameObject.Find("GlobalScripter");
		generalController = globalScripter.GetComponent<GeneralController>();
		globalInput = globalScripter.GetComponent<GlobalInput>();
		if (generalController.currentScene == "mainmenu")
		{
			mainmenuInput = mainmenuScripter.GetComponent<MainmenuInput>();
			playClip = mainmenuScripter.GetComponent<PlayClip>();
		}
		else if (generalController.currentScene == "narrator")
		{
			ingameMenuController = menu.GetComponent<IngameMenuController>();
			playClip = narratorScripter.GetComponent<PlayClip>();
		}
		cursorPosition = Input.mousePosition;
		if (generalController.mobile)
		{
			settings_label_text = settings_label_textM;
			language = languageM;
			language_label_holder = language_label_holderM;
			language_button1 = language_button1M;
			language_para_holder = language_para_holderM;
			language_button2 = language_button2M;
			language_label_text = language_label_textM;
			language_para_text = language_para_textM;
			sound = soundM;
			sound_label_holder = sound_label_holderM;
			sound_button1 = sound_button1M;
			sound_para_holder = sound_para_holderM;
			sound_button2 = sound_button2M;
			sound_label_text = sound_label_textM;
			sound_para_text = sound_para_textM;
			music = musicM;
			music_label_holder = music_label_holderM;
			music_button1 = music_button1M;
			music_para_holder = music_para_holderM;
			music_button2 = music_button2M;
			music_label_text = music_label_textM;
			music_para_text = music_para_textM;
			categories_label_text = categories_label_textM;
			misc = miscM;
			misc_label_holder = misc_label_holderM;
			misc_para1 = misc_para1M;
			misc_para2 = misc_para2M;
			misc_label_text = misc_label_textM;
			misc_para1_text = misc_para1_textM;
			misc_para2_text = misc_para2_textM;
			cinema = cinemaM;
			cinema_label_holder = cinema_label_holderM;
			cinema_para1 = cinema_para1M;
			cinema_para2 = cinema_para2M;
			cinema_label_text = cinema_label_textM;
			cinema_para1_text = cinema_para1_textM;
			cinema_para2_text = cinema_para2_textM;
			vidya = vidyaM;
			vidya_label_holder = vidya_label_holderM;
			vidya_para1 = vidya_para1M;
			vidya_para2 = vidya_para2M;
			vidya_label_text = vidya_label_textM;
			vidya_para1_text = vidya_para1_textM;
			vidya_para2_text = vidya_para2_textM;
			animation = animationM;
			animation_label_holder = animation_label_holderM;
			animation_para1 = animation_para1M;
			animation_para2 = animation_para2M;
			animation_label_text = animation_label_textM;
			animation_para1_text = animation_para1_textM;
			animation_para2_text = animation_para2_textM;
			confirmation = confirmationM;
			cancel_label_holder = cancel_label_holderM;
			apply_label_holder = apply_label_holderM;
			cancel_label_text = cancel_label_textM;
			apply_label_text = apply_label_textM;
			applyPanel = applyPanelM;
		}
	}

	public void Initialize()
	{
		resolutions = Screen.resolutions;
		para_lang = generalController.lang;
		para_resolution = generalController.resolution;
		para_fullscreen = generalController.fullscreen;
		para_soundVol = generalController.soundVol;
		para_musicVol = generalController.musicVol;
		original_soundVol = generalController.soundVol;
		original_musicVol = generalController.musicVol;
		para_misc = generalController.misc;
		para_vidya = generalController.vidya;
		para_cinema = generalController.cinema;
		para_animation = generalController.animation;
		HideApply();
		ChangeLang();
		LoadSettings();
		AllOut();
		if (globalInput.inputMethod == "keys")
		{
			selection = "language";
			LanguageIn();
		}
		timer = 0f;
		cursorPosition = Input.mousePosition;
	}

	private void Update()
	{
		if (!inSettings)
		{
			return;
		}
		if (timer < 1f)
		{
			timer += Time.deltaTime;
		}
		up = globalInput.up;
		down = globalInput.down;
		left = globalInput.left;
		right = globalInput.right;
		enter = globalInput.enter;
		back = globalInput.back;
		esc = globalInput.esc;
		if (up || down || left || right || enter)
		{
			ManageInput();
			globalInput.pulsable = false;
		}
		else if (!up && !down && !left && !right && !enter)
		{
			globalInput.pulsable = true;
		}
		if (esc || back)
		{
			if (selection != "cancel")
			{
				AllOut();
				CancelIn();
				playClip.PlayCustom(decrease);
			}
			else
			{
				CancelClick();
			}
		}
		HasResolutionChanged();
	}

	private void HasResolutionChanged()
	{
		if (!applyHiding && (para_fullscreen != Screen.fullScreen || para_resolution.width != Screen.width || para_resolution.height != Screen.height))
		{
			ToggleApply();
		}
	}

	private void ChangeLang()
	{
		if (para_lang == "es")
		{
			settings_label_text.GetComponent<Text>().text = "Ajustes";
			language_label_text.GetComponent<Text>().text = "Idioma";
			resolution_label_text.GetComponent<Text>().text = "Resolución";
			fullscreen_label_text.GetComponent<Text>().text = "Pantalla completa";
			sound_label_text.GetComponent<Text>().text = "Volumen sonidos";
			music_label_text.GetComponent<Text>().text = "Volumen música";
			categories_label_text.GetComponent<Text>().text = "Categorías de preguntas";
			misc_label_text.GetComponent<Text>().text = "Miscelánea";
			cinema_label_text.GetComponent<Text>().text = "Cine";
			vidya_label_text.GetComponent<Text>().text = "Videojuegos";
			animation_label_text.GetComponent<Text>().text = "Animación";
			language_para_text.GetComponent<Text>().text = "Español";
			fullscreen_para1_text.GetComponent<Text>().text = "Sí";
			fullscreen_para2_text.GetComponent<Text>().text = "No";
			misc_para1_text.GetComponent<Text>().text = "Frecuente";
			misc_para2_text.GetComponent<Text>().text = "Infrecuente";
			cinema_para1_text.GetComponent<Text>().text = "Frecuente";
			cinema_para2_text.GetComponent<Text>().text = "Infrecuente";
			vidya_para1_text.GetComponent<Text>().text = "Frecuente";
			vidya_para2_text.GetComponent<Text>().text = "Infrecuente";
			animation_para1_text.GetComponent<Text>().text = "Frecuente";
			animation_para2_text.GetComponent<Text>().text = "Infrecuente";
			if (ChangesMade())
			{
				cancel_label_text.GetComponent<Text>().text = "Cancelar";
			}
			else
			{
				cancel_label_text.GetComponent<Text>().text = "Volver";
			}
			apply_label_text.GetComponent<Text>().text = "Aplicar";
			policy_label.GetComponent<Text>().text = "Política de privacidad";
		}
		else
		{
			settings_label_text.GetComponent<Text>().text = "Settings";
			language_label_text.GetComponent<Text>().text = "Language";
			resolution_label_text.GetComponent<Text>().text = "Resolution";
			fullscreen_label_text.GetComponent<Text>().text = "Full screen";
			sound_label_text.GetComponent<Text>().text = "Sounds volume";
			music_label_text.GetComponent<Text>().text = "Music volume";
			categories_label_text.GetComponent<Text>().text = "Question categories";
			misc_label_text.GetComponent<Text>().text = "Miscellaneous";
			cinema_label_text.GetComponent<Text>().text = "Cinema";
			vidya_label_text.GetComponent<Text>().text = "Video games";
			animation_label_text.GetComponent<Text>().text = "Animation";
			language_para_text.GetComponent<Text>().text = "English";
			fullscreen_para1_text.GetComponent<Text>().text = "Yes";
			fullscreen_para2_text.GetComponent<Text>().text = "No";
			misc_para1_text.GetComponent<Text>().text = "Frequent";
			misc_para2_text.GetComponent<Text>().text = "Infrequent";
			cinema_para1_text.GetComponent<Text>().text = "Frequent";
			cinema_para2_text.GetComponent<Text>().text = "Infrequent";
			vidya_para1_text.GetComponent<Text>().text = "Frequent";
			vidya_para2_text.GetComponent<Text>().text = "Infrequent";
			animation_para1_text.GetComponent<Text>().text = "Frequent";
			animation_para2_text.GetComponent<Text>().text = "Infrequent";
			if (ChangesMade())
			{
				cancel_label_text.GetComponent<Text>().text = "Cancel";
			}
			else
			{
				cancel_label_text.GetComponent<Text>().text = "Back";
			}
			apply_label_text.GetComponent<Text>().text = "Apply";
			policy_label.GetComponent<Text>().text = "Privacy policy";
		}
	}

	private bool ChangesMade()
	{
		if (para_lang != generalController.lang)
		{
			return true;
		}
		if (para_fullscreen != Screen.fullScreen || para_resolution.width != Screen.width || para_resolution.height != Screen.height)
		{
			return true;
		}
		if (para_resolution.width != generalController.resolution.width || para_resolution.height != generalController.resolution.height)
		{
			return true;
		}
		if (para_fullscreen != generalController.fullscreen)
		{
			return true;
		}
		if (original_soundVol != generalController.soundVol)
		{
			return true;
		}
		if (original_musicVol != generalController.musicVol)
		{
			return true;
		}
		if (para_misc != generalController.misc)
		{
			return true;
		}
		if (para_vidya != generalController.vidya)
		{
			return true;
		}
		if (para_cinema != generalController.cinema)
		{
			return true;
		}
		if (para_animation != generalController.animation)
		{
			return true;
		}
		return false;
	}

	private void ToggleApply()
	{
		if (ChangesMade() && !confirmation.GetComponent<Animator>().GetBool("applicable"))
		{
			ShowApply();
		}
		else if (!ChangesMade() && confirmation.GetComponent<Animator>().GetBool("applicable"))
		{
			HideApply();
		}
	}

	private void CheckResolution()
	{
		if (para_resolution.width != Screen.width || para_resolution.height != Screen.height)
		{
			PlayerPrefs.SetString("resolution", Screen.width + "x" + Screen.height);
			para_resolution.width = Screen.width;
			para_resolution.height = Screen.height;
		}
		resolution_index = -1;
		for (int i = 0; i < resolutions.Length; i++)
		{
			if (resolutions[i].width == para_resolution.width && resolutions[i].height == para_resolution.height)
			{
				resolution_index = i;
				break;
			}
		}
		if (resolution_index == -1)
		{
			resolution_index = 0;
			for (int j = 0; j < resolutions.Length; j++)
			{
				if (resolutions[j].width >= para_resolution.width && resolutions[j].height >= para_resolution.height)
				{
					resolution_index = j;
					break;
				}
			}
			Array.Resize(ref resolutions, resolutions.Length + 1);
			for (int num = resolutions.Length - 1; num > resolution_index; num--)
			{
				resolutions[num] = resolutions[num - 1];
			}
			resolutions[resolution_index].width = para_resolution.width;
			resolutions[resolution_index].height = para_resolution.height;
			PlayerPrefs.SetString("resolution", Screen.width + "x" + Screen.height);
			para_resolution.width = Screen.width;
			para_resolution.height = Screen.height;
		}
		if (para_fullscreen != Screen.fullScreen)
		{
			if (Screen.fullScreen)
			{
				PlayerPrefs.SetString("fullscreen", "true");
			}
			else
			{
				PlayerPrefs.SetString("fullscreen", "false");
			}
			para_fullscreen = Screen.fullScreen;
		}
		if (para_fullscreen)
		{
			fullscreen_para1.GetComponent<SpriteRenderer>().sprite = yesno_holder_selected;
			fullscreen_para2.GetComponent<SpriteRenderer>().sprite = yesno_holder;
		}
		else
		{
			fullscreen_para2.GetComponent<SpriteRenderer>().sprite = yesno_holder_selected;
			fullscreen_para1.GetComponent<SpriteRenderer>().sprite = yesno_holder;
		}
	}

	private void ChangeVol()
	{
		sound_para_text.GetComponent<Text>().text = para_soundVol + "%";
		music_para_text.GetComponent<Text>().text = para_musicVol + "%";
		ApplyVol();
	}

	private void ApplyVol()
	{
		generalController.soundVol = para_soundVol;
		generalController.musicVol = para_musicVol;
		generalController.ApplyVol();
	}

	private void LoadSettings()
	{
		CheckResolution();
		resolution_para_text.GetComponent<Text>().text = para_resolution.width + "x" + para_resolution.height;
		if (para_fullscreen)
		{
			fullscreen_para1.GetComponent<SpriteRenderer>().sprite = yesno_holder_selected;
			fullscreen_para2.GetComponent<SpriteRenderer>().sprite = yesno_holder;
		}
		else
		{
			fullscreen_para2.GetComponent<SpriteRenderer>().sprite = yesno_holder_selected;
			fullscreen_para1.GetComponent<SpriteRenderer>().sprite = yesno_holder;
		}
		ChangeVol();
		if (para_misc)
		{
			misc_para1.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			misc_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
		}
		else
		{
			misc_para2.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			misc_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
		}
		if (para_cinema)
		{
			cinema_para1.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			cinema_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
		}
		else
		{
			cinema_para2.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			cinema_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
		}
		if (para_vidya)
		{
			vidya_para1.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			vidya_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
		}
		else
		{
			vidya_para2.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			vidya_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
		}
		if (para_animation)
		{
			animation_para1.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			animation_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
		}
		else
		{
			animation_para2.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			animation_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
		}
	}

	private void ManageInput()
	{
		if (!globalInput.pulsable)
		{
			return;
		}
		if (down)
		{
			if (selection == string.Empty)
			{
				LanguageIn();
				playClip.PlayCustom(increase);
			}
			else if (selection == "language")
			{
				if (generalController.mobile)
				{
					SoundIn();
					playClip.PlayCustom(decrease);
				}
				else
				{
					ResolutionIn();
					playClip.PlayCustom(decrease);
				}
			}
			else if (selection == "resolution")
			{
				FullscreenIn();
				playClip.PlayCustom(increase);
			}
			else if (selection == "fullscreen")
			{
				SoundIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "sound")
			{
				MusicIn();
				playClip.PlayCustom(increase);
			}
			else if (selection == "music")
			{
				MiscIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "misc")
			{
				CinemaIn();
				playClip.PlayCustom(increase);
			}
			else if (selection == "cinema")
			{
				VidyaIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "vidya")
			{
				AnimationIn();
				playClip.PlayCustom(increase);
			}
			else if (selection == "animation")
			{
				ConfirmationIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "cancel" || selection == "apply")
			{
				LanguageIn();
				playClip.PlayCustom(increase);
			}
		}
		else if (up)
		{
			if (selection == string.Empty)
			{
				LanguageIn();
				playClip.PlayCustom(increase);
			}
			else if (selection == "resolution")
			{
				LanguageIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "fullscreen")
			{
				ResolutionIn();
				playClip.PlayCustom(increase);
			}
			else if (selection == "sound")
			{
				if (generalController.mobile)
				{
					LanguageIn();
					playClip.PlayCustom(decrease);
				}
				else
				{
					FullscreenIn();
					playClip.PlayCustom(decrease);
				}
			}
			else if (selection == "music")
			{
				SoundIn();
				playClip.PlayCustom(increase);
			}
			else if (selection == "misc")
			{
				MusicIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "cinema")
			{
				MiscIn();
				playClip.PlayCustom(increase);
			}
			else if (selection == "vidya")
			{
				CinemaIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "animation")
			{
				VidyaIn();
				playClip.PlayCustom(increase);
			}
			else if (selection == "apply" || selection == "cancel")
			{
				AnimationIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "language")
			{
				ConfirmationIn();
				playClip.PlayCustom(decrease);
			}
		}
		else if (left)
		{
			if (selection == "language")
			{
				LanguageDecrease();
			}
			else if (selection == "resolution")
			{
				ResolutionDecrease();
			}
			else if (selection == "fullscreen")
			{
				FullscreenDecrease();
			}
			else if (selection == "sound")
			{
				SoundDecrease();
			}
			else if (selection == "music")
			{
				MusicDecrease();
			}
			else if (selection == "misc")
			{
				MiscDecrease();
			}
			else if (selection == "cinema")
			{
				CinemaDecrease();
			}
			else if (selection == "vidya")
			{
				VidyaDecrease();
			}
			else if (selection == "animation")
			{
				AnimationDecrease();
			}
			else if (selection == "cancel" || selection == "apply")
			{
				ConfirmationDecrease();
			}
		}
		else if (right)
		{
			if (selection == "language")
			{
				LanguageIncrease();
			}
			else if (selection == "resolution")
			{
				ResolutionIncrease();
			}
			else if (selection == "fullscreen")
			{
				FullscreenIncrease();
			}
			else if (selection == "sound")
			{
				SoundIncrease();
			}
			else if (selection == "music")
			{
				MusicIncrease();
			}
			else if (selection == "misc")
			{
				MiscIncrease();
			}
			else if (selection == "cinema")
			{
				CinemaIncrease();
			}
			else if (selection == "vidya")
			{
				VidyaIncrease();
			}
			else if (selection == "animation")
			{
				AnimationIncrease();
			}
			else if (selection == "cancel" || selection == "apply")
			{
				ConfirmationIncrease();
			}
		}
		else if (enter)
		{
			if (selection == "language" && para_lang != generalController.lang)
			{
				AllOut();
				ConfirmationIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "resolution" && para_resolution.width != generalController.resolution.width && para_resolution.height != generalController.resolution.height)
			{
				AllOut();
				ConfirmationIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "fullscreen")
			{
				ToggleFullscreen();
			}
			else if (selection == "sound" && para_soundVol != generalController.soundVol)
			{
				AllOut();
				ConfirmationIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "music" && para_musicVol != generalController.musicVol)
			{
				AllOut();
				ConfirmationIn();
				playClip.PlayCustom(decrease);
			}
			else if (selection == "misc")
			{
				ToggleMisc();
			}
			else if (selection == "cinema")
			{
				ToggleCinema();
			}
			else if (selection == "vidya")
			{
				ToggleVidya();
			}
			else if (selection == "animation")
			{
				ToggleAnimation();
			}
			else if (selection == "cancel")
			{
				CancelClick();
			}
			else if (selection == "apply")
			{
				ApplyClick();
			}
			else
			{
				playClip.PlayCustom(thump);
			}
		}
	}

	public void AllOutMouse()
	{
		if (globalInput.inputMethod == "mouse")
		{
			AllOut();
		}
		else if (timer >= 1f)
		{
			AllOut();
		}
	}

	public void AllOut()
	{
		selection = string.Empty;
		language.GetComponent<Animator>().SetBool("selected", false);
		language_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		language_button1.GetComponent<SpriteRenderer>().color = unselectedColor;
		language_para_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		language_button2.GetComponent<SpriteRenderer>().color = unselectedColor;
		resolution.GetComponent<Animator>().SetBool("selected", false);
		resolution_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		resolution_button1.GetComponent<SpriteRenderer>().color = unselectedColor;
		resolution_para_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		resolution_button2.GetComponent<SpriteRenderer>().color = unselectedColor;
		fullscreen.GetComponent<Animator>().SetInteger("selected", 0);
		fullscreen_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		if (para_fullscreen)
		{
			fullscreen_para1.GetComponent<SpriteRenderer>().sprite = yesno_holder_selected;
			fullscreen_para2.GetComponent<SpriteRenderer>().sprite = yesno_holder;
			fullscreen_para1.GetComponent<SpriteRenderer>().color = unselectedColor;
			fullscreen_para2.GetComponent<SpriteRenderer>().color = unselectedUnpickedColor;
		}
		else
		{
			fullscreen_para2.GetComponent<SpriteRenderer>().sprite = yesno_holder_selected;
			fullscreen_para1.GetComponent<SpriteRenderer>().sprite = yesno_holder;
			fullscreen_para1.GetComponent<SpriteRenderer>().color = unselectedUnpickedColor;
			fullscreen_para2.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
		sound.GetComponent<Animator>().SetBool("selected", false);
		sound_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		sound_button1.GetComponent<SpriteRenderer>().color = unselectedColor;
		sound_para_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		sound_button2.GetComponent<SpriteRenderer>().color = unselectedColor;
		music.GetComponent<Animator>().SetBool("selected", false);
		music_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		music_button1.GetComponent<SpriteRenderer>().color = unselectedColor;
		music_para_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		music_button2.GetComponent<SpriteRenderer>().color = unselectedColor;
		misc.GetComponent<Animator>().SetInteger("selected", 0);
		misc_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		if (para_misc)
		{
			misc_para1.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			misc_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
			misc_para1.GetComponent<SpriteRenderer>().color = unselectedColor;
			misc_para2.GetComponent<SpriteRenderer>().color = unselectedUnpickedColor;
		}
		else
		{
			misc_para2.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			misc_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
			misc_para1.GetComponent<SpriteRenderer>().color = unselectedUnpickedColor;
			misc_para2.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
		cinema.GetComponent<Animator>().SetInteger("selected", 0);
		cinema_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		if (para_cinema)
		{
			cinema_para1.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			cinema_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
			cinema_para1.GetComponent<SpriteRenderer>().color = unselectedColor;
			cinema_para2.GetComponent<SpriteRenderer>().color = unselectedUnpickedColor;
		}
		else
		{
			cinema_para2.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			cinema_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
			cinema_para1.GetComponent<SpriteRenderer>().color = unselectedUnpickedColor;
			cinema_para2.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
		vidya.GetComponent<Animator>().SetInteger("selected", 0);
		vidya_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		if (para_vidya)
		{
			vidya_para1.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			vidya_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
			vidya_para1.GetComponent<SpriteRenderer>().color = unselectedColor;
			vidya_para2.GetComponent<SpriteRenderer>().color = unselectedUnpickedColor;
		}
		else
		{
			vidya_para2.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			vidya_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
			vidya_para1.GetComponent<SpriteRenderer>().color = unselectedUnpickedColor;
			vidya_para2.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
		animation.GetComponent<Animator>().SetInteger("selected", 0);
		animation_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		if (para_animation)
		{
			animation_para1.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			animation_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
			animation_para1.GetComponent<SpriteRenderer>().color = unselectedColor;
			animation_para2.GetComponent<SpriteRenderer>().color = unselectedUnpickedColor;
		}
		else
		{
			animation_para2.GetComponent<SpriteRenderer>().sprite = para_holder_selected;
			animation_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
			animation_para1.GetComponent<SpriteRenderer>().color = unselectedUnpickedColor;
			animation_para2.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
		if (ChangesMade())
		{
			confirmation.GetComponent<Animator>().SetInteger("selected", 0);
			cancel_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
			apply_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
		else
		{
			confirmation.GetComponent<Animator>().SetInteger("selected", 0);
			cancel_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		}
	}

	public void LanguageIn()
	{
		if (!language.GetComponent<Animator>().GetBool("selected"))
		{
			AllOut();
			selection = "language";
			language.GetComponent<Animator>().SetBool("selected", true);
			language_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			language_button1.GetComponent<SpriteRenderer>().color = selectedColor;
			language_para_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			language_button2.GetComponent<SpriteRenderer>().color = selectedColor;
		}
	}

	public void LanguageInMouse()
	{
		if ((!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition)) && selection != "language")
		{
			playClip.PlayCustom(increase);
			LanguageIn();
		}
	}

	public void LanguageIncrease()
	{
		if (selection != "language")
		{
			LanguageIn();
		}
		if (para_lang == "en")
		{
			para_lang = "es";
			ChangeLang();
		}
		else if (para_lang == "es")
		{
			para_lang = "en";
			ChangeLang();
		}
		language.GetComponent<Animator>().SetTrigger("increase");
		playClip.PlayCustom(increase);
		ToggleApply();
	}

	public void LanguageDecrease()
	{
		if (selection != "language")
		{
			LanguageIn();
		}
		if (para_lang == "en")
		{
			para_lang = "es";
			ChangeLang();
		}
		else if (para_lang == "es")
		{
			para_lang = "en";
			ChangeLang();
		}
		language.GetComponent<Animator>().SetTrigger("decrease");
		playClip.PlayCustom(decrease);
		ToggleApply();
	}

	public void ResolutionIn()
	{
		if (!resolution.GetComponent<Animator>().GetBool("selected"))
		{
			AllOut();
			selection = "resolution";
			resolution.GetComponent<Animator>().SetBool("selected", true);
			resolution_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			resolution_button1.GetComponent<SpriteRenderer>().color = selectedColor;
			resolution_para_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			resolution_button2.GetComponent<SpriteRenderer>().color = selectedColor;
		}
	}

	public void ResolutionInMouse()
	{
		if ((!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition)) && selection != "resolution")
		{
			playClip.PlayCustom(decrease);
			ResolutionIn();
		}
	}

	public void ResolutionIncrease()
	{
		if (selection != "resolution")
		{
			ResolutionIn();
		}
		resolution_index++;
		if (resolution_index > resolutions.Length - 1)
		{
			resolution_index = resolutions.Length - 1;
			playClip.PlayCustom(thump);
		}
		else
		{
			playClip.PlayCustom(increase);
		}
		para_resolution.width = resolutions[resolution_index].width;
		para_resolution.height = resolutions[resolution_index].height;
		resolution_para_text.GetComponent<Text>().text = resolutions[resolution_index].width + "x" + resolutions[resolution_index].height;
		resolution.GetComponent<Animator>().SetTrigger("increase");
		ToggleApply();
	}

	public void ResolutionDecrease()
	{
		if (selection != "resolution")
		{
			ResolutionIn();
		}
		resolution_index--;
		if (resolution_index < 0)
		{
			resolution_index = 0;
			playClip.PlayCustom(thump);
		}
		else
		{
			playClip.PlayCustom(decrease);
		}
		para_resolution.width = resolutions[resolution_index].width;
		para_resolution.height = resolutions[resolution_index].height;
		resolution_para_text.GetComponent<Text>().text = resolutions[resolution_index].width + "x" + resolutions[resolution_index].height;
		resolution.GetComponent<Animator>().SetTrigger("decrease");
		ToggleApply();
	}

	public void FullscreenIn()
	{
		if (fullscreen.GetComponent<Animator>().GetInteger("selected") == 0)
		{
			AllOut();
			selection = "fullscreen";
			if (para_fullscreen)
			{
				fullscreen.GetComponent<Animator>().SetInteger("selected", 1);
				fullscreen_para1.GetComponent<SpriteRenderer>().color = selectedColor;
				fullscreen_para2.GetComponent<SpriteRenderer>().color = selectedUnpickedColor;
			}
			else
			{
				fullscreen.GetComponent<Animator>().SetInteger("selected", 2);
				fullscreen_para2.GetComponent<SpriteRenderer>().color = selectedColor;
				fullscreen_para1.GetComponent<SpriteRenderer>().color = selectedUnpickedColor;
			}
			fullscreen_para1.GetComponent<SpriteRenderer>().sprite = yesno_holder;
			fullscreen_para2.GetComponent<SpriteRenderer>().sprite = yesno_holder;
			fullscreen_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
		}
	}

	public void FullscreenInMouse()
	{
		if ((!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition)) && selection != "fullscreen")
		{
			playClip.PlayCustom(increase);
			FullscreenIn();
		}
	}

	public void ToggleFullscreen()
	{
		if (fullscreen.GetComponent<Animator>().GetInteger("selected") == 1)
		{
			FullscreenIncrease();
		}
		else
		{
			FullscreenDecrease();
		}
	}

	public void FullscreenIncrease()
	{
		if (selection != "fullscreen")
		{
			FullscreenIn();
		}
		if (fullscreen.GetComponent<Animator>().GetInteger("selected") == 1)
		{
			para_fullscreen = false;
			fullscreen.GetComponent<Animator>().SetInteger("selected", 2);
			fullscreen.GetComponent<Animator>().SetTrigger("increase");
			playClip.PlayCustom(increase);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		ToggleApply();
	}

	public void FullscreenDecrease()
	{
		if (selection != "fullscreen")
		{
			FullscreenIn();
		}
		if (fullscreen.GetComponent<Animator>().GetInteger("selected") == 2)
		{
			para_fullscreen = true;
			fullscreen.GetComponent<Animator>().SetInteger("selected", 1);
			fullscreen.GetComponent<Animator>().SetTrigger("decrease");
			playClip.PlayCustom(decrease);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		ToggleApply();
	}

	public void SoundIn()
	{
		if (!sound.GetComponent<Animator>().GetBool("selected"))
		{
			AllOut();
			selection = "sound";
			sound.GetComponent<Animator>().SetBool("selected", true);
			sound_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			sound_button1.GetComponent<SpriteRenderer>().color = selectedColor;
			sound_para_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			sound_button2.GetComponent<SpriteRenderer>().color = selectedColor;
		}
	}

	public void SoundInMouse()
	{
		if ((!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition)) && selection != "sound")
		{
			playClip.PlayCustom(decrease);
			SoundIn();
		}
	}

	public void SoundIncrease()
	{
		if (selection != "sound")
		{
			SoundIn();
		}
		if (para_soundVol < 100)
		{
			para_soundVol += 10;
			ChangeVol();
			playClip.PlayCustom(increase);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		sound.GetComponent<Animator>().SetTrigger("increase");
		ToggleApply();
	}

	public void SoundDecrease()
	{
		if (selection != "sound")
		{
			SoundIn();
		}
		if (para_soundVol > 0)
		{
			para_soundVol -= 10;
			ChangeVol();
			playClip.PlayCustom(decrease);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		sound.GetComponent<Animator>().SetTrigger("decrease");
		ToggleApply();
	}

	public void MusicIn()
	{
		if (!music.GetComponent<Animator>().GetBool("selected"))
		{
			AllOut();
			selection = "music";
			music.GetComponent<Animator>().SetBool("selected", true);
			music_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			music_button1.GetComponent<SpriteRenderer>().color = selectedColor;
			music_para_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			music_button2.GetComponent<SpriteRenderer>().color = selectedColor;
		}
	}

	public void MusicInMouse()
	{
		if ((!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition)) && selection != "music")
		{
			playClip.PlayCustom(increase);
			MusicIn();
		}
	}

	public void MusicIncrease()
	{
		if (selection != "music")
		{
			MusicIn();
		}
		if (para_musicVol < 100)
		{
			para_musicVol += 10;
			ChangeVol();
			playClip.PlayCustom(increase);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		music.GetComponent<Animator>().SetTrigger("increase");
		ToggleApply();
	}

	public void MusicDecrease()
	{
		if (selection != "music")
		{
			MusicIn();
		}
		if (para_musicVol > 0)
		{
			para_musicVol -= 10;
			ChangeVol();
			playClip.PlayCustom(decrease);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		music.GetComponent<Animator>().SetTrigger("decrease");
		ToggleApply();
	}

	public void MiscIn()
	{
		if (misc.GetComponent<Animator>().GetInteger("selected") == 0)
		{
			AllOut();
			selection = "misc";
			if (para_misc)
			{
				misc.GetComponent<Animator>().SetInteger("selected", 1);
				misc_para1.GetComponent<SpriteRenderer>().color = selectedColor;
				misc_para2.GetComponent<SpriteRenderer>().color = selectedUnpickedColor;
			}
			else
			{
				misc.GetComponent<Animator>().SetInteger("selected", 2);
				misc_para2.GetComponent<SpriteRenderer>().color = selectedColor;
				misc_para1.GetComponent<SpriteRenderer>().color = selectedUnpickedColor;
			}
			misc_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
			misc_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
			misc_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
		}
	}

	public void MiscInMouse()
	{
		if ((!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition)) && selection != "misc")
		{
			playClip.PlayCustom(decrease);
			MiscIn();
		}
	}

	public void ToggleMisc()
	{
		if (misc.GetComponent<Animator>().GetInteger("selected") == 1)
		{
			MiscIncrease();
		}
		else
		{
			MiscDecrease();
		}
	}

	public void MiscIncrease()
	{
		if (selection != "misc")
		{
			MiscIn();
		}
		if (misc.GetComponent<Animator>().GetInteger("selected") == 1)
		{
			para_misc = false;
			misc.GetComponent<Animator>().SetInteger("selected", 2);
			misc.GetComponent<Animator>().SetTrigger("increase");
			playClip.PlayCustom(increase);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		ToggleApply();
	}

	public void MiscDecrease()
	{
		if (selection != "misc")
		{
			MiscIn();
		}
		if (misc.GetComponent<Animator>().GetInteger("selected") == 2)
		{
			para_misc = true;
			misc.GetComponent<Animator>().SetInteger("selected", 1);
			misc.GetComponent<Animator>().SetTrigger("decrease");
			playClip.PlayCustom(decrease);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		ToggleApply();
	}

	public void CinemaIn()
	{
		if (cinema.GetComponent<Animator>().GetInteger("selected") == 0)
		{
			AllOut();
			selection = "cinema";
			if (para_cinema)
			{
				cinema.GetComponent<Animator>().SetInteger("selected", 1);
				cinema_para1.GetComponent<SpriteRenderer>().color = selectedColor;
				cinema_para2.GetComponent<SpriteRenderer>().color = selectedUnpickedColor;
			}
			else
			{
				cinema.GetComponent<Animator>().SetInteger("selected", 2);
				cinema_para2.GetComponent<SpriteRenderer>().color = selectedColor;
				cinema_para1.GetComponent<SpriteRenderer>().color = selectedUnpickedColor;
			}
			cinema_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
			cinema_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
			cinema_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
		}
	}

	public void CinemaInMouse()
	{
		if ((!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition)) && selection != "cinema")
		{
			playClip.PlayCustom(increase);
			CinemaIn();
		}
	}

	public void ToggleCinema()
	{
		if (cinema.GetComponent<Animator>().GetInteger("selected") == 1)
		{
			CinemaIncrease();
		}
		else
		{
			CinemaDecrease();
		}
	}

	public void CinemaIncrease()
	{
		if (selection != "cinema")
		{
			CinemaIn();
		}
		if (cinema.GetComponent<Animator>().GetInteger("selected") == 1)
		{
			para_cinema = false;
			cinema.GetComponent<Animator>().SetInteger("selected", 2);
			cinema.GetComponent<Animator>().SetTrigger("increase");
			playClip.PlayCustom(increase);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		ToggleApply();
	}

	public void CinemaDecrease()
	{
		if (selection != "cinema")
		{
			CinemaIn();
		}
		if (cinema.GetComponent<Animator>().GetInteger("selected") == 2)
		{
			para_cinema = true;
			cinema.GetComponent<Animator>().SetInteger("selected", 1);
			cinema.GetComponent<Animator>().SetTrigger("decrease");
			playClip.PlayCustom(decrease);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		ToggleApply();
	}

	public void VidyaIn()
	{
		if (vidya.GetComponent<Animator>().GetInteger("selected") == 0)
		{
			AllOut();
			selection = "vidya";
			if (para_vidya)
			{
				vidya.GetComponent<Animator>().SetInteger("selected", 1);
				vidya_para1.GetComponent<SpriteRenderer>().color = selectedColor;
				vidya_para2.GetComponent<SpriteRenderer>().color = selectedUnpickedColor;
			}
			else
			{
				vidya.GetComponent<Animator>().SetInteger("selected", 2);
				vidya_para2.GetComponent<SpriteRenderer>().color = selectedColor;
				vidya_para1.GetComponent<SpriteRenderer>().color = selectedUnpickedColor;
			}
			vidya_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
			vidya_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
			vidya_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
		}
	}

	public void VidyaInMouse()
	{
		if ((!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition)) && selection != "vidya")
		{
			playClip.PlayCustom(decrease);
			VidyaIn();
		}
	}

	public void ToggleVidya()
	{
		if (vidya.GetComponent<Animator>().GetInteger("selected") == 1)
		{
			VidyaIncrease();
		}
		else
		{
			VidyaDecrease();
		}
	}

	public void VidyaIncrease()
	{
		if (selection != "vidya")
		{
			VidyaIn();
		}
		if (vidya.GetComponent<Animator>().GetInteger("selected") == 1)
		{
			para_vidya = false;
			vidya.GetComponent<Animator>().SetInteger("selected", 2);
			vidya.GetComponent<Animator>().SetTrigger("increase");
			playClip.PlayCustom(increase);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		ToggleApply();
	}

	public void VidyaDecrease()
	{
		if (selection != "vidya")
		{
			VidyaIn();
		}
		if (vidya.GetComponent<Animator>().GetInteger("selected") == 2)
		{
			para_vidya = true;
			vidya.GetComponent<Animator>().SetInteger("selected", 1);
			vidya.GetComponent<Animator>().SetTrigger("decrease");
			playClip.PlayCustom(decrease);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		ToggleApply();
	}

	public void AnimationIn()
	{
		if (animation.GetComponent<Animator>().GetInteger("selected") == 0)
		{
			AllOut();
			selection = "animation";
			if (para_animation)
			{
				animation.GetComponent<Animator>().SetInteger("selected", 1);
				animation_para1.GetComponent<SpriteRenderer>().color = selectedColor;
				animation_para2.GetComponent<SpriteRenderer>().color = selectedUnpickedColor;
			}
			else
			{
				animation.GetComponent<Animator>().SetInteger("selected", 2);
				animation_para2.GetComponent<SpriteRenderer>().color = selectedColor;
				animation_para1.GetComponent<SpriteRenderer>().color = selectedUnpickedColor;
			}
			animation_para1.GetComponent<SpriteRenderer>().sprite = para_holder;
			animation_para2.GetComponent<SpriteRenderer>().sprite = para_holder;
			animation_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
		}
	}

	public void AnimationInMouse()
	{
		if ((!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition)) && selection != "animation")
		{
			playClip.PlayCustom(increase);
			AnimationIn();
		}
	}

	public void ToggleAnimation()
	{
		if (animation.GetComponent<Animator>().GetInteger("selected") == 1)
		{
			AnimationIncrease();
		}
		else
		{
			AnimationDecrease();
		}
	}

	public void AnimationIncrease()
	{
		if (selection != "animation")
		{
			AnimationIn();
		}
		if (animation.GetComponent<Animator>().GetInteger("selected") == 1)
		{
			para_animation = false;
			animation.GetComponent<Animator>().SetInteger("selected", 2);
			animation.GetComponent<Animator>().SetTrigger("increase");
			playClip.PlayCustom(increase);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		ToggleApply();
	}

	public void AnimationDecrease()
	{
		if (selection != "animation")
		{
			AnimationIn();
		}
		if (animation.GetComponent<Animator>().GetInteger("selected") == 2)
		{
			para_animation = true;
			animation.GetComponent<Animator>().SetInteger("selected", 1);
			animation.GetComponent<Animator>().SetTrigger("decrease");
			playClip.PlayCustom(decrease);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
		ToggleApply();
	}

	public void ConfirmationIn()
	{
		if (confirmation.GetComponent<Animator>().GetInteger("selected") == 0)
		{
			if (ChangesMade())
			{
				ApplyIn();
			}
			else
			{
				CancelIn();
			}
		}
	}

	public void ConfirmationIncrease()
	{
		if (ChangesMade() && selection == "cancel")
		{
			selection = "apply";
			confirmation.GetComponent<Animator>().SetInteger("selected", 2);
			confirmation.GetComponent<Animator>().SetTrigger("increase");
			cancel_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			apply_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			playClip.PlayCustom(increase);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
	}

	public void ConfirmationDecrease()
	{
		if (ChangesMade() && selection == "apply")
		{
			selection = "cancel";
			confirmation.GetComponent<Animator>().SetInteger("selected", 1);
			confirmation.GetComponent<Animator>().SetTrigger("decrease");
			cancel_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			apply_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			playClip.PlayCustom(decrease);
		}
		else
		{
			playClip.PlayCustom(thump);
		}
	}

	public void CancelIn()
	{
		AllOut();
		if (confirmation.GetComponent<Animator>().GetInteger("selected") == 2)
		{
			confirmation.GetComponent<Animator>().SetTrigger("decrease");
		}
		selection = "cancel";
		confirmation.GetComponent<Animator>().SetInteger("selected", 1);
		cancel_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
	}

	public void CancelInMouse()
	{
		if ((!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition)) && selection != "cancel")
		{
			playClip.PlayCustom(decrease);
			CancelIn();
		}
	}

	public void ApplyIn()
	{
		if (ChangesMade())
		{
			AllOut();
			selection = "apply";
			confirmation.GetComponent<Animator>().SetInteger("selected", 2);
			cancel_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
			apply_label_holder.GetComponent<SpriteRenderer>().color = selectedColor;
		}
	}

	public void ApplyInMouse()
	{
		if ((!(globalInput.inputMethod != "mouse") || !(cursorPosition == Input.mousePosition)) && selection != "apply" && confirmation.GetComponent<Animator>().GetBool("applicable"))
		{
			playClip.PlayCustom(increase);
			ApplyIn();
		}
	}

	private void ShowApply()
	{
		if (para_lang == "en")
		{
			cancel_label_text.GetComponent<Text>().text = "Cancel";
		}
		else
		{
			cancel_label_text.GetComponent<Text>().text = "Cancelar";
		}
		confirmation.GetComponent<Animator>().SetBool("applicable", true);
		apply_label_text.GetComponent<Animator>().SetBool("visible", true);
	}

	private void HideApply()
	{
		if (para_lang == "en")
		{
			cancel_label_text.GetComponent<Text>().text = "Back";
		}
		else
		{
			cancel_label_text.GetComponent<Text>().text = "Volver";
		}
		confirmation.GetComponent<Animator>().SetBool("applicable", false);
		apply_label_text.GetComponent<Animator>().SetBool("visible", false);
	}

	public void CancelClick()
	{
		if (selection != "cancel")
		{
			CancelIn();
		}
		inSettings = false;
		confirmation.GetComponent<Animator>().SetTrigger("click");
		globalInput.pulsable = false;
		StartCoroutine(HideSettings());
		generalController.soundVol = original_soundVol;
		generalController.musicVol = original_musicVol;
		generalController.ApplyVol();
	}

	private IEnumerator HideSettings()
	{
		yield return new WaitForSeconds(0.1f);
		if (generalController.mobile)
		{
			settingsMobile.GetComponent<Animator>().SetBool("visible", false);
		}
		else
		{
			settings.GetComponent<Animator>().SetBool("visible", false);
		}
		yield return new WaitForSeconds(0.2f);
		AllOut();
		if (generalController.currentScene == "mainmenu")
		{
			mainmenuInput.BackToMainmenu();
		}
		else if (generalController.currentScene == "narrator")
		{
			ingameMenuController.BackToNarrator();
		}
		else if (generalController.currentScene == "quiz")
		{
			ingameMenuController.BackToQuiz();
		}
	}

	public void ApplyClick()
	{
		if (selection != "apply")
		{
			ApplyIn();
		}
		Invoke("CancelToBack", 0.3f);
		if (ChangesMade())
		{
			playClip.PlayCustom(apply);
			confirmation.GetComponent<Animator>().SetTrigger("click");
			if (globalInput.inputMethod == "keys")
			{
				confirmation.GetComponent<Animator>().SetBool("applicable", false);
				StartCoroutine(HideApplyKeys());
			}
			else
			{
				confirmation.GetComponent<Animator>().SetBool("applicable", false);
				StartCoroutine(HideApplyMouse());
			}
			generalController.lang = para_lang;
			PlayerPrefs.SetString("lang", para_lang);
			if (para_resolution.width != generalController.resolution.width || para_resolution.height != generalController.resolution.height || para_fullscreen != generalController.fullscreen)
			{
				Screen.SetResolution(para_resolution.width, para_resolution.height, para_fullscreen);
			}
			generalController.resolution = para_resolution;
			PlayerPrefs.SetString("resolution", para_resolution.width + "x" + para_resolution.height);
			generalController.fullscreen = para_fullscreen;
			if (para_fullscreen)
			{
				PlayerPrefs.SetString("fullscreen", "true");
			}
			else
			{
				PlayerPrefs.SetString("fullscreen", "false");
			}
			generalController.soundVol = para_soundVol;
			PlayerPrefs.SetString("soundVol", para_soundVol + string.Empty);
			original_soundVol = generalController.soundVol;
			generalController.musicVol = para_musicVol;
			PlayerPrefs.SetString("musicVol", para_musicVol + string.Empty);
			original_musicVol = generalController.musicVol;
			generalController.misc = para_misc;
			if (para_misc)
			{
				PlayerPrefs.SetString("misc", string.Empty);
			}
			else
			{
				PlayerPrefs.SetString("misc", "no");
			}
			generalController.cinema = para_cinema;
			if (para_cinema)
			{
				PlayerPrefs.SetString("cinema", string.Empty);
			}
			else
			{
				PlayerPrefs.SetString("cinema", "no");
			}
			generalController.vidya = para_vidya;
			if (para_vidya)
			{
				PlayerPrefs.SetString("vidya", string.Empty);
			}
			else
			{
				PlayerPrefs.SetString("vidya", "no");
			}
			generalController.animation = para_animation;
			if (para_animation)
			{
				PlayerPrefs.SetString("animation", string.Empty);
			}
			else
			{
				PlayerPrefs.SetString("animation", "no");
			}
		}
	}

	private void CancelToBack()
	{
		if (para_lang == "en")
		{
			cancel_label_text.GetComponent<Text>().text = "Back";
		}
		else
		{
			cancel_label_text.GetComponent<Text>().text = "Volver";
		}
	}

	private IEnumerator HideApplyKeys()
	{
		applyHiding = true;
		yield return new WaitForSeconds(0.2f);
		apply_label_text.GetComponent<Animator>().SetBool("visible", false);
		yield return new WaitForSeconds(0.1f);
		confirmation.GetComponent<Animator>().SetInteger("selected", 1);
		selection = "cancel";
		applyPanel.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		applyPanel.SetActive(true);
		applyHiding = false;
	}

	private IEnumerator HideApplyMouse()
	{
		applyHiding = true;
		yield return new WaitForSeconds(0.2f);
		apply_label_text.GetComponent<Animator>().SetBool("visible", false);
		yield return new WaitForSeconds(0.1f);
		confirmation.GetComponent<Animator>().SetInteger("selected", 0);
		cancel_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		apply_label_holder.GetComponent<SpriteRenderer>().color = unselectedColor;
		if (selection == "cancel")
		{
			CancelIn();
		}
		applyPanel.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		applyPanel.SetActive(true);
		applyHiding = false;
	}

	public void PolicyClick()
	{
		Application.OpenURL("https://tapcore.com/en/privacy-policy");
	}
}
