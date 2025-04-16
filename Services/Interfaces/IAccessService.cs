namespace BUMS{
    public interface IAccessService{
        public void AddAccess(Access? access);
        public void DeleteAccess(Access? access);
        public IEnumerable<Access>? FilterAccessByName(string? filter);
        IEnumerable<Access>? GetAccess();
        public Access? GetAccessById(int id);
        public void UpdateAccess(Access? access, string? accessName);
        public List<Access>? GetAllAccess();
    }
}
