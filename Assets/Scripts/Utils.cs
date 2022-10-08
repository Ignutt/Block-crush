using UnityEngine;

public static class Utils
{
    public static string MusicPlayerPrefsKey = "MusicValue";
    public static string AudioMixerMusicProp = "Music";

    public static float MusicValue => PlayerPrefs.GetFloat(Utils.MusicPlayerPrefsKey);
}
