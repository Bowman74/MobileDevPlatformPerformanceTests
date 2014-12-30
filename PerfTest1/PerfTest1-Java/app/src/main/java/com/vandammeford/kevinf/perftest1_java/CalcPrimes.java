package com.vandammeford.kevinf.perftest1_java;

import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;


public class CalcPrimes extends Fragment {

    public CalcPrimes() {
        // Required empty public constructor
    }

    @Override
    public void onStart() {
        super.onStart();
        Button btnCalcPrimes = (Button)this.getActivity().findViewById(R.id.btnCalcPrimes);

        btnCalcPrimes.setOnClickListener((View.OnClickListener)this.getActivity());
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_calc_primes, container, false);
    }

    @Override
    public void onDetach() {
        super.onDetach();
        Button btnCalcPrimes = (Button)this.getActivity().findViewById(R.id.btnCalcPrimes);

        if (btnCalcPrimes != null) {
            btnCalcPrimes.setOnClickListener(null);
        }
    }
}