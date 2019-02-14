using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Server.Core.Domain
{
    public class Meme
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        protected Meme()
        {
        }

        public Meme(Guid id, string title, Guid userId)
        {
            Id = id;
            SetTitle(title);
            UserId = userId;
            //SetPath(imagePath);
            
            CreatedAt = DateTime.Now;
        }

        public void SetPath(string imagePath)
        {
            if (!Directory.Exists(imagePath))
            {
                throw new ArgumentException(ErrorCodes.InvalidPath,
                     "Image path is invalid.");
            }
            //ImagePath = imagePath;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetTitle(string title)
        {
            if (!NameRegex.IsMatch(title))
            {
                throw new ArgumentException(ErrorCodes.InvalidTitle,
                    "Title is invalid.");
            }

            if (String.IsNullOrEmpty(title))
            {
                throw new ArgumentException(ErrorCodes.InvalidTitle,
                    "Title is invalid.");
            }

            Title = title;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
