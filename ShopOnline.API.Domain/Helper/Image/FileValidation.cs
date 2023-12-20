using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TestImagewebapi.Validation
{

    public class FileValidation : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            if(value is IFormFile formFile && formFile!=null && formFile.Length<=1024*1024)
            {
                return true;
            }
            return false;
        }
    }
}
