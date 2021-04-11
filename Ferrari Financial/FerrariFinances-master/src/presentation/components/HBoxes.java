package presentation.components;

import javafx.scene.layout.HBox;
import javafx.stage.Stage;

public class HBoxes {

    //Creating a HBox as a custom top bar
    public HBox topBar = new HBox();
    //Local variables made for own top bar
    private double xOffset, yOffset;

    //Method for adding content and settings to the top bar
    public void initHBox(Stage stage) {
        topBar.setPrefSize(1280, 66);

        //Finds the location of the mouse cursor
        topBar.setOnMousePressed(event1 -> {
            xOffset = stage.getX() - event1.getScreenX();
            yOffset = stage.getY() - event1.getScreenY();
        });

        //Makes the top bar draggable when mouse location is found
        topBar.setOnMouseDragged(event -> {
            stage.setX(event.getScreenX() + xOffset);
            stage.setY(event.getScreenY() + yOffset);
        });
    }

}
