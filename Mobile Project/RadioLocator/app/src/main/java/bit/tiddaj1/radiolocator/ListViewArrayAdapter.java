package bit.tiddaj1.radiolocator;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;

//Array adapter for ListViews on FavouriteStationsActivity and FoundStationsActivity
public class ListViewArrayAdapter extends ArrayAdapter<RadioStation>
{
    //Constructor
    public ListViewArrayAdapter(Context context, int resource, ArrayList<RadioStation> radioStationArrayList)
    {
        super(context, resource, radioStationArrayList);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup container)
    {
        //Get an inflater from the activity
        LayoutInflater inflater = LayoutInflater.from(getContext());

        //Inflate custom view
        View customView = inflater.inflate(R.layout.custom_listview_item, container, false);

        //Reference to TextView
        TextView tvItemCallsign = (TextView) customView.findViewById(R.id.tvItemCallsign);
        TextView tvItemDial = (TextView) customView.findViewById(R.id.tvItemDial);

        //Get the current input item from the array
        RadioStation currentItem = getItem(position);

        //Use radiostation callsign to set text
        tvItemCallsign.setText(currentItem.getCallsign());
        tvItemDial.setText(Double.toString(currentItem.getDial()));

        //Return the view
        return customView;
    }
}
