using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameWork_BaiTapLon;
using Services_BaiTapLon;
using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using EntityFrameWork_BaiTapLon.DataAcces;
using System.IO;
using System.Data;
using System.Web.UI;
using System.Threading.Tasks;
using ExcelDataReader;
using System.Reflection;
using DataTable = System.Data.DataTable;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;

namespace Web_UI.Controllers
{
    [Authorize(Roles = "GiangVien")]
    public class GiangVienController : Controller
    {
        MonHocService serMH;
        LopHocPhanService serLHP;
        SinhVienService serSV;
        KetQuaHocTapService serkqht;
        QLSVDatabaseContext db;
        public GiangVienController()
        {
            serMH = new MonHocService();
            serLHP = new LopHocPhanService();
            serSV = new SinhVienService();
            serkqht = new KetQuaHocTapService();
            db = new QLSVDatabaseContext();
        }
        public ActionResult GiangVien()
        {
            ViewBag.monhoclist = "";
            GiangVienService giangVienService = new GiangVienService();
            string idgv = User.Identity.GetUserName();
            return View(giangVienService.getById(idgv));
        }
        public ActionResult getDanhsachMonHoc()
        {
            MonHocService mh = new MonHocService();
            var list = mh.GetAll();
            return View(list);
        }
        public ActionResult DanhSachMonHoc()
        {
            List<MonHoc> list = new List<MonHoc>();
            MonHocService mh = new MonHocService();
            foreach (var item in mh.GetAll())
            {
                var DataMonHoc = new MonHoc();
                DataMonHoc = item;
                list.Add(DataMonHoc);
            }
            return PartialView(list);
        }

        public JsonResult getDanhSachLopHocPhan(int id)
        {

            var query = (from mh in serMH.GetAll()
                         join
                         lhp in serLHP.GetAll() on mh.MonhocId equals lhp.MonHocId
                         where (mh.MonhocId == id)
                         select new
                         {
                             lhp.LopHocPhanId,
                             lhp.tenLopHocPhan,
                             lhp.NgayKT,
                             lhp.NgayKTDK,
                             lhp.NgayBD,
                             lhp.TrangThai,
                             lhp.Mota,
                             lhp.soLuongSV
                         }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Import1(FormCollection formCollection)
        {
            return View("Import");

        }
        public List<KetQuaHocTap> GetDataFromCSVFile(Stream stream)
        {
            var empList = new List<KetQuaHocTap>();
            try
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // To set First Row As Column Names  
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow objDataRow in dataTable.Rows)
                        {
                            if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                            empList.Add(new KetQuaHocTap()
                            {
                                kqhtID = Convert.ToInt32(objDataRow["kqhtid"].ToString()),
                                LopHocPhanId = Convert.ToInt32(objDataRow["lophpid"].ToString()),
                                SinhVienId = objDataRow["Position"].ToString(),
                                ThuongKy = Convert.ToInt32(objDataRow["Location"].ToString()),
                                GiuaKy = Convert.ToInt32(objDataRow["Age"].ToString()),
                                CuoiKy = Convert.ToInt32(objDataRow["Salary"].ToString()),
                            });
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            return empList;
        }
        [HttpPost]
        public async Task<ActionResult> ImportFile(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                var fileData = GetDataFromCSVFile(importFile.InputStream);

                var dtEmployee = fileData.ToDataTable();
                var tblEmployeeParameter = new SqlParameter("tblEmployeeTableType", SqlDbType.Structured)
                {
                    TypeName = "dbo.tblTypeEmployee",
                    Value = dtEmployee
                };
                await db.Database.ExecuteSqlCommandAsync("EXEC spBulkImportEmployee @tblEmployeeTableType", tblEmployeeParameter);
                return Json(new { Status = 1, Message = "File Imported Successfully " });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }

        public ActionResult Export()
        {
            List<KetQuaHocTap> emps = TempData["ketquahoctaplist"] as List<KetQuaHocTap>;
            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = emps;
            grid.DataBind();
            Response.ClearContent();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment; filename=Expectations.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            ViewBag.EmployeeList = emps;
            return View("Index");
        }
        public JsonResult GetDanhSachSinhVien(int id)
        {
            var query = (from lhp in serLHP.GetAll()
                         join kt in serkqht.GetAll() on lhp.LopHocPhanId equals kt.LopHocPhanId
                         join sv in serSV.GetAll() on kt.SinhVienId equals sv.SinhVienId
                         where (lhp.LopHocPhanId == id)
                         select new
                         {
                             sv.SinhVienId,
                             sv.tenSinhVien,
                             sv.Gioitinh,
                             sv.soDienThoai,
                             sv.Diachi,
                             sv.ChuyenNganh,
                             sv.BacDT
                         }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NhapDiem()
        {
            return View();
        }
    }
}
public static class Extensions
{
    public static DataTable ToDataTable<T>(this List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);

        //Get all the properties  
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Defining type of data column gives proper data table   
            var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
            //Setting column names as Property names  
            dataTable.Columns.Add(prop.Name, type);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                //inserting property values to datatable rows  
                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
        return dataTable;
    }
}
