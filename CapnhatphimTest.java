package Test_PTPMChuyennghiep;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

import static org.junit.jupiter.api.Assertions.*;

public class CapnhatphimTest {
    WebDriver driver;
    String baseURL = "https://localhost:44388/Quanlyphim";

    @BeforeEach
    public void setUp() {
        driver = new ChromeDriver();
        driver.get(baseURL);
    }

    // Test 1: Hiển thị lỗi khi tên phim để trống
    @Test
    public void testDisplayErrorWhenNameIsEmpty() throws InterruptedException {
        // Nhấn vào nút "Cập nhật" của phim
        WebElement capNhatButton = driver.findElement(By.xpath("/html/body/div/div[2]/div/div[5]/div/a[1]"));
        capNhatButton.click();
        Thread.sleep(2000);

        // Cập nhật thông tin với tên phim để trống
        WebElement tenPhimField = driver.findElement(By.id("TenPhim"));
        WebElement submitButton = driver.findElement(By.cssSelector("button.save-button"));

        tenPhimField.clear(); // Để trống tên phim
        submitButton.click();

        // Kiểm tra thông báo lỗi
        WebElement errorMessage = driver.findElement(By.cssSelector("div.alert.error"));
        assertTrue(errorMessage.isDisplayed(), "Thông báo lỗi không hiển thị.");
        assertEquals("Thông tin không hợp lệ. Vui lòng kiểm tra lại.", errorMessage.getText());
    }

    // Test 2: Cập nhật thời lượng quá lớn (3000 phút)
    @Test
    public void testUpdateWithInvalidDuration() throws InterruptedException {
        // Nhấn vào nút "Cập nhật" của phim
        WebElement capNhatButton = driver.findElement(By.xpath("/html/body/div/div[2]/div/div[5]/div/a[1]"));
        capNhatButton.click();
        Thread.sleep(2000);

        // Cập nhật thông tin với thời lượng không hợp lệ (3000 phút)
        WebElement thoiLuongField = driver.findElement(By.id("ThoiLuong"));
        thoiLuongField.clear();
        thoiLuongField.sendKeys("3000"); // Thời lượng quá lớn
        WebElement submitButton = driver.findElement(By.cssSelector("button.save-button"));
        submitButton.click();

        // Kiểm tra thông báo lỗi
        WebElement errorMessage = driver.findElement(By.cssSelector("div.alert.error"));
        assertTrue(errorMessage.isDisplayed(), "Thông báo lỗi không hiển thị.");
        assertEquals("Thông tin không hợp lệ. Vui lòng kiểm tra lại.", errorMessage.getText());
    }

    // Test 3: Cập nhật lại đúng thông tin phim
    @Test
    public void testUpdatePhimSuccess() throws InterruptedException {
        // Nhấn vào nút "Cập nhật" của phim
        WebElement capNhatButton = driver.findElement(By.xpath("/html/body/div/div[2]/div/div[5]/div/a[1]"));
        capNhatButton.click();
        Thread.sleep(2000);

        // Cập nhật thông tin phim đúng
        WebElement tenPhimField = driver.findElement(By.id("TenPhim"));
        WebElement theLoaiField = driver.findElement(By.id("TheLoai"));
        WebElement thoiLuongField = driver.findElement(By.id("ThoiLuong"));
        WebElement submitButton = driver.findElement(By.cssSelector("button.save-button"));

        tenPhimField.clear();
        tenPhimField.sendKeys("30 chưa thấy tết nha");
        theLoaiField.clear();
        theLoaiField.sendKeys("Hài ");
        thoiLuongField.clear();
        thoiLuongField.sendKeys("160"); // Thời lượng hợp lệ
        submitButton.click();

        // Kiểm tra thông báo thành công
        WebElement successMessage = driver.findElement(By.cssSelector("div.alert.success"));
        assertTrue(successMessage.isDisplayed(), "Thông báo thành công không hiển thị.");
        assertEquals("Cập nhật phim thành công!", successMessage.getText());
    }

    @AfterEach
    public void tearDown() throws InterruptedException {
        Thread.sleep(2000);
        if (driver != null) {
            driver.quit();
        }
    }
}
