package bit.tiddaj1.radiolocator;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.location.Criteria;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

public class LocatorActivity extends AppCompatActivity
{
    //Constants
    private final String PD_TITLE = "Searching";
    private final String PD_MESSAGE = "Finding radio stations...";
    private final String NO_STATIONS = "No radio stations found at that location.";

    //Global Fields
    private LocationManager lm;
    private String provider;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_locator);

        //GPS setup
        SetupLocationManager();

        //Reference to ImageView
        ImageView ivRadioTower = (ImageView) findViewById(R.id.ivRadioTower);
        //Setting ImageView's OnClickListener
        ivRadioTower.setOnClickListener(new searchStationsHandler());
    }

    //OnClickListener for ImageView
    public class searchStationsHandler implements View.OnClickListener
    {
        @Override
        //When button clicked
        public void onClick(View v)
        {
            //Get current latitude and longitude
            LatLng currLatLng = getCurrentLatLng(lm, provider);

            //New AsyncRadioSearchAPI
            AsyncRadioSearchAPI APIThread = new AsyncRadioSearchAPI();

            //Starting Async thread
            //Pass LatLng to Async
            APIThread.execute(currLatLng);
        }
    }

    //Sets up necessary gps components
    public void SetupLocationManager()
    {
        lm = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
        Criteria defaultCri = new Criteria();
        provider = lm.getBestProvider(defaultCri, false);
        lm.requestLocationUpdates(provider, 500, 1, new gpsLocationListener());
    }

    //Returns the current latitude and longitude
    public LatLng getCurrentLatLng(LocationManager locationManager, String provider)
    {
        //Read location
        Location currLoc = locationManager.getLastKnownLocation(provider);

        //Pull latitude and longitude from currLoc
        double lat = currLoc.getLatitude();
        double lng = currLoc.getLongitude();

        //Return LatLng
        return new LatLng(lat, lng);
    }

    //Async call to OnRad.io API
    //Documentation: https://docs.google.com/document/d/12HNoXI-z40QLQiSi30g2qSWb8U9YbMd4u5_jrre-YTw/edit
    public class AsyncRadioSearchAPI extends AsyncTask<LatLng, Void, String>
    {
        //Instance of ProgressDialog
        ProgressDialog asyncProgressDialog = new ProgressDialog(LocatorActivity.this);

        @Override
        //Before async starts
        protected void onPreExecute()
        {
            //Set title
            asyncProgressDialog.setTitle(PD_TITLE);
            //Set message
            asyncProgressDialog.setMessage(PD_MESSAGE);
            //Show dialog
            asyncProgressDialog.show();
        }

        @Override
        protected String doInBackground(LatLng... params)
        {
            //String to be returned
            String JSONString = null;

            //Gets current LatLng from params
            LatLng currLoc = params[0];

            //Builds url string using the current location
            String urlString = buildOnRadAPIURLString(currLoc);

            //Gets the Json from the previously built url
            JSONString = getJSONFromUrl(urlString);

            //Returns JSON blob
            return JSONString;
        }

        @Override
        protected void onPostExecute (String fetchedString)
        {
            //Dismiss dialog
            asyncProgressDialog.dismiss();

            //Check here if JSON has data
            //if it does...
            if(JSONHasData(fetchedString))
            {
                //Get all Radio station data out of JSON
                ArrayList<RadioStation> radioStationList = getRadioStationList(fetchedString);

                //Create new intent
                Intent listStations = new Intent(LocatorActivity.this, FoundStationsActivity.class);

                //Attach radio station list to intent
                listStations.putParcelableArrayListExtra("stations", radioStationList);

                //Start intent
                startActivity(listStations);
            }
            else
            {
                //Message to user if no radio stations found
                Toast.makeText(LocatorActivity.this, NO_STATIONS, Toast.LENGTH_SHORT).show();
            }
        }

        //Checks the success flag in the JSON data
        public boolean JSONHasData(String fetchedString)
        {
            boolean success = false;

            try
            {
                //Walk through to success flag
                JSONObject data = new JSONObject(fetchedString);
                success = data.getBoolean("success");
            }
            //Lazy exception handling...
            catch(Exception e) {e.printStackTrace();}

            //Return success
            return success;
        }

        //Builds and returns the URL string used for fetching the data
        public String buildOnRadAPIURLString(LatLng currLoc)
        {
            //URL request to grab radio stations using latitude and longitude
            String urlString = "http://api.dar.fm/darstations.php?" +
                               "&latitude=" + currLoc.getLat() +
                               "&longitude=" + currLoc.getLng() +
                               "&partner_token=KEY GOES HERE" +
                               "&callback=json";

            return urlString;
        }

        //Gets JSON from a specified url and returns it
        public String getJSONFromUrl(String urlString)
        {
            //Declare so its not local to try block
            String JSONString = null;

            try
            {
                //Converts urlString to URL object
                URL URLObject = new URL(urlString);

                //Create HttpURLConnection object via openConnection command of URLObject
                HttpURLConnection connection = (HttpURLConnection) URLObject.openConnection();

                //Send the url
                connection.connect();

                //int responseCode = connection.getResponseCode();

                //Get an InputStream from the HttpURLConnection object
                InputStream inputStream = connection.getInputStream();
                InputStreamReader inputStreamReader = new InputStreamReader(inputStream);
                //Set up a BufferedReader
                BufferedReader bufferedReader = new BufferedReader(inputStreamReader);

                //Read the input
                String responseString;
                StringBuilder stringBuilder = new StringBuilder();
                while ((responseString = bufferedReader.readLine()) != null)
                {
                    stringBuilder = stringBuilder.append(responseString);
                }

                //JSONString now holds input
                JSONString = stringBuilder.toString();
            }
            //Lazy exception handling...
            catch(Exception e) {e.printStackTrace();}

            return JSONString;
        }

        //Walks through the fetched JSON string and pulls out the radio stations
        public ArrayList<RadioStation> getRadioStationList(String JSONString)
        {
            ArrayList<RadioStation> radioStationList = new ArrayList<>();

            try
            {
                //Walk through JSON
                JSONObject data = new JSONObject(JSONString);
                JSONArray result = data.getJSONArray("result");
                JSONObject resultObject = result.getJSONObject(0);
                JSONArray stations = resultObject.getJSONArray("stations");

                //Loop over station array
                for (int i = 0; i < stations.length(); i++)
                {
                    //Get JSON objec from stations array
                    JSONObject station = stations.getJSONObject(i);

                    //Grab the station data I want
                    int id = station.optInt("station_id");
                    String callsign = station.optString("callsign");
                    String genre = station.optString("ubergenre");
                    String band = station.optString("band");
                    double dial = station.optDouble("dial");

                    //Create new RadioStation object
                    RadioStation newStation = new RadioStation(id, callsign, genre, band, dial);

                    //Add to list
                    radioStationList.add(newStation);
                }
            }
            //Lazy exception handling...
            catch (Exception e){e.printStackTrace();}

            //Return list
            return radioStationList;
        }
    }

    @Override
    //Create tool bars
    public boolean onCreateOptionsMenu(Menu menu)
    {
        MenuInflater menuInflater = getMenuInflater();
        //inflates from menu_fav_layout
        menuInflater.inflate(R.menu.menu_fav_layout, menu);

        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        //Get selected item title
        String itemTitle = (String) item.getTitle();

        //Checks on the selected item title
        switch (itemTitle)
        {
            case "favourite":

                //Create new intent
                //Goes to favourites
                Intent favouriteStations = new Intent(LocatorActivity.this, FavouriteStationsActivity.class);

                //Start activity
                startActivity(favouriteStations);
                break;
        }

        return true;
    }

    //This class for the emulator to work.
    private class gpsLocationListener implements LocationListener
    {
        @Override
        public void onLocationChanged(Location location)
        {
            //Toast to confirm Latitude and Longitude have been changed
            Toast.makeText(LocatorActivity.this, "Changed Lat and Lon", Toast.LENGTH_SHORT).show();
        }

        @Override
        public void onStatusChanged(String provider, int status, Bundle extras)
        {
        }

        @Override
        public void onProviderEnabled(String provider)
        {
        }

        @Override
        public void onProviderDisabled(String provider)
        {
        }
    }
}
