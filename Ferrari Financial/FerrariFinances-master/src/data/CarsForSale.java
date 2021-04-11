package data;

public class CarsForSale {

    float modelPrice;

    //Constructor for fetching car prices
    public CarsForSale(float modelPrice) {
        this.modelPrice = modelPrice;
    }

    //To string method
    @Override
    public String toString() {
        return modelPrice + "";
    }
}
