package data;

public class FFCustomer {

    //Variables
    int i;
    String customerID;
    String f_Name;
    String l_Name;
    int customerCPR;

    //Constructor for reading the customers CPR number
    public FFCustomer(int customerCPR){
        i = 3;
        this.customerCPR = customerCPR;
    }

    //Constructor for reading the first and last name of the customer
    public FFCustomer(String f_Name, String l_Name) {
        i = 2;
        this.f_Name = f_Name;
        this.l_Name = l_Name;
    }

    //to String method which can return customerID, full name or customer CPR
    @Override
    public String toString() {
        switch (i) {
            case 1:
                return customerID;
            case 2:
                return f_Name + " " + l_Name;
            case 3:
                return customerCPR + "";
        }
        return null;
    }

}
