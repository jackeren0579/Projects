package data;

public class StaffJobTitle {

    float creditLimit;

    //Constructor for reading creditLimit
    public StaffJobTitle(float creditLimit) {
        this.creditLimit = creditLimit;
    }

    @Override
    public String toString() {
        return creditLimit + "";
    }
}
