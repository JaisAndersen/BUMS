namespace BUMS
{
    public class UserGroup
    {
        public int UserGroupID { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
        public int GroupID { get; set; }
        public Group? Group { get; set; }
    }
}
