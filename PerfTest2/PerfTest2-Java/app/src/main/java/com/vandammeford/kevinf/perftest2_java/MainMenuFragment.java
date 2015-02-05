package com.vandammeford.kevinf.perftest2_java;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.net.Uri;
import android.content.Context;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TableLayout;
import android.widget.TableRow;

import java.util.ArrayList;

public class MainMenuFragment extends Fragment {

    public MainMenuFragment() {
        // Required empty public constructor
    }

    @Override
    public void onStart() {
        super.onStart();

        ListView lstMainMenu = (ListView)this.getActivity().findViewById(R.id.lstMainMenu);
        lstMainMenu.setAdapter(new MainMenuAdapter(this.getActivity()));
        lstMainMenu.setOnItemClickListener((AdapterView.OnItemClickListener)this.getActivity());
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_fragment_main_menu, container, false);
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }
}