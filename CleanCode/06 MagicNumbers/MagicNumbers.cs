
namespace CleanCode.MagicNumbers
{
    public class MagicNumbers
    {
        public enum ApproveDocumentStatus
        {
            Approve = 1,
            Denied = 2
        }

        public const string WithErrors = "1";
        public const string Incomplete = "2";


        public void ApproveDocument(int status)
        {
            if (status == (int)ApproveDocumentStatus.Approve)
            {
                // ...
            }
            else if (status == (int)ApproveDocumentStatus.Denied)
            {
                // ...
            }
        }

        public void RejectDoument(string status)
        {
            switch (status)
            {
                case WithErrors:
                    // ...
                    break;
                case Incomplete:
                    // ...
                    break;
            }
        }
    }
}
