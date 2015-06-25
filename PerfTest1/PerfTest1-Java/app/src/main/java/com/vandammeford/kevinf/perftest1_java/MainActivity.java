package com.vandammeford.kevinf.perftest1_java;

import android.app.ActionBar;
import android.app.Activity;
import android.app.AlertDialog;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.ListView;

import com.microsoft.windowsazure.mobileservices.*;
import java.net.MalformedURLException;
import java.util.ArrayList;
import java.util.List;


public class MainActivity extends Activity implements View.OnClickListener  {

    private MobileServiceClient mobileServicesClient;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getActionBar() != null)
        {
            getActionBar().setNavigationMode(ActionBar.NAVIGATION_MODE_TABS);
        }
        setContentView(R.layout.activity_main);

        ActionBar.TabListener tabListener = new MainTabListener();

        ActionBar.Tab tab = getActionBar().newTab();
        tab.setText("Azure List");
        tab.setTabListener(tabListener);
        getActionBar().addTab(tab);

        tab = getActionBar().newTab();
        tab.setText("Calc Primes");
        tab.setTabListener(tabListener);
        getActionBar().addTab(tab);

        try {
            mobileServicesClient = new MobileServiceClient(
                    "https://malor2014jsmobileservice.azure-mobile.net/",
                    "pdFskoBXcwzaDNTpuRWdVRhUIRYcFF14",
                    this
            );
        } catch (MalformedURLException ex) {
            // Demo code, no need to handle.
        }
    }

    @Override
    public void onClick(View view) {
        if (view != null)
        {
            if (view.getId() == R.id.btnCalcPrimes)
            {
                this.calcPrimes();
            } else if (view.getId() == R.id.btnClear) {
                this.clearList();
            } else if (view.getId() == R.id.btnFetch) {
                this.fillList();
            }
        }
    }

    private void fillList() {

        mobileServicesClient.getTable(Registration.class).top(1000).execute(new TableQueryCallback<Registration>() {
               @Override
               public void onCompleted(List<Registration> result, int count, Exception exception,
                                       ServiceFilterResponse response) {
             final List<Registration> registrations = result;
             runOnUiThread(new Runnable() {
                       @Override
                       public void run() {
                           resetList(registrations);
                       }
                   });
               }
            }
        );
    }

    private void resetList(List<Registration> registrations) {
        ListView lstRegistrations = (ListView)this.findViewById(R.id.lstRegistrations);
        if (lstRegistrations != null) {
            ((RegistrationAdapter)lstRegistrations.getAdapter()).setRegistrations(registrations);
            ((RegistrationAdapter) lstRegistrations.getAdapter()).notifyDataSetChanged();
        }
    }

    private void clearList() {
        resetList(new ArrayList<Registration>());
    }

    private void calcPrimes() {
        EditText txtMaxPrime = (EditText)this.findViewById(R.id.txtMaxPrime);
        try
        {
            int maxValue = Integer.parseInt(txtMaxPrime.getText().toString());
            int maxPrime = getPrimesFromSieve(maxValue);

            AlertDialog.Builder dlgAlert  = new AlertDialog.Builder(this);
            dlgAlert.setMessage("Largest prime found: " + maxPrime);
            dlgAlert.setTitle("Prime Calculation Complete");
            dlgAlert.setPositiveButton("OK", null);
            dlgAlert.setCancelable(true);
            dlgAlert.create().show();                }
        catch(NumberFormatException nfe)
        {
            AlertDialog.Builder dlgAlert  = new AlertDialog.Builder(this);
            dlgAlert.setMessage("Must enter a numeric max value: " + txtMaxPrime.getText().toString());
            dlgAlert.setTitle("Prime Calculation Error");
            dlgAlert.setPositiveButton("OK", null);
            dlgAlert.setCancelable(true);
            dlgAlert.create().show();
        }
    }

    private int getPrimesFromSieve(int maxValue)
    {
        byte[] primes = new byte[maxValue + 1];
        for (int i = 0; i <=maxValue; i++)
        {
            primes[i] = 0;
        }
        int largestPrimeFound = 1;

        for (int i = 2; i <=maxValue; i++)
        {
            if (primes[i - 1] == 0)
            {
                primes[i - 1] = 1;
                largestPrimeFound = i;
            }

            int c = 2;
            int mul = i*c;
            for (; mul <= maxValue;)
            {
                primes[mul - 1] = 1;
                c++;
                mul = i*c;
            }
        }
        return largestPrimeFound;
    }
}
