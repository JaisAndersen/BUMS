namespace BUMS
{
    public class UserGroup
    {
        public int UserGroupID { get; set; }
        public User User { get; set; }
        public int UserNavigationID { get; set; }
        public Group? Group { get; set; }
        public int GroupID { get; set; }
    }
}
