namespace Document_tracking_system
{
    class UserAccount
    {
        private string name;
        private string sex;
        private string username;
        private string password;
        private string position;
        private int phone_number;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public int Phone_number
        {
            get
            {
                return phone_number;
            }
            set
            {
                phone_number = value;
            }
        }

        private void create()
        {

        }
        private void verify()
        {

        }
        private void update()
        {

        }
    }
}
