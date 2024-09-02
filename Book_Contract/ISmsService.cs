namespace Book_Contract
{
    public interface ISmsService
    {
        void SendSms(SmsBody body);

    }
    public class SmsBody
    {
        public string PhoneNumber { get; set; }
        public string Messgae { get; set; }
    }
}
