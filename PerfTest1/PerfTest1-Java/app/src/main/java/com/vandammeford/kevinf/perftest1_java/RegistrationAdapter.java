package com.vandammeford.kevinf.perftest1_java;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

/**
 * Created by KevinF on 12/12/2014.
 */
public class RegistrationAdapter extends BaseAdapter {
    private Context context;

    private List<Registration> registrations;

    public RegistrationAdapter(Context context, List<Registration> registrations)
    {
        this.context = context;
        this.registrations = registrations;
    }

    public final void setRegistrations(List<Registration> registrations) {
        this.registrations = registrations;
    }

    @Override
    public int getCount() {
        return registrations.size();
    }

    @Override
    public Object getItem(int item) {
        // TODO Auto-generated method stub
        return registrations.get(item);
    }

    @Override
    public long getItemId(int position) {
        // TODO Auto-generated method stub
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup viewGroup) {

        Registration entry = registrations.get(position);

        if(convertView == null)
        {
            LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(android.R.layout.simple_list_item_1, null);
        }

        TextView txtItem = (TextView)convertView.findViewById(android.R.id.text1);
        txtItem.setText(entry.getScreenName());

        return convertView;
    }
}
