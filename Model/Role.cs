namespace CarRentalService
{
    public class Role
    {
        private string _id;
        private string _name;
        private string _description;

        public Role (string id, string name, string description)
        {
            _id = id;
            _name = name;
            _description = description;
        }

        public string GetId()
        {
            return _id;
        }
        
        public string GetName()
        {
            return _name;
        }
        
        public string GetDescription()
        {
            return _description;
        }
    }
}