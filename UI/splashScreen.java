package com.example.vrps;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;


/**
 * Created by Erina Dominick on 10/18/16.
 */

public class splashScreen extends Activity
{
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.splash);

        Thread timerThread = new Thread() {
            public void run() {
                try {
                    sleep(3000);
                } catch (InterruptedException iE) {
                    iE.printStackTrace();
                } finally {
                    Intent intent = new Intent(splashScreen.this, MainActivity.class);
                    startActivity(intent);
                }
            }
        };
        timerThread.start();
    }

    @Override
    protected void onPause()
    {
        super.onPause();
        finish();
    }
}
