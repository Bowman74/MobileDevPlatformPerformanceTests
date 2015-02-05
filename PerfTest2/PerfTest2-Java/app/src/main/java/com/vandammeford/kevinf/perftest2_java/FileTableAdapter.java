package com.vandammeford.kevinf.perftest2_java;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;

public class FileTableAdapter extends BaseAdapter {
    private Context context;
    private ArrayList<String> lines;

    public FileTableAdapter(Context context)
    {
        this.context = context;
        loadLines();
    }

    private void loadLines() {
        FileUtilities utilities;

        utilities = new FileUtilities(this.context);
        try {
            lines = utilities.readFileContents();
        } catch (Exception ex) {

        }
    }

    @Override
    public int getCount() {
        return lines.size();
    }

    @Override
    public Object getItem(int item) {
        // TODO Auto-generated method stub
        return lines.get(item);
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
        txtItem.setText(lines.get(position));

        return convertView;
    }
}