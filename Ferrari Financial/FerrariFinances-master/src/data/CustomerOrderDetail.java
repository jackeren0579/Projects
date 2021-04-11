package data;

public class CustomerOrderDetail {

    int orderID;

    //Constructor for reading OrderID
    public CustomerOrderDetail(int orderID) {
        this.orderID = orderID;
    }

    @Override
    public String toString() {
        return orderID + "";
    }

}
