package com.vandammeford.kevinf.perftest2_java;

import android.content.Context;
import android.os.Environment;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.util.ArrayList;

/**
 * Created by KevinF on 1/16/2015.
 */
public class FileUtilities {

    private String filePath;
    BufferedWriter fileHandle;
    Context context;
    File textFile;

    public FileUtilities(Context context) {
        this.context = context;
        String filePath = context.getExternalFilesDir(Environment.DIRECTORY_DOWNLOADS) + File.separator + "testFile.txt";
        textFile = new File(filePath);
    }

    public void openFile() throws Exception {
        fileHandle = new BufferedWriter(new FileWriter(textFile));
    }

    public void closeFile() throws Exception {
        if (fileHandle != null) {
            fileHandle.close();
            fileHandle = null;
        }
    }

    public void deleteFile() {
        if (textFile.exists()) {
            textFile.delete();
        }
    }

    public void createFile() throws Exception {
        if (!textFile.exists()) {
            textFile.createNewFile();
        }
    }

    public void writeLineToFile(String line) throws Exception {
        if (!textFile.exists()) {
            this.createFile();
        }
        if (fileHandle == null) {
            this.openFile();
        }

        fileHandle.write(line);
    }

    public ArrayList<String> readFileContents() throws Exception {

        BufferedReader reader = new BufferedReader(new FileReader(textFile));
        String line;
        ArrayList<String> returnValue = new ArrayList<String>();

        while((line = reader.readLine()) != null){
            returnValue.add(line);
        }
        reader.close();
        return returnValue;
    }
}