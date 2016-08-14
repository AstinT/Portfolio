package bit.tiddaj1.radiolocator;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.TextView;
import android.widget.Toast;

public class StationDetailActivity extends AppCompatActivity
{
    //Global fields
    private DatabaseManager dbManager;
    private RadioStation currentStation;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_station_detail);

        //Instance of database manager
        dbManager = new DatabaseManager(this);

        //Get previous intent
        Intent stationList = getIntent();

        //Grab passed radio station
        currentStation = stationList.getParcelableExtra("station");

        //Loads all text boxes
        loadStation(currentStation);
    }

    //Load up text views with station information
    private void loadStation(RadioStation radioStation)
    {
        //Get references
        TextView tvIDValue = (TextView) findViewById(R.id.tvIDValue);
        TextView tvCallsignValue = (TextView) findViewById(R.id.tvCallsignValue);
        TextView tvGenreValue = (TextView) findViewById(R.id.tvGenreValue);
        TextView tvBandValue = (TextView) findViewById(R.id.tvBandValue);
        TextView tvDialValue = (TextView) findViewById(R.id.tvDialValue);

        //Set text
        tvIDValue.setText("" + radioStation.getId());
        tvCallsignValue.setText(radioStation.getCallsign());
        tvGenreValue.setText(radioStation.getGenre());
        tvBandValue.setText(radioStation.getBand());
        tvDialValue.setText("" + radioStation.getDial());
    }

    @Override
    //Create tool bars
    public boolean onCreateOptionsMenu(Menu menu)
    {
        //Get menu inflater
        MenuInflater menuInflater = getMenuInflater();

        //Get previous intent
        Intent previousIntent = getIntent();

        //Get flag
        String flag = previousIntent.getStringExtra("flag");

        //Check what flag has been passed over
        //Inddicates what was the last activity
        //Came from StationListActivity
        if(flag.equals("StationListActivity"))
        {
            //inflates from the xml I created
            menuInflater.inflate(R.menu.menu_add_layout, menu);
        }

        //Came from FavouriteListActivity
        if(flag.equals("FavouriteListActivity"))
        {
            //inflates from the xml I created
            menuInflater.inflate(R.menu.menu_delete_layout, menu);
        }

        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        //Gets selected
        String itemTitle = (String) item.getTitle();

        if(itemTitle != null)
        {
            //Checks on the selected item title
            switch (itemTitle)
            {
                //Add button
                case "add":
                    //Trys to add currentStation to database
                    //Gets a boolean back indicating if it was add or not
                    boolean addStatus = dbManager.addStation(currentStation);

                    //If it was added
                    if(addStatus)
                        Toast.makeText(StationDetailActivity.this, "Radio station added to favourites!", Toast.LENGTH_SHORT).show();
                    //If it wasn't added
                    else
                        Toast.makeText(StationDetailActivity.this, "Radio station already in favourites!", Toast.LENGTH_SHORT).show();
                    break;

                //Delete button
                case "delete":
                    Toast.makeText(StationDetailActivity.this, "Deleted", Toast.LENGTH_SHORT).show();
                    //Delete radio station
                    dbManager.deleteStation(currentStation);
                    //Return to last activity
                    finish();
                    break;
            }
        }
        //If it is null, back button was pressed
        else
        {
            //Closes current activity
            //For the back navigation
            finish();
        }

        return true;
    }
}
