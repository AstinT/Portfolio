package bit.tiddaj1.radiolocator;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.util.ArrayList;

public class DatabaseManager extends SQLiteOpenHelper
{
    //Database version
    private static final int DATABASE_VERSION = 1;

    //Database name
    private static final String DATABASE_NAME = "favouriteStations";

    //Favourites table name
    private static final String TABLE_FAVOURITES = "tblFavourites";

    //Table tblFavourites column names
    private static final String FAVOURITES_ID = "id";
    private static final String FAVOURITES_API_ID = "api_id";
    private static final String FAVOURITES_CALLSIGN = "callsign";
    private static final String FAVOURITES_GENRE = "genre";
    private static final String FAVOURITES_BAND = "band";
    private static final String FAVOURITES_DIAL = "dial";

    public DatabaseManager(Context context)
    {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    @Override
    //Only gets called once when table is first created
    public void onCreate(SQLiteDatabase db)
    {
        //Create table query
        String CREATE_FAVOURITES_TABLE = "CREATE TABLE " + TABLE_FAVOURITES + "("
                + FAVOURITES_ID + " INTEGER PRIMARY KEY," + FAVOURITES_API_ID + " INTEGER,"
                + FAVOURITES_CALLSIGN + " TEXT," + FAVOURITES_GENRE + " TEXT,"
                + FAVOURITES_BAND + " TEXT," + FAVOURITES_DIAL + " TEXT" + ")";

        //Execute query
        db.execSQL(CREATE_FAVOURITES_TABLE);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {
        //Nothing...
    }

    //Adds a radio station to tblFavourites
    public boolean addStation(RadioStation radioStation)
    {
        //Checks if radio station is already in the table
        //if not in db add it to database
        if(!alreadyInFavourites(radioStation))
        {
            //Connection to database
            SQLiteDatabase db = this.getWritableDatabase();

            //Add all values to a ContentVales variable
            ContentValues values = new ContentValues();
            values.put(FAVOURITES_API_ID, radioStation.getId());
            values.put(FAVOURITES_CALLSIGN, radioStation.getCallsign());
            values.put(FAVOURITES_GENRE, radioStation.getGenre());
            values.put(FAVOURITES_BAND, radioStation.getBand());
            values.put(FAVOURITES_DIAL, "" + radioStation.getDial());

            //Inserts record to database
            db.insert(TABLE_FAVOURITES, null, values);
            //Close connection
            db.close();

            //Returns true to show it was added
            return true;
        }
        else
            //Returns false to show it wasn't added
            return false;
    }

    //Deletes a single Radio Station from tblFavourites
    public void deleteStation(RadioStation station)
    {
        //Connection to database
        SQLiteDatabase db = this.getWritableDatabase();

        //Delete query
        db.delete(TABLE_FAVOURITES, FAVOURITES_API_ID + " = ?",
                new String[] { String.valueOf(station.getId()) });

        //Close connection
        db.close();
    }

    //Checks if the passed in Radio Station is already in tblFavourites
    private boolean alreadyInFavourites(RadioStation station)
    {
        //Connection to database
        SQLiteDatabase db = this.getWritableDatabase();

        //Select query with where clause
        String selectQuery = "SELECT * FROM " + TABLE_FAVOURITES
                            + " WHERE api_id='" + station.getId() + "'";

        //Execute query
        Cursor cursor = db.rawQuery(selectQuery, null);

        //If cursor.getCount is less than or equal to zero
        if(cursor.getCount() <= 0)
            //Not in db
            return false;
        else
            //Already in db
            return true;
    }

    //Gets all Radio Stations from tblFavourites
    public ArrayList<RadioStation> getAllFavouriteStations()
    {
        //Connection to database
        SQLiteDatabase db = this.getWritableDatabase();

        //New ArrayList
        ArrayList<RadioStation> radioStationArrayList = new ArrayList<>();

        //Select all query
        String selectQuery = "SELECT * FROM " + TABLE_FAVOURITES;

        //Execute query
        Cursor cursor = db.rawQuery(selectQuery, null);

        //Moves to first record
        if(cursor.moveToFirst())
        {
            do
            {
                //Grabs all data
                int apiId = cursor.getInt(1);
                String callsign = cursor.getString(2);
                String genre = cursor.getString(3);
                String band = cursor.getString(4);
                double dial = Double.parseDouble(cursor.getString(5));

                //Creates a newStation
                RadioStation newStation = new RadioStation(apiId, callsign, genre, band, dial);

                //Adds station to list
                radioStationArrayList.add(newStation);

                //Moves to next record if there is one
            } while (cursor.moveToNext());
        }

        //Returns ArrayList
        return radioStationArrayList;
    }

    //Resets tblFavourite
    public void resetTblFavourites()
    {
        //Connection to database
        SQLiteDatabase db = this.getWritableDatabase();
        //Drop query
        db.execSQL("DROP TABLE " + TABLE_FAVOURITES);
        //Calls onCreate
        onCreate(db);
    }
}