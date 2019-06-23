using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace FindMyTutor.Data.Services.DTO
{
    public class CommentDTO
    {
        [Required]
        public string CommenterId { get; set; }

        [Required]
        public int OfferId { get; set; }  

        public double? Rating { get; set; }

        [Required]
        [MinLength(3)]
        public string Content { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
