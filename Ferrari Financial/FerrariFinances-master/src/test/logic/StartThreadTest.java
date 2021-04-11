package logic;

import com.ferrari.finances.dk.bank.InterestRate;
import com.ferrari.finances.dk.rki.CreditRator;
import org.junit.Test;

import java.math.BigDecimal;
import java.math.RoundingMode;

import static org.hamcrest.core.Is.is;
import static org.junit.Assert.*;

public class StartThreadTest {



    @Test
    //Tests what happens when a customer has a credit rating of A
    public void startThreadRatingA() {
        StartThread st = new StartThread();
        BigDecimal roundInterest = new BigDecimal(InterestRate.i().todaysRate()).setScale(2, RoundingMode.HALF_UP);

        assertThat(st.makeCal(CreditRator.i().rate("2004989691"), roundInterest.doubleValue()), is(roundInterest.doubleValue() + 1));
    }

    @Test
    //Tests what happens when a customer has a credit rating of B
    public void startThreadRatingB() {
        StartThread st = new StartThread();
        BigDecimal roundInterest = new BigDecimal(InterestRate.i().todaysRate()).setScale(2, RoundingMode.HALF_UP);

        assertThat(st.makeCal(CreditRator.i().rate("2457891368"), roundInterest.doubleValue()), is(roundInterest.doubleValue() + 2));
    }

    @Test
    //Tests what happens when a customer has a credit rating of C
    public void startThreadRatingC() {
        StartThread st = new StartThread();
        BigDecimal roundInterest = new BigDecimal(InterestRate.i().todaysRate()).setScale(2, RoundingMode.HALF_UP);
        Formatters fm = new Formatters();

        assertThat(st.makeCal(CreditRator.i().rate("1234567891"), roundInterest.doubleValue()), is(Double.parseDouble(fm.myFormatter.format(roundInterest.doubleValue() + 3))));
    }

    @Test
    //Tests what happens when a customer has a credit rating of D
    public void startThreadRatingD() {
        StartThread st = new StartThread();
        BigDecimal roundInterest = new BigDecimal(InterestRate.i().todaysRate()).setScale(2, RoundingMode.HALF_UP);

        assertThat(st.makeCal(CreditRator.i().rate("1017718011"), roundInterest.doubleValue()), is(0.0));
    }

    //Testing if it returns a double
    @Test
    public void testMakeCalReturnType(){
        StartThread st = new StartThread();
        BigDecimal roundInterest = new BigDecimal(InterestRate.i().todaysRate()).setScale(2, RoundingMode.HALF_UP);

        assertFalse(Double.isNaN(st.makeCal(CreditRator.i().rate("2004989691"), roundInterest.doubleValue())));
    }

    //What happens when the CPR isn't long enough
    @Test
    public void makeCalWrongCPR(){
        StartThread st = new StartThread();
        assertThat(st.makeCal(CreditRator.i().rate("200498969"), InterestRate.i().todaysRate()), is(InterestRate.i().todaysRate()));
    }

}