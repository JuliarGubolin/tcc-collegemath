﻿using Microsoft.AspNetCore.Http;

namespace CollegeMath.Application.Helpers
{
    public class EmailRequest
    {
        public string ToEmail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<IFormFile> Attachments { get; set; }
    }
}