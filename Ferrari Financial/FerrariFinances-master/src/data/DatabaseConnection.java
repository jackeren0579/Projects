package data;

import javafx.beans.property.SimpleStringProperty;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.util.Callback;

import java.sql.*;
import java.util.ArrayList;

public class DatabaseConnection {

    public Connection connection;
    private boolean DriverLoaded = false;

    public void loadJdbcDriver() {
        try {
            System.out.println("Loading JDBC driver...");

            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");

            System.out.println("JDBC driver loaded");

        } catch (ClassNotFoundException e) {
            System.out.println("Could not load JDBC driver!");
        }
    }

    public void openConnection(String databaseName) {
        //String connectionString = "jdbc:sqlserver://localhost:1433;" + "instanceName=SQLEXPRESS;" + "databaseName=" + databaseName + ";" + "integratedSecurity=true;";

        String user = "laeringsraketten_dk0";
        String pass = "percad5g";
        String connectionString = "jdbc:sqlserver://mssql16.unoeuro.com:1433;" + "instanceName=SQLEXPRESS;" + "databaseName=" + databaseName + ";";

        connection = null;

        try {
            if (!DriverLoaded) {
                loadJdbcDriver();
                DriverLoaded = true;
            }

            System.out.println("Connecting to database...");

            connection = DriverManager.getConnection(connectionString, user, pass);

            System.out.println("Connected to database");

        } catch (SQLException e) {
            System.out.println("Could not connect to database!");
            System.out.println(e.getMessage());

        }
    }

//    CREATE

    public void createLoan(CustomerLoanDetail customerLoanDetail) {
        try {
            String sql = "INSERT INTO CustomerLoanDetail VALUES (" + customerLoanDetail.getOrderID()
                    + "," + customerLoanDetail.getCustomerDownPayment() + "," + customerLoanDetail.getFfInterest() + "," + customerLoanDetail.getNumberOfRepayments() + ", '" + customerLoanDetail.getApproved() + "');";

            Statement statement = connection.createStatement();
            statement.executeUpdate(sql);

            // auto-generated key => id
            ResultSet resultSet = statement.executeQuery("SELECT SCOPE_IDENTITY()");
            resultSet.next();
            customerLoanDetail.setColumnId(resultSet.getInt(1));
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

//    READ

    public CustomerOrderDetail readCustomerOrderById(String email) {
        try {
            String sql = "SELECT MAX(OrderID) AS OrderID FROM CustomerOrderDetail WHERE CustomerID = '" + email + "'";

            Statement statement = connection.createStatement();

            ResultSet resultSet = statement.executeQuery(sql);

            if (resultSet.next()) {
                int orderID = resultSet.getInt("OrderID");

                return new CustomerOrderDetail(orderID);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public CustomerOrderDetail readStaffIDByOrderId(int orderID) {
        try {
            String sql = "SELECT StaffID FROM CustomerOrderDetail WHERE OrderID = " + orderID;

            Statement statement = connection.createStatement();

            ResultSet resultSet = statement.executeQuery(sql);

            if (resultSet.next()) {
                int staffID = resultSet.getInt("StaffID");

                return new CustomerOrderDetail(staffID);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public CustomerOrderDetail readModelNumIDByOrderId(int orderID) {
        try {
            String sql = "SELECT ModelNumID FROM CustomerOrderDetail WHERE OrderID = " + orderID;

            Statement statement = connection.createStatement();

            ResultSet resultSet = statement.executeQuery(sql);

            if (resultSet.next()) {
                int modelNumID = resultSet.getInt("ModelNumID");

                return new CustomerOrderDetail(modelNumID);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public CarsForSale readModelPriceByModelNumId(int modelNumID) {
        try {
            String sql = "SELECT ModelPrice FROM CarsForSale WHERE ModelNumID = " + modelNumID;

            Statement statement = connection.createStatement();

            ResultSet resultSet = statement.executeQuery(sql);

            if (resultSet.next()) {
                float modelPrice = resultSet.getFloat("ModelPrice");

                return new CarsForSale(modelPrice);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public DPStaff readStaffNameByStaffId(int staffID) {
        try {
            String sql = "SELECT Staff_F_Name, Staff_L_Name FROM DPStaff WHERE StaffID =" + staffID;

            Statement statement = connection.createStatement();

            ResultSet resultSet = statement.executeQuery(sql);

            if (resultSet.next()) {
                String fName = resultSet.getString("Staff_F_Name");
                String lName = resultSet.getString("Staff_L_Name");

                return new DPStaff(fName, lName);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public FFCustomer readCustomerNameByCustomerId(String email) {
        try {
            String sql = "SELECT F_Name, L_Name FROM FFCustomer WHERE CustomerID = '" + email + "'";

            Statement statement = connection.createStatement();

            ResultSet resultSet = statement.executeQuery(sql);

            if (resultSet.next()) {
                String f_Name = resultSet.getString("F_Name");
                String l_Name = resultSet.getString("L_Name");

                return new FFCustomer(f_Name, l_Name);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public FFCustomer readCustomerCPRByCustomerId(String email) {
        try {
            String sql = "SELECT CustomerCPR FROM FFCustomer WHERE CustomerID = '" + email + "'";

            Statement statement = connection.createStatement();

            ResultSet resultSet = statement.executeQuery(sql);

            if (resultSet.next()) {
                int customerCPR = resultSet.getInt("CustomerCPR");

                return new FFCustomer(customerCPR);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public StaffJobTitle readCreditLimitByStaffId(int staffID) {
        try {
            String sql = "SELECT JobTitleCreditLimit FROM StaffJobTitle WHERE StaffID =" + staffID;

            Statement statement = connection.createStatement();

            ResultSet resultSet = statement.executeQuery(sql);

            if (resultSet.next()) {
                Float creditLimit = resultSet.getFloat("JobTitleCreditLimit");

                return new StaffJobTitle(creditLimit);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

//    READ ARRAYLIST

    public ArrayList<String> emailChecker() {
        ArrayList<String> emailCheckerList = new ArrayList<>();
        try {
            String sql = "SELECT CustomerID FROM FFCustomer";

            Statement statement = connection.createStatement();

            ResultSet resultSet = statement.executeQuery(sql);

            while (resultSet.next()) {
                String customerID = resultSet.getString("CustomerID");
//                FFCustomer ffCustomer = new FFCustomer(customerID);

                emailCheckerList.add(customerID);

            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return emailCheckerList;
    }

//    READ AND BUILD TABLEVIEW

    public void buildData(TableView tableview) {
        ObservableList<ObservableList> data = FXCollections.observableArrayList();
        try {
            //SQL FOR SELECTING ALL OF CUSTOMER
            String SQL = "SELECT * from CustomerLoanDetail";
            //ResultSet
            ResultSet rs = connection.createStatement().executeQuery(SQL);

            /**********************************
             * TABLE COLUMN ADDED DYNAMICALLY *
             **********************************/
            tableview.getColumns().clear();
            for (int i = 0; i < rs.getMetaData().getColumnCount(); i++) {
                //We are using non property style for making dynamic table
                final int j = i;
                TableColumn col = new TableColumn(rs.getMetaData().getColumnName(i + 1));
                col.setCellValueFactory(new Callback<TableColumn.CellDataFeatures<ObservableList, String>, ObservableValue<String>>() {
                    public ObservableValue<String> call(TableColumn.CellDataFeatures<ObservableList, String> param) {
                        return new SimpleStringProperty(param.getValue().get(j).toString());
                    }
                });

                tableview.getColumns().addAll(col);
            }

            /********************************
             * Data added to ObservableList *
             ********************************/
            while (rs.next()) {
                //Iterate Row
                ObservableList<String> row = FXCollections.observableArrayList();
                for (int i = 1; i <= rs.getMetaData().getColumnCount(); i++) {
                    //Iterate Column
                    row.add(rs.getString(i));
                }
                data.add(row);

            }

            //FINALLY ADDED TO TableView
            tableview.setItems(data);
        } catch (Exception e) {
            e.printStackTrace();
            System.out.println("Error on Building Data");
        }
    }

//    UPDATE
    public void updateLoanByLoanDetailID(String loanDetailID) {
        try {
            String sql = "UPDATE CustomerLoanDetail SET Approved='" + "Bekræftet" + "'" + " WHERE LoanDetailID=" + "'"
                    + loanDetailID + "'";

            Statement statement = connection.createStatement();

            if (statement.executeUpdate(sql) == 0)
                System.out.println("Ingen tabel at opdatere");
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

}