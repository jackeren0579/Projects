package logic;

import javax.swing.*;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.math.BigDecimal;
import java.math.RoundingMode;

public class PrintCSV {

    //Variables
    private double restgaeldPrimo;
    private double rente;
    private double ydelse;
    private double renteAfRestgaeld;
    private double restgaeldUltimo;
    private double afdrag;
    private int terminer;
    private String nyRente;
    private String originalRente;
    private String navn;

    //Constructor for CSV printer
    public PrintCSV(double maengde, String rente, double terminer, String navn) {
        this.restgaeldPrimo = maengde;
        this.restgaeldUltimo = maengde;
        this.nyRente = rente.replace(',', '.');
        this.rente = Double.parseDouble(nyRente) / 100 / 12;
        this.originalRente = nyRente;
        this.terminer = (int) terminer;
        this.navn = navn;
        calcPayment();
    }

    // Calculate monthly payment
    private void calcPayment() {

        ydelse = (restgaeldPrimo * rente * Math.pow(1 + rente, terminer)) / (Math.pow(1 + rente, terminer) - 1);
    }

    //Method that prints CSV file with calculations each month of payment
    public void printReport(String fileName) throws IOException {

        try {

            //File writer
            FileWriter fWriter = new FileWriter(fileName);
            //Print writer
            PrintWriter pWriter = new PrintWriter(fWriter);

            //Print CSV header
            pWriter.println("Terminer, Navn, Rente pr. år, Primo restgæld, Ydelse, Rente af primogæld, Afdrag, Ultimo restgæld");

            //For-loop that prints each month of payment
            for (int month = 1; month <= terminer; month++) {

                //Calculates "Rente af restgæld"
                renteAfRestgaeld = restgaeldPrimo * rente;
                //Calculates "Afdrag"
                afdrag = ydelse - renteAfRestgaeld;
                //Calculates "Restgæld ultimo"
                restgaeldUltimo = restgaeldPrimo - afdrag;

                // BigDecimal rounders for values
                BigDecimal roundRenteAfRestgaeld = new BigDecimal(renteAfRestgaeld);
                roundRenteAfRestgaeld = roundRenteAfRestgaeld.setScale(2, RoundingMode.HALF_UP);

                BigDecimal roundAfdrag = new BigDecimal(afdrag);
                roundAfdrag = roundAfdrag.setScale(2, RoundingMode.HALF_UP);

                BigDecimal roundRestgaeldUltimo = new BigDecimal(restgaeldUltimo);
                roundRestgaeldUltimo = roundRestgaeldUltimo.setScale(2, RoundingMode.HALF_UP);

                BigDecimal roundYdelse = new BigDecimal(ydelse);
                roundYdelse = roundYdelse.setScale(2, RoundingMode.HALF_UP);

                BigDecimal roundRestgaeldPrimo = new BigDecimal(restgaeldPrimo);
                roundRestgaeldPrimo = roundRestgaeldPrimo.setScale(2, RoundingMode.HALF_UP);

                //Prints all calculations in a comma separated line
                pWriter.println(month + ", " + navn + ", " + originalRente + ", " + roundRestgaeldPrimo + ", " + roundYdelse + ", " + roundRenteAfRestgaeld + ", " + roundAfdrag + ", " + (restgaeldPrimo = roundRestgaeldUltimo.doubleValue()));

            }
            //Stops printer
            pWriter.close();
            //Pop-up window telling the user that print was a success
            JOptionPane.showMessageDialog(null, "Lånet er bekræftet & printet i en CSV fil.");

        } catch (IOException e) {
            //Pop-up window telling the user that print wasn't a success
            JOptionPane.showMessageDialog(null, "Lånet er ikke bekræftet & er ikke printet i enCSV fil.");
            e.printStackTrace();
        }
    }
}