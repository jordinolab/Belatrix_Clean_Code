
namespace CleanCode.MagicNumbers
{
    public class MagicNumbers
    {
        public enum DocumentStatus
        {
            Approve = 1,
            Denied = 2
        }

        public const string WITH_ERRORS = "1";
        public const string INCOMPLETE = "2";
        
        public void ApproveDocument(DocumentStatus status)
        {
            if (status == DocumentStatus.Approve)
            {
                // ...
            }
            else if (status == DocumentStatus.Denied)
            {
                // ...
            }
        }

        public void RejectDoument(string status)
        {
            switch (status)
            {
                case WITH_ERRORS:
                    // ...
                    break;
                case INCOMPLETE:
                    // ...
                    break;
            }
        }
    }
}
