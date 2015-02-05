package com.vandammeford.kevinf.perftest2_java;

import android.app.Activity;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

public class SqLiteTableFragment extends Fragment {

    private OnFragmentInteractionListener mListener;
    private SqLiteDisplayType displayType;

    public SqLiteTableFragment() {
        // Required empty public constructor
    }

    @Override
    public void onStart() {
        super.onStart();

        ListView lstSqLiteTable = (ListView)this.getActivity().findViewById(R.id.lstSqLiteTable);
        SqLiteTableAdapter adapter = new SqLiteTableAdapter(this.getActivity(), displayType);
        lstSqLiteTable.setAdapter(adapter);
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Bundle bundle = getArguments();
        displayType = (SqLiteDisplayType)bundle.getSerializable("displayType");
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_sq_lite_table, container, false);
    }

    public void onButtonPressed(Uri uri) {
        if (mListener != null) {
            mListener.onFragmentInteraction(uri);
        }
    }

    @Override
    public void onAttach(Activity activity) {
        super.onAttach(activity);
        try {
            mListener = (OnFragmentInteractionListener) activity;
        } catch (ClassCastException e) {
            throw new ClassCastException(activity.toString()
                    + " must implement OnFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }

    public interface OnFragmentInteractionListener {
        // TODO: Update argument type and name
        public void onFragmentInteraction(Uri uri);
    }

}
