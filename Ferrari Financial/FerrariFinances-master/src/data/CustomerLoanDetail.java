package data;

public class CustomerLoanDetail {

    //Variables
    int loanDetailID;
    int orderID;
    int customerDownPayment;
    double ffInterest;
    int numberOfRepayments;
    private int columnId;
    private String columnStuff;
    private String updateColumnStuff;
    private String approved;
    private String updateApproved;

    //Constructor for create Loan
    public CustomerLoanDetail(int orderID, int customerDownPayment,
                              double ffInterest, int NumberOfRepayments, String approved) {
        this.orderID = orderID;
        this.customerDownPayment = customerDownPayment;
        this.ffInterest = ffInterest;
        this.numberOfRepayments = NumberOfRepayments;
        this.approved = approved;
    }

    public CustomerLoanDetail(String approved) {
        this.approved = approved;
    }

    //Constructor for approving loan
    public CustomerLoanDetail(String approved, String updateApproved) {
        this.approved = approved;
        this.updateApproved = updateApproved;
    }

    //************************ GETTERS & SETTERS ************************
    public void setColumnId(int id) {
        this.columnId = id;
    }

    public int getOrderID() {
        return orderID;
    }

    public int getCustomerDownPayment() {
        return customerDownPayment;
    }

    public double getFfInterest() {
        return ffInterest;
    }

    public double getNumberOfRepayments() {
        return numberOfRepayments;
    }

    public String getApproved() {
        return approved;
    }

    //to String method
    @Override
    public String toString() {
        return columnId + ": " +
                columnStuff;
    }
}
