﻿using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ReviewWithUserDto
    {
        public string BookId { get; set; }

        public string Text { get; set; }

        public double Rating { get; set; }
    }
}
