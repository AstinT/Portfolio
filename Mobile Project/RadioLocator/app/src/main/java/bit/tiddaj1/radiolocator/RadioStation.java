package bit.tiddaj1.radiolocator;

import android.os.Parcel;
import android.os.Parcelable;

public class RadioStation implements Parcelable
{
    private static final String UNKNOWN = "Unknown";

    private int id;
    private String callsign;
    private String genre;
    private String band;
    private double dial;

    public RadioStation(int id, String callsign, String genre, String band, double dial)
    {
        this.id = id;

        if(callsign == null)
            this.callsign = UNKNOWN;
        else
            this.callsign = callsign.substring(0, 4);

        if(genre == null)
            this.genre = UNKNOWN;
        else
            this.genre = genre;

        if(band == null)
            this.band = UNKNOWN;
        else
            this.band = band.toUpperCase();

        this.dial = dial;
    }

    public RadioStation(Parcel source)
    {
        id = source.readInt();
        callsign = source.readString();
        genre = source.readString();
        band = source.readString();
        dial = source.readDouble();
    }

    @Override
    public int describeContents()
    {
        return this.hashCode();
    }

    @Override
    public void writeToParcel(Parcel dest, int flags)
    {
        dest.writeInt(id);
        dest.writeString(callsign);
        dest.writeString(genre);
        dest.writeString(band);
        dest.writeDouble(dial);
    }

    public static final Parcelable.Creator<RadioStation> CREATOR = new Parcelable.Creator<RadioStation>()
    {
        @Override
        public RadioStation createFromParcel(Parcel in)
        {
            return new RadioStation(in);
        }

        @Override
        public RadioStation[] newArray(int size)
        {
            return new RadioStation[size];
        }
    };

    //Get id
    public int getId()
    {
        return id;
    }

    //Set id
    public void setId(int id)
    {
        this.id = id;
    }

    //Get callsign
    public String getCallsign()
    {
        return callsign;
    }

    //Get genre
    public String getGenre()
    {
        return genre;
    }

    //Get band
    public String getBand()
    {
        return band;
    }

    //Get dial
    public double getDial()
    {
        return dial;
    }
}
