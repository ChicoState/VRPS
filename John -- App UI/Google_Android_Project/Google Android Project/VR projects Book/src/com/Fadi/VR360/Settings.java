package com.Fadi.VR360;

import android.os.Bundle;
import android.preference.PreferenceFragment;

/**
 * Created by John on 10/9/2016.
 */

public class Settings extends PreferenceFragment {
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        addPreferencesFromResource(R.xml.preferences);
    }
}
