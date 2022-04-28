using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book.Models.Member
{
    public class MemberModel
    {
		public class DoRegisterIn
		{
			public string UserID { get; set; }
			public string UserPwd { get; set; }
			public string UserName { get; set; }
			public string UserEmail { get; set; }
		}

		public class DoRegisterOut
		{
			public string ErrMsg { get; set; }
			public string ResultMsg { get; set; }
		}
		public class DoLoginIn
		{
			public string UserID { get; set; }
			public string UserPwd { get; set; }
		}

		public class DoLoginOut
		{
			public string ErrMsg { get; set; }
			public string ResultMsg { get; set; }
		}
		public class GetUserProfileOut
		{
			public string ErrMsg { get; set; }
			public string UserID { get; set; }
			public string UserName { get; set; }
			public string UserEmail { get; set; }
		}

		/// <summary>
		/// 修改個人資料參數
		/// </summary>
		public class DoEditProfileIn
		{
			public string UserName { get; set; }
			public string UserEmail { get; set; }
		}

		/// <summary>
		/// 修改個人資料回傳
		/// </summary>
		public class DoEditProfileOut
		{
			public string ErrMsg { get; set; }
			public string ResultMsg { get; set; }
		}

		/// <summary>
		/// 修改密碼參數
		/// </summary>
		public class DoEditPwdIn
		{
			public string NewUserPwd { get; set; }
			public string CheckUserPwd { get; set; }
		}

		/// <summary>
		/// 修改密碼回傳
		/// </summary>
		public class DoEditPwdOut
		{
			public string ErrMsg { get; set; }
			public string ResultMsg { get; set; }
		}
	}
}