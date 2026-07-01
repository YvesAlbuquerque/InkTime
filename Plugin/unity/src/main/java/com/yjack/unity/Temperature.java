package com.yjack.unity;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.BatteryManager;

public class Temperature
{
    private Context context;
    static public int temperature;

    public Temperature(Context context)
    {
        this.context=context;
        BroadcastReceiver batteryInfoReceiver = new BroadcastReceiver()
        {
            @Override
            public void onReceive(Context context, Intent intent)
            {
                updateTemperature(intent);
            }
        };
        loadBatterySection(batteryInfoReceiver);
    }

    private void loadBatterySection(BroadcastReceiver batteryInfoReceiver)
    {
        IntentFilter intentFilter = new IntentFilter();
        intentFilter.addAction(Intent.ACTION_BATTERY_CHANGED);
        context.registerReceiver(batteryInfoReceiver, intentFilter);
    }

    private void updateTemperature (Intent intent)
    {
        temperature = intent.getIntExtra(BatteryManager.EXTRA_TEMPERATURE, -1);
    }
}