using ModelValidationDemo.Entities;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationDemo
{
    public class ProductRuleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, 
                                                ValidationContext validationContext)
        {
            //从上下文中取得验证的实体信息
            Product product = (Product)validationContext.ObjectInstance;
            //对数据进行判断
            if (product.Amount < 100 || product.Amount > 9999 ) {
                //不满足验证规则，返回错误信息
                return new ValidationResult(ErrorMessage = "你这个价位的产品，我们不收的。", 
                                                    new[] { nameof(product.Amount) });
            }

            if (product.Qty < 100 || product.Qty > 500)
            {
                //不满足验证规则，返回错误信息
                return new ValidationResult(ErrorMessage = "你这个数量，我们不收的。", 
                                                    new[] { nameof(product.Qty) });
            }
            
            //验证通过
            return ValidationResult.Success;
        }
    }
}
