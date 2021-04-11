package presentation.components;

import javafx.scene.control.TableView;

public class TableViews {

    //Creates TableView so it's ready for content
    public TableView<String> loanData;

    //Method for instantiating the table view
    public void initTableView() {
        loanData = new TableView<>();
    }
}
