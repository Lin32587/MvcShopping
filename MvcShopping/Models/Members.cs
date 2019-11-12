using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MvcShopping.Models
{
    [DisplayName("会员信息")]
    [DisplayColumn("Name")]
    public class Members
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("会员账号")]
        [Required(ErrorMessage ="请输入Email地址")]
        [Description("我们直接以Email当成会员的登录账号")]
        [MaxLength(250,ErrorMessage ="Email地址长度无法超过250个字符")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("会员密码")]
        [Required(ErrorMessage ="请输入密码")]
        [MaxLength(40,ErrorMessage ="密码不得超过40个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("中文姓名")]
        [Required(ErrorMessage ="请输入姓名")]
        [MaxLength(5,ErrorMessage ="姓名不可超过5个字")]
        public string Name { get; set; }

        [DisplayName("网络昵称")]
        [Required(ErrorMessage ="请输入网络昵称")]
        [MaxLength(10,ErrorMessage ="网络昵称请勿输入超过10个字")]
        public string Nickname { get; set; }

        [DisplayName("会员注册时间")]
        public DateTime RegisterOn { get; set; }

        [DisplayName("会员启用认证码")]
        [MaxLength(36)]
        public string AuthCode { get; set; }
    }
}