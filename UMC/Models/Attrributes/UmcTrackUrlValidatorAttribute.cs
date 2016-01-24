using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using UMC.Models.Constants;

namespace UMC.Models.Attrributes
{
    public class UmcTrackUrlValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string url = value.ToString();

                if (Regex.IsMatch(url, ValidationConstants.SoundcloudUrlRegex, RegexOptions.IgnoreCase) || Regex.IsMatch(url, ValidationConstants.YoutubeUrlRegex, RegexOptions.IgnoreCase))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("Please Enter a Valid Soundcloud or Youtube Url.");
            }

            return new ValidationResult("" + validationContext.DisplayName + " is required");
        }
    }
}