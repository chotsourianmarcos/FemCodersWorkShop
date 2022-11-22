using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class CurriculumItem
    {
        public CurriculumItem() {
            this.UserPassword = Guid.NewGuid().ToString();
        }
        public CurriculumItem(int ownerID) {
            this.UserPassword = Guid.NewGuid().ToString();
            this.OwnerId = ownerID;
        }
        
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public int OwnerId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; set; }
        private string UserPassword { get; set; }
        public string Content { get; set; } //not implemented content
        public string ProfessionalArea { get; set; }
        public string TesetMigration1 { get; set; }
        public string TesetMigrationX { get; set; }

        public void UserDiactivation(string inputPassword)
        {
            if (inputPassword == this.UserPassword)
            {
                this.IsActive = false;
            }
        }
        public void AdminDiactivation(string inputPassword)
        {
            //not implemented
        }
        public void ChangeUserPassword(string userCurrentPassword, string userNewPassword)
        {
            if(userCurrentPassword == this.UserPassword)
            {
                this.UserPassword = userNewPassword;
            }
        }
    }
}
