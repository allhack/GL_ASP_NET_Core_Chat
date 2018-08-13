using Microsoft.EntityFrameworkCore;
using SimpleChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleChatApp.Data
{
    public class ChatContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ChatContext(DbContextOptions<ChatContext> options)
            :base(options)
        {

        }
    }
}
