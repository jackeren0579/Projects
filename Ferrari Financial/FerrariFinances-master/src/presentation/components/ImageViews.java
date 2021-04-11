package presentation.components;

import javafx.scene.image.Image;
import javafx.scene.image.ImageView;

public class ImageViews {

    //Creates and adds image to imageview. Image can be found in resource package
    Image background = new Image("resources/FerrariBG.jpg");
    public ImageView backgroundView = new ImageView(background);

    //Method for setting background size
    public void initImageView() {
        backgroundView.setFitWidth(1280);
        backgroundView.setFitHeight(720);
    }
}

