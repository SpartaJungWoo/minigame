using UnityEngine;

public static class Vibration
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass AndroidPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject AndroidcurrentActivity =
 AndroidPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject AndroidVibrator =
 AndroidcurrentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#endif
    public static void Vibrate()
    {
        Handheld.Vibrate();
    }

    public static void Vibrate(long milliseconds)
    {
        Handheld.Vibrate();
    }

    public static void Vibrate(long[] pattern, int repeat)
    {
        Handheld.Vibrate();
    }

    public static void Cancel()
    {
    }
}