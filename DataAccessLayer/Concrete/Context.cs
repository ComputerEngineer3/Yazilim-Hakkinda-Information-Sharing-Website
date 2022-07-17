using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Subtitle> Subtitles { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Writing> Writings { get; set; }
        public DbSet<EditorialApplication> EditorialApplications { get; set; }
    }
}
