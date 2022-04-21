using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Book.Models.Member.MemberModel;

namespace Book.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
		public ActionResult DoRegister(DoRegisterIn inModel)
		{
			DoRegisterOut outModel = new DoRegisterOut();

			if (string.IsNullOrEmpty(inModel.UserID) || string.IsNullOrEmpty(inModel.UserPwd) || string.IsNullOrEmpty(inModel.UserName) || string.IsNullOrEmpty(inModel.UserEmail))
			{
				outModel.ErrMsg = "請輸入資料";
			}
			else
			{
				SqlConnection conn = null;
				try
				{
					// 資料庫連線
					string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;
					conn = new SqlConnection();
					conn.ConnectionString = connStr;
					conn.Open();

					// 檢查帳號是否存在
					string sql = "select * from Member where UserID = @UserID";
					SqlCommand cmd = new SqlCommand();
					cmd.CommandText = sql;
					cmd.Connection = conn;

					// 使用參數化填值
					cmd.Parameters.AddWithValue("@UserID", inModel.UserID);

					// 執行資料庫查詢動作
					DbDataAdapter adpt = new SqlDataAdapter();
					adpt.SelectCommand = cmd;
					DataSet ds = new DataSet();
					adpt.Fill(ds);

					if (ds.Tables[0].Rows.Count > 0)
					{
						outModel.ErrMsg = "此登入帳號已存在";
					}
					else
					{
						//// 將密碼使用 SHA256 雜湊運算(不可逆)
						//string salt = inModel.UserID.Substring(0, 1).ToLower(); //使用帳號前一碼當作密碼鹽
						//SHA256 sha256 = SHA256.Create();
						//byte[] bytes = Encoding.UTF8.GetBytes(salt + inModel.UserPwd); //將密碼鹽及原密碼組合
						//byte[] hash = sha256.ComputeHash(bytes);
						//StringBuilder result = new StringBuilder();
						//for (int i = 0; i < hash.Length; i++)
						//{
						//	result.Append(hash[i].ToString("X2"));
						//}
						//string NewPwd = result.ToString(); // 雜湊運算後密碼

						// 註冊資料新增至資料庫
						sql = @"INSERT INTO Member (UserID,UserPwd,UserName,UserEmail) VALUES (@UserID, @UserPwd, @UserName, @UserEmail)";
						cmd = new SqlCommand();
						cmd.Connection = conn;
						cmd.CommandText = sql;

						// 使用參數化填值
						cmd.Parameters.AddWithValue("@UserID", inModel.UserID);
						cmd.Parameters.AddWithValue("@UserPwd", inModel.UserPwd);
						cmd.Parameters.AddWithValue("@UserName", inModel.UserName);
						cmd.Parameters.AddWithValue("@UserEmail", inModel.UserEmail);

						// 執行資料庫更新動作
						cmd.ExecuteNonQuery();

						outModel.ResultMsg = "註冊完成!";
						
					}
					
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (conn != null)
					{
						//關閉資料庫連線
						conn.Close();
						conn.Dispose();
					}

				}

			}

			// 輸出json
			return Json(outModel);
			
		}
		public ActionResult Login()
		{
			return View();
		}
		public ActionResult DoLogin(DoLoginIn inModel)
		{
			DoLoginOut outModel = new DoLoginOut();

			// 檢查輸入資料
			if (string.IsNullOrEmpty(inModel.UserID) || string.IsNullOrEmpty(inModel.UserPwd))
			{
				outModel.ErrMsg = "請輸入資料";
			}
			else
			{
				SqlConnection conn = null;

				try
				{
					// 資料庫連線
					string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;
					conn = new SqlConnection();
					conn.ConnectionString = connStr;
					conn.Open();

					//// 將密碼轉為 SHA256 雜湊運算(不可逆)
					//string salt = inModel.UserID.Substring(0, 1).ToLower(); //使用帳號前一碼當作密碼鹽
					//SHA256 sha256 = SHA256.Create();
					//byte[] bytes = Encoding.UTF8.GetBytes(salt + inModel.UserPwd); //將密碼鹽及原密碼組合
					//byte[] hash = sha256.ComputeHash(bytes);
					//StringBuilder result = new StringBuilder();
					//for (int i = 0; i < hash.Length; i++)
					//{
					//	result.Append(hash[i].ToString("X2"));
					//}
					//string CheckPwd = result.ToString(); // 雜湊運算後密碼

					// 檢查帳號、密碼是否正確
					string sql = "select * from Member where UserID = @UserID and UserPwd = @UserPwd";
					SqlCommand cmd = new SqlCommand();
					cmd.CommandText = sql;
					cmd.Connection = conn;

					// 使用參數化填值
					cmd.Parameters.AddWithValue("@UserID", inModel.UserID);
					cmd.Parameters.AddWithValue("@UserPwd", inModel.UserPwd); // 雜湊運算後密碼

					// 執行資料庫查詢動作
					SqlDataAdapter adpt = new SqlDataAdapter();
					adpt.SelectCommand = cmd;
					DataSet ds = new DataSet();
					adpt.Fill(ds);

					if (ds.Tables[0].Rows.Count > 0)
					{
						// 有查詢到資料，表示帳號密碼正確

						// 將登入帳號記錄在 Session 內
						Session["UserID"] = inModel.UserID;

						outModel.ResultMsg = "登入成功";
					}
					else
					{
						// 查無資料，帳號或密碼錯誤
						outModel.ErrMsg = "帳號或密碼錯誤";
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (conn != null)
					{
						//關閉資料庫連線
						conn.Close();
						conn.Dispose();
					}
				}

			}

			// 輸出json
			return Json(outModel);
		}
		public ActionResult EditProfile()
		{
			return View();
		}
		public ActionResult GetUserProfile()
		{
			GetUserProfileOut outModel = new GetUserProfileOut();

			// 檢查會員 Session 是否存在
			if (Session["UserID"] == null || Session["UserID"].ToString() == "")
			{
				outModel.ErrMsg = "你還沒登入!!!!!";
				return Json(outModel);
			}

			// 取得連線字串
			string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;

			// 當程式碼離開 using 區塊時，會自動關閉連接
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				// 資料庫連線
				conn.Open();

				// 取得會員資料
				string sql = "select * from Member where UserID = @UserID";
				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = sql;
				cmd.Connection = conn;

				// 使用參數化填值
				cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

				// 執行資料庫查詢動作
				SqlDataAdapter adpt = new SqlDataAdapter();
				adpt.SelectCommand = cmd;
				DataSet ds = new DataSet();
				adpt.Fill(ds);
				DataTable dt = ds.Tables[0];

				if (dt.Rows.Count > 0)
				{
					// 將資料回傳給前端
					outModel.UserID = dt.Rows[0]["UserID"].ToString();
					outModel.UserName = dt.Rows[0]["UserName"].ToString();
					outModel.UserEmail = dt.Rows[0]["UserEmail"].ToString();
				}
				else
				{
					outModel.ErrMsg = "查無會員資料";
				}
			}

			// 回傳 Json 給前端
			return Json(outModel);
		}
		[ValidateAntiForgeryToken]
		public ActionResult DoEditProfile(DoEditProfileIn inModel)
		{
			DoEditProfileOut outModel = new DoEditProfileOut();

			// 檢查個人資料是否有輸入
			if (string.IsNullOrEmpty(inModel.UserName) || string.IsNullOrEmpty(inModel.UserEmail))
			{
				outModel.ErrMsg = "請輸入資料";
				return Json(outModel);
			}

			// 檢查會員 Session 是否存在
			if (Session["UserID"] == null || Session["UserID"].ToString() == "")
			{
				outModel.ErrMsg = "無會員登入記錄";
				return Json(outModel);
			}

			// 取得連線字串
			string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;

			// 當程式碼離開 using 區塊時，會自動關閉連接
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				// 資料庫連線
				conn.Open();

				// 修改個人資料至資料庫
				string sql = @"UPDATE Member SET UserName = @UserName, UserEmail = @UserEmail WHERE UserID = @UserID";
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = sql;

				// 使用參數化填值
				cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
				cmd.Parameters.AddWithValue("@UserName", inModel.UserName);
				cmd.Parameters.AddWithValue("@UserEmail", inModel.UserEmail);

				// 執行資料庫更新動作
				int Ret = cmd.ExecuteNonQuery();

				if (Ret > 0)
				{
					outModel.ResultMsg = "修改個人資料完成";
				}
				else
				{
					outModel.ErrMsg = "無異動資料";
				}
			}

			// 回傳 Json 給前端
			return Json(outModel);
		}
		[ValidateAntiForgeryToken]
		public ActionResult DoEditPwd(DoEditPwdIn inModel)
		{
			DoEditPwdOut outModel = new DoEditPwdOut();

			// 檢查是否有輸入密碼
			if (string.IsNullOrEmpty(inModel.NewUserPwd))
			{
				outModel.ErrMsg = "請輸入修改密碼";
				return Json(outModel);
			}
			if (string.IsNullOrEmpty(inModel.CheckUserPwd))
			{
				outModel.ErrMsg = "請輸入確認新密碼";
				return Json(outModel);
			}
			if (inModel.NewUserPwd != inModel.CheckUserPwd)
			{
				outModel.ErrMsg = "新密碼與確認新密碼不相同";
				return Json(outModel);
			}

			// 檢查會員 Session 是否存在
			if (Session["UserID"] == null || Session["UserID"].ToString() == "")
			{
				outModel.ErrMsg = "無會員登入記錄";
				return Json(outModel);
			}

			//// 將新密碼使用 SHA256 雜湊運算(不可逆)
			//string salt = Session["UserID"].ToString().Substring(0, 1).ToLower(); //使用帳號前一碼當作密碼鹽
			//SHA256 sha256 = SHA256.Create();
			//byte[] bytes = Encoding.UTF8.GetBytes(salt + inModel.NewUserPwd); //將密碼鹽及新密碼組合
			//byte[] hash = sha256.ComputeHash(bytes);
			//StringBuilder result = new StringBuilder();
			//for (int i = 0; i < hash.Length; i++)
			//{
			//	result.Append(hash[i].ToString("X2"));
			//}
			//string NewPwd = result.ToString(); // 雜湊運算後密碼

			// 取得連線字串
			string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MemberDB"].ConnectionString;

			// 當程式碼離開 using 區塊時，會自動關閉連接
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				// 資料庫連線
				conn.Open();

				// 修改個人資料至資料庫
				string sql = @"UPDATE Member SET UserPwd = @UserPwd WHERE UserID = @UserID";
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = sql;

				// 使用參數化填值
				cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
				cmd.Parameters.AddWithValue("@UserPwd", inModel.NewUserPwd);

				// 執行資料庫更新動作
				int Ret = cmd.ExecuteNonQuery();

				if (Ret > 0)
				{
					outModel.ResultMsg = "修改密碼完成";
				}
				else
				{
					outModel.ErrMsg = "無異動資料";
				}
			}

			// 回傳 Json 給前端
			return Json(outModel);
		}
	}
}