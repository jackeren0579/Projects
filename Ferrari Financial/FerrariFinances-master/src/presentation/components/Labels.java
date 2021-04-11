package presentation.components;

import javafx.scene.control.Label;

public class Labels {

    //Creating labels
    public Label emailLabel = new Label("E-mail");
    public Label saelgerLabel = new Label("Sælger");
    public Label maanederLabel = new Label("Antal måneder");
    public Label foersteGangsYdelseLabel = new Label("Førstegangsydelse");
    public Label ordreNummerLabel = new Label("Ordrenummer");
    public Label salesManagerLabel = new Label("Password");

    //Setting location for labels
    public void initLabels() {
        emailLabel.relocate(0, 0);
        foersteGangsYdelseLabel.relocate(220, 0);
        ordreNummerLabel.relocate(440, 140);
        saelgerLabel.relocate(440, 70);
        maanederLabel.relocate(440, 0);
        salesManagerLabel.relocate(523.5, 10);
    }
}
