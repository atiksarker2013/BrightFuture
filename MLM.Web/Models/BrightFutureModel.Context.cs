﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MLM.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BrightFutureHoustoneEntities : DbContext
    {
        public BrightFutureHoustoneEntities()
            : base("name=BrightFutureHoustoneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyForm> CompanyForm { get; set; }
        public virtual DbSet<CompanyModule> CompanyModule { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<StaffList> StaffList { get; set; }
        public virtual DbSet<Usergroup> Usergroup { get; set; }
        public virtual DbSet<UserGroupForm> UserGroupForm { get; set; }
        public virtual DbSet<UserGroupModule> UserGroupModule { get; set; }
    }
}
