using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace OA.Data
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.HasOne(t => t.UserProfile).WithOne(u => u.User).HasForeignKey<UserProfile>(x => x.Id);
            entityBuilder.HasData(new User { Id = 1, UserName = "Kole", Password = "Kole", AddedDate = DateTime.Now, Email = "Kole@yopmail.com", IPAddress = "192.168.100.0", ModifiedDate = DateTime.Now });
        }
    }
}
