package com.vandammeford.kevinf.perftest1_java;

/**
 * Created by KevinF on 12/12/2014.
 */
public class Registration {

    @com.google.gson.annotations.SerializedName("screenname")
    private String screenName;

    @com.google.gson.annotations.SerializedName("id")
    private String id;

    @com.google.gson.annotations.SerializedName("email")
    private String eMail;

    @com.google.gson.annotations.SerializedName("birthdate")
    private String birthDate;

    @com.google.gson.annotations.SerializedName("gender")
    private int gender;

    @com.google.gson.annotations.SerializedName("zip")
    private String zip;
    /**
     * ToDoItem constructor
     */
    public Registration() {

    }

    @Override
    public String toString() {
        return getScreenName();
    }

    public String getScreenName() {
        return this.screenName;
    }

    public final void setScreenName(String screenName) {
        this.screenName = screenName;
    }

    public String getId() {
        return this.id;
    }

    public final void setId(String id) {
        this.id = id;
    }
    public String geteMail() {
        return this.eMail;
    }

    public final void seteMail(String eMail) {
        this.eMail = eMail;
    }

    public String getBirthDate() {
        return this.birthDate;
    }

    public final void setBirthDate(String birthDate) {
        this.birthDate = birthDate;
    }

    public int getGender() {
        return this.gender;
    }

    public final void setGender(int gender) {
        this.gender = gender;
    }

    public String getZip() {
        return this.zip;
    }

    public final void setZip(String zip) {
        this.zip = zip;
    }

    @Override
    public boolean equals(Object o) {
        return o instanceof Registration && ((Registration) o).id == this.id;
    }
}
