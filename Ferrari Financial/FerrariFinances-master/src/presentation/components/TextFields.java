package presentation.components;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.control.TextFormatter;

public class TextFields {

    //Create Text fields
    public TextField saelger = new TextField();
    public TextField email = new TextField();
    public TextField foersteGangsYdelse = new TextField();
    public TextField ordreID = new TextField();
    public PasswordField salesManager = new PasswordField();

    //Method for adding settings to the text fields
    public void initTextFields() {
        saelger.setPrefWidth(150);
        email.setPrefWidth(150);
        foersteGangsYdelse.setPrefWidth(150);
        ordreID.setPrefWidth(150);
        salesManager.setPrefWidth(150);

        saelger.setEditable(false);
        ordreID.setEditable(false);

        //Method making email text field free of spaces
        email.setTextFormatter(new TextFormatter<>(change -> {
            if (change.getText().equals(" ")) {
                change.setText("");
            }
            return change;
        }));

        //Method making foersteGangsYdelse text field free of spaces and letters
        foersteGangsYdelse.textProperty().addListener(new ChangeListener<>() {
            @Override
            public void changed(ObservableValue<? extends String> observable, String oldValue,
                                String newValue) {
                if (!newValue.matches("\\d*")) {
                    foersteGangsYdelse.setText(oldValue);
                }
            }
        });

        email.relocate(0, 20);
        foersteGangsYdelse.relocate(220, 20);
        saelger.relocate(440, 90);
        salesManager.relocate(523.5, 30);
        ordreID.relocate(440, 160);
    }
}
