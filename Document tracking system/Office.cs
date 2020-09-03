namespace Document_tracking_system
{
    class Office
    {
        private string officename;
        private int officenumber;
        private int blocknumber;

        public string Officename
        {
            get
            {
                return officename;
            }
            set
            {
                officename = value;
            }
        }
        public int Officenumber
        {
            get
            {
                return officenumber;
            }
            set
            {
                officenumber = value;
            }
        }
        public int Blocknumber
        {
            get
            {
                return blocknumber;
            }
            set
            {
                blocknumber = value;
            }
        }
    }
}
