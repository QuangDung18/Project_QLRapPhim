package Test_PTPMChuyennghiep;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import static org.junit.Assert.assertEquals;

public class CapnhatnhanvienTest {
    private WebDriver driver;

    @Before
    public void setUp() {
        driver = new ChromeDriver();
        driver.manage().window().maximize();
    }

    @Test
    public void testUpdateEmployeeWithValidData() throws InterruptedException {
        driver.get("https://localhost:44388/Quanlynhanvien");

        // Nhấn vào liên kết cập nhật nhân viên trong bảng
        WebElement updateLink = driver.findElement(By.xpath("/html/body/div/table/tbody/tr[5]/td[7]/a[1]"));
        updateLink.click();
        
        // Chờ tải trang cập nhật
        Thread.sleep(2000);

        // Điền vào các trường thông tin hợp lệ
        WebElement hoTenField = driver.findElement(By.name("HoTen"));
        hoTenField.clear();
        hoTenField.sendKeys("Lưu Nguyễn");

        WebElement emailField = driver.findElement(By.name("Email"));
        emailField.clear();
        emailField.sendKeys("luunguyen@gmail.com");

        WebElement soDienThoaiField = driver.findElement(By.name("SoDienThoai"));
        soDienThoaiField.clear();
        soDienThoaiField.sendKeys("0123456789");

        WebElement vaiTroField = driver.findElement(By.name("VaiTro"));
        vaiTroField.clear();
        vaiTroField.sendKeys("Nhân viên");

        WebElement trangThaiField = driver.findElement(By.name("TrangThai"));
        trangThaiField.clear();
        trangThaiField.sendKeys("Đang làm việc");

        // Nhấn nút cập nhật
        WebElement updateButton = driver.findElement(By.cssSelector("button[type='submit']"));
        updateButton.click();

        // Kiểm tra xem có chuyển hướng về trang quản lý nhân viên hay không
        String currentUrl = driver.getCurrentUrl();
        assertEquals("https://localhost:44388/Quanlynhanvien", currentUrl);

        Thread.sleep(3000);
    }

    @Test
    public void testUpdateEmployeeWithExistingEmail() throws InterruptedException {
        driver.get("https://localhost:44388/Quanlynhanvien");

        // Nhấn vào liên kết cập nhật nhân viên trong bảng
        WebElement updateLink = driver.findElement(By.xpath("/html/body/div/table/tbody/tr[5]/td[7]/a[1]"));
        updateLink.click();
        
        // Chờ tải trang cập nhật
        Thread.sleep(2000);

        // Điền vào các trường thông tin
        WebElement hoTenField = driver.findElement(By.name("HoTen"));
        hoTenField.clear();
        hoTenField.sendKeys("Quang Huy");

        WebElement emailField = driver.findElement(By.name("Email"));
        emailField.clear();
        emailField.sendKeys("quanghuy@gmail.com"); 
        WebElement soDienThoaiField = driver.findElement(By.name("SoDienThoai"));
        soDienThoaiField.clear();
        soDienThoaiField.sendKeys("0123456789");

        WebElement vaiTroField = driver.findElement(By.name("VaiTro"));
        vaiTroField.clear();
        vaiTroField.sendKeys("Nhân viên");

        WebElement trangThaiField = driver.findElement(By.name("TrangThai"));
        trangThaiField.clear();
        trangThaiField.sendKeys("Đang làm việc");

        // Nhấn nút cập nhật
        WebElement updateButton = driver.findElement(By.cssSelector("button[type='submit']"));
        updateButton.click();

        // Kiểm tra thông báo lỗi về email
        WebElement errorMessage = driver.findElement(By.className("text-danger"));
        assertEquals("Email này đã được sử dụng.", errorMessage.getText());

        Thread.sleep(3000);
    }

    @Test
    public void testUpdateEmployeeMissingPhone() throws InterruptedException {
        driver.get("https://localhost:44388/Quanlynhanvien");

        // Nhấn vào liên kết cập nhật nhân viên trong bảng
        WebElement updateLink = driver.findElement(By.xpath("/html/body/div/table/tbody/tr[5]/td[7]/a[1]"));
        updateLink.click();
        
        // Chờ tải trang cập nhật
        Thread.sleep(2000);

        // Điền vào các trường thông tin
        WebElement hoTenField = driver.findElement(By.name("HoTen"));
        hoTenField.clear();
        hoTenField.sendKeys("Mai Sơn");

        WebElement emailField = driver.findElement(By.name("Email"));
        emailField.clear();
        emailField.sendKeys("maison@gmail.com");

        // Không điền số điện thoại
        WebElement vaiTroField = driver.findElement(By.name("VaiTro"));
        vaiTroField.clear();
        vaiTroField.sendKeys("Nhân viên");

        WebElement trangThaiField = driver.findElement(By.name("TrangThai"));
        trangThaiField.clear();
        trangThaiField.sendKeys("Đang làm việc");

        // Nhấn nút cập nhật
        WebElement updateButton = driver.findElement(By.cssSelector("button[type='submit']"));
        updateButton.click();

        // Kiểm tra thông báo lỗi về số điện thoại
        WebElement errorMessage = driver.findElement(By.className("text-danger"));
        assertEquals("Số điện thoại là bắt buộc.", errorMessage.getText());

        Thread.sleep(3000);
    }

    @After
    public void tearDown() throws InterruptedException {
        Thread.sleep(3000);

        if (driver != null) {
            driver.quit();
        }
    }
}
