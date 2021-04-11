package logic;

import javafx.application.Application;
import javafx.scene.text.Font;
import javafx.stage.Stage;
import presentation.screens.MainScreen;

public class Main extends Application {
    public static void main(String[] args){ launch(args); }

    @Override
    public void start(Stage stage) {
        Font.loadFont(getClass().getResourceAsStream("BebasNeue-Reqular.ttf"), 10);
        MainScreen mainScreen = new MainScreen();
        mainScreen.init();
    }
}