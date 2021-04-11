package logic;

public class BeregnYdelse {

    //Method for calculating payment
    public double udregnYdelse(double laan, double rente, double terminer) {

        rente = rente / (12 * 100);

        double ydelse = (laan * rente * Math.pow(1 + rente, terminer)) / (Math.pow(1 + rente, terminer) - 1);
        return ydelse;
    }

}
