package presentation.components;

import javafx.scene.control.Button;

public class Buttons {

    //Creates buttons
    public Button beregnLaan = new Button("BEREGN");
    public Button close = new Button("X");
    public Button loan = new Button("OPRET LÅN");
    public Button tjekLaan = new Button("TJEK LÅN");
    public Button bekraeftLaan = new Button("BEKRÆFT LÅN");
    public Button opdaterBekraeft = new Button("BEKRÆFT LÅN");
    public Button beregnRente = new Button("BEREGN RENTE");

    //Method for adding settings to buttons
    public void initButts() {
        beregnLaan.setId("loanButton");
        close.setId("closeButton");
        bekraeftLaan.setId("loanButton");
        opdaterBekraeft.setId("loanButton");
        beregnRente.setId("loanButton");

        beregnRente.relocate(440, 200);
        beregnLaan.relocate(440, 200);
        close.relocate(1254, 2);
        opdaterBekraeft.relocate(683.5, 25);
        loan.relocate(0, 0);
        tjekLaan.relocate(230, 0);
        close.relocate(1254, 2);
        bekraeftLaan.relocate(440, 200);
    }
}
