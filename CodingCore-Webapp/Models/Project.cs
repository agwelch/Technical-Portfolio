using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Query;
using ProgrammingFinal2024.Pages;
using ProgrammingFinal2024.Models;


namespace ProgrammingFinal2024.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

}






    }
   
    
