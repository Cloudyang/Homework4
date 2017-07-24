using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.AttributeExtend;

namespace Model
{
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [RequiredValidate]
        [LengthValidate(6)]
        public string Account
        {
            set;
            get;
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set;
            get;
        }
        /// <summary>
        /// EMaill
        /// </summary>
        [EmailValidate]
        [RequiredValidate]
        [LengthValidate(6,30)]
        public string Email
        {
            set;
            get;
        }

        /// <summary>
        /// 手机
        /// </summary>
        [MobileValidate]
        public string Mobile
        {
            set;
            get;
        }

        /// <summary>
        /// 用户状态  0正常 1冻结 2删除
        /// </summary>
        public int? State
        {
            set;
            get;
        }

        /// <summary>
        /// 用户类型  1 普通用户 2管理员 4超级管理员
        /// </summary>
        public int UserType
        {
            set;
            get;
        }

        /// <summary>
        /// 国别
        /// </summary>
        public People nationality
        {
            get;
            set;
        }
    }
}

