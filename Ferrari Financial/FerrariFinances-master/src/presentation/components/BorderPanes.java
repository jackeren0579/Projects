package presentation.components;

import javafx.scene.layout.BorderPane;

public class BorderPanes {

    //Instantiates panes to apply in initBorderPanes method
    Panes panes = new Panes();

    //Creates a Border pane
    public BorderPane bp = new BorderPane();

    //Method for adding contents to bp
    public void initBorderPanes() {
        bp.setId("mainscreen");
        bp.setCenter(panes.pane);
    }
}
