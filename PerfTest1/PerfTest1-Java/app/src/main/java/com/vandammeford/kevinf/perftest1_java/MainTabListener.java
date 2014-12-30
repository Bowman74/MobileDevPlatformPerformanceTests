package com.vandammeford.kevinf.perftest1_java;

import android.app.ActionBar;
import android.app.Fragment;
import android.app.FragmentTransaction;
import android.widget.Button;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by KevinF on 12/12/2014.
 */
public class MainTabListener implements ActionBar.TabListener {
    Fragment currentFragment;

    public MainTabListener() {
    }

    @Override
    public void onTabSelected(ActionBar.Tab tab, FragmentTransaction fragmentTransaction) {
        currentFragment = null;
        if (tab.getPosition() == 0) {
            currentFragment = new AzureList();
            fragmentTransaction.replace(R.id.main_area, currentFragment);
        } else if (tab.getPosition() == 1){
            currentFragment = new CalcPrimes();
            fragmentTransaction.replace(R.id.main_area, currentFragment);
        }
    }

    @Override
    public void onTabUnselected(ActionBar.Tab tab, FragmentTransaction fragmentTransaction) {
        fragmentTransaction.remove(currentFragment);
    }

    @Override
    public void onTabReselected(ActionBar.Tab tab, FragmentTransaction fragmentTransaction) {

    }
}