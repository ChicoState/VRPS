package com.Our430Company.TestProgram;

/**
 * Created by John on 10/4/2016.
 */
import android.content.Context;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;


public class MainActivity extends AppCompatActivity {
    public final static String EXTRA_MESSAGE = "com.example.app.message";
    public final static String FILE_NAME = "config";

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
       // if(!fileExists(FILE_NAME))
         //   new File(this.getFilesDir(),FILE_NAME);
        getFragmentManager().beginTransaction()
                .replace(android.R.id.content, new SettingsFragment())
                .commit();
      // setContentView(R.layout.activity_main);
    }

    public void startUnity() {
        Intent intent = new Intent(this, UnityPlayerActivity.class);
        startActivity(intent);
    }


 /*   public void sendMessage(View view) {
        Intent intent = new Intent(this, DisplayMessageActivity.class);
        EditText editText = (EditText) findViewById(R.id.edit_message);
        String message = editText.getText().toString();
        intent.putExtra(EXTRA_MESSAGE,message);
        startActivity(intent);
    }
    public boolean fileExists(String filename){
        File file = getBaseContext().getFileStreamPath(filename);
        return file.exists();
    }*/
}