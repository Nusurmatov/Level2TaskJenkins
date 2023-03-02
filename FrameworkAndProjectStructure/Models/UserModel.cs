namespace FrameworkAndProjectStructure.Models
{
    public class UserModel
    {
        public User[] User { get; set; }
    }

    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    
        public string Email { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }
        
        public string Department { get; set; }

        public override string ToString()
        {
            return $"{FirstName}{LastName}{Age}{Email}{Salary}{Department}";
        }
    }
}
