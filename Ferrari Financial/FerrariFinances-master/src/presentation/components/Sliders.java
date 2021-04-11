package presentation.components;

import javafx.scene.control.Slider;

public class Sliders {

    //Creates slider
    public Slider maaneder = new Slider();

    //Method for adding settings to slider
    public void initSlider() {
        maaneder.setPrefWidth(155);
        maaneder.setMin(12);
        maaneder.setMax(72);
        maaneder.setValue(48);
        maaneder.setShowTickLabels(true);
        maaneder.setShowTickMarks(true);
        maaneder.setMajorTickUnit(12);
        maaneder.setMinorTickCount(0);
        maaneder.setBlockIncrement(12);
        maaneder.setSnapToTicks(true);
        maaneder.relocate(436,20);
    }
}
