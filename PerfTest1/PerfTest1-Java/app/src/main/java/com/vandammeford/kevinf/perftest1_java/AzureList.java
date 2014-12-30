package com.vandammeford.kevinf.perftest1_java;

import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ListView;

import java.util.ArrayList;


public class AzureList extends Fragment {

    public AzureList() {
        // Required empty public constructor
    }

    @Override
    public void onStart() {
        super.onStart();
        Button btnClear = (Button)this.getActivity().findViewById(R.id.btnClear);
        Button btnFetch = (Button)this.getActivity().findViewById(R.id.btnFetch);

        btnClear.setOnClickListener((View.OnClickListener)this.getActivity());
        btnFetch.setOnClickListener((View.OnClickListener) this.getActivity());

        ListView lstRegistrations = (ListView)this.getActivity().findViewById(R.id.lstRegistrations);
        lstRegistrations.setAdapter(new RegistrationAdapter(this.getActivity(), new ArrayList<Registration>()));
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_azure_list, container, false);
    }

    @Override
    public void onDetach() {
        super.onDetach();
        Button btnClear = (Button)this.getActivity().findViewById(R.id.btnClear);
        Button btnFetch = (Button)this.getActivity().findViewById(R.id.btnFetch);

        if (btnClear != null) {
            btnClear.setOnClickListener(null);
        }
        if (btnFetch != null) {
            btnFetch.setOnClickListener(null);
        }
    }
}
