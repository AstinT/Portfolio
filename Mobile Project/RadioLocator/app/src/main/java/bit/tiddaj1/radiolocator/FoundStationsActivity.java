package bit.tiddaj1.radiolocator;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import java.util.ArrayList;

public class FoundStationsActivity extends AppCompatActivity
{
    //Global fields
    private ArrayList<RadioStation> radioStationArrayList;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_station_list);

        //Reference to listview lvStationList
        ListView stationListView = (ListView) findViewById(R.id.lvStationList);

        //Get previous intent
        Intent locator = getIntent();
        //Grab radio station array list out of intent
        radioStationArrayList = locator.getParcelableArrayListExtra("stations");

        //Create adapter
        ListViewArrayAdapter radioStationAdapter = new ListViewArrayAdapter(this,
                                                                            R.layout.custom_listview_item,
                                                                            radioStationArrayList);

        //Set adapter
        stationListView.setAdapter(radioStationAdapter);

        //Set onItemClickListener
        stationListView.setOnItemClickListener(new listViewItemHandler());
    }

    public class listViewItemHandler implements AdapterView.OnItemClickListener
    {
        //When list item is selected
        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id)
        {
            //New intent
            Intent station = new Intent(FoundStationsActivity.this, StationDetailActivity.class);

            //Grab the selected station
            RadioStation selectedStation = radioStationArrayList.get(position);

            //Attach selected station to intent
            station.putExtra("station", selectedStation);

            station.putExtra("flag", "StationListActivity");

            //Start intent
            startActivity(station);
        }
    }
}
