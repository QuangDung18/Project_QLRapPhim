package TestQuanLyPhim;

import static org.testng.Assert.assertTrue;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

public class SuaThongTinPhim{
	WebDriver driver;
    String baseURL = "https://localhost:7119/"; // Địa chỉ URL dễ dàng chỉnh sửa

    // Thiết lập WebDriver và khởi động trình duyệt
    @BeforeMethod
    public void SetUp() {
        driver = new ChromeDriver();
        driver.get(baseURL); // Mở trang web
    }

    // Đảm bảo đóng WebDriver sau mỗi Test case
    @AfterMethod
    public void tearDown() {
        if (driver != null) {
            driver.quit(); // Đóng phiên làm việc của WebDriver
        }
    }
    
    // Sửa phim thành công 
    @Test(priority = 1)
    public void suaphimhople() throws InterruptedException {
        WebElement qlphim = driver.findElement(By.xpath("/html/body/header/nav/a[7]"));
        Thread.sleep(1000);
        qlphim.click();

        WebElement suaphimbutton = driver.findElement(By.xpath("/html/body/div/div[2]/div/div[10]/div/a[1]"));
        Thread.sleep(1000);
        suaphimbutton.click();

        // Chỉ sửa "Tên phim", "Thể loại", và "Ngày khởi chiếu"
        WebElement tenPhim = driver.findElement(By.xpath("/html/body/div/form/div[1]/input"));
        tenPhim.clear();
        tenPhim.sendKeys("Linh Miêu 3");

        WebElement theLoai = driver.findElement(By.xpath("/html/body/div/form/div[2]/input"));
        theLoai.clear();
        theLoai.sendKeys("Kinh dị");

        WebElement ngayKhoiChieu = driver.findElement(By.xpath("/html/body/div/form/div[3]/input"));
        ngayKhoiChieu.clear();
        ngayKhoiChieu.sendKeys("11/22/2024");

        WebElement saveButton = driver.findElement(By.className("save-button"));
        saveButton.click();
        WebElement suaphimbutton2 = driver.findElement(By.xpath("/html/body/div/div[2]/div/div[10]/div/a[1]"));
        Thread.sleep(1000);
        suaphimbutton2.click();
        assertTrue(driver.getPageSource().contains("Cập nhật phim thành công!"));
    }
    
    	// Sửa phim không thành công khi để trống tên phim
    @Test(priority = 2)
    public void suaphimkhitenphimdetrong() throws InterruptedException {
        WebElement qlphim = driver.findElement(By.xpath("/html/body/header/nav/a[7]"));
        Thread.sleep(1000);
        qlphim.click();

        WebElement suaphimbutton = driver.findElement(By.xpath("/html/body/div/div[2]/div/div[10]/div/a[1]"));
        Thread.sleep(1000);
        suaphimbutton.click();

        // Để trống tên phim
        WebElement tenPhim = driver.findElement(By.xpath("/html/body/div/form/div[1]/input"));
        tenPhim.clear();
        tenPhim.sendKeys(""); // Tên phim trống

        WebElement saveButton = driver.findElement(By.className("save-button"));
        saveButton.click();

        assertTrue(driver.getPageSource().contains("Thông tin không hợp lệ. Vui lòng kiểm tra lại."));
    }
    
    // Hệ thống báo Phim đã tồn tại
    @Test(priority = 3)
    public void suaphimkhiphimdatontai() throws InterruptedException {
        WebElement qlphim = driver.findElement(By.xpath("/html/body/header/nav/a[7]"));
        Thread.sleep(1000);
        qlphim.click();

        WebElement suaphimbutton = driver.findElement(By.xpath("/html/body/div/div[2]/div/div[11]/div/a[1]"));
        Thread.sleep(1000);
        suaphimbutton.click();

        // Thay đổi tên phim thành tên phim đã tồn tại trong cơ sở dữ liệu
        WebElement tenPhim = driver.findElement(By.xpath("/html/body/div/form/div[1]/input"));
        tenPhim.clear();
        tenPhim.sendKeys("Linh Miêu"); // Giả sử phim này đã tồn tại trong DB

        WebElement theLoai = driver.findElement(By.xpath("/html/body/div/form/div[2]/input"));
        theLoai.clear();
        theLoai.sendKeys("Phiêu lưu");

        WebElement ngayKhoiChieu = driver.findElement(By.xpath("/html/body/div/form/div[3]/input"));
        ngayKhoiChieu.clear();
        ngayKhoiChieu.sendKeys("11/22/2024");

        WebElement saveButton = driver.findElement(By.className("save-button"));
        saveButton.click();
        Thread.sleep(1000);
        assertTrue(driver.getPageSource().contains("Phim đã tồn tại!"));
    }
    
}
