package bit.tiddaj1.radiolocator;

//Holds the latitude and longitude
public class LatLng
{
    //Fields
    private double lat;
    private double lng;

    //Constructor
    public LatLng(double lat, double lng)
    {
        this.lat = lat;
        this.lng = lng;
    }

    //Get latitude
    public double getLat()
    {
        return lat;
    }

    //Get longitude
    public double getLng()
    {
        return lng;
    }
}
