//package logic;
//
//import com.ferrari.finances.dk.bank.InterestRate;
//import com.ferrari.finances.dk.rki.CreditRator;
//import com.ferrari.finances.dk.rki.Rating;
//
//import java.math.BigDecimal;
//import java.math.RoundingMode;
//
//public class StartThread extends Thread {
//    private String cpr = "0000000000";
//    private double il;
//    private Rating rating;
//    private double totalInterest;
//    private int periode;
//    private double downpayment;
//    private double price;
//
//    public void startThread(String Cpr) {
//        this.cpr = Cpr;
//    }
//
//    public Double getTotalInterest() {
//        return totalInterest;
//    }
//
//    public void run() {
//        calculateRate(cpr);
//        toDaysInterest();
//        makeCal(rating, il);
//    }
//
//    public double toDaysInterest() {
//        il = InterestRate.i().todaysRate();
//        BigDecimal b = new BigDecimal(il);
//        b = b.setScale(2, RoundingMode.HALF_UP);
//        System.out.println("To days Interest = " + b);
//        return il;
//    }
//
//    public String calculateRate(String cpr) {
//        rating = CreditRator.i().rate(cpr);
//        System.out.println("Customer rating = " + rating);
//        return "rating";
//    }
//
//    public double makeCal(Rating rating, double interest) {
//        switch (rating) {
//            case A:
//                totalInterest = interest + 1;
//                break;
//            case B:
//                totalInterest = interest + 2;
//                break;
//            case C:
//                totalInterest = interest + 3;
//                break;
//            case D:
//                System.out.println("Lånet kan ikke gennemføres.");
//                break;
//            default:
//                System.out.println("Lånet kan ikke gennemføres.");
//        }
//
//        BigDecimal totalinterestRound = new BigDecimal(totalInterest);
//        totalinterestRound = totalinterestRound.setScale(2, RoundingMode.HALF_UP);
//        System.out.println("Den samlede rente i double er: " + totalInterest);
//        System.out.println("Den samlede rente er: " + totalinterestRound);
//        return totalInterest;
//    }
//}

package logic;

import com.ferrari.finances.dk.bank.InterestRate;
import com.ferrari.finances.dk.rki.CreditRator;
import com.ferrari.finances.dk.rki.Rating;

import javax.swing.*;
import java.math.BigDecimal;
import java.math.RoundingMode;
import java.sql.SQLOutput;

import static com.ferrari.finances.dk.rki.Rating.D;

public class StartThread extends Thread {

    //Local variables
    private String cpr = "0000000000";
    private double il;
    private Rating rating;
    private double totalInterest = 0;
    private int period = 32;
    private double downPayment = 750000;
    private double price = 1000000;

    //Method for setting local variables to database variables.
    public void startThread(String Cpr, int period, double downPayment, double price) {
        this.cpr = Cpr;
        this.period = period;
        this.downPayment = downPayment;
        this.price = price;
    }

    //Starts a new thread
    public void run() {
        calculateRate(cpr);
        todaysInterest();
        makeCal(rating, il);
    }

    //Fetches todays interest
    public void todaysInterest() {
        il = InterestRate.i().todaysRate();
    }

    //Calculates a customers credit rating, based on CPR
    public void calculateRate(String cpr) {
        rating = CreditRator.i().rate(cpr);
    }

    //Adds additional interest based on credit rating, initial payment and repayments
    public double makeCal(Rating rating, double interest) {
        if (rating != D) {
            switch (rating) {
                case A:
                    totalInterest = interest + 1;
                    break;
                case B:
                    totalInterest = interest + 2;
                    break;
                case C:
                    totalInterest = interest + 3;
                    break;
                default:
                    JOptionPane.showMessageDialog(null, "Lånet kan ikke gennemføres.");
            }

            if (price / 2 > downPayment) {
                System.out.println("Prisen bliver lagt til");
                this.totalInterest = totalInterest + 1;
            }

            if (period > 36) {
                System.out.println("Måneder bliver lagt til");
                this.totalInterest = totalInterest + 1;
            }

            JOptionPane.showMessageDialog(null, "Renten er udregnet.\nDu kan nu fortsætte.");
        } else {
            JOptionPane.showMessageDialog(null, "Lånet kan ikke gennemføres.\nKundens RKI score er 'D'.");
        }
        BigDecimal roundRestgaeldPrimo = new BigDecimal(totalInterest);
        BigDecimal roundTotalInterest = roundRestgaeldPrimo.setScale(2, RoundingMode.HALF_UP);
        return roundTotalInterest.doubleValue();
    }

    public double getTotalInterest() {
        return totalInterest;
    }
}


