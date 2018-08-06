using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace OA.Data
{
    public class UserProfileMap
    {
        public UserProfileMap(EntityTypeBuilder<UserProfile> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Address);
            entityBuilder.HasData(new UserProfile { Id = 1, AddedDate = DateTime.Now, IPAddress = "192.168.100.0", ModifiedDate = DateTime.Now, Address = "aaa", FirstName = "Kole", LastName = "Vasilevski" });
        }
    }
}
