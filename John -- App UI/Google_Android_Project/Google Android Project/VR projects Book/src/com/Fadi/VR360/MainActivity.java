package com.Fadi.VR360;

import android.app.Activity;
import android.os.Bundle;

/**
 * Created by John on 10/9/2016.
 */

public class MainActivity extends Activity {
    @Override
    protected void  onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        getFragmentManager().beginTransaction()
                .replace(android.R.id.content, new Settings())
                .commit();
            }
    }

