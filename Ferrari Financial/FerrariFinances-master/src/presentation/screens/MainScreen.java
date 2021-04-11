package presentation.screens;

import data.DatabaseConnection;
import data.CustomerLoanDetail;
import logic.PrintCSV;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.ListView;
import javafx.scene.image.Image;
import javafx.stage.Stage;
import javafx.stage.StageStyle;
import logic.BeregnYdelse;
import logic.Formatters;
import logic.StartThread;
import presentation.components.*;

import javax.swing.*;
import java.io.IOException;
import java.text.DecimalFormat;

public class MainScreen {

    private float restGaeld = 0;
    private String navn, totalInterestStringGL;
    private double antalMaanederGL, ydelse, rente;
    private int restBeloebGL, staffIDTest = 0;
    private boolean opretLaanSwitch = true, tjekLaanSwitch = true;

    public void init() {

        //Instantiating components
        Buttons buttons = new Buttons();
        Labels labels = new Labels();
        Sliders sliders = new Sliders();
        TextFields textFields = new TextFields();
        BorderPanes borderPanes = new BorderPanes();
        Panes panes = new Panes();
        ListViews listViews = new ListViews();
        ImageViews imageViews = new ImageViews();
        TableViews tableViews = new TableViews();
        Formatters formatters = new Formatters();
        HBoxes hBoxes = new HBoxes();

        //Instantiating stage
        Stage stage = new Stage();
        Scene myScene = new Scene(panes.pane, 1280, 720);

        //Running initiating methods to all components
        buttons.initButts();
        sliders.initSlider();
        textFields.initTextFields();
        labels.initLabels();
        borderPanes.initBorderPanes();
        panes.initPanes();
        listViews.initListViews();
        imageViews.initImageView();
        tableViews.initTableView();
        hBoxes.initHBox(stage);

        //Start Thread
        StartThread startThread = new StartThread();

        //Database Call
        DatabaseConnection DBC = new DatabaseConnection();
        DBC.loadJdbcDriver();
        DBC.openConnection("laeringsraketten_dk0_db_rocket");

        //Call BeregnYdelse
        BeregnYdelse by = new BeregnYdelse();

        //Get CSS file from Resource folder
        myScene.getStylesheets().add("resources/FerrariFinances.css");

        //Adding components to pane
        panes.pane.getChildren().addAll(imageViews.backgroundView, hBoxes.topBar, buttons.loan, buttons.tjekLaan, buttons.close);

        //Opens loan screen
        buttons.loan.setOnAction(e -> {
            if (opretLaanSwitch) {
                panes.pane.getChildren().remove(panes.tjekLaanPane);
                panes.pane.getChildren().add(panes.opretLaan);
                panes.tjekLaanPane.getChildren().clear();
                panes.opretLaan.getChildren().addAll(textFields.email, textFields.foersteGangsYdelse,
                        buttons.beregnRente, labels.emailLabel, labels.saelgerLabel, textFields.saelger, textFields.ordreID, labels.ordreNummerLabel, labels.foersteGangsYdelseLabel, sliders.maaneder, labels.maanederLabel);

                panes.opretLaan.relocate(300, 70);

                opretLaanSwitch = false;
                tjekLaanSwitch = true;
            } else {
                panes.pane.getChildren().remove(panes.opretLaan);
                panes.opretLaan.getChildren().clear();
                opretLaanSwitch = true;
            }
        });

        //Runs calculations to get rate
        buttons.beregnRente.setOnAction(e -> {
            String cprNumber = DBC.readCustomerCPRByCustomerId(textFields.email.getText()).toString();
            textFields.ordreID.setText(DBC.readCustomerOrderById(textFields.email.getText()).toString());
            panes.opretLaan.getChildren().remove(buttons.beregnRente);
            panes.opretLaan.getChildren().add(buttons.beregnLaan);

            int modelNumId = Integer.parseInt(DBC.readModelNumIDByOrderId(Integer.parseInt(textFields.ordreID.getText())).toString());
            int maanederInt = (int) sliders.maaneder.getValue();
            float modelPris = Float.parseFloat(DBC.readModelPriceByModelNumId(modelNumId).toString());
            if(Float.parseFloat(textFields.foersteGangsYdelse.getText()) <= modelPris) {
                try {
                    startThread.startThread(cprNumber, maanederInt, Double.parseDouble(textFields.foersteGangsYdelse.getText()), modelPris);
                    startThread.start();

                } catch (Exception ex) {
                    JOptionPane.showMessageDialog(null, "Fejl! Noget gik galt. Prøv igen.");
                }
            } else {
                JOptionPane.showMessageDialog(null, "Førstegangsydelsen er højere eller lig med prisen på bilen.");
            }
        });

        //Opens the listview and makes it accessible to confirm loan
        buttons.beregnLaan.setOnAction(e -> {
            if (DBC.emailChecker().contains(textFields.email.getText())) {
                Double totalInterest = startThread.getTotalInterest();
                rente = totalInterest;
                if (!formatters.rateFormatter.format(totalInterest).equals("0")) {
                    panes.opretLaan.getChildren().remove(listViews.infoBox);
                    panes.opretLaan.getChildren().remove(buttons.bekraeftLaan);
                    panes.opretLaan.getChildren().remove(buttons.beregnLaan);

                    int modelNumId = Integer.parseInt(DBC.readModelNumIDByOrderId(Integer.parseInt(textFields.ordreID.getText())).toString());
                    float modelPris = Float.parseFloat(DBC.readModelPriceByModelNumId(modelNumId).toString());
                    float foersteGangsYdelseFloat = Float.parseFloat(textFields.foersteGangsYdelse.getText());
                    String prisFormat = "Pris: " + formatters.myFormatter.format(Float.parseFloat(DBC.readModelPriceByModelNumId(modelNumId).toString()));
                    int staffIdInt = Integer.parseInt(DBC.readStaffIDByOrderId(Integer.parseInt(textFields.ordreID.getText())).toString());
                    textFields.saelger.setText(DBC.readStaffNameByStaffId(staffIdInt).toString());
                    float restBeloeb = modelPris - foersteGangsYdelseFloat;

                    ydelse = by.udregnYdelse(restBeloeb, totalInterest, (int) sliders.maaneder.getValue());

                    staffIDTest = staffIdInt;
                    this.restGaeld = restBeloeb;

                    float testfoersteGangsYdelse = Float.parseFloat(textFields.foersteGangsYdelse.getText());
                    String foresteGangsYdelseFormat = "Førstegangsydelse: " + formatters.myFormatter.format(testfoersteGangsYdelse);

                    String testFornavn = "Navn: " + DBC.readCustomerNameByCustomerId(textFields.email.getText()).toString();
                    String emailToView = "E-mail: " + textFields.email.getText();
                    String antalMaaneder = "Antal måneder: " + (int) sliders.maaneder.getValue();
                    String restBeloebString = "Rest gæld: " + formatters.myFormatter.format(restBeloeb);
                    String totalInterestString = "Den samlede rente er: " + formatters.rateFormatter.format(totalInterest);

                    navn = DBC.readCustomerNameByCustomerId(textFields.email.getText()).toString();
                    antalMaanederGL = sliders.maaneder.getValue();
                    restBeloebGL = (int) restBeloeb;
                    totalInterestStringGL = formatters.rateFormatter.format(totalInterest);

                    String[] information2 = {testFornavn, emailToView, prisFormat, foresteGangsYdelseFormat, restBeloebString, antalMaaneder, totalInterestString};

                    ObservableList<String> laanInformation2 = FXCollections.observableArrayList(information2);
                    ListView<String> infoBox2 = new ListView<>(laanInformation2);
                    infoBox2.setPrefSize(368, 380);

                    panes.opretLaan.getChildren().addAll(infoBox2, buttons.bekraeftLaan);
                    infoBox2.relocate(0, 60);
                } else {
                    JOptionPane.showMessageDialog(null, "Kunden kan ikke få beregnet et lån grundet RKI værdi \nEller manglende beregning på renten.");
                }
            } else if (textFields.email.getText().equals("")) {
                Alert alert = new Alert(Alert.AlertType.INFORMATION);
                alert.setTitle("Information");
                alert.setHeaderText("You have to insert a Email");

                alert.showAndWait();
            } else {
                Alert alert = new Alert(Alert.AlertType.INFORMATION);
                alert.setTitle("Information");
                alert.setHeaderText("The Email does not exist in the system");

                alert.showAndWait();
            }
        });

        //Opens tjek laan screen
        buttons.tjekLaan.setOnAction(e -> {
            if (tjekLaanSwitch) {
                panes.pane.getChildren().remove(panes.opretLaan);
                panes.pane.getChildren().add(panes.tjekLaanPane);
                panes.opretLaan.getChildren().clear();

                DBC.buildData(tableViews.loanData);

                tableViews.loanData.setPrefSize(673, 380);

                panes.tjekLaanPane.getChildren().addAll(tableViews.loanData, buttons.opdaterBekraeft, textFields.salesManager, labels.salesManagerLabel);

                //***********VBox lokation*************//
                panes.tjekLaanPane.relocate(163.5, 70);

                //***********Tableview lokation***********//
                tableViews.loanData.relocate(130, 70);

                tjekLaanSwitch = false;
                opretLaanSwitch = true;
            } else {
                panes.pane.getChildren().remove(panes.tjekLaanPane);
                panes.tjekLaanPane.getChildren().clear();
                tjekLaanSwitch = true;
            }
        });

        //Updates a non-confirmed loan to confirmed if password is correct
        buttons.opdaterBekraeft.setOnAction(e -> {

            ObservableList<String> approvedSelection = tableViews.loanData.getSelectionModel().getSelectedItems();

            String selected = approvedSelection.toString();
            String[] arrOfSelected = selected.split("[,\\[\\]]");

            if (textFields.salesManager.getText().equals("password")) {
                if (arrOfSelected[7].equals(" Ikke bekræftet")) {
                    for (int i = 1; i > 0; i--) {
                        DBC.updateLoanByLoanDetailID(arrOfSelected[2]);
                    }
                }
            }
        });

        //Saves loan in database and prints it in a CSV File
        buttons.bekraeftLaan.setOnAction(e -> {
            for (int i = 1; i > 0; i--) {

                int OrderID = Integer.parseInt(textFields.ordreID.getText());
                String FFString = formatters.rateFormatter.format(startThread.getTotalInterest());
                double FF_Interest = Double.parseDouble(FFString);
                DecimalFormat myFormatter2 = new DecimalFormat("#");
                String d = myFormatter2.format(sliders.maaneder.getValue());
                int nor = Integer.parseInt(d);
                String approved;

                if (restGaeld > Float.parseFloat(DBC.readCreditLimitByStaffId(staffIDTest).toString())) {
                    approved = "Ikke bekræftet";
                } else {
                    approved = "Bekræftet";
                }

                CustomerLoanDetail customerLoanDetail = new CustomerLoanDetail(OrderID, Integer.parseInt(textFields.foersteGangsYdelse.getText()),
                        FF_Interest, nor, approved);
                DBC.createLoan(customerLoanDetail);

                PrintCSV printCSV = new PrintCSV(restBeloebGL, totalInterestStringGL, antalMaanederGL, navn);
                try {
                    printCSV.printReport("Ordre_" + DBC.readCustomerOrderById(textFields.email.getText()) + ".csv");
                } catch (IOException ex) {
                    ex.printStackTrace();
                }
            }
        });

        //Close button for closing application
        buttons.close.setOnAction(e -> stage.close());

        //Stage components
        stage.getIcons().add(new Image("resources/Ferrari-Logo-2.png"));
        stage.initStyle(StageStyle.UNDECORATED);
        stage.setTitle("Ferrari Finances");
        stage.setScene(myScene);
        stage.show();
    }
}