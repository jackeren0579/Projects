package presentation.components;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.ListView;

public class ListViews {

    //Creating String[], ObservableList and a ListView so it's ready for content to be added.
    String[] information = {};
    ObservableList<String> laanInformation = FXCollections.observableArrayList(information);
    public ListView<String> infoBox = new ListView<>(laanInformation);

    //Method for setting size of the table view
    public void initListViews() {
        infoBox.setPrefSize(400, 450);
    }
}
