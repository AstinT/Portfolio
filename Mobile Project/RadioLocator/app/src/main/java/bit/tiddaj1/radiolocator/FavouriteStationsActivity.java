package bit.tiddaj1.radiolocator;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;

public class FavouriteStationsActivity extends AppCompatActivity
{
    //Global fields
    private ArrayList<RadioStation> radioStationArrayList;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_favourites);

        //Initialise ArrayList
        radioStationArrayList = new ArrayList<>();

        //Sets up ListView
        SetupListView();
    }

    @Override
    //Gets called when returning from StationDetailActivity
    protected void onResume()
    {
        super.onResume();

        //Sets up ListView again incase a station has been deleted
        SetupListView();
    }

    //Sets up the ListView of radio stations
    public void SetupListView()
    {
        //DatabaseManager instance
        DatabaseManager dbManager = new DatabaseManager(this);

        //Gets ArrayList of favourite stations
        radioStationArrayList = dbManager.getAllFavouriteStations();

        //Create adapter
        ListViewArrayAdapter radioStationAdapter = new ListViewArrayAdapter(this,
                                                                            R.layout.custom_listview_item,
                                                                            radioStationArrayList);

        //Reference to ListView lvFavouritesStations
        ListView lvFavourites = (ListView) findViewById(R.id.lvFavouriteStations);
        //Sets onItemClickListener
        lvFavourites.setOnItemClickListener(new listViewItemHandler());
        //Sets adapter
        lvFavourites.setAdapter(radioStationAdapter);

        //Display toast if there are no radio stations in the ArrayList
        if(radioStationArrayList.isEmpty())
        {
            Toast.makeText(FavouriteStationsActivity.this, "No radio stations in favourites!", Toast.LENGTH_SHORT).show();
        }
    }

    public class listViewItemHandler implements AdapterView.OnItemClickListener
    {
        //When list item is selected
        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id)
        {
            //New intent
            Intent station = new Intent(FavouriteStationsActivity.this, StationDetailActivity.class);

            //Grab the selected station
            RadioStation selectedStation = radioStationArrayList.get(position);

            //Attach selected station to intent
            station.putExtra("station", selectedStation);

            station.putExtra("flag", "FavouriteListActivity");

            //Start intent
            startActivity(station);
        }
    }
}
