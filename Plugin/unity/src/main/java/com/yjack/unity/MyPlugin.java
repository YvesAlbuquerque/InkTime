package com.yjack.unity;
import android.util.Log;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.BatteryManager;
import com.unity3d.player.UnityPlayer;

public class MyPlugin
{
    private static final MyPlugin ourInstance = new MyPlugin();
    private static final String LOGTAG = "YJack";

    public static MyPlugin getInstance()
    {
        return ourInstance;
    }

    private MyPlugin()
    {
        Log.i(LOGTAG, "Created MyPlugin");
        new Temperature(getCurrentContext());
    }

    public int getTemperature()
    {
        return Temperature.temperature;
    }


    public static Context getCurrentContext()
    {
        Context context = null;
        context = UnityPlayer.currentActivity;

        return context;
    }
}