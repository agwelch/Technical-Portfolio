using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Query;
using ProgrammingFinal2024.Pages;
using ProgrammingFinal2024.Models;


namespace ProgrammingFinal2024.Models
{
        public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public ICollection<Project> ParticipatingProjects { get; set; } = new List<Project>();
        public ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();

    }
}
