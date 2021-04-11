package presentation.components;

import javafx.scene.layout.Pane;

public class Panes {

    //Creating panes
    public Pane pane = new Pane();
    public Pane opretLaan = new Pane();
    public Pane tjekLaanPane = new Pane();

    //Method that sets size of panes and adds css to pane
    public void initPanes() {
        opretLaan.setPrefSize(1000, 650);
        tjekLaanPane.setPrefSize(1000, 650);
        opretLaan.relocate(300, 70);
        pane.setId("mainscreen");
    }
}
