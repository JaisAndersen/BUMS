namespace BUMS{
    public interface IAccessService{
        IEnumerable<Access?>? GetAccess();
        public void AddAccess(Access? access);
        public void DeleteAccess(Access? access);
        public Access GetAccessById(int? id);
        public IEnumerable<Access?>? FilterAccessByName(string? filter);
        public void UpdateAccess(Access? access, string? accessName);
        public List<Access?>? GetAllAccess();
    }
}
