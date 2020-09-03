using System;

namespace Document_tracking_system
{
    class EnteringDocumentRecording
    {
        private string doc_id;
        private string doc_title;
        private string destination_office;
        private string source_office;
        private DateTime doc_entering_date;
        private string doc_comment;
        private string refer_to;

        public string Doc_id
        {
            get
            {
                return doc_id;
            }
            set
            {
                doc_id = value;
            }
        }
        public string Doc_title
        {
            get
            {
                return doc_title;
            }
            set
            {
                doc_title = value;
            }
        }
        public string Destination_office
        {
            get
            {
                return destination_office;
            }
            set
            {
                destination_office = value;
            }
        }
        public string Source_office
        {
            get
            {
                return source_office;
            }
            set
            {
                source_office = value;
            }
        }
        public DateTime Doc_entering_date
        {
            get
            {
                return doc_entering_date;
            }
            set
            {
                doc_entering_date = value;
            }
        }
        public string Doc_comment
        {
            get
            {
                return doc_comment;
            }
            set
            {
                doc_comment = value;
            }
        }
        public string Refer_to
        {
            get
            {
                return refer_to;
            }
            set
            {
                refer_to = value;
            }
        }
        private void record()
        {

        }
    }
}
