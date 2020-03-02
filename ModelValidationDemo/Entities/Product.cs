using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationDemo.Entities
{
    [ProductRule]
    public class Product : IValidatableObject
    {
        public int ID { get; set; }

        [Display(Name = "产品编号")]
        [Required(ErrorMessage = "{0}是必填的")]
        public string ProductCode { get; set; }

        [Display(Name = "产品名称")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0}的长度应在{2}~{1}之间")]
        [Required(ErrorMessage = "{0}是必填的")]
        public string ProductName { get; set; }

        [Display(Name = "单价")]
        public decimal Amount { get; set; }

        [Display(Name = "产品数量")]
        [Required(ErrorMessage = "{0}是必填的")]
        public int Qty { get; set; }

        [Display(Name = "所有者邮箱")]
        [EmailAddress(ErrorMessage = "{0}格式不正确")]
        public string OwerEmail { get; set; }

        [Display(Name = "备注")]
        [MaxLength(200, ErrorMessage = "{0}最大长度为200")]
        public string Remark { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Remark.Contains(ProductName))
            {
                yield return new ValidationResult(errorMessage: "备注中没有包含产品名称", 
                                                    new[] { nameof(Remark) });
                //new[] { nameof(Remark) }这个参数是一个数组，它表示这个错误是哪一个字段引起的，
                //如果涉及到多个字段，那么应该归为这个类的错误，即：new[] { nameof(Product) }
            }
        }
    }
}
