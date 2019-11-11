using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Drawing;

namespace MvcShopping.Models
{
    [DisplayName("商品信息")]
    [DisplayColumn("Name")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("商品类别")]
        [Required]
        public ProductCategory ProductCategory { get; set; }

        [DisplayName("商品名称")]
        [Required(ErrorMessage ="请输入商品名称")]
        [MaxLength(60,ErrorMessage ="商品名称不可超过60个字")]
        public string Name { get; set; }

        [DisplayName("商品简介")]
        [Required(ErrorMessage ="请输入商品简介")]
        [MaxLength(250,ErrorMessage ="商品介绍请勿输入超过250个字")]
        public string Description { get; set; }

        [DisplayName("商品颜色")]
        [Required(ErrorMessage ="请选择颜色")]
        public Color Color { get; set; }

        [DisplayName("商品售价")]
        [Required(ErrorMessage ="请输入售价")]
        [Range(5,10000,ErrorMessage ="商品售价必须在5~10000的区间")]
        public int Price { get; set; }

        [DisplayName("上架时间")]
        [Description("如果不设置上架时间，代表此商品永不上架")]
        public DateTime? PublishOn { get; set; }
    }
}