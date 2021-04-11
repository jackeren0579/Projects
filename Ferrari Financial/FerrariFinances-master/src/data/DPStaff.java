package data;

public class DPStaff {

    //Variables
    String fName;
    String lName;

    //Constructor for reading staff name
    public DPStaff(String fName, String lName) {
        this.fName = fName;
        this.lName = lName;
    }

    @Override
    public String toString() {
        return fName + " " + lName;
    }
}
