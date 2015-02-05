package com.vandammeford.kevinf.perftest2_java;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

public class MainMenuAdapter extends BaseAdapter {
    private Context context;
    private String[] myMenuItems = new String[6];

    public final int CLEAN_UP_TEST = 0;
    public final int ADD_SQL_RECORDS = 1;
    public final int DISPLAY_ALL_RECORDS = 2;
    public final int DISPLAY_RECORDS_WITH_WHERE = 3;
    public final int SAVE_LARGE_FILE = 4;
    public final int DISPLAY_LARGE_FILE = 5;

    public MainMenuAdapter(Context context)
    {
        this.context = context;
        myMenuItems[CLEAN_UP_TEST] = "Clean up and prepare for tests";
        myMenuItems[ADD_SQL_RECORDS] = "Add 1,000 records to SQLite";
        myMenuItems[DISPLAY_ALL_RECORDS] = "Display all records";
        myMenuItems[DISPLAY_RECORDS_WITH_WHERE] = "Display all records that contain 1";
        myMenuItems[SAVE_LARGE_FILE] = "Save large file";
        myMenuItems[DISPLAY_LARGE_FILE] = "Load and display large file";
    }

    @Override
    public int getCount() {
        return myMenuItems.length;
    }

    @Override
    public Object getItem(int item) {
        // TODO Auto-generated method stub
        return myMenuItems[item];
    }

    @Override
    public long getItemId(int position) {
        // TODO Auto-generated method stub
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup viewGroup) {

        if(convertView == null)
        {
            LayoutInflater inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(android.R.layout.simple_list_item_1, null);
        }

        TextView txtItem = (TextView)convertView.findViewById(android.R.id.text1);
        txtItem.setText(myMenuItems[position]);

        return convertView;
    }
}
