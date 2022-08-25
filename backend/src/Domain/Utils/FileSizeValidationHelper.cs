using System;
using Microsoft.Extensions.Configuration;

namespace Domain.Utils
{
    public class FileSizeValidationHelper
    {
        public static bool IsFileSizeAllowed(IConfiguration configuration, long fileSizeInBytes)
        {
            int maxFileSizeAllowedMB = configuration.GetSection("AppSettings").GetValue<int>("MaxFileSizeUpload");

            double fileSizeKB = fileSizeInBytes / 1024;

            double fileSizeMB = Math.Round(fileSizeKB / 1024, 2);

            return fileSizeMB <= maxFileSizeAllowedMB;
        }
    }
}