using System;

namespace KissU.Modules.Blogging.Application.Contracts.Files
{
    public class BloggingWebConsts
    {
        public class FileUploading
        {
            public const int MaxFileSize = 5242880; //5MB

            public static int MaxFileSizeAsMegabytes => Convert.ToInt32((MaxFileSize / 1024f) / 1024f);
        }
    }
}