package john.gettingimages;


import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;


public class MainActivity extends AppCompatActivity {


    Intent intent = new Intent();
    intent.setType("image/*");
    intent.setAction(Intent.ACTION_GET_CONTENT);
    startActivityForResult(Intent.createChooser(intent, "Select Picture"), PICK_IMAGE);
}
