﻿using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class BookDetailsDto
    {
        public int Id { get; set; }

        public string BookId { get; set; }

        public string Title { get; set; }

    }
}
