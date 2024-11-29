package TestQuanLyPhim;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.Test;

public class ThemPhimMoi {
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

    // Test Case 1: Xác minh hệ thống thêm phim thành công khi nhập thông tin hợp lệ
    @Test(priority = 1)
    public void themPhimHopLe() throws InterruptedException {
        // Tìm và nhấn vào quản lý phim
        driver.findElement(By.xpath("/html/body/header/nav/a[7]")).click();
        Thread.sleep(1000); // Thời gian đợi giữa các thao tác

        // Nhấn nút thêm phim
        driver.findElement(By.xpath("/html/body/div/div[1]/a")).click();
        Thread.sleep(1000); // Thời gian đợi giữa các thao tác
        // cần đổi Tên phim sau mỗi lần thêm với trường hợp thêm thành công!
        // Điền thông tin phim hợp lệ
        driver.findElement(By.xpath("/html/body/div/form/div[1]/input")).sendKeys("Linh Miêu9");
        driver.findElement(By.xpath("/html/body/div/form/div[2]/input")).sendKeys("Kinh dị");
        driver.findElement(By.xpath("/html/body/div/form/div[3]/input")).sendKeys("Lưu Thành Luân");
        driver.findElement(By.xpath("/html/body/div/form/div[4]/input")).sendKeys("Hồng Đào, Thiên An, Thuỳ Tiên");
        driver.findElement(By.xpath("/html/body/div/form/div[5]/textarea"))
                .sendKeys("Linh Miêu: Quỷ Nhập Tràng lấy cảm hứng từ truyền thuyết dân gian về “quỷ nhập tràng”.");
        driver.findElement(By.xpath("/html/body/div/form/div[6]/input")).sendKeys("109");
        driver.findElement(By.xpath("/html/body/div/form/div[7]/input")).sendKeys("5");
        driver.findElement(By.xpath("/html/body/div/form/div[8]/input")).sendKeys("11/22/2024");
        driver.findElement(By.xpath("/html/body/div/form/div[9]/input")).sendKeys("linhmieu.png");
        driver.findElement(By.xpath("/html/body/div/form/button")).click();
        Thread.sleep(1000); // Thời gian đợi giữa các thao tác

        // Xác minh thêm phim thành công
        assert driver.getPageSource().contains("Thêm phim mới thành công!");
    }

    // Test Case 2: Xác minh thêm phim không thành công khi để trống trường Diễn viên và Mô tả
    @Test(priority = 2)
    public void themPhimThieuThongTinBatBuoc() throws InterruptedException {
        driver.findElement(By.xpath("/html/body/header/nav/a[7]")).click();
        Thread.sleep(1000);

        driver.findElement(By.xpath("/html/body/div/div[1]/a")).click();
        Thread.sleep(1000);

        driver.findElement(By.xpath("/html/body/div/form/div[1]/input")).sendKeys("SẮC MÀU CỦA CẢM XÚC");
        driver.findElement(By.xpath("/html/body/div/form/div[2]/input")).sendKeys("Hoạt hình");
        driver.findElement(By.xpath("/html/body/div/form/div[3]/input")).sendKeys("Naoko Yamada");
        // Không nhập dữ liệu Đạo diễn và Mô tả
        driver.findElement(By.xpath("/html/body/div/form/div[6]/input")).sendKeys("105");
        driver.findElement(By.xpath("/html/body/div/form/div[7]/input")).sendKeys("5");
        driver.findElement(By.xpath("/html/body/div/form/div[8]/input")).sendKeys("11/24/2024");
        driver.findElement(By.xpath("/html/body/div/form/div[9]/input")).sendKeys("sacmautuoitre.png");
        driver.findElement(By.xpath("/html/body/div/form/button")).click();
        Thread.sleep(1000);

        // Xác minh hệ thống thông báo lỗi
        assert driver.getPageSource().contains("Đã xảy ra lỗi. Vui lòng kiểm tra thông tin nhập!");
    }

    // Test Case 3: Xác minh thêm phim không thành công khi phim đã tồn tại trong cơ sở dữ liệu
    @Test(priority = 3)
    public void themPhimDaTonTai() throws InterruptedException {
        driver.findElement(By.xpath("/html/body/header/nav/a[7]")).click();
        Thread.sleep(1000);

        driver.findElement(By.xpath("/html/body/div/div[1]/a")).click();
        Thread.sleep(1000);

        driver.findElement(By.xpath("/html/body/div/form/div[1]/input")).sendKeys("Linh Miêu");
        driver.findElement(By.xpath("/html/body/div/form/div[2]/input")).sendKeys("Kinh dị");
        driver.findElement(By.xpath("/html/body/div/form/div[3]/input")).sendKeys("Lưu Thành Luân");
        driver.findElement(By.xpath("/html/body/div/form/div[4]/input")).sendKeys("Hồng Đào");
        driver.findElement(By.xpath("/html/body/div/form/div[5]/textarea"))
                .sendKeys("Linh Miêu: Quỷ Nhập Tràng lấy cảm hứng từ truyền thuyết dân gian.");
        driver.findElement(By.xpath("/html/body/div/form/div[6]/input")).sendKeys("109");
        driver.findElement(By.xpath("/html/body/div/form/div[7]/input")).sendKeys("5");
        driver.findElement(By.xpath("/html/body/div/form/div[8]/input")).sendKeys("11/22/2024");
        driver.findElement(By.xpath("/html/body/div/form/div[9]/input")).sendKeys("linhmieu.png");
        driver.findElement(By.xpath("/html/body/div/form/button")).click();
        Thread.sleep(1000);

        // Xác minh hệ thống báo lỗi phim đã tồn tại
        assert driver.getPageSource().contains("Phim đã tồn tại trong cơ sở dữ liệu!");
    }

    // Test Case 4: Xác minh thêm phim thành công với dữ liệu đặc biệt (có dấu tiếng Việt)
    @Test(priority = 4)
    public void themPhimDacBiet() throws InterruptedException {
        driver.findElement(By.xpath("/html/body/header/nav/a[7]")).click();
        Thread.sleep(1000);

        driver.findElement(By.xpath("/html/body/div/div[1]/a")).click();
        Thread.sleep(1000);
        // cần đổi Tên phim sau mỗi lần thêm với trường hợp thêm thành công!
        driver.findElement(By.xpath("/html/body/div/form/div[1]/input")).sendKeys("Linh Miêu: Quỷ Nhập Tràng"); 
        driver.findElement(By.xpath("/html/body/div/form/div[2]/input")).sendKeys("Kinh dị");
        driver.findElement(By.xpath("/html/body/div/form/div[3]/input")).sendKeys("Lưu Thành Luân");
        driver.findElement(By.xpath("/html/body/div/form/div[4]/input")).sendKeys("Hồng Đào, Thiên An, Thuỳ Tiên");
        driver.findElement(By.xpath("/html/body/div/form/div[5]/textarea"))
                .sendKeys("Phim có yếu tố dân gian Việt Nam.");
        driver.findElement(By.xpath("/html/body/div/form/div[6]/input")).sendKeys("109");
        driver.findElement(By.xpath("/html/body/div/form/div[7]/input")).sendKeys("5");
        driver.findElement(By.xpath("/html/body/div/form/div[8]/input")).sendKeys("11/22/2024");
        driver.findElement(By.xpath("/html/body/div/form/div[9]/input")).sendKeys("linhmieu.png");
        driver.findElement(By.xpath("/html/body/div/form/button")).click();
        Thread.sleep(1000);

        // Xác minh thêm phim thành công
        assert driver.getPageSource().contains("Thêm phim mới thành công!");
    }

    // Test Case 5: Xác minh hệ thống thông báo lỗi khi nhập ngày phát hành không hợp lệ
    @Test(priority = 5)
    public void themPhimNgayPhatHanhKhongHopLe() throws InterruptedException {
        driver.findElement(By.xpath("/html/body/header/nav/a[7]")).click();
        Thread.sleep(1000);

        driver.findElement(By.xpath("/html/body/div/div[1]/a")).click();
        Thread.sleep(1000);

        driver.findElement(By.xpath("/html/body/div/form/div[1]/input")).sendKeys("SẮC MÀU CỦA CẢM XÚC");
        driver.findElement(By.xpath("/html/body/div/form/div[2]/input")).sendKeys("Hoạt hình");
        driver.findElement(By.xpath("/html/body/div/form/div[3]/input")).sendKeys("Naoko Yamada");
        driver.findElement(By.xpath("/html/body/div/form/div[4]/input")).sendKeys("Sayu Suzukawa, Akari Takaishi");
        driver.findElement(By.xpath("/html/body/div/form/div[5]/textarea")).sendKeys("Mô tả phim");
        driver.findElement(By.xpath("/html/body/div/form/div[6]/input")).sendKeys("105");
        driver.findElement(By.xpath("/html/body/div/form/div[7]/input")).sendKeys("5");
        driver.findElement(By.xpath("/html/body/div/form/div[8]/input")).sendKeys("32/13/2024"); // Ngày không hợp lệ
        driver.findElement(By.xpath("/html/body/div/form/div[9]/input")).sendKeys("sacmautuoitre.png");
        driver.findElement(By.xpath("/html/body/div/form/button")).click();
        Thread.sleep(1000);

        // Xác minh hệ thống báo lỗi ngày phát hành không hợp lệ
        assert driver.getPageSource().contains("Đã xảy ra lỗi. Vui lòng kiểm tra thông tin nhập!");
    }
}
