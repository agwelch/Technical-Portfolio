using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Query;
using ProgrammingFinal2024.Pages;
using ProgrammingFinal2024.Models;
namespace ProgrammingFinal2024
{
    public class Message
    {
        public int MessageID{get; set;}
        public int SenderID {get; set;}
        public User Sender {get; set;}= null!;
        public int ReceiverID {get; set;}
        public User Receiver {get; set;} = null!;
        [StringLength(1000)]
        public string Content {get; set;} = string.Empty;
        
    }
}